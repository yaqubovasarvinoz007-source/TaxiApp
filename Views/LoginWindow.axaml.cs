using Avalonia.Controls;
using TaxiApp.Views;
using Avalonia.Media;
using System.Linq;

namespace TaxiApp.Views
{
    public partial class LoginWindow : Window
    {
        private const string AdminLogin = "admin";
        private const string AdminParol = "1234";
        private const string DriverLogin = "driver";
        private const string DriverParol = "5678";
        
        private string selectedRole = "Admin";

        public LoginWindow()
        {
            InitializeComponent();
            
            btnAdmin.Click += (_, _) => SelectRole("Admin", btnAdmin, btnDriver);
            btnDriver.Click += (_, _) => SelectRole("Driver", btnDriver, btnAdmin);
            
            btnKirish.Click += (_, _) => Tekshir();
            txtParol.KeyDown += (_, e) => { if (e.Key == Avalonia.Input.Key.Enter) Tekshir(); };
            
            btnAdmin.Background = Brush.Parse("#3B82F6");
        }

        private void SelectRole(string role, Button selected, Button unselected)
        {
            selectedRole = role;
            selected.Background = Brush.Parse("#3B82F6");
            unselected.Background = Brush.Parse("#64748B");
        }

        private void Tekshir()
        {
            string login = txtLogin.Text?.Trim() ?? "";
            string parol = txtParol.Text ?? "";
            
            bool valid = false;
            
            if (selectedRole == "Admin")
            {
                valid = (login == AdminLogin && parol == AdminParol);
            }
            else if (selectedRole == "Driver")
            {
                if (int.TryParse(login, out int driverId))
                {
                    var servis = new TaxiServis();
                   using var db = new TaxiDbContext();
                    valid = db.Haydovchilar.Any(h => h.Id == driverId) && parol == $"taxi{driverId}";
                }
            }
            
            if (valid)
            {
                if (selectedRole == "Driver")
                {
                    new DriverDashboard(int.Parse(login)).Show();
                }
                else
                {
                    new MainWindow().Show();
                }
                Close();
            }
            else
            {
                lblXabar.Text = "❌ Login yoki parol noto'g'ri!";
                lblXabar.Foreground = Brush.Parse("#EF4444");
                lblXabar.IsVisible = true;
                txtParol.Text = "";
                txtParol.Focus();
            }
        }
    }
}
