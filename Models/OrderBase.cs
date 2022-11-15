using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace test_crud.Models
{
    public class OrderBase
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public bool IsEmpty { get; set; }
        public string Mail { get; set; }
        public string Adress { get; set; }
        public string Amount { get; set; }
        public List<ProductOrder> Products {get;set;}
        public string Message { get; set; }
        public string Status { get; set; }


    }
}
