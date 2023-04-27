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
        private readonly IRepository repository;
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

        public CarViewModel(IRepository repository)
        {
            this.repository = repository;
            CarList = new ObservableCollection<Car>(repository.GetAll<Car>());

            SaveCommandOLD = new SaveCommand(repository);
            SaveCommand = new RelayCommand(() => repository.SaveAll());
            NewCommand = new RelayCommand(UserWantsToAddNewCar);
        }

        private void UserWantsToAddNewCar()
        {
            var car = new Car() { Model = "NEU", Manufacturer = "NEU", KW = 500 + DateTime.Now.Second, Color = "Pink" };
            repository.Add(car);
            CarList.Add(car);
        }
    }

    class SaveCommand : ICommand
    {
        private readonly IRepository repo;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public SaveCommand(IRepository repo)
        {
            this.repo = repo;
        }
        public void Execute(object? parameter)
        {
            repo.SaveAll();
        }
    }
}
