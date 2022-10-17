using Microsoft.EntityFrameworkCore;
using WishList_RestService.Models;

namespace WishList_RestService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Wish> WishList { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }
    }
}
