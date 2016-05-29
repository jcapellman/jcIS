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
            _settings.SetValue<string>(Common.SettingsOptions.SELECTED_PLATFORM, SelectedPlatform.Name);
            _settings.SetValue<string>(Common.SettingsOptions.SELECTED_DEVICES, string.Join(",", selectedDevices.Select(a => a.Name).ToList()));

            return true;
        }

        public SettingsModel() {
            _settings = new Settings();
        }

        private void LoadPlatform() {
            Platforms = Platform.GetPlatforms().ToList().Select(a => new jcISPlatform(a)).ToList();

            var settingPlatform = _settings.GetValue<string>(Common.SettingsOptions.SELECTED_PLATFORM);

            if (string.IsNullOrEmpty(settingPlatform)) {
                SelectedPlatform = Platforms.FirstOrDefault();

                return;
            }

            var selectedPlatform = Platforms.FirstOrDefault(a => a.Name == settingPlatform);

            if (selectedPlatform == null) {
                SelectedPlatform = Platforms.FirstOrDefault();

                return;
            }

            SelectedPlatform = selectedPlatform;
        }

        private void LoadDevices() {
            var devices = SelectedPlatform.GetDevices();

            var settingDevice = _settings.GetValue<string>(Common.SettingsOptions.SELECTED_DEVICES);

            if (string.IsNullOrEmpty(settingDevice)) {
                devices[0].IsSelected = true;

                Devices = devices;

                return;
            }

            foreach (var device in devices) {
                if (device.Name != settingDevice) {
                    device.IsSelected = false;

                    continue;
                }

                device.IsSelected = true;
                break;
            }

            Devices = devices;
        }

        public void LoadSettings() {
            LoadPlatform();

            LoadDevices();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}