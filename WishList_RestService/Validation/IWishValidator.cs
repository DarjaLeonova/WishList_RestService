using WishList_RestService.Models;

namespace WishList_RestService.Validation
{
    public interface IWishValidator
    {
        public bool IsInvalidId(int id);

        public bool AlreadyExist(Wish wish);

        public bool HasEmptyValue(Wish wish);  
    }
}
