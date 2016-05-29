using System.Runtime.Serialization;

namespace jcIS.WPF.Transports.Common {
    [DataContract]
    public class SettingsConfigItem {
        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public string Value { get; set; }
    }
}