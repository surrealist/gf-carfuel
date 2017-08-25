using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using System.Data.Entity;
using CarFuel.Models;

namespace CarFuel.Data {
  public class CarFuelDb : DbContext {

    public DbSet<Car> Cars { get; set; }
    public DbSet<TodoItem> TodoItems { get; set; }


    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder
        .Entity<Car>()
        .Property(t => t.Model)
        .HasColumnAnnotation("AuthorName", "Suthep S");
    }
  }
}
