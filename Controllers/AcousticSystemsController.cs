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
    [Route("AcousticSystemsController")]
    public class AcousticSystemsController : ControllerBase
    {
        private IRepository _acoucsticSystemsRepository;
        private ApplicationContext _context;


        public AcousticSystemsController(IRepository acoucsticSystemsRepository, ApplicationContext context)
        {
            _acoucsticSystemsRepository = acoucsticSystemsRepository;

        }

        [HttpGet("GetAcousticSystemsList")]
        public IEnumerable<AcousticSystems> GetAcousticSystems()
        {
            return _acoucsticSystemsRepository.Get<AcousticSystems>();
        }

        [HttpGet("AcousticSystemsFindByID")]
        public AcousticSystems GetById(int id)
        {
            return _acoucsticSystemsRepository.FindById<AcousticSystems>(id);
        }

        [HttpPost("AddAcousticSystem")]
        public void Add(AcousticSystems item)
        {
            _acoucsticSystemsRepository.Create(item);
        }

        [HttpPost("UpdateAcousticSystem")]
        public bool Update([FromBody] AcousticSystems item)
        {
            _acoucsticSystemsRepository.Update(item);
            return true;
        }

        [HttpPost("RemoveAcousticSystem")]
        public void Remove( int id)
        {
            _acoucsticSystemsRepository.Remove<AcousticSystems>(_acoucsticSystemsRepository.FindById<AcousticSystems>(id));
        }

        [HttpPost("SearchByParametrs")]
        public IEnumerable<AcousticSystems> SearchByParametrs([FromBody] AcousticSystemsSearch search)
        {
            var acousticsystem = new List<AcousticSystems>();

            acousticsystem = search.Manafacturer != null ? _context.Set<AcousticSystems>().Where(x => search.Manafacturer.Contains(x.Manafacturer)).ToList() : _context.Set<AcousticSystems>().ToList();

            if (acousticsystem == null)
                return acousticsystem;

            acousticsystem = search.Type != null ? acousticsystem.Where(x => search.Type.Contains(x.Type)).ToList() : acousticsystem;

            if (acousticsystem == null)
                return acousticsystem;

            acousticsystem = search.BodyMaterial != null ? acousticsystem.Where(x => search.BodyMaterial.Contains(x.BodyMaterial)).ToList() : acousticsystem;

            if (acousticsystem == null)
                return acousticsystem;

            acousticsystem = search.BiAmping != null ? acousticsystem.Where(x => search.BiAmping.Contains(x.BiAmping)).ToList() : acousticsystem;

            if (acousticsystem == null)
                return acousticsystem;

            acousticsystem = search.Color != null ? acousticsystem.Where(x => search.Color.Contains(x.Color)).ToList() : acousticsystem;

            if (acousticsystem == null)
                return acousticsystem;

            acousticsystem = search.RemoteController != null ? acousticsystem.Where(x => search.RemoteController.Contains(x.RemoteController)).ToList() : acousticsystem;

            if (acousticsystem == null)
                return acousticsystem;

            acousticsystem = search.Display != null ? acousticsystem.Where(x => search.Display.Contains(x.Display)).ToList() : acousticsystem;

            if (acousticsystem == null)
                return acousticsystem;

            acousticsystem = search.FmReciver != null ? acousticsystem.Where(x => search.FmReciver.Contains(x.FmReciver)).ToList() : acousticsystem;

            if (acousticsystem == null)
                return acousticsystem;

            acousticsystem = search.CardReader != null ? acousticsystem.Where(x => search.CardReader.Contains(x.CardReader)).ToList() : acousticsystem;

            if (acousticsystem == null)
                return acousticsystem;


            return acousticsystem;
        }
    }
}
