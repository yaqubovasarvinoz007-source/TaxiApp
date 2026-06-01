using Avalonia.Controls;
using TaxiApp.ViewModels;

namespace TaxiApp.Views
{
    public partial class HaydovchiDashboard : Window
    {
        public HaydovchiDashboard()
        {
            InitializeComponent();
            DataContext = new HaydovchiDashboardViewModel();
        }
    }
}
