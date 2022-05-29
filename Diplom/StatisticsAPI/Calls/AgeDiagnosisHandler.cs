using Ambulance.DAL.CallAPI;
using MediatR;
using OfficeOpenXml.Table.PivotTable;
using StatisticsAPI.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StatisticsAPI.Calls
{
    public class AgeDiagnosisHandler : IRequestHandler<AgeDiagnosisRequest, Guid>
    {
        private readonly IDatabaseProvider _databaseProvider;
        private readonly IExcelService _excelService;

        public AgeDiagnosisHandler(IDatabaseProvider databaseProvider, IExcelService excelService)
        {
            _databaseProvider = databaseProvider;
            _excelService = excelService;
        }

        public async Task<Guid> Handle(AgeDiagnosisRequest request, CancellationToken cancellationToken)
        {
            var (package, range) = await _excelService.CreateDataAndGetCallsRange("AgeDiagnosis.xlsx");

            var pivot = package.Workbook.Worksheets.Add("PivotTable");
            var pTable = pivot.PivotTables.Add(pivot.Cells["A1"], range, "Болезни по возрасту");

            pTable.RowFields.Add(pTable.Fields["Age"]);
            pTable.RowFields.Add(pTable.Fields["FIO"]);
            pTable.ColumnFields.Add(pTable.Fields["Gender"]);
            pTable.ColumnFields.Add(pTable.Fields["DiagnosisName"]);
            pTable.DataFields.Add(pTable.Fields["CallNumber"]).Function = DataFieldFunctions.Count;

            await package.SaveAsync();

            return Guid.NewGuid();
        }
    }
}
