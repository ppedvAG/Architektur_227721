using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using ppedv.Rent_A_Wheel.Model;
using System.Reflection;

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

            //Assert.Equal(1, result);
            result.Should().Be(1);
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
                //Assert.Equal(car.Model, loaded.Model);
                loaded.Model.Should().Be(car.Model);
            }
        }

        [Fact]
        public void Can_update_Car()
        {
            var car = new Car() { Model = $"Testmodel_{Guid.NewGuid()}" };
            var newModel = $"NewModel_{Guid.NewGuid()}";

            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Cars.Add(car);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Cars.Find(car.Id);
                loaded.Model = newModel;
                con.SaveChanges().Should().Be(1);
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Cars.Find(car.Id);
                loaded.Model.Should().Be(newModel);
            }
        }

        [Fact]
        public void Can_delete_Car()
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
                con.Cars.Remove(loaded);
                con.SaveChanges().Should().Be(1);
            }

            using (var con = new EfContext(conString))
            {
                con.Cars.Find(car.Id).Should().BeNull();
            }
        }



        [Fact]
        public void Can_insert_and_read_Car_with_AutoFixure()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));
            var car = fix.Create<Car>();

            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Cars.Add(car);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Cars.Find(car.Id);
                loaded.Should().BeEquivalentTo(car, x => x.IgnoringCyclicReferences());
            }
        }

        internal class PropertyNameOmitter : ISpecimenBuilder
        {
            private readonly IEnumerable<string> names;

            internal PropertyNameOmitter(params string[] names)
            {
                this.names = names;
            }

            public object Create(object request, ISpecimenContext context)
            {
                var propInfo = request as PropertyInfo;
                if (propInfo != null && names.Contains(propInfo.Name))
                    return new OmitSpecimen();

                return new NoSpecimen();
            }
        }
    }
}