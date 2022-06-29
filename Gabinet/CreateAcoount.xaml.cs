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
    /// Logika interakcji dla klasy CreateAcoount.xaml
    /// </summary>
    public partial class CreateAcoount : Window
    {
        private GabinetContext Context;

        public CreateAcoount(GabinetContext context)
        {
            InitializeComponent();
            this.Context = context;
        }

        /// <summary>
        /// Ustawienie widoczności elementów dla doktora
        /// </summary>
        private void DoctorT_Click(object sender, RoutedEventArgs e)
        {
            this.SpecjalizationDropDown.SelectedIndex = -1;
            this.RoleComboBox.SelectedIndex = -1;
            this.Pesel.Clear();
            this.NameSurname.Clear();
            this.PassInput.Clear();
            this.PermissionNumber.Clear();
            this.Adress.Clear();

            this.SpecjalizationText.Visibility = Visibility.Visible;
            this.SpecjalizationDropDown.Visibility = Visibility.Visible;
            this.PeselT.Visibility = Visibility.Hidden;
            this.Pesel.Visibility = Visibility.Hidden;
            this.RoleText.Visibility = Visibility.Visible;
            this.RoleComboBox.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Ustawienie widoczności elementów dla pielęgniarki
        /// </summary>

        private void NurseT_Click(object sender, RoutedEventArgs e)
        {
            this.RoleComboBox.SelectedIndex = -1;
            this.NameSurname.Clear();
            this.PassInput.Clear();
            this.PermissionNumber.Clear();
            this.Adress.Clear();

            this.SpecjalizationText.Visibility = Visibility.Hidden;
            this.SpecjalizationDropDown.Visibility = Visibility.Hidden;
            this.PermissionNumberT.Visibility = Visibility.Visible;
            this.PermissionNumber.Visibility = Visibility.Visible;
            this.PeselT.Visibility = Visibility.Hidden;
            this.Pesel.Visibility = Visibility.Hidden;
            this.RoleText.Visibility = Visibility.Visible;
            this.RoleComboBox.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Ustawienie widoczności elementów dla pacjenta
        /// </summary>
        private void PatientT_Click(object sender, RoutedEventArgs e)
        {
            this.NameSurname.Clear();
            this.PassInput.Clear();
            this.Adress.Clear();

            this.SpecjalizationText.Visibility = Visibility.Hidden;
            this.SpecjalizationDropDown.Visibility = Visibility.Hidden;
            this.PermissionNumberT.Visibility = Visibility.Hidden;
            this.PermissionNumber.Visibility = Visibility.Hidden;
            this.PeselT.Visibility = Visibility.Visible;
            this.Pesel.Visibility = Visibility.Visible;
            this.RoleText.Visibility = Visibility.Hidden;
            this.RoleComboBox.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Metoda odpowiada za dodawanie użytkowników do bazy danych.
        /// </summary>

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string addName = this.NameSurname.Text;
            string addAdres = this.Adress.Text;
            string password = this.PassInput.Text;

            try
            {
                /// <summary>
                /// Dodanie usera - doctor do bazy danych
                /// </summary>
                ///
                if (DoctorT.IsChecked == true)
                {
                    var addRole = RoleComboBox.SelectedValue.ToString();
                    long addRole2 = long.Parse(addRole);
                    var addSpecjalization = this.SpecjalizationDropDown.SelectedValue.ToString();
                    long addSpecjalization2 = long.Parse(addSpecjalization);
                    string addPermission = this.PermissionNumber.Text;
                    this.Context.Add(new ProjektZaliczeniowy.Doctor { NameSurname = addName, Adress = addAdres, PermissionNumber = addPermission, RoleId = addRole2, SpecializationId = addSpecjalization2, Password = password });
                }
                /// <summary>
                /// Dodanie usera -patient do bazy danych
                /// </summary>
                if (PatientT.IsChecked == true)
                {
                    string addPesel = this.Pesel.Text;
                    long addPesel2 = long.Parse(addPesel);
                    this.Context.Add(new ProjektZaliczeniowy.Patient { Name = addName, Adress = addAdres, Pesel = addPesel2, RoleId = 2, Password = password });
                }
                /// <summary>
                /// Dodanie usera -nurse do bazy danych
                /// </summary>
                if (NurseT.IsChecked == true)
                {
                    var addRole = RoleComboBox.SelectedValue.ToString();
                    long addRole2 = long.Parse(addRole);
                    string addPermission = this.PermissionNumber.Text;
                    this.Context.Add(new ProjektZaliczeniowy.Nurse { NameSurname = addName, Adress = addAdres, PermissionNumber = addPermission, RoleId = addRole2, Password = password });
                }

                Context.SaveChanges();
                MessageBox.Show("The user has been created");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Invalid data");
            }
        }

        /// <summary>
        ///Dodanie akcji do przycisku go back.
        /// </summary>
        private void GoBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Gabinet.Nurse nurse = new Gabinet.Nurse(this.Context);
            this.Visibility = Visibility.Hidden;
            nurse.Show();
        }

        /// <summary>
        ///Dodanie akcji do przycisku logout.
        /// </summary>
        private void LogOutt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Gabinet.MainWindow main = new Gabinet.MainWindow(this.Context);
            this.Visibility = Visibility.Hidden;
            main.Show();
        }
    }
}