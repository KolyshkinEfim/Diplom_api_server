using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using test_crud.Entity;
using test_crud.Interfaces;
using test_crud.Models;

namespace test_crud.Controllers
{
    [ApiController]
    [Route("BackConnect")]
    public class BackConnectController : ControllerBase
    {
        private IRepository _backConnectRepos;
        private ApplicationContext _context;

        public BackConnectController(IRepository backConnectRepos, ApplicationContext context)
        {
            _backConnectRepos = backConnectRepos;
            _context = context;
        }

        [HttpGet("GetBackConnectList")]
        public IEnumerable<BackConnect> GetBackConnectList()
        {
            return _backConnectRepos.Get<BackConnect>();
        }

        [HttpGet("GetBackConnectById")]
        public BackConnect FindBackConnectById(int id)
        {
            return _backConnectRepos.FindById<BackConnect>(id);
        }

        [HttpPost("AddBackConnect")]
        public void Add([FromBody] BackConnect item)
        {
            _backConnectRepos.Create(item);
        }

        [HttpPost("ChangeStatus")]
        public IActionResult Update([FromBody]int item)
        {
            var updatedFeedback = _context.BackConnectsTable.FirstOrDefault((x) => x.ID == item);
            if (updatedFeedback != null)
            {
                updatedFeedback.Status = "Обработано";
                _backConnectRepos.Update(updatedFeedback);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("RemoveFromBackConnectList")]
        public void Remove(int id)
        {
            _backConnectRepos.Remove<BackConnect>(_backConnectRepos.FindById<BackConnect>(id));
        }


    }
}
