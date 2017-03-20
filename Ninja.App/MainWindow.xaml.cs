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

namespace Ninja.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Ninja.App.NinjaDataSet ninjaDataSet = ((Ninja.App.NinjaDataSet)(this.FindResource("ninjaDataSet")));
            // Load data into the table Ninjas. You can modify this code as needed.
            Ninja.App.NinjaDataSetTableAdapters.NinjasTableAdapter ninjaDataSetNinjasTableAdapter = new Ninja.App.NinjaDataSetTableAdapters.NinjasTableAdapter();
            ninjaDataSetNinjasTableAdapter.Fill(ninjaDataSet.Ninjas);
            System.Windows.Data.CollectionViewSource ninjasViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("ninjasViewSource")));
            ninjasViewSource.View.MoveCurrentToFirst();
        }
    }
}
