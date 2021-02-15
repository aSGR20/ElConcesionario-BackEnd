using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using ElConcesionario.Core.DTO;

namespace ElConcesionario.IntegrationTests
{
    public class VehiculoTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public VehiculoTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task VehiculoTests_ListVehiculos_ReturnsSuccessStatusCode()
        {
            var request = new
            {
                Url = "/vehiculo"
            };

            var response = await Client.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();
            var listaVehiculo = JsonSerializer.Deserialize<List<VehiculoDTO>>(value);

            response.EnsureSuccessStatusCode();
            Assert.True(listaVehiculo.Count == 7);
        }
    }
}
