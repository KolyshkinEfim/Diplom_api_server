using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_crud.Models
{
    public class HeadphonesSearch
    {
        public List<string>  Manufacturer { get; set; }
        public List<string> Type { get; set; }
        public List<string> Color { get; set; }
        public List<string> Bluetooth { get; set; }
        public List<string> NFC { get; set; }
        public List<string> Microphone { get; set; }
        public List<string> Connector { get; set; }
        public List<string> FastCharge { get; set; }
        public List<string> SurroundSound { get; set; }
        public List<string> NoiseSuppression { get; set; }
        public List<string> VolumeControl { get; set; }
        public List<string> EarCushionsMaterial { get; set; }
        public List<string> BodyMaterial { get; set; }
            
    }
}
