using Ambulance.Domain.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Ambulance.WebClient.Pages
{
    public partial class CallDisplay
    {
        [Parameter]
        public List<CallFullOfficeInfo> Calls { get; set; }
    }
}