namespace ppedv.Rent_A_Wheel.Model.Domain
{
    public class Rent : Entity
    {
        public DateTime OrderDate { get; set; }
        public DateTime StartDate { get; set; }
        public string StartLocation { get; set; } = string.Empty;
        public DateTime EndDate { get; set; }
        public string EndLocation { get; set; } = string.Empty;

        public virtual Customer? Customer { get; set; }
        public virtual Car? Car { get; set; }
    }
}