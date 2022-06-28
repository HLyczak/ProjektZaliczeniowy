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
    /// Logika interakcji dla klasy Patient.xaml
    /// </summary>
    public partial class Patient : Window
    {
        private GabinetContext Context;
        private ProjektZaliczeniowy.Patient CurrentPatient;

        public Patient(GabinetContext context, ProjektZaliczeniowy.Patient patient)
        {
            InitializeComponent();
            this.Context = context;
            this.CurrentPatient = patient;
        }

        private void Show_grafik_Click(object sender, RoutedEventArgs e)
        {
            var data = this.Date.Text;
            var datasq = this.Context.Grafik.Where(u => u.Data.ToString().Contains(data) && u.PatientId == CurrentPatient.Id);
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

            var data = this.Date.Text;
            var datasq = this.Context.Grafik.Where(u => u.Data.ToString().Contains(data) && u.PatientId == CurrentPatient.Id);
            var patientid = datasq.Select(u => new RowGrafik { Doctor_Name = u.Doctor.NameSurname, Room_Number = u.Room.Number, Grafik_Id = u.Id, Name_Patient = u.Patient.Name }).ToList();
            datagrid.ItemsSource = patientid;
        }

        private void LogOutP_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Gabinet.MainWindow main = new Gabinet.MainWindow(this.Context);
            this.Visibility = Visibility.Hidden;
            main.Show();
        }
    }
}