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
    /// Логика взаимодействия для WaysInspections.xaml
    /// </summary>
    public partial class WaysInspections : Window
    {
        public RailwayEngineerInspection Ways { get; private set; }
        public Way Way { get; set;}
        public List<Way> WaysList { get; set; } = DbControl.GetWays();


        public WaysInspections()
        {
            InitializeComponent();

            Ways = new RailwayEngineerInspection()
            {
                InspectionDate = System.DateTime.Now,
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
            try
            {
                DbControl.AddRailwayEngineerInspections(Ways);
                MessageBox.Show("Нарушение успешно записано и отправлено дежурному по станции.");
            }
            catch
            {
                MessageBox.Show("Введите пожалуйста данные!");
            }
            ResetWays();
        }

        private void ResetWays()
        {
            Ways = new RailwayEngineerInspection();
            Ways.InspectionDate = System.DateTime.Now;
            this.DataContext = Ways;
        }

    private void NoDiscrepanciesButton_Click(object sender, RoutedEventArgs e)
        {
            // Обработка нажатия кнопки "Нет выявленных несоответствий"
            if (Way != null)
            {
                Ways.IsViolation = false;
                Ways.RailwayEngineerId = CurrentUser.Id;
                Ways.Vways = Way.Id;
            }
            try
            {
                DbControl.AddRailwayEngineerInspections(Ways);
                MessageBox.Show("Данные успешно записанны");
            }
            catch
            {
                MessageBox.Show("Вы не ввели данные о пути!");
            }
            ResetWays();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
