using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.DAL.CallAPI
{
    public interface IDatabaseProvider
    {
        Task<T> InDatabaseScope<T>(Func<ICallContext, ValueTask<T>> action, CancellationToken cancellationToken = default);

        Task<T> InDatabaseScope<T>(Func<ICallContext, Task<T>> action, CancellationToken cancellationToken = default);

        Task<T> InDatabaseScope<T>(Func<ICallContext, T> action, CancellationToken cancellationToken = default);
    }

    public class DatabaseProvider : IDatabaseProvider
    {
        private readonly CallContext _callContext;

        public DatabaseProvider(CallContext callContext)
        {
            _callContext = callContext;
        }

        public async Task<T> InDatabaseScope<T>(Func<ICallContext, ValueTask<T>> action, CancellationToken cancellationToken)
        {
            try
            {
                await _callContext.Database.BeginTransactionAsync(cancellationToken);
                var result = await action(_callContext);
                _callContext.SaveChanges();
                await _callContext.Database.CommitTransactionAsync(cancellationToken);
                return result;
            }
            catch
            {
                await _callContext.Database.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }

        public async Task<T> InDatabaseScope<T>(Func<ICallContext, Task<T>> action, CancellationToken cancellationToken)
        {
            try
            {
                await _callContext.Database.BeginTransactionAsync(cancellationToken);
                var result = await action(_callContext);
                _callContext.SaveChanges();
                await _callContext.Database.CommitTransactionAsync(cancellationToken);
                return result;
            }
            catch
            {
                await _callContext.Database.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }

        public async Task<T> InDatabaseScope<T>(Func<ICallContext, T> action, CancellationToken cancellationToken)
        {
            try
            {
                await _callContext.Database.BeginTransactionAsync(cancellationToken);
                var result = action(_callContext);
                _callContext.SaveChanges();
                await _callContext.Database.CommitTransactionAsync(cancellationToken);
                return result;
            }
            catch
            {
                await _callContext.Database.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }
    }
}
