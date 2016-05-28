using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

using NOpenCL;

namespace jcIS.WPF.ViewModels {
    public class SettingsModel : INotifyPropertyChanged {
        private List<Platform> _platforms;

        public List<Platform> Platforms { get {  return _platforms;} set { _platforms = value; OnPropertyChanged(); } }

        private Platform _selectedPlatform;

        public Platform SelectedPlatform { set { _selectedPlatform = value; OnPropertyChanged(); Devices = value.GetDevices().ToList(); } get { return _selectedPlatform; } }

        private List<Device> _devices;

        public List<Device> Devices {  get { return _devices; } set { _devices = value;  OnPropertyChanged(); SelectedDevice = value.FirstOrDefault(); } }

        private Device _selectedDevice;

        public Device SelectedDevice {  get { return _selectedDevice; } set { _selectedDevice = value;  OnPropertyChanged(); } }

        public void LoadSettings() {
            Platforms = Platform.GetPlatforms().ToList();

            SelectedPlatform = Platforms.FirstOrDefault();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}