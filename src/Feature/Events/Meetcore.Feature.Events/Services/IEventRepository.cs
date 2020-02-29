using System.Collections.Generic;
using Meetcore.Feature.Events.Model;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Meetcore.Feature.Events.Services
{
    public interface IEventRepository
    {
        IEnumerable<Item> GetEvents(Item parent);
        IEnumerable<Item> GetEvents(Item parent, string keyword);
        string SaveNewEvent(string parentId, EventViewModel eventToSave);
    }
}
