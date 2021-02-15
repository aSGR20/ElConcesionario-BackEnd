using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using ElConcesionario.Core.DTO;

namespace ElConcesionario.IntegrationTests
{
    public class UsuarioTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public UsuarioTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task UsuarioTests_ListUsuarios_ReturnsSuccessStatusCode()
        {
            var request = new
            {
                Url = "/usuario"
            };

            var response = await Client.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();
            var listaUsuario = JsonSerializer.Deserialize<List<UsuarioDTO>>(value);

            response.EnsureSuccessStatusCode();
            Assert.True(listaUsuario.Count == 4);
        }
    }
}
