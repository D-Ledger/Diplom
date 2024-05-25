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
    /// Логика взаимодействия для EditWaysInspections.xaml
    /// </summary>
    public partial class EditWaysInspections : Window
    {
        public RailwayEngineerInspection Ways { get; private set; }
        public Way Way { get; set; }
        public List<Way> WaysList { get; set; } = DbControl.GetWays();


        public EditWaysInspections(RailwayEngineerInspection railwayEngineerInspections)
        {
            InitializeComponent();

            DateTime.SelectedDate = railwayEngineerInspections.InspectionDate;
            WaysNumber.Text = railwayEngineerInspections.WaysNumber.ToString();
            WaysComboBox.Text = railwayEngineerInspections.Vways.ToString();
            Description.Text = railwayEngineerInspections.Description.ToString();

            var selectedWay = WaysList.FirstOrDefault(x => x.Id == railwayEngineerInspections.Vways);
            if (selectedWay != null)
            {
                int selectedIndex = WaysList.IndexOf(selectedWay);
                WaysComboBox.SelectedIndex = selectedIndex;
            }

            Ways = new RailwayEngineerInspection()
            {
                InspectionDate = System.DateTime.Now,
                WaysNumber = railwayEngineerInspections.WaysNumber,
                Vways = railwayEngineerInspections.Vways,
                Description = railwayEngineerInspections.Description,
                RailwayEngineerId = railwayEngineerInspections.RailwayEngineerId,
                RailwayEngineerInspectionId = railwayEngineerInspections.RailwayEngineerInspectionId
            };

            WaysComboBox.DataContext = this;
            this.DataContext = Ways;
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика для отправки дежурному по станции
            if (Way != null)
            {
                Ways.IsViolation = true;
                Ways.RailwayEngineerId = CurrentUser.Id;
                Ways.Vways = Way.Id;
            }

            DbControl.EditRailwayEngineerInspections(Ways);
            MessageBox.Show("Отчет отредактирован.");
            this.Close();

        }

        //private void ResetWays()
        //{
        //    Ways = new RailwayEngineerInspections();
        //    Ways.InspectionDate = System.DateTime.Now;
        //    this.DataContext = Ways;
        //}

        private void NoDiscrepanciesButton_Click(object sender, RoutedEventArgs e)
        {
            // Обработка нажатия кнопки "Нет выявленных несоответствий"
            if (Way != null)
            {
                Ways.IsViolation = false;
                Ways.RailwayEngineerId = CurrentUser.Id;
                Ways.Vways = Way.Id;
            }

            DbControl.EditRailwayEngineerInspections(Ways);
            MessageBox.Show("Отчет отредактирован.");
            this.Close();
        }

        //private void Exit_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow mainWindow = new MainWindow();
        //    mainWindow.Show();
        //    this.Close();
        //}
    }
}
