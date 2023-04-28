using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ppedv.Rent_A_Wheel.Model.Contracts;
using ppedv.Rent_A_Wheel.Model.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.Windows.Input;

namespace ppedv.Rent_A_Wheel.UI.Wpf.ViewModels
{
    internal class CarViewModel : ObservableObject
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICarStatService carStatService;
        private Car selectedCar;


        public ObservableCollection<Car> CarList { get; set; }

        public Car SelectedCar
        {
            get => selectedCar;
            set
            {
                selectedCar = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedCar"));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PS"));
                OnPropertyChanged(nameof(SelectedCar));
                OnPropertyChanged(nameof(PS));
                OnPropertyChanged(nameof(IsSelectedCarTheMostRented));
            }
        }
        public ICommand SaveCommandOLD { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }

        public string PS
        {
            get
            {
                if (SelectedCar == null)
                    return "???";
                return $"{SelectedCar.KW * 1.35962} PS";
            }
        }

        ////todo: ersetzen durch DI
        //public CarViewModel() : this(new Data.EfCore.EfRepository("Server=(localdb)\\mssqllocaldb;Database=Rent-A-Wheel_dev;Trusted_Connection=true;"))
        //{ }

        public CarViewModel(IUnitOfWork unitOfWork, ICarStatService carStatService)
        {
            this.unitOfWork = unitOfWork;
            this.carStatService = carStatService;
            mostRentedCar = carStatService.GetCarThatWasRentedTheMostDays();
            CarList = new ObservableCollection<Car>(unitOfWork.CarRepository.GetAll());

            SaveCommandOLD = new SaveCommand(unitOfWork);
            SaveCommand = new RelayCommand(() => unitOfWork.SaveAll());
            NewCommand = new RelayCommand(UserWantsToAddNewCar);
        }


        private Car? mostRentedCar;
        public bool IsSelectedCarTheMostRented
        {
            get => selectedCar?.Id == mostRentedCar?.Id;
        }

        private void UserWantsToAddNewCar()
        {
            var car = new Car() { Model = "NEU", Manufacturer = "NEU", KW = 500 + DateTime.Now.Second, Color = "Pink" };
            unitOfWork.CarRepository.Add(car);
            CarList.Add(car);
        }
    }

    class SaveCommand : ICommand
    {
        private readonly IUnitOfWork uow;

        public SaveCommand(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }


        public void Execute(object? parameter)
        {
            uow.SaveAll();
        }
    }
}
