using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AuditorStartWindow.xaml
    /// </summary>
    public partial class AuditorStartWindow : Window
    {
        public ObservableCollection<Train> Trains { get; set; }
        public ObservableCollection<RailwayEngineerInspection> RailwayEngineerInspections { get; set; }
        public ObservableCollection<InspectionsAuditorTrain> InspectionsAuditorTrains { get; set; }
        public ObservableCollection<InspectionsAuditorWay> InspectionsAuditorWays { get; set; }

        private DateTime? _searchDateTrainInspection;
        public DateTime? SearchDateTrainInspection
        {
            set
            {
                _searchDateTrainInspection = value;
                DateSearchTrainInspection();
            }
            get => _searchDateTrainInspection;
        }
        private DateTime? _searchDateWaysInspection;
        public DateTime? SearchDateWaysInspection
        {
            set
            {
                _searchDateWaysInspection = value;
                DateSearchWaysInspections();
            }
            get => _searchDateWaysInspection;
        }
        private DateTime? _searchDateAuditorTrainInspection;
        public DateTime? SearchDateAuditorTrainInspection
        {
            set
            {
                _searchDateAuditorTrainInspection = value;
                DateSearchAuditorTrainInspection();
            }
            get => _searchDateAuditorTrainInspection;
        }
        private DateTime? _searchDateAuditorWays;
        public DateTime? SearchDateAuditorWays
        {
            set
            {
                _searchDateAuditorWays = value;
                DateSearchAuditorWays();
            }
            get => _searchDateAuditorWays;
        }

        public AuditorStartWindow()
        {
            InitializeComponent();
            DataContext = this;
            Trains = new ObservableCollection<Train>(DbControl.GetTrains());
            RailwayEngineerInspections = new ObservableCollection<RailwayEngineerInspection>(DbControl.GetRailwayEngineerInspections());
            InspectionsAuditorTrains = new ObservableCollection<InspectionsAuditorTrain>(DbControl.GetInspectionsAuditorTrains());
            InspectionsAuditorWays = new ObservableCollection<InspectionsAuditorWay>(DbControl.GetInspectionsAuditorWays());

            dataGridTrainInspection.ItemsSource = Trains;
            dataGridWaysInspections.ItemsSource = RailwayEngineerInspections;
            dataGridAuditorTrainInspection.ItemsSource = InspectionsAuditorTrains;
            dataGridAuditorWays.ItemsSource = InspectionsAuditorWays;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Train? train = dataGridTrainInspection.SelectedItem as Train;
            RailwayEngineerInspection? railwayEngineerInspections = dataGridWaysInspections.SelectedItem as RailwayEngineerInspection;
            InspectionsAuditorTrain? inspectionsAuditorTrains = dataGridAuditorTrainInspection.SelectedItem as InspectionsAuditorTrain;
            InspectionsAuditorWay? inspectionsAuditorWays = dataGridAuditorWays.SelectedItem as InspectionsAuditorWay;
            if (train != null)
            {
                EditTrainInspection editTrainInspection = new EditTrainInspection(train);
                editTrainInspection.ShowDialog();
            }
            else if (railwayEngineerInspections != null)
            {
                EditWaysInspections editWaysInspections = new EditWaysInspections(railwayEngineerInspections);
                editWaysInspections.ShowDialog();
            }
            else if (inspectionsAuditorTrains != null)
            {
                EditAuditorTrainInspection editAuditorTrainInspection = new EditAuditorTrainInspection(inspectionsAuditorTrains);
                editAuditorTrainInspection.ShowDialog();
            }
            else if (inspectionsAuditorWays != null)
            {
                EditAuditorWaysInspections editAuditorWaysInspection = new EditAuditorWaysInspections(inspectionsAuditorWays);
                editAuditorWaysInspection.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите отчет");
            }
            RefreshTable();
        }

        private void TrainInspection(object sender, RoutedEventArgs e)
        {
            AuditorTrainInspection trainInspection = new AuditorTrainInspection();
            trainInspection.RefrashTable += RefreshTable;
            trainInspection.ShowDialog();
            RefreshTable();
        }

        private void WaysInspections(object sender, RoutedEventArgs e)
        {
            AuditorWays auditorWays = new AuditorWays();
            auditorWays.ShowDialog();
            RefreshTable();
        }

        public void RefreshTable()
        {
            dataGridTrainInspection.ItemsSource = null;
            dataGridWaysInspections.ItemsSource = null;
            dataGridAuditorTrainInspection.ItemsSource = null;
            dataGridAuditorWays.ItemsSource = null;
            dataGridTrainInspection.ItemsSource = DbControl.GetTrains().OrderByDescending(t => t.TrainId).OrderByDescending(t => t.NumberOfWagons);
            dataGridWaysInspections.ItemsSource = DbControl.GetRailwayEngineerInspections();
            dataGridAuditorTrainInspection.ItemsSource = DbControl.GetInspectionsAuditorTrains();
            dataGridAuditorWays.ItemsSource = DbControl.GetInspectionsAuditorWays();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите удалить?", "Подтверждение", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Train? train = dataGridTrainInspection.SelectedItem as Train;
                if (train != null)
                    DbControl.RemoveTrains(train);

                RailwayEngineerInspection? railwayEngineerInspections = dataGridWaysInspections.SelectedItem as RailwayEngineerInspection;
                if (railwayEngineerInspections != null)
                    DbControl.RemoveRailwayEngineerInspections(railwayEngineerInspections);

                InspectionsAuditorTrain? inspectionsAuditorTrains = dataGridAuditorTrainInspection.SelectedItem as InspectionsAuditorTrain;
                if (inspectionsAuditorTrains != null)
                    DbControl.RemoveInspectionsAuditorTrains(inspectionsAuditorTrains);

                InspectionsAuditorWay? inspectionsAuditorWays = dataGridAuditorWays.SelectedItem as InspectionsAuditorWay;
                if (inspectionsAuditorWays != null)
                    DbControl.RemoveInspectionsAuditorWays(inspectionsAuditorWays);

                RefreshTable();
            }
        }

        private void checkBoxTrainInspection_Checked(object sender, RoutedEventArgs e)
        {
            HideGrids();
            dataGridTrainInspection.Visibility = Visibility.Visible;
            SearchTrainInspection.Visibility = Visibility.Visible;
            DateTrainInspection.Visibility = Visibility.Visible;
        }

        private void checkBoxWaysInspections_Checked(object sender, RoutedEventArgs e)
        {
            HideGrids();
            dataGridWaysInspections.Visibility = Visibility.Visible;
            SearchWaysInspections.Visibility = Visibility.Visible;
            DateWaysInspection.Visibility = Visibility.Visible;
        }

        private void checkBoxAuditorTrainInspection_Checked(object sender, RoutedEventArgs e)
        {
            HideGrids();
            dataGridAuditorTrainInspection.Visibility = Visibility.Visible;
            SearchAuditorTrainInspection.Visibility = Visibility.Visible;
            DateAuditorTrainInspection.Visibility = Visibility.Visible;
        }

        private void checkBoxAuditorWays_Checked(object sender, RoutedEventArgs e)
        {
            HideGrids();
            dataGridAuditorWays.Visibility = Visibility.Visible;
            SearchAuditorWays.Visibility = Visibility.Visible;
            DateAuditorWays.Visibility = Visibility.Visible;
        }

        private void HideGrids()
        {
            dataGridTrainInspection.Visibility = Visibility.Collapsed;
            dataGridWaysInspections.Visibility = Visibility.Collapsed;
            dataGridAuditorTrainInspection.Visibility = Visibility.Collapsed;
            dataGridAuditorWays.Visibility = Visibility.Collapsed;

            SearchTrainInspection.Visibility = Visibility.Collapsed;
            SearchWaysInspections.Visibility = Visibility.Collapsed;
            SearchAuditorTrainInspection.Visibility = Visibility.Collapsed;
            SearchAuditorWays.Visibility = Visibility.Collapsed;

            DateTrainInspection.Visibility = Visibility.Collapsed;
            DateWaysInspection.Visibility = Visibility.Collapsed;
            DateAuditorTrainInspection.Visibility = Visibility.Collapsed;
            DateAuditorWays.Visibility = Visibility.Collapsed;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SearchTrainInspection_KeyUp(object sender, KeyEventArgs e)  /*t.Description + t.TrainId + t.NumberOfWagons + t.StartOfInspection + t.EndOfInspection*/
        {
            Trains = new ObservableCollection<Train>(DbControl.GetTrains());
            Trains = new ObservableCollection<Train>(Trains.Where(t=> t.Description.ToLower().Contains(SearchTrainInspection.Text.ToLower()) ||
                                                                        SearchTrainInspection.Text == t.TrainId.ToString() ||
                                                                        SearchTrainInspection.Text == t.NumberOfWagons.ToString()).ToList());
            dataGridTrainInspection.ItemsSource = null;
            dataGridTrainInspection.ItemsSource = Trains;
        }

        private void SearchWaysInspections_KeyUp(object sender, KeyEventArgs e)
        {
            RailwayEngineerInspections = new ObservableCollection<RailwayEngineerInspection>(DbControl.GetRailwayEngineerInspections()); /*r.Vways + r.WaysNumber + r.Description + r.InspectionDate*/
            RailwayEngineerInspections = new ObservableCollection<RailwayEngineerInspection>(RailwayEngineerInspections.Where(r => r.Description.ToLower().Contains(SearchWaysInspections.Text.ToLower()) ||
                                                                                                                                    SearchWaysInspections.Text == r.WaysNumber.ToString())
                                                                                                                                    .ToList());
            dataGridWaysInspections.ItemsSource = null;
            dataGridWaysInspections.ItemsSource = RailwayEngineerInspections;
        }

        private void SearchAuditorTrainInspection_KeyUp(object sender, KeyEventArgs e)
        {
            InspectionsAuditorTrains = new ObservableCollection<InspectionsAuditorTrain>(DbControl.GetInspectionsAuditorTrains()); /*it.TrainId + it.DepartureStation + it.ArrivalStation + it.Date*/
            InspectionsAuditorTrains = new ObservableCollection<InspectionsAuditorTrain>(InspectionsAuditorTrains.Where(it => it.DepartureStation.ToLower().Contains(SearchAuditorTrainInspection.Text.ToLower()) ||
                                                                                                                                SearchAuditorTrainInspection.Text == it.TrainId.ToString() ||
                                                                                                                                it.ArrivalStation.ToLower().Contains(SearchAuditorTrainInspection.Text.ToLower())).ToList());
            dataGridAuditorTrainInspection.ItemsSource = null;
            dataGridAuditorTrainInspection.ItemsSource = InspectionsAuditorTrains;
        }

        private void SearchAuditorWays_KeyUp(object sender, KeyEventArgs e)
        {
            InspectionsAuditorWays = new ObservableCollection<InspectionsAuditorWay>(DbControl.GetInspectionsAuditorWays());  /*iw.Nways + iw.Description + iw.Date*/
            InspectionsAuditorWays = new ObservableCollection<InspectionsAuditorWay>(InspectionsAuditorWays.Where(iw => iw.Description.ToLower().Contains(SearchAuditorWays.Text.ToLower()) ||
                                                                                                                           SearchAuditorWays.Text == iw.Id.ToString() ||
                                                                                                                           iw.NwaysNavigation.WaysName.ToLower().Contains(SearchAuditorWays.Text.ToLower())).ToList());
            dataGridAuditorWays.ItemsSource = null;
            dataGridAuditorWays.ItemsSource = InspectionsAuditorWays;
        }

        private void DateSearchTrainInspection()
        {
            Trains = new ObservableCollection<Train>(DbControl.GetTrains());
            if (SearchDateTrainInspection != null)
            {        
                Trains = new ObservableCollection<Train>(Trains.Where(t => t.StartOfInspection.Date == SearchDateTrainInspection || t.EndOfInspection.Date == SearchDateTrainInspection));
            }
            dataGridTrainInspection.ItemsSource = null;
            dataGridTrainInspection.ItemsSource = Trains;
        }

        private void DateSearchWaysInspections()
        {
            RailwayEngineerInspections = new ObservableCollection<RailwayEngineerInspection>(DbControl.GetRailwayEngineerInspections());
            if (SearchDateWaysInspection != null)
            {
                RailwayEngineerInspections = new ObservableCollection<RailwayEngineerInspection>(RailwayEngineerInspections.Where(r => r.InspectionDate.Date == SearchDateWaysInspection));
            }
            dataGridWaysInspections.ItemsSource = null;
            dataGridWaysInspections.ItemsSource = RailwayEngineerInspections;
        }

        private void DateSearchAuditorTrainInspection()
        {
            InspectionsAuditorTrains = new ObservableCollection<InspectionsAuditorTrain>(DbControl.GetInspectionsAuditorTrains());
            if (SearchDateAuditorTrainInspection != null)
            {
                InspectionsAuditorTrains = new ObservableCollection<InspectionsAuditorTrain>(InspectionsAuditorTrains.Where(it => it.Date.Date == SearchDateAuditorTrainInspection));
            }
            dataGridAuditorTrainInspection.ItemsSource = null;
            dataGridAuditorTrainInspection.ItemsSource = InspectionsAuditorTrains;
        }

        private void DateSearchAuditorWays()
        {
            InspectionsAuditorTrains = new ObservableCollection<InspectionsAuditorTrain>(DbControl.GetInspectionsAuditorTrains());
            if (SearchDateAuditorWays != null)
            {
                InspectionsAuditorWays = new ObservableCollection<InspectionsAuditorWay>(InspectionsAuditorWays.Where(iw => iw.Date.Date == SearchDateAuditorWays));
            }
            dataGridAuditorWays.ItemsSource = null;
            dataGridAuditorWays.ItemsSource = InspectionsAuditorWays;
        }

        private void ClearDate_Click(object sender, RoutedEventArgs e)
        {
            DateTrainInspection.SelectedDate = null;
            DateWaysInspection.SelectedDate = null;
            DateAuditorTrainInspection.SelectedDate = null;
            DateAuditorWays.SelectedDate = null;
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
