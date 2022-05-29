using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Ambulance.CallApi.Client;
using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Call;

namespace Ambulance.Web.Pages
{
    public partial class FillCallAdditionalInfo
    {
        [Inject]
        private ICallApiClient CallApiClient { get; set; }

        DisplayCallModel model = new();

        AdditionalInfoRequest request = new();

        private CallOfficeInfo Call { get; set; }

        async Task OnSeackClick()
        {
            var call = await CallApiClient.CallOperations.GetCall(model.CallNumber);
            Call = call;
        }

        async Task OnSaveDataClick()
        {
            request.CallId = model.CallNumber;
            await CallApiClient.CallOperations.AddAdditionalInfo(request);
            request = new();
            model = new();
        }
    }

    class DisplayCallModel
    {
        public int CallNumber { get; set; }
    }
}