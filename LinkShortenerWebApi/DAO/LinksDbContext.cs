using LinkShortenerWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkShortenerWebApi.DAO
{
    public class LinksDbContext : DbContext
    {
        public LinksDbContext(DbContextOptions<LinksDbContext> options) : base(options)
        {
        }

        public DbSet<Link> Links {get; set;}
    }
}