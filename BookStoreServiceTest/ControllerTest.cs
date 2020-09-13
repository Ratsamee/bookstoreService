using bookstoreService.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Priority;

namespace BookStoreServiceTest
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [DefaultPriority(2)]
    public class ControllerTest : IClassFixture<WebApplicationFactory<bookstoreService.Startup>>
    {
        private readonly HttpClient _client;
        private const string MAIN_URL = "http://localhost:44386/api";
        private string _token = string.Empty;

        public ControllerTest(WebApplicationFactory<bookstoreService.Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact, Priority(0)]
        public async Task LoginTestPass()
        {
            var user = new SignIn
            {
                Email = "jayin@hotmail.com",
                Password = "chicken"
            };

            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{MAIN_URL}/login", content);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var data = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(data);
           
            var result = JsonConvert.DeserializeAnonymousType(data, new { jwt = "" });
            Assert.NotNull(result.jwt);

            _token = result.jwt;
        }

        [Fact, Priority(1)]
        public async void GetUserTestPass()
        {
            await LoginTestPass();

            var user = new SignIn
            {
                Email = "jayin@hotmail.com",
                Password = "chicken"
            };

            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await _client.PostAsync($"{MAIN_URL}/users/signin", content);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var data = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(data);

            var result = JsonConvert.DeserializeObject<SignInUser>(data);
            Assert.NotNull(result);
            Assert.Equal(result.Email, user.Email);
        }
    }
}
