using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambulance.DAL.CallAPI
{
    public interface IDatabaseProvider
    {
        Task<T> InDatabaseScope<T>(Func<ICallContext, ValueTask<T>> action);
    }

    public class DatabaseProvider : IDatabaseProvider
    {
        private readonly CallContext _callContext;

        public DatabaseProvider(CallContext callContext)
        {
            _callContext = callContext;
        }

        public async Task<T> InDatabaseScope<T>(Func<ICallContext, ValueTask<T>> action)
        {
            await _callContext.Database.BeginTransactionAsync();
            var result = await action(_callContext);
            _callContext.SaveChanges();
            await _callContext.Database.CommitTransactionAsync();
            return result;
        }

        public async Task InDatabaseScope<T>(Func<ICallContext, Task<T>> action)
        {
            await _callContext.Database.BeginTransactionAsync();
            await action(_callContext);
            _callContext.SaveChanges();
            await _callContext.Database.CommitTransactionAsync();
        }
    }
}
