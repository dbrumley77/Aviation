namespace Aviation.Models
{
    public class Airport
    {

        public int AirportID { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postal_code { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
    }
}
