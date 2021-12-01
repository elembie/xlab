using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace findabeer.api.Models 
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

        public virtual List<VenueTag> VenueTags { get; set; }

        public double DistanceTo(float toLat, float toLong)
        {
            // for more complex applications, would move this to a
            // domain object with additional business logic
            var d1 = Lat * (Math.PI / 180.0);
            var num1 = Long * (Math.PI / 180.0);
            var d2 = toLat * (Math.PI / 180.0);
            var num2 = toLong * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                 Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}