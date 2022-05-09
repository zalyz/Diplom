using Ambulance.ServiceAPI.Client.Resources;
using RestEase;
using System;
using System.Net.Http;

namespace Ambulance.ServiceAPI.Client
{
    internal class ResourceCreator
    {
        private readonly HttpClient _httpClient;
        private readonly string _tenant;

        public ResourceCreator(string baseAddress, string tenant)
        {
            _tenant = tenant;
            _httpClient = GetHttpClient(baseAddress);
        }

        internal TResource CreateResource<TApiSpec, TResource>()
            where TApiSpec : class, IBaseContract
            where TResource : ResourceBase<TApiSpec>
        {
            var apiClient = RestClient.For<TApiSpec>(_httpClient);
            var resource = Activator.CreateInstance(typeof(TResource), apiClient, _tenant);

            return (TResource)resource;
        }

        private static HttpClient GetHttpClient(string baseAddress)
        {
            if (baseAddress == null)
            {
                throw new ArgumentNullException(nameof(baseAddress));
            }

            return new HttpClient(new HttpClientHandler())
            {
                BaseAddress = new Uri(baseAddress),
            };
        }
    }
}
