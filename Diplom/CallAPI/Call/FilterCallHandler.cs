using Ambulance.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Ambulance.DAL.CallAPI;
using Mapster;
using Ambulance.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace CallAPI.Call
{
    public class FilterCallHandler : IRequestHandler<FilterCallCommand, List<CallFullOfficeInfo>>
    {
        private readonly IDatabaseProvider _databaseProvider;

        public FilterCallHandler(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<List<CallFullOfficeInfo>> Handle(FilterCallCommand request, CancellationToken cancellationToken)
        {
            var calls = request.Request.CallStatus == CallStatus.TransferedToBrigade
                ? await GetTransferedCalls()
                : await GetProceccedCalls();

            if (request.Request.CallNumber.HasValue)
            {
                calls = calls.Where(e => e.CallNumber.ToString().Contains(request.Request.CallNumber.Value.ToString()));
            }

            if (!string.IsNullOrWhiteSpace(request.Request.FIO))
            {
                calls = calls.Where(e => e.FIO.ToUpper().Contains(request.Request.FIO.ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(request.Request.Street))
            {
                calls = calls.Where(e => e.Street.ToUpper().Contains(request.Request.Street.ToUpper()));
            }

            if (!string.IsNullOrEmpty(request.Request.HouseNumber))
            {
                calls = calls.Where(e => e.HouseNumber.ToUpper().Contains(request.Request.HouseNumber.ToUpper()));
            }

            if (!string.IsNullOrEmpty(request.Request.FlatNumber))
            {
                calls = calls.Where(e => e.FlatNumber.ToUpper().Contains(request.Request.FlatNumber.ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(request.Request.Diagnosis))
            {
                calls = calls.Where(e => e.DiagnosisName.ToUpper().Contains(request.Request.Diagnosis.ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(request.Request.Result))
            {
                var results = await _databaseProvider.InDatabaseScope(context => context.Results.AsQueryable(), cancellationToken);
                calls = from call in calls
                        join r in results on call.DiagnosisId equals r.Id
                        where r.Name.ToUpper().Contains(request.Request.Result.ToUpper())
                        select call;
            }

            if (request.Request.DateFrom.HasValue)
            {
                calls = calls.Where(e => e.DateTimeReception >= request.Request.DateFrom.Value);
            }

            if (request.Request.DateTo.HasValue)
            {
                calls = calls.Where(e => e.DateTimeReception <= request.Request.DateTo.Value);
            }

            if (request.Request.NumberOfElementsOnPage.HasValue && request.Request.PageNumber.HasValue)
            {
                var number = request.Request.NumberOfElementsOnPage.Value;
                var page = request.Request.PageNumber.Value;
                calls = calls.Skip(number * (page - 1)).Take(number);
            }

            return calls.ToList();
        }

        private async Task<IQueryable<CallFullOfficeInfo>> GetProceccedCalls()
        {
            var resultSet = await _databaseProvider.InDatabaseScope(context =>
            {
                return from call in context.Calls
                       join patient in context.Patients on call.PatientId equals patient.Id
                       join street in context.Streets on patient.StreetId equals street.Id
                       join diagnosis in context.Diagnoses on call.DiagnosisId equals diagnosis.Id
                       join brigade in context.AmbulanceBrigades on call.AmbulanceBrigadeId equals brigade.Id
                       join doctor in context.Doktors on brigade.DoktorId equals doctor.Id
                       join firstMed in context.MedicalAssistants on brigade.FirstMedicalAssistantId equals firstMed.Id
                       join orderly in context.Orderlies on brigade.OrderlyId equals orderly.Id
                       join driver in context.Drivers on brigade.DriverId equals driver.Id
                       join result in context.Results on call.ResultId equals result.Id
                       join dispatcher in context.Dispatchers on call.DispatcherId equals dispatcher.Id
                       join dispatcherSecond in context.Dispatchers on call.ProcessingDispatcherid equals dispatcherSecond.Id
                       join dispatcherThird in context.Dispatchers on call.TransferingDispatcherId equals dispatcherThird.Id
                       where call.Status == (byte)CallStatus.Processed
                       select new
                       {
                           call,
                           patient,
                           street,
                           diagnosis,
                           brigade,
                           doctor,
                           firstMed,
                           orderly,
                           driver,
                           result,
                           dispatcher,
                           dispatcherSecond,
                           dispatcherThird,
                       };
            });

            var calls = new List<CallFullOfficeInfo>();
            foreach (var item in resultSet)
            {
                var call = item.call.Adapt<CallFullOfficeInfo>();
                ////if (item.brigade.SecondMedicalAssistantId != null && item.brigade.SecondMedicalAssistantId > 0)
                ////{
                ////    var secondMed = await _databaseProvider.InDatabaseScope(context => context.MedicalAssistants.FirstAsync(e => e.Id == item.brigade.SecondMedicalAssistantId.Value));
                ////    call.SecondMedicalAssistantFIO = GetFIO(secondMed);
                ////}

                call.FIO = item.patient.FIO;
                call.Age = item.patient.Age;
                call.Street = item.street.Name;
                call.HouseNumber = item.patient.HouseNumber;
                call.FlatNumber = item.patient.FlatNumber;
                call.DoktorFIO = GetFIO(item.doctor);
                call.FirstMedicalAssistantFIO = GetFIO(item.firstMed);
                call.OrderlyFIO = GetFIO(item.orderly);
                call.DriverFIO = GetFIO(item.driver);
                call.BrigadeNumber = item.brigade.Number;
                call.DiagnosisName = item.diagnosis.Name;
                call.ResultName = item.result.Name;
                call.Dispatcher = GetFIO(item.dispatcher);
                call.ProcessingDispatcher = GetFIO(item.dispatcherSecond);
                call.TransferingDispatcher = GetFIO(item.dispatcherThird);
                call.Type = GetType(item.call.CallType);

                calls.Add(call);
            }

            return calls.AsQueryable();
        }

        private async Task<IQueryable<CallFullOfficeInfo>> GetTransferedCalls()
        {
            var resultSet = await _databaseProvider.InDatabaseScope(context =>
            {
                return from call in context.Calls
                       join patient in context.Patients on call.PatientId equals patient.Id
                       join street in context.Streets on patient.StreetId equals street.Id
                       join diagnosis in context.Diagnoses on call.DiagnosisId equals diagnosis.Id
                       join brigade in context.AmbulanceBrigades on call.AmbulanceBrigadeId equals brigade.Id
                       join doctor in context.Doktors on brigade.DoktorId equals doctor.Id
                       join firstMed in context.MedicalAssistants on brigade.FirstMedicalAssistantId equals firstMed.Id
                       join orderly in context.Orderlies on brigade.OrderlyId equals orderly.Id
                       join driver in context.Drivers on brigade.DriverId equals driver.Id
                       join dispatcher in context.Dispatchers on call.DispatcherId equals dispatcher.Id
                       join dispatcherThird in context.Dispatchers on call.TransferingDispatcherId equals dispatcherThird.Id
                       where call.Status == (byte)CallStatus.TransferedToBrigade
                       select new
                       {
                           call,
                           patient,
                           street,
                           diagnosis,
                           brigade,
                           doctor,
                           firstMed,
                           orderly,
                           driver,
                           dispatcher,
                           dispatcherThird,
                       };
            });

            var calls = new List<CallFullOfficeInfo>();
            foreach (var item in resultSet)
            {
                var call = item.call.Adapt<CallFullOfficeInfo>();
                ////if (item.brigade.SecondMedicalAssistantId != null && item.brigade.SecondMedicalAssistantId > 0)
                ////{
                ////    var secondMed = await _databaseProvider.InDatabaseScope(context => context.MedicalAssistants.FirstAsync(e => e.Id == item.brigade.SecondMedicalAssistantId.Value));
                ////    call.SecondMedicalAssistantFIO = GetFIO(secondMed);
                ////}

                call.FIO = item.patient.FIO;
                call.Age = item.patient.Age;
                call.Street = item.street.Name;
                call.HouseNumber = item.patient.HouseNumber;
                call.FlatNumber = item.patient.FlatNumber;
                call.DoktorFIO = GetFIO(item.doctor);
                call.FirstMedicalAssistantFIO = GetFIO(item.firstMed);
                call.OrderlyFIO = GetFIO(item.orderly);
                call.DriverFIO = GetFIO(item.driver);
                call.BrigadeNumber = item.brigade.Number;
                call.DiagnosisName = item.diagnosis.Name;
                call.Dispatcher = GetFIO(item.dispatcher);
                call.TransferingDispatcher = GetFIO(item.dispatcherThird);
                call.Type = GetType(item.call.CallType);

                calls.Add(call);
            }

            return calls.AsQueryable();
        }

        private static string GetFIO(Ambulance.DAL.CallAPI.Models.EmployeeBase employee)
        {
            return $"{employee.Surname} {employee.Name[0]}.{employee.MiddleName[0]}.";
        }

        private static string GetType(byte type)
        {
            var callType = (CallType)type;
            return callType.ToString();
        }
    }
}
