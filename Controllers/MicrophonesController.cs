using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using test_crud.Entity;
using test_crud.Interfaces;
using test_crud.Models;

namespace test_crud.Controllers
{
    [ApiController]
    [Route("MicrophonesController")]
    public class MicrophonesController : ControllerBase
    {
        private IRepository _microphonesRepository;
        private ApplicationContext _context;

        public MicrophonesController(IRepository microphonesRepository, ApplicationContext context)
        {
            _microphonesRepository = microphonesRepository;
            _context = context;
        }

        [HttpGet("GetMicrophonesList")]
        public IEnumerable<Microphones> GetMicrophones()
        {
            return _microphonesRepository.Get<Microphones>();
        }

        [HttpGet("MicrophonesFindById")]
        public Microphones GetById(int id)
        {
            return _microphonesRepository.FindById<Microphones>(id);
        }

        [HttpPost("AddMicrophones")]
        public void Add([FromBody]Microphones item)
        {
            _microphonesRepository.Create(item);
        }

        [HttpPost("UpdateMicrophone")]
        public bool Update(Microphones item)
        {
            _microphonesRepository.Update(item);
            return true;
        }

        [HttpPost("RemoveMicrophone")]
        public void Remove(int id)
        {
            _microphonesRepository.Remove<Microphones>(_microphonesRepository.FindById<Microphones>(id));
        }

        [HttpPost("SearchByParametrs")]
        public IEnumerable<Microphones> SearchByParametrs([FromBody] MicrophonesSearch search)
        {
            var microphones = new List<Microphones>();

            microphones = search.Manafacturer != null ? _context.Set<Microphones>().Where(x => search.Manafacturer.Contains(x.Manafacturer)).ToList() : _context.Set<Microphones>().ToList();
            if (microphones == null)
                return microphones;

            microphones = search.Type != null ? microphones.Where(x => search.Type.Contains(x.Type)).ToList() : microphones;
            if (microphones == null)
                return microphones;

            microphones = search.BodyMaterial != null ? microphones.Where(x => search.BodyMaterial.Contains(x.BodyMaterial)).ToList() : microphones;
            if (microphones == null)
                return microphones;

            microphones = search.Color != null ? microphones.Where(x => search.Color.Contains(x.Color)).ToList() : microphones;
            if (microphones == null)
                return microphones;

            microphones = search.Connection != null ? microphones.Where(x => search.Connection.Contains(x.Connection)).ToList() : microphones;
            if (microphones == null)
                return microphones;

            return microphones;
        }
    }

}
