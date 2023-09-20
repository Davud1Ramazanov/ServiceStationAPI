namespace ServiceStationAPI.Models
{
    public class Car
    {
        public int CarId { get; set; } 
        public string OwnerName { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Number { get; set; }
        public string VIN { get; set; }
        public int Capacity { get; set; }
    }
}
