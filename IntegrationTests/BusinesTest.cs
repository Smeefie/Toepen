using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class BusinesTest
    {
        [Fact]
        public async Task GetAllStatistics()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/User/Statistics");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
