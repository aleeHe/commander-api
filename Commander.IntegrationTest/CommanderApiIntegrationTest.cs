using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Commander.Dtos;
using Newtonsoft.Json;
using Xunit;

namespace Commander.IntegrationTest
{
    public class CommanderApiIntegrationTest
    {
        [Fact]
        public async Task Test_Get_All()
        {
            using var client = new TestClientProvider().Client;

            var response = await client.GetAsync("api/commands");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Test_Post()
        {
            using var client = new TestClientProvider().Client;

            var commandCreateDto = JsonConvert.SerializeObject(new CommandCreateDto { HowTo = "1", Line = "22", Platform = "333" });
            var requestContent = new StringContent(commandCreateDto, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/commands", requestContent);

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
