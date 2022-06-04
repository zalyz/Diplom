using Ambulance.DAL.CallAPI;
using Ambulance.Domain.Models.Statistics;
using MediatR;
using OfficeOpenXml.Table.PivotTable;
using StatisticsAPI.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StatisticsAPI.Calls
{
    public class DiagnosisGenderHandler : IRequestHandler<DiagnosisGenderQuery, byte[]>
    {
        private readonly IExcelService _excelService;

        public DiagnosisGenderHandler(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public async Task<byte[]> Handle(DiagnosisGenderQuery request, CancellationToken cancellationToken)
        {
            var (package, range) = await _excelService.CreateDataAndGetCallsRange("DiagnosisGender.xlsx");

            var pivot = package.Workbook.Worksheets.Add("PivotTable");
            var pTable = pivot.PivotTables.Add(pivot.Cells["A1"], range, "Болезни по полу");

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

            pTable.RowFields.Add(pTable.Fields["DiagnosisName"]);
            pTable.RowFields.Add(pTable.Fields["Age"]);
            pTable.ColumnFields.Add(pTable.Fields["Gender"]);
            pTable.DataFields.Add(pTable.Fields["CallNumber"]).Function = DataFieldFunctions.Count;

            return package.GetAsByteArray();
        }
    }
}
