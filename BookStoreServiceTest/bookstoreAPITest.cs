using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using bookstoreService;
using bookstoreService.Model;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http.Headers;
using bookstoreService.Data;

namespace BookStoreServiceTest
{
    public class bookstoreAPITest
    {
        private readonly HttpClient _client;
        private const string POST = "POST";
        private const string GET = "GET";
        private IConfiguration _config;
        public bookstoreAPITest()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _config = configuration;
            var webHostBuilder = WebHost.CreateDefaultBuilder().ConfigureAppConfiguration((context, config) =>
            {
                config.AddConfiguration(configuration);
            });
                
            var server = new TestServer(webHostBuilder.UseEnvironment("Development").UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Fact]
        public async void GetUserPassTest()
        {
            var connectionString = _config.GetConnectionString("devConnection");
            var userAccess = new UserAccess(connectionString);
            var user = await userAccess.GetUser("jayin@hotmail.com", "chicken");
            Assert.NotNull(user);
            Assert.Equal("jayin@hotmail.com", user.Email);
        }
    }
}
