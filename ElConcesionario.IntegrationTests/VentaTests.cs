using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using ElConcesionario.Core.DTO;

namespace ElConcesionario.IntegrationTests
{
    public class VentaTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public VentaTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task VentaTests_ListVentas_ReturnsSuccessStatusCode()
        {
            var request = new
            {
                Url = "/venta"
            };

            var response = await Client.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();
            var listaVenta = JsonSerializer.Deserialize<List<VentaDTO>>(value);

            response.EnsureSuccessStatusCode();
            Assert.True(listaVenta.Count == 8);
        }
    }
}
