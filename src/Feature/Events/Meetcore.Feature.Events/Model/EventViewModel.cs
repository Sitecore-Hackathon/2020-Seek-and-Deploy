using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sitecore.Data;

namespace Meetcore.Feature.Events.Model
{
    public class EventViewModel
    {
        public string Name {get; set;}
        public string Description { get; set; }
        public int Capacity {get; set;}
        public decimal Cost {get; set;}
        public bool IsPublic {get; set;}
        public ID BannerImage {get; set;}

        [DataType(DataType.DateTime)]
        public DateTime DateAndTime {get; set;}

        public float Longitude {get; set;}
        public float Latitude {get; set;}
        public IEnumerable<ID> Staff {get; set;}
        public IEnumerable<ID> Attendees {get; set;}
        public IEnumerable<ID> Categories { get; set; }
    }
}