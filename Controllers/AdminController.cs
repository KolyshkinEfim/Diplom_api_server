using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_crud.Entity;
using test_crud.Interfaces;
using test_crud.Models;

namespace test_crud.Controllers
{
    [ApiController]
    [Route("AdminController")]
    public class AdminController : ControllerBase
    {
        private IRepository _adminrepos;
        private ApplicationContext _context;

        public AdminController(IRepository adminRepository, ApplicationContext context)
        {
            _adminrepos = adminRepository;
            _context = context;
        }

        [HttpPost("AddAdmin")]
        public ActionResult Add([FromBody] Admin item)
        {
            if (_context.AdminsTable.FirstOrDefault((x) => x.Login == item.Login) == null)
            {
                _adminrepos.Create(item);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
         
        [HttpGet("FindAdminByID/{id}")]
        public Admin Get([FromRoute] int id)
        {
            return _adminrepos.FindById<Admin>(id);
        }

    }   
}
