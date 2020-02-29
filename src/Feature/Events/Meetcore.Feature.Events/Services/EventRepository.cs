using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Sitecore.Abstractions;
using Sitecore.ContentSearch;
using Sitecore.Data.Items;

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

        public IEnumerable<Item> GetEvents(Item parent)
        {
            using (var context = GetSearchContext(parent))
            {
                var results = context.GetQueryable<EventSearchQuery>()
                    .Where(evnt => evnt.Paths.Contains(parent.ID) && evnt.Templates.Contains(Templates.Event.Id))
                    .Select(x => new {
                        Uri = x.UniqueId,
                        Database = Factory.GetDatabase(x.UniqueId.DatabaseName)
                    }).ToList();
                return results.Select(x => ItemManager.GetItem(x.Uri.ItemID, x.Uri.Language, x.Uri.Version, x.Database));
            }
        }

        protected virtual IProviderSearchContext GetSearchContext(Item item)
        {
            return ContentSearchManager.GetIndex((SitecoreIndexableItem)item).CreateSearchContext();
        }
    }
}