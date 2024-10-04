namespace Aviation.Models
{
    public class Gulfstream
    {

        public int GulfstreamID { get; set; }

        public string Manufacturer { get; set; }

        public string Airframe { get; set; }

        public string Aircraft_Type { get; set; }

        public int Crew { get; set; }

        public int Seating_Capacity { get; set; }

        public decimal Length { get; set; }

        public decimal Wingspan { get; set; }

        public decimal Height { get; set; }

        public int Powerplant { get; set; }

        public decimal Max_Speed { get; set; }
        public int Distance_Range { get; set; }

        public int Ceiling { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }

}
