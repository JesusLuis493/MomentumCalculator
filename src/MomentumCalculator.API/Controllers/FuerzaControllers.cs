// ═══════════════════════════════════════════════════════════════
// FuerzaController. cs - Maneja todas las peticiones a /api/fuerza
// ═══════════════════════════════════════════════════════════════

using Microsoft.AspNetCore. Mvc;
using MomentumCalculator.API.Models;
using Operations;  // ← Tu clase Operaciones.cs del proyecto Core

namespace MomentumCalculator.API.Controllers
{
    // ┌─────────────────────────────────────────────────────────┐
    // │ ATRIBUTOS - Le dicen a ASP. NET cómo funciona este controller
    // └─────────────────────────────────────────────────────────┘
    
    [ApiController]                    // "Soy un controller de API"
    [Route("api/[controller]")]        // Mi ruta base es /api/fuerza
                                       // ([controller] = nombre sin "Controller")
    public class FuerzaController : ControllerBase
    {
        // ┌─────────────────────────────────────────────────────┐
        // │ Tu clase de operaciones (la lógica que YA tienes)   │
        // └─────────────────────────────────────────────────────┘
        private readonly Create _operaciones = new Create();

        // ┌─────────────────────────────────────────────────────┐
        // │ ENDPOINT:  POST /api/fuerza/componentes              │
        // │                                                     │
        // │ [HttpPost] = Responde a peticiones POST             │
        // │ ("componentes") = La ruta adicional                 │
        // │                                                     │
        // │ Ruta completa: POST /api/fuerza/componentes         │
        // └─────────────────────────────────────────────────────┘
        [HttpPost("componentes")]
        public ActionResult<FuerzaComponentesResponse> CalcularComponentes(
            [FromBody] FuerzaComponentesRequest request)  // ← El JSON del body
        {
            // ══════════════════════════════════════════════════
            // PASO 1: Validar los datos de entrada
            // ══════════════════════════════════════════════════
            if (request.Fuerza < 0)
            {
                // Retornar error 400 (Bad Request)
                return BadRequest(new FuerzaComponentesResponse
                {
                    Success = false,
                    Error = "La fuerza no puede ser negativa"
                });
            }

            // ══════════════════════════════════════════════════
            // PASO 2: Usar TU lógica existente (Operaciones. cs)
            // ══════════════════════════════════════════════════
            double componenteX = _operaciones.CompX(request.Fuerza, request.Angulo);
            double componenteY = _operaciones.CompY(request.Fuerza, request. Angulo);

            // ══════════════════════════════════════════════════
            // PASO 3: Crear y retornar la respuesta
            // ══════════════════════════════════════════════════
            var response = new FuerzaComponentesResponse
            {
                ComponenteX = Math.Round(componenteX, 4),
                ComponenteY = Math.Round(componenteY, 4),
                Success = true,
                Error = null
            };

            // Retornar 200 OK con el resultado
            return Ok(response);
        }
    }
}