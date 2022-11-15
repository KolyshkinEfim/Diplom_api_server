using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_crud.Models
{
    public class UpdateUserPassword
    {
        
        public string? Mail { get; set; }

        public string? OldPassword { get; set; }

        public string? NewPassword { get; set; }
    }
}
