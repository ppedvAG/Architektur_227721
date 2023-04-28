namespace ppedv.Rent_A_Wheel.API.REST.Model
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int BuildYear { get; set; }
        public int PS { get; set; }
    }
}
