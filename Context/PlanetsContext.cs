using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using planets_api.Entities;

namespace planets_api.Context
{
    public class PlanetsContext : DbContext
    {
        public PlanetsContext(DbContextOptions<PlanetsContext> options) : base(options)
        {

        }

        public DbSet<Planets> PlanetsDb { get; set; }
    }

}