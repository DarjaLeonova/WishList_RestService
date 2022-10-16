using WishList_RestService.Models;

namespace WishList_RestService.Services
{
    public interface IWishService
    {
        public List<Wish> GetWishes();
        public Wish GetWishById(int id);
        public Wish AddWish(Wish wish);
        public Wish UpdateWish(Wish wish, int id);
        public Wish DeleteWishById(int id);
        public string DeleteAllWishes();
    }
}
