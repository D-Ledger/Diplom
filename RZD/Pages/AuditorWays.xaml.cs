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
    /// Логика взаимодействия для AuditorWays.xaml
    /// </summary>
    public partial class AuditorWays : Window
    {
        public InspectionsAuditorWay Ways { get; private set; }

        public Way Way { get; set; }

        public List<Way> WaysList { get; set; } = DbControl.GetWays();

        public AuditorWays()
        {
            InitializeComponent();

            Ways = new InspectionsAuditorWay()
            {
                Date = System.DateTime.Now,
            };

            WaysComboBox.DataContext = this;
            this.DataContext = Ways;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            CloseMovement(false);
            // Отправка сообщения путейцам на устранение несоответствий
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрытие движения
            CloseMovement(true);
            MessageBox.Show("Движение закрыто!");
        }

        private void SaveInspection(DateTime departureDate, string description, bool closureOfTheMovement, int Nways)
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
            DbControl.AddInspectionsAuditorWays(inspectionsAuditorWays);
        }

        private void CloseMovement(bool isClosure)
        {
            // Логика закрытия движения
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
            }
            else
            {
                recordInfoTextBlock.Text = "";
                SaveInspection(departureDate, description, isClosure, Nways);
                Close();
            }
        }
    }
}
