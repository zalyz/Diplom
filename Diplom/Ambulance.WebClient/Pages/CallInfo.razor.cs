using Ambulance.CallApi.Client;
using Ambulance.Domain.Models;
using Ambulance.Domain.Models.Call;
using Ambulance.Domain.Models.Enums;
using Ambulance.Domain.Models.ServiceModels;
using Ambulance.ServiceAPI.Client;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ambulance.WebClient.Pages
{
    public partial class CallInfo
    {
        [Inject]
        private ICallApiClient CallApiClient { get; set; }

        [Inject]
        private IServiceApiClient ServiceApiClient { get; set; }

        [Parameter]
        public CallStatus CallStatus { get; set; } = CallStatus.Processed;

        private CallFilerModel model = new();

        private List<CallFullOfficeInfo> FilteredCalls { get; set; } = new();

        private List<Street> Streets = new();
        private List<Diagnosis> Diagnosiss = new();
        private List<Result> Results = new();
        private int pagenumber = 1;
        private int numberOfElements = 10;

        private bool isShowNext = true;
        private bool isShowPrev = false;

        protected override async Task OnInitializedAsync()
        {
            Streets = await ServiceApiClient.ServiceResource.GetStreets();
            Diagnosiss = await ServiceApiClient.ServiceResource.GetDiagnosis();
            Results = await ServiceApiClient.ServiceResource.GetResults();
        }

        private async Task OnSeackClick()
        {
            pagenumber = 1;
            isShowPrev = false;
            isShowNext = true;
            await MakeRequest();
        }

        private async Task OnNextClick()
        {
            pagenumber++;
            await MakeRequest();
            if (!FilteredCalls.Any())
            {
                isShowNext = false;
                isShowPrev = true;
            }
        }

        private async Task OnPrevClick()
        {
            if (pagenumber > 1)
            {
                pagenumber--;
                isShowNext = true;

                if (pagenumber == 1)
                {
                    isShowPrev = false;
                }

            }

            await MakeRequest();
        }

        private async Task MakeRequest()
        {
            var result = await CallApiClient.CallOperations.FilterCall(new FilterRequest
            {
                CallNumber = model.CallNumber,
                FIO = model.FIO,
                Street = model.Street,
                HouseNumber = model.HouseNumber,
                FlatNumber = model.FlatNumber,
                Diagnosis = model.Diagnosis,
                Result = model.Result,
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                NumberOfElementsOnPage = numberOfElements,
                PageNumber = pagenumber,
                CallStatus = CallStatus,
            });

            FilteredCalls = result;
        }
    }

    class CallFilerModel
    {
        public int? CallNumber { get; set; }

        public string FIO { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string FlatNumber { get; set; }

        public string Diagnosis { get; set; }

        public string Result { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public int? PageNumber { get; set; }
    }
}