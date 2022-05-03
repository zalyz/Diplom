using Ambulance.DAL.CallAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ambulance.DAL.CallAPI
{
    public interface ICallContext
    {
        public DbSet<AmbulanceBrigadeEntity> AmbulanceBrigades { get; set; }

        public DbSet<CallEntity> Calls { get; set; }

        public DbSet<CallerEntity> Callers { get; set; }

        public DbSet<DiagnosisEntity> Diagnoses { get; set; }

        public DbSet<DispatcherEntity> Dispatchers { get; set; }

        public DbSet<DoktorEntity> Doktors { get; set; }

        public DbSet<DriverEntity> Drivers { get; set; }

        public DbSet<MedicalAssistantEntity> MedicalAssistants { get; set; }

        public DbSet<MedicamentEntity> Medicaments { get; set; }

        public DbSet<OrderlyEntity> Orderlies { get; set; }

        public DbSet<PatientEntity> Patients { get; set; }

        public DbSet<PlaceEntity> Places { get; set; }

        public DbSet<ResultEntity> Results { get; set; }

        public DbSet<TreatmentEntity> Treatments { get; set; }
    }

    public class CallContext : DbContext, ICallContext
    {
        public DbSet<AmbulanceBrigadeEntity> AmbulanceBrigades { get; set; }

        public DbSet<CallEntity> Calls { get; set; }

        public DbSet<CallerEntity> Callers { get; set; }

        public DbSet<DiagnosisEntity> Diagnoses { get; set; }

        public DbSet<DispatcherEntity> Dispatchers { get; set; }

        public DbSet<DoktorEntity> Doktors { get; set; }

        public DbSet<DriverEntity> Drivers { get; set; }

        public DbSet<MedicalAssistantEntity> MedicalAssistants { get; set; }

        public DbSet<MedicamentEntity> Medicaments { get; set; }

        public DbSet<OrderlyEntity> Orderlies { get; set; }

        public DbSet<PatientEntity> Patients { get; set; }

        public DbSet<PlaceEntity> Places { get; set; }

        public DbSet<ResultEntity> Results { get; set; }

        public DbSet<TreatmentEntity> Treatments { get; set; }

        public CallContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
