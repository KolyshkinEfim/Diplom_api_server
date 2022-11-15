using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace test_crud.Models
{
    public class User
    {
        public int ID { get; set; }
        public List<FavoriteItem> FavoriteItems { get; set; } = new List<FavoriteItem>();

        public string? Password { get; set; }

        public string? Name { get; set; }
        
        public string? Surname { get; set; }
        
        public string? LastName { get; set; }
        
        public string? Mail { get; set; }
        
        public string? Adress { get; set; }

    }
}
