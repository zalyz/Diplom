using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models.Statistics;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Ambulance.Domain.Models.Enums;
using Mapster;

namespace StatisticsAPI.Services
{
    public interface IExcelService
    {
        Task<(ExcelPackage package, ExcelRangeBase range)> CreateDataAndGetCallsRange(string fileName);

        List<CallFullInfo> GetCalls();
    }

    public class ExcelService : IExcelService
    {
        private readonly IDatabaseProvider _databaseProvider;

        public ExcelService(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public async Task<(ExcelPackage package, ExcelRangeBase range)> CreateDataAndGetCallsRange(string fileName)
        {
            var calls = GetCalls();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(fileName);

            var package = new ExcelPackage(file);
            var callsInfoPage = package.Workbook.Worksheets.Add("CallsInfo");
            var range = callsInfoPage.Cells["A1"].LoadFromCollection(calls, true);
            range.AutoFitColumns();

            return new (package, range);
        }

        public List<CallFullInfo> GetCalls()
        {
            var resultSet = _databaseProvider.Read(context =>
            {
                return from call in context.Calls
                       join additional in context.CallAdditionalInfo on call.Id equals additional.CallId
                       join patient in context.Patients on call.PatientId equals patient.Id
                       join street in context.Streets on patient.StreetId equals street.Id
                       join dispatcher in context.Dispatchers on call.DispatcherId equals dispatcher.Id
                       join tDispatcher in context.Dispatchers on call.TransferingDispatcherId equals tDispatcher.Id
                       join pDispatcher in context.Dispatchers on call.ProcessingDispatcherid equals pDispatcher.Id
                       join diagnosis in context.Diagnoses on call.DiagnosisId equals diagnosis.Id
                       join brigade in context.AmbulanceBrigades on call.AmbulanceBrigadeId.Value equals brigade.Id
                       join doctor in context.Doktors on brigade.DoktorId equals doctor.Id
                       join firstMed in context.MedicalAssistants on brigade.FirstMedicalAssistantId equals firstMed.Id
                       join orderly in context.Orderlies on brigade.OrderlyId equals orderly.Id
                       join driver in context.Drivers on brigade.DriverId equals driver.Id
                       join result in context.Results on call.ResultId equals result.Id
                       join caller in context.Callers on call.CallerId equals caller.Id
                       join place in context.Places on call.PlaceId equals place.Id
                       where call.Status == (byte)CallStatus.Processed
                       select new
                       {
                           call,
                           additional,
                           patient,
                           street,
                           dispatcher,
                           tDispatcher,
                           pDispatcher,
                           diagnosis,
                           brigade,
                           doctor,
                           firstMed,
                           orderly,
                           driver,
                           result,
                           caller,
                           place,
                       };
            });

            var calls = new List<CallFullInfo>();
            foreach (var item in resultSet)
            {
                var call = item.additional.Adapt<CallFullInfo>();
                ////if (item.brigade.SecondMedicalAssistantId != null && item.brigade.SecondMedicalAssistantId > 0)
                ////{
                ////    var secondMed = await _databaseProvider.InDatabaseScope(context => context.MedicalAssistants.FirstAsync(e => e.Id == item.brigade.SecondMedicalAssistantId.Value));
                ////    call.SecondMedicalAssistantFIO = GetFIO(secondMed);
                ////}
                call.CallNumber = item.call.CallNumber;
                call.DateTimeReception = item.call.DateTimeReception;
                call.TransferDateTime = item.call.TransferDateTime;
                call.ArrivalDateTime = item.call.ArrivalDateTime;
                call.DepartureDateTime = item.call.DepartureDateTime;
                call.ComeBackDateTime = item.call.ComeBackDateTime;
                call.KilometrageBefor = item.call.KilometrageBefore;
                call.KilometrageAfter = item.call.KilometrageAfter;
                call.CallNotes = item.call.CallNotes;
                call.Type = ((CallType)item.call.CallType).ToString();
                call.FIO = item.patient.FIO;
                call.Age = item.patient.Age;
                call.Street = item.street.Name;
                call.HouseNumber = item.patient.HouseNumber;
                call.FlatNumber = item.patient.FlatNumber;
                call.Gender = (Gender)item.patient.Gender;
                call.DoktorFIO = GetFIO(item.doctor);
                call.FirstMedicalAssistantFIO = GetFIO(item.firstMed);
                call.OrderlyFIO = GetFIO(item.orderly);
                call.DriverFIO = GetFIO(item.driver);
                call.BrigadeNumber = item.brigade.Number;
                call.Dispatcher = GetFIO(item.dispatcher);
                call.TransferingDispatcher = GetFIO(item.tDispatcher);
                call.ProcessingDispatcher = GetFIO(item.pDispatcher);
                call.Dispatcher = GetFIO(item.dispatcher);
                call.DiagnosisName = item.diagnosis.Name;
                call.ResultName = item.result.Name;
                call.CallerName = item.caller.Name;
                call.PlaceName = item.place.Name;

                calls.Add(call);
            }

            return calls;
        }

        private static string GetFIO(Ambulance.DAL.CallAPI.Models.EmployeeBase employee)
        {
            return $"{employee.Surname} {employee.Name[0]}.{employee.MiddleName[0]}.";
        }
    }
}
