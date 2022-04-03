using Ambulance.DAL.CallAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Ambulance.DAL.CallAPI
{
    public class CallContext : DbContext
    {
        public DbSet<CallEntity> Calls { get; set; }

        public CallContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
