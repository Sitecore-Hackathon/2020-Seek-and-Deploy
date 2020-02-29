using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Meetcore.Feature.Events.Model;
using Sitecore;
using Sitecore.Abstractions;
using Sitecore.ContentSearch;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Links.UrlBuilders;

namespace Meetcore.Feature.Events.Services
{
    public class EventRepository : IEventRepository
    {
        protected readonly BaseFactory Factory;
        protected readonly BaseItemManager ItemManager;

        public EventRepository(BaseFactory factory, BaseItemManager itemManager)
        {
            Debug.Assert(factory != null);
            Debug.Assert(itemManager != null);
            Factory = factory;
            ItemManager = itemManager;
        }

        public IEnumerable<Item> GetEvents(Item parent, string keyword)
        {
            var searchWord = string.IsNullOrEmpty(keyword) ? "*" : keyword;
            using (var context = GetSearchContext(parent))
            {
                var results = context.GetQueryable<EventSearchQuery>()
                    .Where(evnt => evnt.Paths.Contains(parent.ID) && evnt.Templates.Contains(Templates.Event.Id) 
                                                                  && (evnt.Name.Contains(searchWord) || evnt.Description.Contains(searchWord)))
                    .Select(x => new {
                        Uri = x.UniqueId,
                        Database = Factory.GetDatabase(x.UniqueId.DatabaseName)
                    }).ToList();
                return results.Select(x => ItemManager.GetItem(x.Uri.ItemID, x.Uri.Language, x.Uri.Version, x.Database));
            }
        }

        public IEnumerable<Item> GetEvents(Item parent)
        {
            return GetEvents(parent, null);
        }

        public string SaveNewEvent(string parentId, EventViewModel eventToSave)
        {
            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                try
                {
                    var masterDB = Database.GetDatabase("master");
                    TemplateItem templateItem = masterDB.GetItem(Templates.Event.Id);
                    var parentItem = masterDB.GetItem(new ID(parentId));
                    if (parentItem != null)
                    {
                        var eventName =
                            $"{eventToSave.Name.Replace(@"\", "").Replace(@"/", "").Replace(@":", "").Replace(@"?", "").Replace(@"<", "").Replace(@">", "").Replace(@"|", "").Replace(@"[", "").Replace(@"]", "").Replace(@"-", "").Replace("\"", "").Replace(@"(", "").Replace(@")", "")}";

                        var newEvent = parentItem.Add(eventName, templateItem);
                        newEvent.Editing.BeginEdit();
                        newEvent.Fields["Description"].Value = eventToSave.Description;
                        newEvent.Fields["Capacity"].Value = eventToSave.Capacity.ToString();
                        newEvent.Fields["Cost"].Value = eventToSave.Cost.ToString("F");
                        newEvent.Fields["IsPublic"].Value = eventToSave.IsPublic ? "1" : "0";
                        Sitecore.Data.Fields.ImageField bannerImageField = newEvent.Fields["BannerImage"];
                        bannerImageField.MediaID = new ID("{2F6BB916-F5ED-4BF3-80BD-F3D068EAA52B}");
                        newEvent.Fields["DateAndTime"].Value = DateUtil.ToIsoDate(eventToSave.DateAndTime);
                        newEvent.Fields["Longitude"].Value =  eventToSave.Longitude.ToString();
                        newEvent.Fields["Latitude"].Value = eventToSave.Latitude.ToString();
                        newEvent.Fields["Staff"].Value = "";
                        newEvent.Editing.EndEdit();
                        PublishItem(newEvent);
                        return LinkManager.GetItemUrl(newEvent, new ItemUrlBuilderOptions());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return null;
            }
        }

        protected virtual IProviderSearchContext GetSearchContext(Item item)
        {
            return ContentSearchManager.GetIndex((SitecoreIndexableItem)item).CreateSearchContext();
        }

        private static void PublishItem(Item item)
        {
            var publishOptions =
                new Sitecore.Publishing.PublishOptions(item.Database,
                    Database.GetDatabase("web"),
                    Sitecore.Publishing.PublishMode.SingleItem,
                    item.Language,
                    DateTime.Now);
            var publisher = new Sitecore.Publishing.Publisher(publishOptions);
            publisher.Options.RootItem = item;
            publisher.Options.Deep = true;
            publisher.Publish();
        }
    }
}