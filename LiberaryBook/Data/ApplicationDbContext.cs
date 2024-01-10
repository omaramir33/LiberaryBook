

using LiberaryBook.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace LiberaryBook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Record> Records { get; set; }
    }
}
