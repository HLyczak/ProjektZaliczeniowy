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
    /// Logika interakcji dla klasy Grafik.xaml
    /// </summary>
    public partial class Grafik : Window
    {
        private GabinetContext Context;

        public Grafik(GabinetContext context)
        {
            InitializeComponent();
            this.Context = context;
            var doctors = this.Context.Doctor.ToList();
            var patient = this.Context.Patient.ToList();
            var room = this.Context.Room.ToList();

            this.ComboBoxDoctor.ItemsSource = doctors;
            this.ComboBoxPatient.ItemsSource = patient;
            this.ComboBoxRoom.ItemsSource = room;
        }

        private void LogOut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Gabinet.MainWindow main = new Gabinet.MainWindow(this.Context);
            this.Visibility = Visibility.Hidden;
            main.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var data = DataInput.SelectedDate.Value.Date;

            string addDoctor = ComboBoxDoctor.SelectedValue.ToString();
            long addDoctor1 = long.Parse(addDoctor);
            string addPatient = ComboBoxPatient.SelectedValue.ToString();
            long addPatient1 = long.Parse(addPatient);
            string addRoom = ComboBoxRoom.SelectedValue.ToString();
            long addRoom2 = long.Parse(addRoom);

            this.Context.Add(new ProjektZaliczeniowy.Grafik { PatientId = addPatient1, DoctorId = addDoctor1, RoomId = addRoom2, Data = data });

            Context.SaveChanges();
            MessageBox.Show("The visit has been created");
        }

        private void GoBack1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Gabinet.Nurse nurse = new Gabinet.Nurse(this.Context);
            this.Visibility = Visibility.Hidden;
            nurse.Show();
        }
    }
}