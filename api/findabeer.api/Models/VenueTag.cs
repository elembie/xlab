namespace findabeer.api.Models
{
    public class VenueTag
    {
        public long VenueId { get; set; }
        public Venue Venue { get; set; }
        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}