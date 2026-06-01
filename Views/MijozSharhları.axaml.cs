using Avalonia.Controls;
using TaxiApp.ViewModels;

namespace TaxiApp.Views
{
    public partial class MijozSharhları : Window
    {
        public MijozSharhları()
        {
            InitializeComponent();
            DataContext = new MijozSharhlariViewModel();
        }
    }
}
