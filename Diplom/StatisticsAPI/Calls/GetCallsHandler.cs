using Ambulance.Domain.Models.Statistics;
using MediatR;
using StatisticsAPI.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StatisticsAPI.Calls
{
    public class GetCallsHandler : IRequestHandler<GetCallsQuery, List<CallFullInfo>>
    {
        private readonly IExcelService _excelService;

        public GetCallsHandler(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public Task<List<CallFullInfo>> Handle(GetCallsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_excelService.GetCalls());
        }
    }
}
