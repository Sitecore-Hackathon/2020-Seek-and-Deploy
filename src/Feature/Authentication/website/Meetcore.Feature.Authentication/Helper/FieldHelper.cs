using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ExperienceForms.Models;

namespace Meetcore.Feature.Authentication.Helper
{
    public static class FieldHelper
    {
        public static IViewModel GetFieldById(Guid id, IList<IViewModel> fields)
        {
            return fields.FirstOrDefault(f => Guid.Parse(f.ItemId) == id);
        }

        public static string GetValue(object field)
        {
            return field?.GetType().GetProperty("Value")?
                       .GetValue(field, null)?.ToString() ?? string.Empty;
        }
    }
}