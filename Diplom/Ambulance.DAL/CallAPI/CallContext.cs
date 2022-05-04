using Ambulance.DAL.CallAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading.Tasks;

namespace Ambulance.DAL.CallAPI
{
    public interface ICallContext
    {
        DbSet<AmbulanceBrigadeEntity> AmbulanceBrigades { get; set; }

        DbSet<CallEntity> Calls { get; set; }

        DbSet<CallerEntity> Callers { get; set; }

        DbSet<DiagnosisEntity> Diagnoses { get; set; }

        DbSet<DispatcherEntity> Dispatchers { get; set; }

        DbSet<DoktorEntity> Doktors { get; set; }

        DbSet<DriverEntity> Drivers { get; set; }

        DbSet<MedicalAssistantEntity> MedicalAssistants { get; set; }

        DbSet<MedicamentEntity> Medicaments { get; set; }

        DbSet<OrderlyEntity> Orderlies { get; set; }

        DbSet<PatientEntity> Patients { get; set; }

        DbSet<StreetEntity> Streets { get; set; }

        DbSet<PlaceEntity> Places { get; set; }

        DbSet<ResultEntity> Results { get; set; }

        DbSet<TreatmentEntity> Treatments { get; set; }

        DatabaseFacade DatabaseInstance { get; }

        Task<int> SaveMyChangesAsync();
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

        public DbSet<StreetEntity> Streets { get; set; }

        public DbSet<PlaceEntity> Places { get; set; }

        public DbSet<ResultEntity> Results { get; set; }

        public DbSet<TreatmentEntity> Treatments { get; set; }

        public DatabaseFacade DatabaseInstance => Database;

        public Task<int> SaveMyChangesAsync() => SaveChangesAsync();

        public CallContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
