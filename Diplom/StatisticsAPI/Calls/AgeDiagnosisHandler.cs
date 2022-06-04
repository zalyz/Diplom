using Ambulance.DAL.CallAPI;
using MediatR;
using OfficeOpenXml.Table.PivotTable;
using StatisticsAPI.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StatisticsAPI.Calls
{
    public class AgeDiagnosisHandler : IRequestHandler<AgeDiagnosisRequest, byte[]>
    {
        private readonly IExcelService _excelService;

        public AgeDiagnosisHandler(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public async Task<byte[]> Handle(AgeDiagnosisRequest request, CancellationToken cancellationToken)
        {
            var (package, range) = await _excelService.CreateDataAndGetCallsRange("AgeDiagnosis.xlsx");

            var pivot = package.Workbook.Worksheets.Add("PivotTable");
            var pTable = pivot.PivotTables.Add(pivot.Cells["A1"], range, "Болезни по возрасту");

            var names = new string[]
            {
                "DateTimeReception",
                "TransferDateTime",
                "ArrivalDateTime",
                "DepartureDateTime",
                "ComeBackDateTime",
            };

            var dates = pTable.ColumnFields.Where(e => names.Contains(e.Name)).ToList();
            dates.ForEach(e => e.Format = "yyy-mm-dd h:mm tt");

            pTable.RowFields.Add(pTable.Fields["Age"]);
            pTable.RowFields.Add(pTable.Fields["FIO"]);
            pTable.ColumnFields.Add(pTable.Fields["Gender"]);
            pTable.ColumnFields.Add(pTable.Fields["DiagnosisName"]);
            pTable.DataFields.Add(pTable.Fields["CallNumber"]).Function = DataFieldFunctions.Count;

            return package.GetAsByteArray();
        }
    }
}
