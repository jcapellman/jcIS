using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

using NOpenCL;

namespace jcIS.WPF.ViewModels {
    public class SettingsModel : INotifyPropertyChanged {
        private List<Platform> _platforms;

        public List<Platform> Platforms { get {  return _platforms;} set { _platforms = value; OnPropertyChanged(); } }

        public void LoadSettings() {
            Platforms = Platform.GetPlatforms().ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}