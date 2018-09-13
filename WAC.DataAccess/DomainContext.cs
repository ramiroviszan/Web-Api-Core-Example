using System;
using Microsoft.EntityFrameworkCore;
using WAC.Domain.Users;

namespace WAC.DataAccess
{
    public class DomainContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
     
            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
        } 
    }
}
