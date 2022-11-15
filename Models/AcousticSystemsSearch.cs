using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_crud.Models
{
    public class AcousticSystemsSearch
    {
        public List<string> Manafacturer { get; set; }
        public List<string> Type { get; set; }
        public List<string> BodyMaterial { get; set; }
        public List<string> BiAmping { get; set; }
        public List<string> Color { get; set; }
        public List<string> RemoteController { get; set; }
        public List<string> Display { get; set; }
        public List<string> FmReciver { get; set; }
        public List<string> CardReader { get; set; }
    }
}
