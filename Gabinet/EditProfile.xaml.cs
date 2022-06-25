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
    /// Logika interakcji dla klasy EditProfile.xaml
    /// </summary>
    public partial class EditProfile : Window
    {
        private GabinetContext Context;

        public EditProfile(GabinetContext context)
        {
            InitializeComponent();
            this.Context = context;
        }
    }
}