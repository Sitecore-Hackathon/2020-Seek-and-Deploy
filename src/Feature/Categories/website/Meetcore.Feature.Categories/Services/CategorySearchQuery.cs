﻿using System.Collections.Generic;
using Sitecore.ContentSearch;
using Sitecore.Data;

namespace Meetcore.Feature.Categories.Services
{
    public class CategorySearchQuery
    {
        [IndexField("_uniqueid")]
        public virtual ItemUri UniqueId { get; set; }
        [IndexField("_path")]
        public virtual IEnumerable<ID> Paths { get; set; }
        [IndexField("_templates")]
        public virtual IEnumerable<ID> Templates { get; set; }
    }
}