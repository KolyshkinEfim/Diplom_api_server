using Microsoft.AspNetCore.Mvc;
using test_crud.Interfaces;
using System.Collections.Generic;
using test_crud.Models;
using test_crud.Entity;
using System.Linq;
using AutoMapper;

namespace test_crud.Controllers
{
    [ApiController]
    [Route("FavoriteItemsController")]
    public class FavoriteItemsController : ControllerBase
    {
        private IRepository _favoriteItems;
        private ApplicationContext _context;
        private IMapper _mapper;

        public FavoriteItemsController(IRepository favoriteItems, ApplicationContext context, IMapper mapper)
        {
            _favoriteItems = favoriteItems;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetUsersFavoriteItems")]
        public IEnumerable<FavoriteItemInfo> GetUsersFavoriteItems(int id)
        {
            return _mapper.Map<IEnumerable<FavoriteItemInfo>>(_context.FavoriteItemsTable.Where(x => x.UserId == id));
        }

        [HttpGet("FindFavoriteById")]
        public FavoriteItemInfo Get(int id)
        {
            return _mapper.Map<FavoriteItemInfo>(_favoriteItems.FindById<FavoriteItem>(id));
        }

        [HttpPost("AddFavorites")]
        public void Add(FavoriteItemInfo item)
        {
            if(_context.FavoriteItemsTable.FirstOrDefault(x=>x.UserId == item.UserId && x.ItemId == item.ItemId) == null)
                _favoriteItems.Create(_mapper.Map<FavoriteItem>(item));
        }

        [HttpPost("RemoveFavoriteItem")]
        public void Remove(int id)
        {
            _favoriteItems.Remove<FavoriteItem>(_favoriteItems.FindById<FavoriteItem>(id));
        }
    }
}
