using Ambulance.DAL.CallAPI;
using Ambulance.DAL.CallAPI.Models;
using Ambulance.Domain.Models.Enums;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallAPI.Call
{
    public class ProcessCallHandler : IRequestHandler<ProcessCallCommand, Guid>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public ProcessCallHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<Guid> Handle(ProcessCallCommand request, CancellationToken cancellationToken)
        {
            var callEntity = await _databaseProvider.InDatabaseScope(context => context.Calls.FirstAsync(e => e.Id == request.Request.Id), cancellationToken);
            callEntity.PatientId = request.Request.PatientId;
            callEntity.ResultId = request.Request.ResultId;
            callEntity.DiagnosisId = request.Request.DiagnosisId;
            callEntity.DateTimeReception = request.Request.DateTimeReception;
            callEntity.TransferDateTime = request.Request.TransferDateTime;
            callEntity.ArrivalDateTime = request.Request.ArrivalDateTime;
            callEntity.DepartureDateTime = request.Request.DepartureDateTime;
            callEntity.ComeBackDateTime = request.Request.ComeBackDateTime;
            callEntity.ProcessingDispatcherid = request.Request.ProcessingDispatcherid;
            callEntity.KilometrageBefore = request.Request.KilometrageBefore;
            callEntity.KilometrageAfter = request.Request.KilometrageAfter;
            callEntity.PlaceId = request.Request.PlaceId;
            callEntity.Status = (byte)CallStatus.Processed;

            await _databaseProvider.InDatabaseScope(context => context.Calls.Update(callEntity), cancellationToken);
            await _databaseProvider.InDatabaseScope(context => context.Treatments.AddRangeAsync(request.Request.Treatment.Select(e =>
            {
                return new TreatmentEntity
                {
                    CallId = request.Request.Id,
                    DrugId = e.Id,
                };
            })), cancellationToken);

            return Guid.NewGuid();
        }
    }
}
