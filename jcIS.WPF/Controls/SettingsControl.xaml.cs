using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using jcIS.WPF.Transports;
using jcIS.WPF.ViewModels;

namespace jcIS.WPF.Controls {
    public partial class SettingsControl : UserControl {
        public delegate void OnClosingHandler(object sender);

        public event OnClosingHandler OnClosing;

        private SettingsModel viewModel => (SettingsModel) DataContext;

        public SettingsControl() {
            InitializeComponent();
            
            DataContext = new SettingsModel();

            viewModel.LoadSettings();
        }

        private List<jcISDevice> selectedDevices => lstBxDevices.SelectedItems.Cast<jcISDevice>().ToList();

        private void BtnSave_OnClick(object sender, RoutedEventArgs e) {
            var result = viewModel.Save(selectedDevices);

            OnClosing(this);
        }
    }
}