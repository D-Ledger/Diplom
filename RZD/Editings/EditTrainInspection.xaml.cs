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
    /// Логика взаимодействия для EditTrainInspection.xaml
    /// </summary>
    public partial class EditTrainInspection : Window
    {
        public Train Train { get; private set; }

        public EditTrainInspection(Train train)
        {
            InitializeComponent();
            Train = train;
                
            txtWagonNumber.Text = train.TrainId.ToString();
            txtWagonCount.Text = train.NumberOfWagons.ToString();
            StartInspection1.Value = train.StartOfInspection;
            EndInspection1.Value = train.EndOfInspection;
            if (train.TechnicalReadiness)
            {
                rbReady.IsChecked = true;
            }
            else
            {
                rbNotReady.IsChecked = true;

            }
            txtViolations.Text = train.Description.ToString();
        }

        public string reading = "";

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            string wagonNumber = txtWagonNumber.Text;
            int wagonCount = 0;
            if (!int.TryParse(txtWagonCount.Text, out wagonCount))
            {
                MessageBox.Show("Пожалуйста, введите все данные");
                return;
            }

            DateTime? startTime = StartInspection1.Value;
            DateTime? endTime = EndInspection1.Value;

            bool isReady = rbReady.IsChecked!.Value;
            string violations = "";
            if (!isReady)
            {
                violations = txtViolations.Text;
            }

            // Сохранение данных осмотра вагонов
            SaveInspectionData(wagonNumber, wagonCount, startTime, endTime, isReady, violations);
            // Очистка полей ввода
            //ClearInputFields();
        }

        private void SaveInspectionData(string wagonNumber, int wagonCount, DateTime? startTime, DateTime? endTime, bool isReady, string violations)
        {
            if (startTime != null && endTime != null)
            {
                var train = new Train()
                {
                    TrainId = Train.TrainId,
                    NumberOfWagons = wagonCount,
                    StartOfInspection = (DateTime)startTime,
                    EndOfInspection = (DateTime)endTime,
                    TechnicalReadiness = isReady,
                    Description = violations,
                    WagonInspectorId = CurrentUser.Id
                };

                MessageBox.Show("Данные успешно сохранены!");
                DbControl.EditTrain(train);
                this.Close();
            }
            else
            {
                MessageBox.Show("Дата не задана!");
            }
            // Cохранение данных осмотра вагонов в базу данных
        }

        //private void ClearInputFields()
        //{
        //    txtWagonNumber.Clear();
        //    txtWagonCount.Clear();
        //    StartInspection1.Value = null;
        //    EndInspection1.Value = null;
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
    }
}
