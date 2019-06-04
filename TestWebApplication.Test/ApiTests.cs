using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace TestWebApplication
{
    public class ApiTests
    {
        private TestServer _testServer;

        [SetUp]
        public void Setup()
        {
            var builder = new WebHostBuilder()
                    .UseStartup<Startup>()
                    .UseTestServer()
                    .UseEnvironment("Development")
                ;

            _testServer = new TestServer(builder);
        }

        [Test]
        public async Task Test1()
        {
            var client = _testServer.CreateClient();
            var responseMessage = await client.GetJsonAsync<string[]>("api/values");

            CollectionAssert.AreEqual(new []{"value1", "value2"}, responseMessage);
        }
    }
}