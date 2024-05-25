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
    /// Логика взаимодействия для AuditorTrainInspection.xaml
    /// </summary>
    public partial class AuditorTrainInspection : Window
    {
        public InspectionsAuditorTrain InspectionsAuditorTrains { get; private set; }


        public AuditorTrainInspection()
        {
            InitializeComponent();
        }

        public delegate void RefrASHHandler();
        public event RefrASHHandler RefrashTable;

        private void OformitZapis_Click(object sender, RoutedEventArgs e)
        {
            // Получение данных из полей ввода
            string departureStation = DepartureStation.Text;
            string arrivalStation = ArrivalStation.Text;
            DateTime departureDate = DepartureDate.SelectedDate ?? DateTime.MinValue;

            // Проверка заполненности полей
            if (string.IsNullOrWhiteSpace(departureStation) ||
                string.IsNullOrWhiteSpace(arrivalStation) || departureDate == DateTime.MinValue || string.IsNullOrWhiteSpace(TrainNumber.Text) || !int.TryParse(TrainNumber.Text, out int trainNumber))
            {

                recordInfoTextBlock.Text = "Введены некоректные данные!";
            }
            else
            {
                recordInfoTextBlock.Text = "";
                SaveInspectionData(trainNumber, departureStation, arrivalStation, departureDate, true);
                Close();  
            }

            //// Оформление записи на готовность поезда
        }

        private void OtmenitGotovnost_Click(object sender, RoutedEventArgs e)
        {
            // Отмена технической готовности поезда
            string departureStation = DepartureStation.Text;
            string arrivalStation = ArrivalStation.Text;
            DateTime departureDate = DepartureDate.SelectedDate ?? DateTime.MinValue;

            // Проверка заполненности полей
            if (string.IsNullOrWhiteSpace(departureStation) ||
                string.IsNullOrWhiteSpace(arrivalStation) || departureDate == DateTime.MinValue || string.IsNullOrWhiteSpace(TrainNumber.Text) || !int.TryParse(TrainNumber.Text, out int trainNumber))
            {
                recordInfoTextBlock.Text = "Введены некоректные данные!";
                //return;
            }
            else
            {
                recordInfoTextBlock.Text = "";
                SaveInspectionData(trainNumber, departureStation, arrivalStation, departureDate, false);
            }

            //MessageBox.Show("Данные успешно сохранены!");
            //DbControl.AddInspectionsAuditorTrains(inspectionsAuditorTrains);

            //// Оформление записи на готовность поезда
        }

        private void SaveInspectionData(int trainNumber, string departureStation, string arrivalStation, DateTime departureDate, bool readiness)
        {
            // Cохранение данных осмотра вагонов в базу данных
            var inspectionsAuditorTrains = new InspectionsAuditorTrain()
            {
                TrainId = trainNumber,
                DepartureStation = departureStation,
                ArrivalStation = arrivalStation,
                Date = departureDate,
                Auditor = CurrentUser.Id,
                Readiness = readiness
            };

            MessageBox.Show("Данные успешно сохранены!");
            DbControl.AddInspectionsAuditorTrains(inspectionsAuditorTrains);
            RefrashTable.Invoke();
            Close(); 
        }
    }
}
