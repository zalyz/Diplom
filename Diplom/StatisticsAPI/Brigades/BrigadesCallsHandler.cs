using Ambulance.DAL.CallAPI;
using MediatR;
using OfficeOpenXml.Table.PivotTable;
using System;
using System.Threading;
using System.Threading.Tasks;
using StatisticsAPI.Services;

namespace StatisticsAPI.Brigades
{
    public class BrigadesCallsHandler : IRequestHandler<BrigadesCallsRequest, byte[]>
    {
        private readonly IExcelService _excelService;

        public BrigadesCallsHandler(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public async Task<byte[]> Handle(BrigadesCallsRequest request, CancellationToken cancellationToken)
        {
            var (package, range) = await _excelService.CreateDataAndGetCallsRange("BrigadesCalls.xlsx");

            var pivot = package.Workbook.Worksheets.Add("PivotTable");
            var pTable = pivot.PivotTables.Add(pivot.Cells["A1"], range, "Бригады и вызова");

            pTable.RowFields.Add(pTable.Fields["BrigadeNumber"]);
            pTable.RowFields.Add(pTable.Fields["FIO"]);
            pTable.RowFields.Add(pTable.Fields["Street"]);
            pTable.ColumnFields.Add(pTable.Fields["DoktorFIO"]);
            pTable.ColumnFields.Add(pTable.Fields["CallNumber"]);
            pTable.DataFields.Add(pTable.Fields["CallNumber"]).Function = DataFieldFunctions.Count;

            return package.GetAsByteArray();
        }
    }
}
