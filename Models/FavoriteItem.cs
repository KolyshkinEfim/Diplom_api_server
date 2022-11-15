using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_crud.Models
{
    public class FavoriteItem
    {
        public int ID { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
} 
