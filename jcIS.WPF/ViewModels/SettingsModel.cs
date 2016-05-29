using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

using jcIS.WPF.Transports;
using jcIS.WPF.Helpers;

using NOpenCL;

namespace jcIS.WPF.ViewModels {
    public class SettingsModel : INotifyPropertyChanged {
        private Settings _settings;

        private List<jcISPlatform> _platforms;

        public List<jcISPlatform> Platforms { get {  return _platforms;} set { _platforms = value; OnPropertyChanged(); } }

        private jcISPlatform _selectedPlatform;

        public jcISPlatform SelectedPlatform { set { _selectedPlatform = value; OnPropertyChanged(); Devices = value.GetDevices(); } get { return _selectedPlatform; } }

        private List<jcISDevice> _devices;

        public List<jcISDevice> Devices {  get { return _devices; } set { _devices = value;  OnPropertyChanged(); } }

        public bool Save(List<jcISDevice> selectedDevices) {
            _settings.SetValue<string>(Common.SettingsOptions.SELECTED_PLATFORM, SelectedPlatform.NOCLPlatform.Name);
            _settings.SetValue<string>(Common.SettingsOptions.SELECTED_DEVICES, string.Join(",", selectedDevices.Select(a => a.NOCLDevice.Name).ToList()));

            return true;
        }

        public SettingsModel() {
            _settings = new Settings();
        }

        public void LoadSettings() {
            Platforms = Platform.GetPlatforms().ToList().Select(a => new jcISPlatform(a)).ToList();

            SelectedPlatform = Platforms.FirstOrDefault();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}