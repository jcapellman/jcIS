using System.Linq;

using jcIS.PCL;
using MahApps.Metro.Controls;

namespace jcIS.WPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow {
        public MainWindow() {
            InitializeComponent();

            var c = new jcScaler();

            lvPlatforms.ItemsSource = c.GetPlatforms().Select(a => a.Name).ToList();
        }
    }
}