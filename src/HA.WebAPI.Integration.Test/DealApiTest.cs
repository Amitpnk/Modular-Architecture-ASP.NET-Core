using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HA.WebAPI.Integration.Test
{
    public class DealApiTest
    {
        [TestCase("Get", "api/v1/deal")]
        [TestCase("Get", "api/v1/deal/guid")]
        [Ignore("Need to implement")]
        public async Task GetAllCustomerTestAsync(string method, string URL)
        {
            using var client = new TestClientProvider().Client;
            var request = new HttpRequestMessage(new HttpMethod(method), URL);
            var response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}