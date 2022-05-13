using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ambulance.DAL.CallAPI
{
    public interface IDatabaseProvider
    {
        Task<T> InDatabaseScopeValue<T>(Func<ICallContext, ValueTask<T>> action, CancellationToken cancellationToken = default);

        Task<T> InDatabaseScope<T>(Func<ICallContext, Task<T>> action, CancellationToken cancellationToken = default);

        Task<T> InDatabaseScope<T>(Func<ICallContext, T> action, CancellationToken cancellationToken = default);
    }

    public class DatabaseProvider : IDatabaseProvider
    {
        private readonly ICallContext _callContext;

        public DatabaseProvider(ICallContext callContext)
        {
            _callContext = callContext;
        }

        public async Task<T> InDatabaseScopeValue<T>(Func<ICallContext, ValueTask<T>> action, CancellationToken cancellationToken)
        {
            try
            {
                await _callContext.DatabaseInstance.BeginTransactionAsync(cancellationToken);
                var result = await action(_callContext);
                await _callContext.SaveMyChangesAsync();
                await _callContext.DatabaseInstance.CommitTransactionAsync(cancellationToken);
                return result;
            }
            catch
            {
                await _callContext.DatabaseInstance.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }

        public async Task<T> InDatabaseScope<T>(Func<ICallContext, Task<T>> action, CancellationToken cancellationToken)
        {
            try
            {
                await _callContext.DatabaseInstance.BeginTransactionAsync(cancellationToken);
                var result = await action(_callContext);
                await _callContext.SaveMyChangesAsync();
                await _callContext.DatabaseInstance.CommitTransactionAsync(cancellationToken);
                return result;
            }
            catch
            {
                await _callContext.DatabaseInstance.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }

        public async Task<T> InDatabaseScope<T>(Func<ICallContext, T> action, CancellationToken cancellationToken)
        {
            try
            {
                await _callContext.DatabaseInstance.BeginTransactionAsync(cancellationToken);
                var result = action(_callContext);
                await _callContext.SaveMyChangesAsync();
                await _callContext.DatabaseInstance.CommitTransactionAsync(cancellationToken);
                return result;
            }
            catch
            {
                await _callContext.DatabaseInstance.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }
    }
}
