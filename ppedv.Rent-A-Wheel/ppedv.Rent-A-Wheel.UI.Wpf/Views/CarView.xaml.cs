using Microsoft.Extensions.DependencyInjection;
using ppedv.Rent_A_Wheel.Model.Contracts;
using ppedv.Rent_A_Wheel.UI.Wpf.ViewModels;
using System.Windows.Controls;

namespace ppedv.Rent_A_Wheel.UI.Wpf.Views
{
    /// <summary>
    /// Interaction logic for CarView.xaml
    /// </summary>
    public partial class CarView : UserControl
    {
        public CarView()
        {
            InitializeComponent();

            this.DataContext = App.Current.Services.GetService<CarViewModel>();
            //this.DataContext = new CarViewModel(App.Current.Services.GetService<IRepository>());
        }
    }
}
