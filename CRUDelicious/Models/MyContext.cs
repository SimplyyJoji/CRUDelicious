using System;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        // the "Monsters" table name will come from the DbSet variable name
        public DbSet<Dishes> Dishes { get; set; }

    internal Dishes FirstOrDefault(Func<object, bool> p)
    {
      throw new NotImplementedException();
    }
  }
}