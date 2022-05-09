using Ambulance.Domain;
using Ambulance.Domain.Models.Patients;
using MediatR;
using System;

namespace CallAPI.Patients
{
    public class UpdatePatientQuery : MessageBase<UpdatePatienRequest>, IRequest<Guid>
    {
        public UpdatePatientQuery(UpdatePatienRequest request)
            : base(request)
        {
        }
    }
}
