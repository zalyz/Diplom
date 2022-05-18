using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ambulance.DAL.Services
{
    public interface ISecretStorageService
    {
        Task<string> GetConnectionString(string tenant);
    }

    public class SecretStorageService : ISecretStorageService
    {
        private const string FilePath = "../ConnectionStrings.json";

        public SecretStorageService()
        {
        }

        public async Task<string> GetConnectionString(string tenant)
        {
            using var reader = new StreamReader(FilePath);
            var data = await reader.ReadToEndAsync();
            var strings = JsonConvert.DeserializeObject<List<ConnectionString>>(data);
            return strings.FirstOrDefault(e => string.Equals(e.Tenant, tenant))?.Path;
        }

        private class ConnectionString
        {
            public string Tenant { get; set; }

            public string Path { get; set; }
        }
    }
}
