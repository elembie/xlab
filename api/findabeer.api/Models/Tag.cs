using System;
using System.Collections.Generic;

namespace findabeer.api.Models 
{
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual List<Venue> Venues { get; set; }
    }
}