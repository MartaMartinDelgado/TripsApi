using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TripsApi.Models
{
    public class TripsContext : DbContext
    {
        public TripsContext(DbContextOptions<TripsContext> options)
            : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }
    }
}
