using Microsoft.AspNetCore.Mvc;
using WishList_RestService.Models;
using WishList_RestService.Services;
using WishList_RestService.Validation;

namespace WishList_RestService.Controllers
{
    [Route("wish-api")]
    [ApiController]
    public class WishListController : Controller
    {
        private IWishService _service;
        private IWishValidator _validator;

        public WishListController(IWishService wishService, IWishValidator validator)
        {
            _service = wishService;
            _validator = validator;
        }

        [Route("wishes")]
        [HttpGet]
        public IActionResult GetWishes()
        {
            return Ok(_service.GetWishes());
        }

        [Route("wish/{id}")]
        [HttpGet]
        public IActionResult GetWishById(int id)
        {
            if(_validator.IsInvalidId(id))
            {
                return NoContent();
            }
            return Ok(_service.GetWishById(id));
        }

        [Route("wish")]
        [HttpPost]
        public IActionResult AddWish(Wish wish)
        {
            if(!ModelState.IsValid 
                || _validator.AlreadyExist(wish))
            {
                return BadRequest(ModelState);  
            }
            return Created("", _service.AddWish(wish));
        }

        [Route("wish/{id}")]
        [HttpPut]
        public IActionResult UpdateWish(Wish wish, int id)
        {
            if(_validator.HasEmptyValue(wish) 
                || _validator.IsInvalidId(id))
            {
                return BadRequest();
            }
            return Ok(_service.UpdateWish(wish, id));
        }

        [Route("wish/clear/{id}")]
        [HttpDelete]
        public IActionResult DeleteWish(int id)
        {
            if (_validator.IsInvalidId(id))
            {
                return BadRequest();
            }
            return Ok(_service.DeleteWishById(id));
        }

        [Route("clear")]
        [HttpDelete]
        public IActionResult DeleteWishes()
        {
            return Ok(_service.DeleteAllWishes());
        }
    }
}
