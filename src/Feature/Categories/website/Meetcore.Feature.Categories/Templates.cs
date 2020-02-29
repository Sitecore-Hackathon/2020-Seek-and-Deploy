using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Meetcore.Feature.Categories
{
    public static class Templates
    {
        public static class Category
        {
            public static readonly ID Id = new ID("{26F784C1-4B03-478F-A912-2E00AB618865}");

            public static class Fields
            {
                public static readonly ID Name = new ID("{561A5339-D535-46DD-8373-24F1477F2C56}");
                public static readonly ID DisplayImage = new ID("{FDCF2A58-27C9-4AF6-AC12-E9544A758A81}");
            }
        }
    }
}