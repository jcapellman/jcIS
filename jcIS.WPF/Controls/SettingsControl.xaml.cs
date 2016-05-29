using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using jcIS.WPF.Transports;
using jcIS.WPF.ViewModels;

namespace jcIS.WPF.Controls {
    public partial class SettingsControl : UserControl {
        private SettingsModel viewModel => (SettingsModel) DataContext;

        public SettingsControl() {
            InitializeComponent();

            DataContext = new SettingsModel();

            viewModel.LoadSettings();
        }

        private List<jcISDevice> selectedDevices => lstBxDevices.SelectedItems.Cast<jcISDevice>().ToList();

        private async void BtnSave_OnClick(object sender, RoutedEventArgs e) {
            var result = await viewModel.Save(selectedDevices);

            if (result) {
                MessageBox.Show("Settings Saved");
            }
        }
    }
}