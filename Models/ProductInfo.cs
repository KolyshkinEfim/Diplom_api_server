using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_crud.Models
{
    public class ProductInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Manafacturer { get; set; }
        public int Price { get; set; }
        public string ImgLink { get; set; }
        public string EntityType { get; set; }
    }
}
