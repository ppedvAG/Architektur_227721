using ppedv.Rent_A_Wheel.Model;

namespace ppedv.Rent_A_Wheel.Data.EfCore.Tests
{
    public class EfContextTests
    {
        string conString = "Server=(localdb)\\mssqllocaldb;Database=Rent-A-Wheel_dev;Trusted_Connection=true;";

        [Fact]
        public void Can_create_DB()
        {
            var con = new EfContext(conString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        public void Can_add_Car()
        {
            var car = new Car() { Model = "Testmodel" };
            var con = new EfContext(conString);
            con.Database.EnsureCreated();

            con.Cars.Add(car);
            var result = con.SaveChanges();

            Assert.Equal(1, result);
        }

        [Fact]
        public void Can_read_Car()
        {
            var car = new Car() { Model = $"Testmodel_{Guid.NewGuid()}" };
            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();

                con.Cars.Add(car);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Cars.Find(car.Id);
                Assert.Equal(car.Model, loaded.Model);
            }
        }

    }
}