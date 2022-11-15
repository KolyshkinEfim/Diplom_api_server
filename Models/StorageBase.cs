using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_crud.Models
{
    public class StorageBase
    {
        public int ID { set; get; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
