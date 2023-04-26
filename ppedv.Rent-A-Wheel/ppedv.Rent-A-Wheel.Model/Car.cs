namespace ppedv.Rent_A_Wheel.Model
{
    public class Car : Entity
    {
        public string Manufacturer { get; set; } = string.Empty;
        public DateTime ManufacturingDate { get; set; } = DateTime.Now;
        public string Model { get; set; } = string.Empty;
        public int KW { get; set; }
        public int Seats { get; set; }
        public string Color { get; set; } = string.Empty;

        public virtual ICollection<Rent> Rents { get; set; } = new HashSet<Rent>();
    }
}