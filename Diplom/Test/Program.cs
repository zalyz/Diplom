using Ambulance.CallApi.Client;
using System;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new CallApiClient("https://localhost:44368/", "testTenant");
            var asd = client.CallOperations.GetAccepted().GetAwaiter().GetResult();
            Console.WriteLine($"Result: {asd}");
        }
    }
}
