using Ambulance.Domain.Models.Statistics;
using Ambulance.StatisticsApi.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Ambulance.WebClient.Pages
{
    public partial class BrigadeCallsChart
    {
        [Inject]
        public IStatisticsApiClient StatisticsApiClient { get; set; }

        [Inject]
        public IJSRuntime JS { get; set; }

        public List<CallFullInfo> Calls { get; set; }

        private bool isLoad = true;

        protected override async Task OnInitializedAsync()
        {
            Calls = await StatisticsApiClient.CallResource.GetCalls();
            isLoad = false;
        }

        private async Task DownloadFile()
        {
            var bytes = await StatisticsApiClient.BrigadeResource.GetBrigadeCalls();
            await JS.InvokeVoidAsync("downloadFromByteArray", new
            {
                ByteArray = bytes,
                FileName = "ВызоваБригад.xlsx",
                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            });
        }
    }
}