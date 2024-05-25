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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;

namespace RZD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();

        public MainWindow()
        {
            InitializeComponent();
            User = new User();
        }
        public User User { get; private set; }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private bool ValidateRegistrationInput(string login, string password)
        {
            return !string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password);
        }

        private void GoToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = RegisterUsername.Text;
            string password = RegisterPassword.Password;

            if (ValidateRegistrationInput(login, password) && DbControl.Authorize(login, password, out User user))
            {
                CurrentUser.StartSession(user);
                if(CurrentUser.PositionId == 1)
                {
                    AuditorStartWindow auditorStartWindow = new AuditorStartWindow();
                    auditorStartWindow.Show();
                    this.Close();
                }
                else if (CurrentUser.PositionId == 2)
                {
                    StartWindow startWindow = new StartWindow();
                    startWindow.Show();
                    this.Close();
                }
                else if (CurrentUser.PositionId == 3)
                {
                    WaysInspections waysInspections = new WaysInspections();
                    waysInspections.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Введите корректные данные в поля!");
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Сollapse_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
