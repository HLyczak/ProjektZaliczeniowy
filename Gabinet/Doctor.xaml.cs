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
    /// Logika interakcji dla klasy Doctor.xaml
    /// </summary>
    public partial class Doctor : Window
    {
        private GabinetContext Context;
        private ProjektZaliczeniowy.Doctor CurrentDoctor;

        public Doctor(GabinetContext context, ProjektZaliczeniowy.Doctor doctor)
        {
            InitializeComponent();
            this.Context = context;
            this.CurrentDoctor = doctor;

            var doctorVisits = this.Context.Grafik.Where(u => u.DoctorId == CurrentDoctor.Id);
            var dateList = doctorVisits.Select(v => v.Data.ToString("yyyy-MM-dd")).Distinct().ToList();
            dropdownData.ItemsSource = dateList;
        }

        private void LogOut_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Gabinet.MainWindow main = new Gabinet.MainWindow(this.Context);
            this.Visibility = Visibility.Hidden;
            main.Show();
        }

        /// <summary>
        ///Dodanie wyświetlania listy wizyt dla jednego usera.
        /// </summary>

        private void Show_grafik_Click(object sender, RoutedEventArgs e)
        {
            var data = this.dropdownData.Text;
            var datasq = this.Context.Grafik.Where(u => u.Data.ToString().Contains(data) && u.DoctorId == CurrentDoctor.Id);
            var patientid = datasq.Select(u => new RowGrafik
            {
                Doctor_Name = u.Doctor.NameSurname,
                Room_Number = u.Room.Number,
                Grafik_Id = u.Id,
                Name_Patient = u.Patient.Name
            }).ToList();
            datagrid.ItemsSource = patientid;
        }

        /// <summary>
        ///Funkcja odpowiadająca za usuwanie usera z bazy oraz refresh listy.
        /// </summary>
        public void btnView_Click(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Show("Are you sure?", "Caution", MessageBoxButton.OK, MessageBoxImage.Warning);
            var obj = ((FrameworkElement)sender).DataContext as RowGrafik;
            var delete = this.Context.Grafik.First(u => u.Id == obj.Grafik_Id);
            this.Context.Grafik.Remove(delete);
            Context.SaveChanges();

            var data = this.dropdownData.Text;
            var datasq = this.Context.Grafik.Where(u => u.Data.ToString().Contains(data));
            var patientid = datasq.Select(u => new RowGrafik { Doctor_Name = u.Doctor.NameSurname, Room_Number = u.Room.Number, Grafik_Id = u.Id, Name_Patient = u.Patient.Name }).ToList();
            datagrid.ItemsSource = patientid;
        }
    }
}