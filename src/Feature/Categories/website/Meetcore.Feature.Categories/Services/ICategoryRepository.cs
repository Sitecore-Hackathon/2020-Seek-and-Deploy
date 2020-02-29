using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Meetcore.Feature.Categories.Services
{
    public interface ICategoryRepository
    {
        IEnumerable<Item> GetCategories(Item parent);
    }
}
