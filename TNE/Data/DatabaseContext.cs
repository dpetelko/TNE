﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using TNE.Models;

namespace TNE.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<LeadDivision> LeadDivisions { get; set; }
        public DbSet<SubDivision> SubDivisions { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<BillingPoint> BillingPoints { get; set; }
        public DbSet<ControlPoint> ControlPoints { get; set; }
        public DbSet<DeliveryPoint> DeliveryPoints { get; set; }
        public DbSet<ElectricityMeter> ElectricityMeters { get; set; }
        public DbSet<CurrentTransformer> CurrentTransformers { get; set; }
        public DbSet<VoltageTransformer> VoltageTransformers { get; set; }
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeadDivision>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Entity<SubDivision>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Entity<Provider>()
                .HasIndex(b => b.Name)
                .IsUnique();

            var converter = new EnumToNumberConverter<Status, int>();

            modelBuilder
                .Entity<Device>()
                .Property(e => e.Status)
                .HasConversion(converter);
        }
    }
}
