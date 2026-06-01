using Avalonia.Controls;
using TaxiApp.Views;
using Avalonia.Media;

namespace TaxiApp.Views
{
    public partial class LoginWindow : Window
    {
        private const string ToGriLogin = "admin";
        private const string ToGriParol = "1234";

        public LoginWindow()
        {
            InitializeComponent();
            // FindControl qatorlarini o'chirib tashlang, 
            // chunki Avalonia buni avtomatik bog'laydi.
            
            btnKirish.Click += (_, _) => Tekshir();
            txtParol.KeyDown += (_, e) => { if (e.Key == Avalonia.Input.Key.Enter) Tekshir(); };
        }

        private void Tekshir()
        {
            // Endi txtLogin, txtParol, lblXabar, btnKirish to'g'ridan-to'g'ri ishlaydi
            if ((txtLogin.Text?.Trim() ?? "") == ToGriLogin && (txtParol.Text ?? "") == ToGriParol)
            {
                new MainWindow().Show();
                Close();
            }
            else
            {
                lblXabar.Text = "❌  Login yoki parol noto'g'ri!";
                lblXabar.Foreground = Brush.Parse("#EF4444");
                lblXabar.IsVisible = true;
                txtParol.Text = "";
                txtParol.Focus();
            }
        }
    }
}