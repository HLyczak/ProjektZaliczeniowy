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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gabinet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GabinetContext Context;

        public MainWindow()
        {
        }

        public MainWindow(GabinetContext context)
        {
            InitializeComponent();
            this.Context = context;
        }

        private void submitLogin_Click(object sender, RoutedEventArgs e)
        {
            var name = this.LogIn.Text;
            var pass = this.Password.Password;

            if (DoctorT.IsChecked == true)
            {
                var nameSql = this.Context.Doctor.FirstOrDefault(u => u.NameSurname == name);
                var passSql = this.Context.Doctor.FirstOrDefault(u => u.Password == pass);
                if (nameSql is not null && passSql is not null)
                {
                    Gabinet.Doctor doctor = new Gabinet.Doctor(this.Context, nameSql);
                    this.Visibility = Visibility.Hidden;
                    doctor.Show();
                }
                else
                {
                    MessageBox.Show("Corect the data", "Wrong data", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (Patient.IsChecked == true)
            {
                var nameSql = this.Context.Patient.FirstOrDefault(u => u.Name == name);
                var passSql = this.Context.Patient.FirstOrDefault(u => u.Password == pass);
                if (nameSql is not null && passSql is not null)
                {
                    Gabinet.Patient pacjent = new Gabinet.Patient(this.Context, nameSql);
                    this.Visibility = Visibility.Hidden;
                    pacjent.Show();
                }
                else
                {
                    MessageBox.Show("Incorect data", "Wrong data", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (Nurse.IsChecked == true)
            {
                var nameSql = this.Context.Nurse.FirstOrDefault(u => u.NameSurname == name);
                var passSql = this.Context.Nurse.FirstOrDefault(u => u.Password == pass);
                if (nameSql is not null && passSql is not null)
                {
                    Gabinet.Nurse nurse = new Gabinet.Nurse(this.Context);
                    this.Visibility = Visibility.Hidden;
                    nurse.Show();
                }
                else
                {
                    MessageBox.Show("Corect the data", "Wrong data", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public bool textInput(GabinetContext contex)
        {
            return true;
        }

        private void LogIn_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}