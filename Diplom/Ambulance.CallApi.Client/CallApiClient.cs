using Ambulance.CallApi.Client.Resources.Brigades;
using Ambulance.CallApi.Client.Resources.Calls;
using Ambulance.CallApi.Client.Resources.Patients;

namespace Ambulance.CallApi.Client
{
    public interface ICallApiClient
    {
        ICallResource CallOperations { get; }

        IBrigadeResource BrigadeOperations { get; }

        IPatientResource PatientResource { get; }
    }

    public class CallApiClient : ICallApiClient
    {
        private readonly ResourceCreator _resourceCreator;

        public CallApiClient(string baseAddress, string tenant)
        {
            _resourceCreator = new ResourceCreator(baseAddress, tenant);
        }

        public ICallResource CallOperations => _resourceCreator.CreateResource<ICallEndpoint, CallResource>();

        public IBrigadeResource BrigadeOperations => _resourceCreator.CreateResource<IBrigadeEndpoint, BrigadeResource>();

        public IPatientResource PatientResource => _resourceCreator.CreateResource<IPatientEndpoint, PatientResource>();
    }
}
