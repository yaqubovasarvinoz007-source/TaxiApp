using Avalonia.Controls;
using TaxiApp.ViewModels;

namespace TaxiApp.Views
{
    public partial class PulYechish : Window
    {
        public PulYechish()
        {
            InitializeComponent();
            DataContext = new PulYechishViewModel();
        }
    }
}
