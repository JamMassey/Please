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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.HasIndex(e => e.Key)
                    .HasName("Key")
                    .IsUnique();                  

                entity.Property(e => e.UserName).HasColumnName("UserName")                   
                    .IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("Password");                                     //Clean up and add ensure created!!

            });

            modelBuilder.Entity<User>().HasData
            (

                new User() { Key = 1, UserName = "Customer1@email1.com", Password = "Password123!" },
                new User() { Key = 2, UserName = "Customer1@email2.com", Password = "Password123!" },
                new User() { Key = 3, UserName = "Customer1@email3.com", Password = "Password123!" },
                new User() { Key = 4, UserName = "Customer1@email4.com", Password = "Password123!" },
                new User() { Key = 5, UserName = "Customer1@email5.com", Password = "Password123!" },
                new User() { Key = 6, UserName = "Member1@email.com", Password = "Password123!" }


            );
        }
    }

}