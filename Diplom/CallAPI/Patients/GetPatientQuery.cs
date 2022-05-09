using Ambulance.Domain;
using Ambulance.Domain.Models;
using MediatR;

namespace CallAPI.Patients
{
    public class GetPatientQuery : MessageBase<int>, IRequest<Patient>
    {
        public GetPatientQuery(int request)
            : base(request)
        {
        }
    }
}
