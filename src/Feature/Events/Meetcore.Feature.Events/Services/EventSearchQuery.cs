using System.Collections.Generic;
using Sitecore.ContentSearch;
using Sitecore.Data;

namespace Meetcore.Feature.Events.Services
{
    public class EventSearchQuery
    {
        [IndexField("_uniqueid")]
        public virtual ItemUri UniqueId { get; set; }
        [IndexField("_path")]
        public virtual IEnumerable<ID> Paths { get; set; }
        [IndexField("_templates")]
        public virtual IEnumerable<ID> Templates { get; set; }

        //Searchable params
        [IndexField("_name")]
        public virtual string Name { get; set; }
        [IndexField("description")]
        public virtual string Description { get; set; }
    }
}