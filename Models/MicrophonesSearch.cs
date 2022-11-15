using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_crud.Models
{
    public class MicrophonesSearch
    {
        public List<string> Manafacturer { get; set; }
        public List<string> Type { get; set; }
        public List<string> BodyMaterial { get; set; }
        public List<string> Color { get; set; }
        public List<string> Connection { get; set; }
    }
}
