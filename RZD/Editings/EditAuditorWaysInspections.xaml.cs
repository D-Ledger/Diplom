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
    /// Логика взаимодействия для EditAuditorWaysInspections.xaml
    /// </summary>
    public partial class EditAuditorWaysInspections : Window
    {
        public InspectionsAuditorWay Ways { get; private set; }

        public Way Way { get; set; }

        public List<Way> WaysList { get; set; } = DbControl.GetWays();


        public EditAuditorWaysInspections(InspectionsAuditorWay auditorWays)
        {
            InitializeComponent();

            DepartureDate.SelectedDate = auditorWays.Date;
            WaysComboBox.Text = auditorWays.Nways.ToString();
            Description.Text = auditorWays.Description.ToString();

            var selectedWay = WaysList.FirstOrDefault(x => x.Id == auditorWays.Nways);
            if (selectedWay != null)
            {
                int selectedIndex = WaysList.IndexOf(selectedWay);
                WaysComboBox.SelectedIndex = selectedIndex;
            }

            Ways = new InspectionsAuditorWay()
            {
                Date = System.DateTime.Now,
                Nways = auditorWays.Nways,
                Description = auditorWays.Description
            };

            WaysComboBox.DataContext = this;
            this.DataContext = Ways;
        }
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime departureDate = DepartureDate.SelectedDate ?? DateTime.MinValue;
            string description = Description.Text;

            var temp = WaysComboBox.SelectedValue as Way;

            int Nways = 0;
            if (temp != null)
            {
                Nways = temp.Id;
            }
            // Проверка заполненности полей
            if (string.IsNullOrWhiteSpace(description) || departureDate == DateTime.MinValue || Nways == 0)
            {

                recordInfoTextBlock.Text = "Введены некоректные данные!";
                //return;
            }
            else
            {
                recordInfoTextBlock.Text = "";
                SaveInspection(departureDate, description, false, Nways);
                Close();
            }
            // Отправка сообщения путейцам на устранение несоответствий

        }

        private void SaveInspection( DateTime departureDate, string description, bool closureOfTheMovement, int Nways)
        {
            // Cохранение данных осмотра вагонов в базу данных
            var inspectionsAuditorWays = new InspectionsAuditorWay()
            {
                Date = departureDate,
                Description = description,
                Auditor = CurrentUser.Id,
                ClosureOfTheMovement = closureOfTheMovement,
                Nways = Nways
            };

            MessageBox.Show("Данные успешно сохранены!");
            DbControl.EditInspectionsAuditorWays(inspectionsAuditorWays);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрытие движения
            CloseMovement();
        }

        //private void SendToPathmen(Dictionary<string, string> dictionary)
        //{
        //    // Логика отправки сообщения путейцам


        //    MessageBox.Show("Сообщение отправлено путейцам!");
        //}

        private void CloseMovement()
        {
            // Логика закрытия движения

            MessageBox.Show("Движение закрыто!");
        }
    }
}
