using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UsersApp;

namespace UserApp
{

    public partial class MainWindow : Window
    {
        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string password = PassBox.Password.Trim();
            if(login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Not Correct";
                TextBoxLogin.Background = Brushes.Red;
            }
            else if(password.Length < 5)
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

                MessageBox.Show("Good");
                User user = new User(login, password);


                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();


            }
        }

        private void Button_Window_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();

        }
    }
}
