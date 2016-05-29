using jcIS.WPF.Common;
using jcIS.WPF.Transports.Common;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace jcIS.WPF.Helpers {
    public class Settings {
        private List<SettingsConfigItem> _settings;

        private string _fileName;

        public Settings(string fileName = null) {
            if (string.IsNullOrEmpty(fileName)) {
                _fileName = Common.Constants.SETTINGS_FILE;
            }

            _settings = LoadFile(_fileName);
        }

        private List<SettingsConfigItem> LoadFile(string fileName) {
            if (!File.Exists(fileName)) {
                return new List<SettingsConfigItem>();
            }

            var fileData = File.ReadAllText(fileName);

            return JsonConvert.DeserializeObject<List<SettingsConfigItem>>(fileData);
        }

        private void WriteFile(string fileName) {
            var strValue = JsonConvert.SerializeObject(_settings);

            File.WriteAllText(fileName, strValue);
        }

        private SettingsConfigItem getOption(SettingsOptions settingsOption) => _settings.FirstOrDefault(a => a.Key == settingsOption.ToString());

        public T GetValue<T>(SettingsOptions settingsOption) {
            var settingsValue = getOption(settingsOption);

            if (settingsValue == null) {
                return default(T);
            }

            return (T)Convert.ChangeType(settingsValue.Value, typeof(T));
        }

        public void SetValue<T>(SettingsOptions settingsOption, object settingsValue) {
            var existingValue = getOption(settingsOption);

            if (existingValue == null) {
                _settings.Add(new SettingsConfigItem {
                    Key = settingsOption.ToString(),
                    Value = settingsValue.ToString()
                });

                return;
            }

            _settings.Remove(existingValue);

            existingValue.Value = settingsValue.ToString();

            _settings.Add(existingValue);
        }

        ~Settings() {
            WriteFile(_fileName);
        }
    }
}