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
using UsersApp;

namespace UserApp
{

    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string password = PassBox.Password.Trim();
            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Not Correct";
                TextBoxLogin.Background = Brushes.Red;
            }
            else if (password.Length < 5)
            {
                PassBox.ToolTip = "Not correct";
                PassBox.Background = Brushes.Red;
            }
            else
            {
                TextBoxLogin.ToolTip = " ";
                TextBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = " ";
                PassBox.ToolTip = Brushes.Transparent;


                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Password == password).FirstOrDefault();
                }



                if (authUser != null)
                {
                    MessageBox.Show("Good");
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();

                }
                else
                {
                    MessageBox.Show("Bad");
                }
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}