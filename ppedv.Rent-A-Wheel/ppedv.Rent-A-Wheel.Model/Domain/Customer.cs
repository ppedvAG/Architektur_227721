namespace ppedv.Rent_A_Wheel.Model.Domain
{
    public class Customer : Entity
    {
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Rent> Rents { get; set; } = new HashSet<Rent>();
    }
}