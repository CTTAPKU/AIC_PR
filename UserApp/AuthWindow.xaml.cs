using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace UserApp
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();

            DoubleAnimation btnAnimation = new DoubleAnimation(); ;
            btnAnimation.From = 0;
            btnAnimation.To = 450;
            btnAnimation.Duration = TimeSpan.FromSeconds(3);
            authButton.BeginAnimation(Button.WidthProperty, btnAnimation);
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            int k = 1;

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Це поле введено невірно!";
                textBoxLogin.Background = Brushes.Khaki;
                k = 0;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
            }
            if (pass.Length < 5)
            {
                passBox.ToolTip = "Це поле введено невірно!";
                passBox.Background = Brushes.Khaki;
                k = 0;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
            }
            if (k==1)
            {
                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }
                if (authUser != null)
                {
                    MessageBox.Show("Все добре!");
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не авторизовано. Щось ви ввели не так!");

                }
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
