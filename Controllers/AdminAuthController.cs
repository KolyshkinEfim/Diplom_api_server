using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_crud.Entity;
using test_crud.Models;

namespace test_crud.Controllers
{
    public class AdminLogin 
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

   

    [ApiController]
    [Route("AdminAuthController")]
    public class AdminAuthController : ControllerBase
    {

        private readonly ApplicationContext _context;
        public AdminAuthController(ApplicationContext context)
        {
            _context = context;
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] AdminLogin admin)
        {
            var account = Authentificate(admin.Login, admin.Password);
            if (account != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        private Admin Authentificate(string login, string password)
        {
            return _context.AdminsTable.FirstOrDefault(x => x.Login == login && x.Password == password);
        }
    }
}
