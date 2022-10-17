using WishList_RestService.Data;
using WishList_RestService.Models;

namespace WishList_RestService.Services.Impl
{
    public class WishService : IWishService
    {

        private readonly ApplicationDbContext _db;
        public WishService(ApplicationDbContext db)
        {
            _db = db;
        }
        public Wish AddWish(Wish wish)
        {
            _db.WishList.Add(wish);
            _db.SaveChanges();
            return wish;
        }

        public string DeleteAllWishes()
        {
            _db.WishList.RemoveRange(_db.WishList);
            _db.SaveChanges();
            return "Wish list successfully deleted";
        }

        public Wish DeleteWishById(int id)
        {
            var wish = GetWishById(id);
            _db.WishList.Remove(wish);
            _db.SaveChanges();
            return wish;
        }

        public Wish GetWishById(int id)
        {

            var wish = _db.WishList.Where(a => a.WishId == id).FirstOrDefault();
            return wish;
        }

        public List<Wish> GetWishes()
        {
            return _db.WishList.ToList();
        }

        public Wish UpdateWish(Wish wish, int id)
        {
            var entity = _db.WishList.Find(id);
            if (entity == null)
            {
                return null;
            }
            entity.Name = wish.Name;
            entity.Description = wish.Description;
            _db.WishList.Update(entity);
            _db.SaveChanges();
            return wish;
        }
    }
}
