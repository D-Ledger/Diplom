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
    /// Логика взаимодействия для EditAuditorTrainInspection.xaml
    /// </summary>
    public partial class EditAuditorTrainInspection : Window
    {
        public InspectionsAuditorTrain InspectionsAuditorTrains { get; private set; }

        public EditAuditorTrainInspection(InspectionsAuditorTrain auditorTrains)
        {
            InitializeComponent();
            InspectionsAuditorTrains = auditorTrains;

            TrainNumber.Text = auditorTrains.TrainId.ToString();
            DepartureStation.Text = auditorTrains.DepartureStation.ToString();
            ArrivalStation.Text = auditorTrains.ArrivalStation.ToString();
            DepartureDate.SelectedDate = auditorTrains.Date;
        }
        private void FormalizationRecording_Click(object sender, RoutedEventArgs e)
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

        private void CancelReadiness_Click(object sender, RoutedEventArgs e)
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
                Id = trainNumber,
                TrainId = trainNumber,
                DepartureStation = departureStation,
                ArrivalStation = arrivalStation,
                Date = departureDate,
                Auditor = CurrentUser.Id,
                Readiness = readiness
            };

            MessageBox.Show("Данные успешно сохранены!");
            DbControl.EditInspectionsAuditorTrains(inspectionsAuditorTrains);
        }
    }
}
