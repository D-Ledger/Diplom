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
    /// Логика взаимодействия для TrainInspection.xaml
    /// </summary>
    public partial class TrainInspection : Window
    {
        public Train Train { get; private set; }

        public TrainInspection()
        {
            InitializeComponent();
            Train = new Train();

        }
        public string reading = "";

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {

            if(ValidateTrain(txtWagonNumber.Text, txtWagonCount.Text, StartOfInspection.Value, EndOfInspection.Value, txtViolations.Text, out string errors)) 
            {
                Train train = new Train()
                {

                TrainNumber = int.Parse(txtWagonNumber.Text),
                NumberOfWagons = int.Parse(txtWagonCount.Text),
                StartOfInspection = (DateTime)StartOfInspection.Value,
                EndOfInspection = (DateTime)EndOfInspection.Value,
                TechnicalReadiness = rbNotReady.IsChecked == true ? false : true,
                Description = txtViolations.Text,
                WagonInspectorId = CurrentUser.Id
                };

                MessageBox.Show("Данные успешно сохранены!");
                DbControl.AddTrain(train);
                StartWindow startWindow = new StartWindow();
                startWindow.Show();
                this.Close();
                return;
            }
            MessageBox.Show(errors);

            // Очистка полей ввода
            //ClearInputFields();
        }

        private bool ValidateTrain(string number, string numberOfWagons, DateTime? startTime, DateTime? endTime, string violations, out string errors)
        {
            errors = "";
            
            if(!int.TryParse(number, out int value))
            {
                errors += "Не записан номер состава!\n";
            }
            if(!int.TryParse(numberOfWagons, out value))
            {
                errors += "Не записано количество вагонов!\n";
            }
            if (startTime == null)
            {
                errors += "Не введено начало осмотра!\n";
            }
            if (endTime == null)
            {
                errors += "Не введен конец осмотра!\n";
            }
            if(violations == "" && rbNotReady.IsChecked == true)
            {
                errors += "Нарушение не описано!";
            }
            return errors == string.Empty;
        }

        //private void ClearInputFields()
        //{
        //    txtWagonNumber.Clear();
        //    txtWagonCount.Clear();
        //    StartOfInspection.Value = null;
        //    EndOfInspection.Value = null;
        //    rbReady.IsChecked = true;
        //    txtViolations.Clear();
        //}

        private void rbNotReady_Click(object sender, RoutedEventArgs e)
        {
            if (rbNotReady != null)
            {
                if (rbNotReady.IsChecked == false)
                {
                    txtViolations.IsEnabled = false;  
                }
                else
                {
                    txtViolations.IsEnabled = true;
                }
            }
        }

//        string errors = "";

//                if (!CheckingCharacters(txtWagonNumber.Text))
//                {
//                    errors += "Не записан номер состава!";
//                }
//                else if (txtWagonNumber.Text == "")
//                {
//                    errors += "\nПоле номер состава пустое";
//                }
//                if (!CheckingCharacters(txtWagonCount.Text))
//                {
//                    errors += "Не записано количество вагонов!";
//                }
//                else if (txtWagonCount.Text == "")
//                {
//                    errors += "\nПоле количество вагонов пустое";
//                }
//                if (errors != "")
//                {
//                    MessageBox.Show(errors);
//}

//            private bool CheckingCharacters(string text)
//        {
//            foreach (var item in text.ToLower())
//            {
//                if (!(item >= 'а' && item <= 'я') && !(item >= 'a' && item <= 'z')
//                    && !(item == '.') && !(item == '_') && !(item >= '0' && item <= '9'))
//                {
//                    return false;
//                }
//            }
//            return true;
        }
    }
