using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Meetcore.Feature.Events.Services
{
    public interface IEventRepository
    {
        IEnumerable<Item> GetEvents(Item parent);
    }
}
