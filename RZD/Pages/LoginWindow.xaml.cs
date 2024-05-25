using Npgsql;
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

namespace RZD
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            //DataContext = User;
            User = new User();
            Gender.ItemsSource = DbControl.GetGenderStatus();
            Position.ItemsSource = DbControl.GetPositionStatus();
        }
        public User User { get; private set; }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {
                Fullname = FirstName.Text + " " + LastName.Text + " " + Patronymic.Text,
                Username = Username.Text,
                PositionId = (int)Position.SelectedValue,
                Gender = (int)Gender.SelectedValue,
                Birthdate = DateOfBirth.SelectedDate,
                Password = Password.Password
            };
            
            // Реализация логики аутентификации при входе в систему
            if (ValidateUser(user))
            {
                DbControl.AddUser(user);
                MessageBox.Show("Регистрация прошла успешно!");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        
            string errors = "";
            
            if (!CheckOnRussionSybbols(LastName.Text))
            {
                errors += "Ошибка в фамилии";
            }
            else if (LastName.Text == "")
            {
                errors += "Поле фамилии пустое";
            }
            if (!CheckOnRussionSybbols(FirstName.Text))
            {
                errors += "\nОшибка в имени";
            }
            else if (FirstName.Text == "")
            {
                errors += "\nПоле имени пустое";
            }
            if (!CheckOnRussionSybbols(Patronymic.Text))
            {
                errors += "\nОшибка в отчестве";
            }
            else if (Patronymic.Text == "")
            {
                errors += "\nПоле отчества пустое";
            }
            if (!CheckOnUsernameSybbols(Username.Text))
            {
                errors += "\nНекоректный username";
            }
            else if (Username.Text == "")
            {
                errors += "\nПоле username пустое";
            }
            if (Position.SelectedItem == null)
            {
                errors += "\nПоле должность пустое";
            }
            if (DateOfBirth.SelectedDate == null)
            {
                errors += "\nПоле выбора даты пустое";
            }
            if (Gender.SelectedItem == null)
            {
                errors += "\nПоле gender пустое";
            }
            if (!CheckOnUsernameSybbols(Password.Password))
            {
                errors += "\nПароль введен некорректно";
            }
            else if (Password.Password == "")
            {
                errors += "\nПоле пароль пустое";
            }

            if (errors != "")
            {
                MessageBox.Show(errors);
            }
        }

        private bool CheckOnRussionSybbols(string text)
        {
            foreach (var item in text.ToLower()) 
            {
                if (!(item >= 'а' && item <= 'я'))
                {
                    return false;
                }
            }
            return true;
        }
        private bool CheckOnUsernameSybbols(string text)
        {
            foreach (var item in text.ToLower())
            {
                if (!(item >= 'а' && item <= 'я') && !(item >= 'a' && item <= 'z') 
                    && !(item == '.') && !(item == '_') && !(item >= '0' && item <= '9'))
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidateUser(User user)
        {
            return !string.IsNullOrWhiteSpace(user.Fullname) &&
                    !string.IsNullOrWhiteSpace(user.Username) &&
                    user.Birthdate.HasValue &&
                    !string.IsNullOrWhiteSpace(user.Password);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Сollapse_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
