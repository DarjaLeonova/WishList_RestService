using WishList_RestService.Models;
using WishList_RestService.Services;

namespace WishList_Tests.Utils
{
    public class WishServiceFake : IWishService
    {
        private readonly List<Wish> _wishList;
        public WishServiceFake()
        {
            _wishList = new List<Wish>()
            {
                new Wish() {Id = 1, Name = "Cookie", Description = "Buy Cookies"},
                new Wish() {Id = 2, Name = "Candy", Description = "Eat candies"},
                new Wish() {Id = 3, Name = "Pizza", Description = "Make pizza"},
                new Wish() {Id = 4, Name = "Pasta Carbonara", Description = "Fly to Italy and eat carbonara"},
                new Wish() {Id = 5, Name = "Dog", Description = "Pet Stormy"}
            };
        }
        public Wish AddWish(Wish wish)
        {
             _wishList.Add(wish);
            return wish;
        }

        public string DeleteAllWishes()
        {
            _wishList.Clear();
            return "All wishes deleted";
        }

        public Wish DeleteWishById(int id)
        {
            var wish = GetWishById(id);
            _wishList.Remove(wish);
            return wish;
        }

        public Wish GetWishById(int id)
        {
            return _wishList.Where(a => a.Id == id).FirstOrDefault();
        }

        public List<Wish> GetWishes()
        {
            return _wishList; 
        }

        public Wish UpdateWish(Wish wish, int id)
        {
            var updatedWish = GetWishById(id);
            updatedWish.Name = wish.Name;
            updatedWish.Description = wish.Description;
            return updatedWish;  
        }
    }
}
