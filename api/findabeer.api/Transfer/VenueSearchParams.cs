namespace findabeer.Transfer
{
    public class VenueSearchParams
    {
        public string Query { get; set; }
        public float? Lat { get; set; }
        public float? Lng { get; set; }
        public bool HasLocation => Lat != null && Lng != null;
    }
}