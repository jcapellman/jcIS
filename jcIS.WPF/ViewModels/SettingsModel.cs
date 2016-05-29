using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using jcIS.WPF.Transports;
using NOpenCL;

namespace jcIS.WPF.ViewModels {
    public class SettingsModel : INotifyPropertyChanged {
        private List<jcISPlatform> _platforms;

        public List<jcISPlatform> Platforms { get {  return _platforms;} set { _platforms = value; OnPropertyChanged(); } }

        private jcISPlatform _selectedPlatform;

        public jcISPlatform SelectedPlatform { set { _selectedPlatform = value; OnPropertyChanged(); Devices = value.GetDevices(); } get { return _selectedPlatform; } }

        private List<jcISDevice> _devices;

        public List<jcISDevice> Devices {  get { return _devices; } set { _devices = value;  OnPropertyChanged(); } }

        public async Task<bool> Save(List<jcISDevice> selectedDevices) {


            return true;
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