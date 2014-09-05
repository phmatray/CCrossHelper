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
using CCrossHelper.Lib.Helpers;
using CCrossHelper.Lib.Portable.Extensions;

namespace CCrossHelper.Test.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var romanNumber = 1.ToRoman();
            var assemblyVersion = AssemblyHelper.GetAssemblyVersion();
            TBox.Text = romanNumber + " - " + assemblyVersion;
        }
    }
}
