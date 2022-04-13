using Ambulance.DAL.CallAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ambulance.DAL.CallAPI
{
    public interface ICallContext
    {
        DbSet<CallEntity> Calls { get; set; }
    }

    public class CallContext : DbContext, ICallContext
    {
        public DbSet<CallEntity> Calls { get; set; }

        public CallContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
