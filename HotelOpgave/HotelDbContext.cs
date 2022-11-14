using HotelOpgave.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpgave
{
    public class HotelDbContext: DbContext
    {
        public HotelDbContext()
        {
        }
        public HotelDbContext(DbContextOptions<HotelDbContext> options)
            : base(options)
        {
        }
        public DbSet<Facility> Facilities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facility>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsFixedLength(true);
            });
        }
    }
}
