using WishList_RestService.Models;
using WishList_RestService.Services;

namespace WishList_RestService.Validation.Impl
{
    public class WishValidator : IWishValidator
    {
        private IWishService _service;

        public WishValidator(IWishService service)
        {
            _service = service;
        }
        public bool IsInvalidId(int id)
        {
            if(_service.GetWishById(id) == null)
            {
                return true;
            }
            return false;
        }

        public bool AlreadyExist(Wish wish)
        {
            var list = _service.GetWishes();

            foreach(var item in list)
            {
                if(item.Name == wish.Name 
                    || item.WishId == wish.WishId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasEmptyValue(Wish wish)
        {
            if(wish.Name == "" || 
               wish.Description == "")
            {
                return true;
            }
            return false;
        }
    }
}
