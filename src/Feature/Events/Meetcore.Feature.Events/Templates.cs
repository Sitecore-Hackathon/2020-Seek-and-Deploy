using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Meetcore.Feature.Events
{
    public static class Templates
    {
        public static class Event
        {
            public static readonly ID Id = new ID("{3CD24332-35F4-44D6-9745-1051FEE14D0E}");

            public static class Fields
            {
                public static readonly ID Name = new ID("{0D32293D-F2CC-409A-B141-700B5CBC4343}");
                public static readonly ID Description = new ID("{9B515B06-B9A8-4209-A4D1-8A83CBFCCE8D}");
                public static readonly ID Capacity = new ID("{86013127-D30F-4AED-8254-5AD0C112CE42}");
                public static readonly ID Cost = new ID("{33AA3F56-EBA3-4767-BCEE-BD3293A893A3}");
                public static readonly ID IsPublic = new ID("{9032E4AE-851B-450D-8650-04FE73F8BC19}");
                public static readonly ID BannerImage = new ID("{906BC393-F093-4C18-BD69-32B62F5BC02E}");
                public static readonly ID DateAndTime = new ID("{C80F8469-F958-47AC-B16D-2385E3152B21}");
                public static readonly ID Photos = new ID("{272DB439-2648-4B60-ABA9-D619634DD597}");
                public static readonly ID Longitude = new ID("{CE04D0EE-F727-4449-BEB1-207A1EB69658}");
                public static readonly ID Latitude = new ID("{4591ADEC-5677-4AF8-ABBD-AFE2780C49D9}");
                public static readonly ID Staff = new ID("{229A5FDF-7074-4252-B45A-D0F44C703AA8}");
                public static readonly ID Attendees = new ID("{A06184E5-CAC5-4036-AABE-4647CBBE4C92}");
                public static readonly ID Categories = new ID("{3047F1D0-71B1-4127-88B7-01776394C900}");
            }
        }
    }
}