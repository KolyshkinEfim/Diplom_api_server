using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using test_crud.Entity;
using test_crud.Models;

namespace test_crud.Controllers
{
    [ApiController]
    [Route("ProductController")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationContext context;
        private IMapper mapper;



        public ProductController(ApplicationContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        [HttpPost("AddToOrderBase")]
        public IActionResult Add([FromBody] OrderBase item)
        {


            return Ok();
            
        }


        [HttpGet("Products/{Type}")]
        public IEnumerable<ProductInfo> GetAll([FromRoute] string Type) {

            try
            {
            switch (Type)
            {   
                case "headphones":
                    return mapper.Map<IEnumerable<ProductInfo>>(context.Set<Headphones>());
                    case "microphones":
                        return mapper.Map<IEnumerable<ProductInfo>>(context.Set<Microphones>());
                    case "acousticsystems":
                        return mapper.Map<IEnumerable<ProductInfo>>(context.Set<AcousticSystems>());
                    default:
                    return null;
            }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        [HttpGet("Products/Search/{Name}")]
        public IEnumerable<ProductInfo> GetSearchedProducts([FromRoute] string Name) {
            try
            {
                List<ProductInfo> products = new List<ProductInfo>();
                products.AddRange(mapper.Map<IEnumerable<ProductInfo>>(context.Set<Headphones>().Where(x => x.Name.Contains(Name))));
                products.AddRange(mapper.Map<IEnumerable<ProductInfo>>(context.Set<Microphones>().Where(x => x.Name.Contains(Name))));
                products.AddRange(mapper.Map<IEnumerable<ProductInfo>>(context.Set<AcousticSystems>().Where(x => x.Name.Contains(Name))));
                return products;
            }
            catch (System.Exception ex)
            {

                throw;
            }
          
        }

    }
}
