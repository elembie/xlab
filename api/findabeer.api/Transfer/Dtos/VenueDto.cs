using System;
using System.Collections.Generic;

namespace findabeer.api.Transfer.Dtos
{
    public class VenueDto
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

        public decimal StarsBeer { get; set; }

        public decimal StarsAtmosphere { get; set; }

        public decimal StarsAmenities { get; set; }

        public decimal StarsValue { get; set; }
        public double? DistanceTo { get; set; }

        public virtual List<TagDto> Tags { get; set; }
    }
}