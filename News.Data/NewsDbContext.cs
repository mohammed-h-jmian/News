using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using News.Data.Models;

namespace News.Data
{
    public class NewsDbContext : IdentityDbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options)
            : base(options)
        {
        }
        public DbSet<News.Data.Models.News> News { get; set; }
        public DbSet<Classification> Classifications { get; set; }
    }
}