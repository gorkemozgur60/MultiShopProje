using Microsoft.EntityFrameworkCore;
using MutliShop.Comment.Entites;

namespace MutliShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;initial Catalog=MultiShopCommentDb;User=sa;Password=Gorkem123.");
        }

        public DbSet<UserComment> UserComments { get; set; }
        
    }
}
