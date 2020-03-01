using Meetcore.Feature.Events.Models;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Links.UrlBuilders;
using Sitecore.Mvc.Presentation;
using System;
using System.Web.Mvc;

namespace Meetcore.Feature.Events.Controllers
{
    public class AttendeeController : Controller
    {
        public ActionResult CheckAttendance()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckAttendance(Attendee viewModel)
        {
            Sitecore.
            return View();
        }

        public Item GetItem(string id) {
            var masterDB = Database.GetDatabase("master");
            var item = masterDB.GetItem(id);
            return item;
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
                        newEvent.Fields["ModuleTitle"].Value = projectModel.ModuleTitle;
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

            }
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