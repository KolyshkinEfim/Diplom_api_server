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
    [Route("StorageBaseController")]
    public class StorageBaseController : Controller
    {
        private ApplicationContext _context;
        private IRepository _storageBaseRepos;

        public StorageBaseController(ApplicationContext context, IRepository storageBaseRepos)
        {
            _context = context;
            _storageBaseRepos = storageBaseRepos;
        }

        [HttpGet("GetStorageList")]
        public IEnumerable<StorageBase> GetStorageList() {
            return _storageBaseRepos.Get<StorageBase>();
        }

        [HttpGet("StorageItemById")]
        public StorageBase GetById(int id)
        {
            return _storageBaseRepos.FindById<StorageBase>(id);
        }

        [HttpPost("AddStorageItem")]
        public void Add([FromBody] StorageBase item)
        {
            _storageBaseRepos.Create(item);
        }

        [HttpPost("DeleteStorageItem")]
        public IActionResult Delete([FromBody]int id)
        {
            var delete = _context.StorageBaseTable.FirstOrDefault((x) => x.ID == id);
            if (delete != null)
            {
                _storageBaseRepos.Remove<StorageBase>(_storageBaseRepos.FindById<StorageBase>(id));
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
