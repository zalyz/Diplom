using System;
using System.Collections.Generic;
using Ambulance.Classes;
using Ambulance.Classes.Staff;
using Microsoft.EntityFrameworkCore;

namespace Ambulance.DBAccess
{
    class AmbulanceDBContext : DbContext
    {
        public AmbulanceDBContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Dispatcher> Dispatchers { get;  set; }

        public DbSet<Doktor> Doktors { get;  set; }

        public DbSet<MedicalAssistant> MedicalAssistants { get;  set; }

        public DbSet<Orderly> Orderlies { get;  set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Statistician> Statisticians { get; set; }

        public DbSet<ProcessedCall> ProcessedCalls { get;  set; }

        public DbSet<IncidentalCall> IncidentalCalls { get;  set; }

        public DbSet<ChronicPatient> ChronicPatients { get;  set; }

        public DbSet<Patient> Patients { get;  set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=AmbulanceDB; Trusted_Connection=True");
        }
    }
}
