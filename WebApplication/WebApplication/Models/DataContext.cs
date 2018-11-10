using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace WebApplication.Models

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}