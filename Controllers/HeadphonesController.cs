using Microsoft.AspNetCore.Mvc;
using test_crud.Models;
using test_crud.Interfaces;
using System.Collections.Generic;
using test_crud.Entity;
using System.Linq;

namespace test_crud.Controllers
{
    [ApiController]
    [Route("HeadphonesController")]
    public class HeadphonesController : ControllerBase
    {
        private IRepository _headphonesRepos;
        private ApplicationContext _context;

        public HeadphonesController(IRepository headphonesRepository, ApplicationContext context)
        {
            _headphonesRepos = headphonesRepository;
            _context = context;
        }

        [HttpGet("GetHeadphonesList")]
        public IEnumerable<Headphones> GetHeadphones()
        {
            return _headphonesRepos.Get<Headphones>();
        }   

        [HttpGet("HeadphonesFindByID")]
        public Headphones GetById(int id)
        {
            return _headphonesRepos.FindById<Headphones>(id);
        }

        [HttpPost("AddHeadphones")]
        public void Add([FromBody]Headphones item)
        {
            _headphonesRepos.Create(item);
        }

        [HttpPost("UpdateHeadphones")]
        public bool Update(Headphones item)
        {
            _headphonesRepos.Update(item);
            return true;
        }

        [HttpPost("RemoveHeadphones")]
        public IActionResult Remove([FromBody]int id)
        {
            var finded = _context.HeadphonesTable.FirstOrDefault((x) => x.ID == id);
            if (finded != null)
            {
            _headphonesRepos.Remove<Headphones>(_headphonesRepos.FindById<Headphones>(id));
            return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("SearchByParametrs")]
        public IEnumerable<Headphones> SearchByParametrs([FromBody] HeadphonesSearch search)
        {
            var headphones = new List<Headphones>();

            headphones = search.Manufacturer != null ? _context.Set<Headphones>().Where(x => search.Manufacturer.Contains(x.Manafacturer)).ToList() : _context.Set<Headphones>().ToList();
            if (headphones == null)
                return headphones;

            headphones = search.Type != null ? headphones.Where(x => search.Type.Contains(x.Type)).ToList() : headphones;
            if (headphones == null)
                return headphones;

            headphones = search.Color != null ? headphones.Where(x => search.Color.Contains(x.Color)).ToList() : headphones;
            if (headphones == null)
                return headphones;

            headphones = search.Bluetooth != null ? headphones.Where(x => search.Bluetooth.Contains(x.Bluetooth)).ToList() : headphones;
            if (headphones == null)
                return headphones;

            headphones = search.NFC != null ? headphones.Where(x => search.NFC.Contains(x.NFC)).ToList() : headphones;
            if (headphones == null)
                return headphones;

            headphones = search.Microphone != null ? headphones.Where(x => search.Microphone.Contains(x.Microphone)).ToList() : headphones;
            if (headphones == null)
                return headphones;

            headphones = search.Connector != null ? headphones.Where(x => search.Connector.Contains(x.Connector)).ToList() : headphones;
            if (headphones == null)
                return headphones;

            headphones = search.FastCharge != null ? headphones.Where(x => search.FastCharge.Contains(x.FastCharge)).ToList() : headphones;
            if (headphones == null)
                return headphones;

            headphones = search.SurroundSound != null ? headphones.Where(x => search.SurroundSound.Contains(x.SurroundSound)).ToList() : headphones;
            if (headphones == null)
                return headphones;

            headphones = search.NoiseSuppression != null ? headphones.Where(x => search.NoiseSuppression.Contains(x.NoiseSuppression)).ToList() : headphones;
            if (headphones == null)
                return headphones;

            headphones = search.VolumeControl != null ? headphones.Where(x => search.VolumeControl.Contains(x.VolumeControl)).ToList() : headphones;
            if (headphones == null)
                return headphones;

            headphones = search.EarCushionsMaterial != null ? headphones.Where(x => search.EarCushionsMaterial.Contains(x.EarCushionsMaterial)).ToList() : headphones;
            if (headphones == null)
                return headphones;

            headphones = search.BodyMaterial != null ? headphones.Where(x => search.BodyMaterial.Contains(x.BodyMaterial)).ToList() : headphones;
            if (headphones == null)
                return headphones;

            return headphones;
        }

    }
}
