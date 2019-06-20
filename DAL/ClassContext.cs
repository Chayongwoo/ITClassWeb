using ITClassWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ITClassWeb.DAL
{
    public class ClassContext : DbContext
    {
        public ClassContext() : base("ClassContext")
        {

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplySchedule> ApplySchedules { get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}