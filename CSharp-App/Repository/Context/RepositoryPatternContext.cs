using CSharp_App.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp_App.Repository.Context
{
    public class RepositoryPatternContext : DbContext
    {

        public DbSet<ProductModel> Products { get; set; }

        public RepositoryPatternContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
