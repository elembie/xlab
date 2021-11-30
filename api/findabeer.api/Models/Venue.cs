using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace findabeer.Models 
{
    public class Venue
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public string Excerpt { get; set; }
        public string ThumbnailUrl { get; set; }
        public float Lat { get; set; }
        public float Long { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Twitter { get; set; }

        [Column(TypeName = "decimal(2,1)")]
        public decimal StarsBeer { get; set; }

        [Column(TypeName = "decimal(2,1)")]
        public decimal StarsAtmosphere { get; set; }

        [Column(TypeName = "decimal(2,1)")]
        public decimal StarsAmenities { get; set; }

        [Column(TypeName = "decimal(2,1)")]
        public decimal StarsValue { get; set; }

        public virtual List<VenueTag> Tags { get; set; }
    }
}