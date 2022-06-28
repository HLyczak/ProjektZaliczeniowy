using ProjektZaliczeniowy;
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

namespace Gabinet
{
    /// <summary>
    /// Logika interakcji dla klasy Nurse.xaml
    /// </summary>
    public partial class Nurse : Window
    {
        private GabinetContext Context;

        public Nurse(GabinetContext context)
        {
            InitializeComponent();
            this.Context = context;
        }

        private void LogOut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Gabinet.MainWindow main = new Gabinet.MainWindow(this.Context);
            this.Visibility = Visibility.Hidden;
            main.Show();
        }

        /// <summary>
        /// Metoda odpowiadająca za pokazanie grafiku wizyt dla zalogowanego pacjenta.
        /// </summary>
        private void show_Click(object sender, RoutedEventArgs e)
        {
            var data = this.dataNurse.Text;
            var datasq = this.Context.Grafik.Where(u => u.Data.ToString().Contains(data));
            var patientid = datasq.Select(u => new RowGrafik { Doctor_Name = u.Doctor.NameSurname, Room_Number = u.Room.Number, Grafik_Id = u.Id, Name_Patient = u.Patient.Name }).ToList();
            datagrid.ItemsSource = patientid;
        }

        /// <summary>
        /// Metoda odpowiadająca za usunięcie wizyty z grafiku oraz za odświeżenie listy.
        /// </summary>
        public void btnView_Click(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Show("Are you sure?", "Caution", MessageBoxButton.OK, MessageBoxImage.Warning);
            var obj = ((FrameworkElement)sender).DataContext as RowGrafik;
            var delete = this.Context.Grafik.First(u => u.Id == obj.Grafik_Id);
            this.Context.Grafik.Remove(delete);
            Context.SaveChanges();

            var data = this.dataNurse.Text;
            var datasq = this.Context.Grafik.Where(u => u.Data.ToString().Contains(data));
            var patientid = datasq.Select(u => new RowGrafik { Doctor_Name = u.Doctor.NameSurname, Room_Number = u.Room.Number, Grafik_Id = u.Id, Name_Patient = u.Patient.Name }).ToList();
            datagrid.ItemsSource = patientid;
        }

        private void CreateAcoountButton_Click(object sender, RoutedEventArgs e)
        {
            Gabinet.CreateAcoount account = new Gabinet.CreateAcoount(this.Context);
            this.Visibility = Visibility.Hidden;
            account.Show();
        }

        private void AddVisit_Click(object sender, RoutedEventArgs e)
        {
            Gabinet.Grafik grafik = new Gabinet.Grafik(this.Context);
            this.Visibility = Visibility.Hidden;
            grafik.Show();
        }
    }

    public class RowGrafik
    {
        public string Name_Patient { get; set; }
        public long Room_Number { get; set; }
        public long Grafik_Id { get; set; }
        public string Doctor_Name { get; set; }
    }
}