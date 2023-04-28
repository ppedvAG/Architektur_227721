using Moq;
using ppedv.Rent_A_Wheel.Model.Contracts;
using ppedv.Rent_A_Wheel.Model.Domain;
using ppedv.Rent_A_Wheel.UI.Wpf.ViewModels;

namespace ppedv.Rent_A_Wheel.UI.Wpf.Tests.ViewModels
{
    public class CarViewModelTests
    {
        [Fact]
        public void IsSelectedCarTheMostRented_both_same_id_should_be_true()
        {
            var car = new Car() { Id = 4 };
            var repoMock = new Mock<ICarRepository>();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.CarRepository).Returns(repoMock.Object);
            var serviceMock = new Mock<ICarStatService>();
            serviceMock.Setup(x => x.GetCarThatWasRentedTheMostDays()).Returns(car);

            var vm = new CarViewModel(uowMock.Object, serviceMock.Object);
            vm.SelectedCar = car;

            Assert.True(vm.IsSelectedCarTheMostRented);
        }

        [Fact]
        public void IsSelectedCarTheMostRented_not_same_id_should_be_true()
        {
            var car = new Car() { Id = 4 };
            var car2 = new Car() { Id = 8 };
            var repoMock = new Mock<ICarRepository>();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.CarRepository).Returns(repoMock.Object);
            var serviceMock = new Mock<ICarStatService>();
            serviceMock.Setup(x => x.GetCarThatWasRentedTheMostDays()).Returns(car2);

            var vm = new CarViewModel(uowMock.Object, serviceMock.Object);
            vm.SelectedCar = car;

            Assert.False(vm.IsSelectedCarTheMostRented);
        }

        [Fact]
        public void IsSelectedCarTheMostRented_both_null_should_be_false()
        {
            var repoMock = new Mock<ICarRepository>();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.CarRepository).Returns(repoMock.Object);
            var serviceMock = new Mock<ICarStatService>();

            var vm = new CarViewModel(uowMock.Object, serviceMock.Object);
            vm.SelectedCar = null;

            Assert.False(vm.IsSelectedCarTheMostRented);
        }

        [Fact]
        public void IsSelectedCarTheMostRented_selectedCar_null_should_be_false()
        {
            var car = new Car() { Id = 4 };
            var repoMock = new Mock<ICarRepository>();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.CarRepository).Returns(repoMock.Object);
            var serviceMock = new Mock<ICarStatService>();
            serviceMock.Setup(x => x.GetCarThatWasRentedTheMostDays()).Returns(car);

            var vm = new CarViewModel(uowMock.Object, serviceMock.Object);
            vm.SelectedCar = null;

            Assert.False(vm.IsSelectedCarTheMostRented);
        }

        [Fact]
        public void IsSelectedCarTheMostRented_mostRented_null_should_be_false()
        {
            var car = new Car() { Id = 4 };
            var repoMock = new Mock<ICarRepository>();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.CarRepository).Returns(repoMock.Object);
            var serviceMock = new Mock<ICarStatService>();

            var vm = new CarViewModel(uowMock.Object, serviceMock.Object);
            vm.SelectedCar = car;

            Assert.False(vm.IsSelectedCarTheMostRented);

        }
    }
}