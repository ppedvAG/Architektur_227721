using FluentAssertions;
using Moq;
using ppedv.Rent_A_Wheel.Model.Contracts;
using ppedv.Rent_A_Wheel.Model.Domain;

namespace ppedv.Rent_A_Wheel.Logic.Tests
{
    public class CarStatServiceTests
    {
        [Fact]
        public void Ctor_should_throw_if_repo_is_null()
        {
            var act = () => new CarStatService(null!);

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GetCarThatWasRentedTheMostDays_no_cars_in_db_should_return_null()
        {
            var repoMock = new Mock<ICarRepository>();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.CarRepository).Returns(repoMock.Object);
            var carStatService = new CarStatService(uowMock.Object);

            var result = carStatService.GetCarThatWasRentedTheMostDays();

            result.Should().BeNull();
        }

        [Fact]
        public void GetCarThatWasRentedTheMostDays_3_cars_the_blue_should_have_most_days()
        {
            var repoMock = new Mock<ICarRepository>();
            repoMock.Setup(x => x.GetAll()).Returns(() =>
            {
                var c1 = new Car() { Color = "red" };
                c1.Rents.Add(new Rent()
                {
                    StartDate = new DateTime(2000, 1, 1),
                    EndDate = new DateTime(2000, 1, 10)
                });
                var c2 = new Car() { Color = "blue" };
                c2.Rents.Add(new Rent()
                {
                    StartDate = new DateTime(2000, 1, 1),
                    EndDate = new DateTime(2000, 1, 20)
                });
                var c3 = new Car() { Color = "green" };
                c3.Rents.Add(new Rent()
                {
                    StartDate = new DateTime(2000, 1, 1),
                    EndDate = new DateTime(2000, 1, 5)
                });

                return new Car[] { c1, c2, c3 };
            });
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.CarRepository).Returns(repoMock.Object);
            var carStatService = new CarStatService(uowMock.Object);

            var result = carStatService.GetCarThatWasRentedTheMostDays();

            result.Should().NotBeNull();
            result!.Color.Should().Be("blue");
        }
    }
}