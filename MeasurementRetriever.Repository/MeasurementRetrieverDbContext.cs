using MeasurementRetriever.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeasurementRetriever.Repository
{
    public class MeasurementRetrieverDbContext : DbContext
    {
        public MeasurementRetrieverDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<DatasetInfo> DatasetInfo { get; set; }
        public DbSet<AgregatedMeasurment> AgregatedMeasurments { get; set; }
    
        public DbSet<Region> Regions { get; set; }
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatasetInfo>().HasKey(x => x.Id);
            modelBuilder.Entity<DatasetInfo>().Property(x => x.Url).HasMaxLength(500);

      


            modelBuilder.Entity<Region>().HasKey(x => x.RegionId);
            modelBuilder.Entity<Region>().Property(x => x.RegionName).HasMaxLength(300);
            modelBuilder.Entity<Region>().HasIndex(x => x.RegionName);





            modelBuilder.Entity<AgregatedMeasurment>().HasKey(x => x.MeasurmentId);
   
            modelBuilder.Entity<AgregatedMeasurment>().HasOne(x => x.Region).WithMany();
            modelBuilder.Entity<AgregatedMeasurment>().Property(x => x.PPlus);
            base.OnModelCreating(modelBuilder);

        }
    }
}
