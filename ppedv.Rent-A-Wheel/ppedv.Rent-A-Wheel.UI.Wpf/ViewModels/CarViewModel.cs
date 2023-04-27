using ppedv.Rent_A_Wheel.Model.Contracts;
using ppedv.Rent_A_Wheel.Model.Domain;
using System.Collections.Generic;

namespace ppedv.Rent_A_Wheel.UI.Wpf.ViewModels
{
    internal class CarViewModel
    {
        private readonly IRepository repository;

        public List<Car> CarList { get; set; }

        public Car SelectedCar { get; set; }

        //todo: ersetzen durch DI
        public CarViewModel() : this(new Data.EfCore.EfRepository("Server=(localdb)\\mssqllocaldb;Database=Rent-A-Wheel_dev;Trusted_Connection=true;"))
        { }

        public CarViewModel(IRepository repository)
        {
            this.repository = repository;
            CarList = new List<Car>(repository.GetAll<Car>());
        }
    }
}
