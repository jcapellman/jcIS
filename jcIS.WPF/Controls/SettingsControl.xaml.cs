using System.Windows.Controls;

using jcIS.WPF.ViewModels;

namespace jcIS.WPF.Controls {
    public partial class SettingsControl : UserControl {
        private SettingsModel viewModel => (SettingsModel) DataContext;

        public SettingsControl() {
            InitializeComponent();

            DataContext = new SettingsModel();

            viewModel.LoadSettings();
        }
    }
}