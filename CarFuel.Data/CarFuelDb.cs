﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using System.Data.Entity;
using CarFuel.Models;

namespace CarFuel.Data {
  public class CarFuelDb : DbContext {

    public DbSet<Car> Cars { get; set; }
    
  }
}
