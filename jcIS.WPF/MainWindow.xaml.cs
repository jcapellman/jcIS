using System.Windows;

using MahApps.Metro.Controls;

namespace jcIS.WPF {
    public partial class MainWindow : MetroWindow {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnSettings_OnClick(object sender, RoutedEventArgs e) {
            if (fSettings.IsOpen) {
                return;
            }

            fSettings.IsOpen = true;
        }

        private void SettingsControl_OnClosing(object sender) {
            fSettings.IsOpen = false;
        }
    }
}