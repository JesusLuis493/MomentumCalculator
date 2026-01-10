using Microsoft.AspNetCore.Mvc. Testing;
using System.Net;
using System.Net.Http.Json;

namespace MomentumCalculator.API. Tests
{
    // WebApplicationFactory<Program> reemplaza a Startup
    // Crea una instancia de tu API para testing
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        // Constructor:  recibe la fábrica y crea un cliente HTTP
        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        // HEALTH CONTROLLER
        [Fact]
        [Trait("Category", "Integration")]
        public async Task Health_ReturnsOk()
        {
            // Arrange & Act
            var response = await _client. GetAsync("/api/health");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // FUERZA CONTROLLER
        [Fact]
        [Trait("Category", "Integration")]
        public async Task Fuerza_Componentes_ValidInput_ReturnsOk()
        {
            // Arrange
            var request = new { fuerza = 100, angulo = 45 };

            // Act
            var response = await _client.PostAsJsonAsync("/api/fuerza/componentes", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // MOMENTUM CONTROLLER
        [Fact]
        [Trait("Category", "Integration")]
        public async Task Momentum_CalcularMomentumX_ValidInput_ReturnsOk()
        {
            // Arrange
            var request = new { distanciaY = 5, fuerzaX = 20 };

            // Act 
            var response = await _client.PostAsJsonAsync("/api/momentum/x", request);

            // Assert
            Assert. Equal(HttpStatusCode.OK, response. StatusCode);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task Momentum_CalcularMomentumY_ValidInput_ReturnsOk()
        {
            // Arrange
            var request = new { distanciaX = 3, fuerzaY = 15 };  

            // Act 
            var response = await _client.PostAsJsonAsync("/api/momentum/y", request);

            // Assert
            Assert. Equal(HttpStatusCode.OK, response. StatusCode);
        }

        // TRIANGULO CONTROLLER
        [Fact]
        [Trait("Category", "Integration")]
        public async Task Triangulo_CalcularComponentes_ValidInput_ReturnsOk()
        {
            // Arrange
            var request = new 
            { 
                FuerzaTotal = 150, 
                CatetoAdyacente = 3, 
                CatetoOpuesto = 4, 
                Hipotenusa = 5 
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/triangulo/componentes", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task Triangulo_calcularAngulo_ValidInput_ReturnsOk()
        {
            // Arrange
            var request = new 
            { 
                FuerzaResultanteX = 120, 
                FuerzaResultanteY = 80 
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/triangulo/angulo", request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}