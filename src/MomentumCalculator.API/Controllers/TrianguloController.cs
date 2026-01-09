// ═══════════════════════════════════════════════════════════════
// TrianguloController.cs - Maneja todas las peticiones a /api/triangulo
// ═══════════════════════════════════════════════════════════════

using Microsoft.AspNetCore.Mvc;
using MomentumCalculator.API.Models;
using Operations;

namespace MomentumCalculator.API. Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrianguloController :  ControllerBase
    {
        private readonly Create _operaciones = new Create();

        // ┌─────────────────────────────────────────────────────┐
        // │ POST /api/triangulo/componentes                     │
        // │ Calcula componentes X e Y usando triángulo          │
        // └─────────────────────────────────────────────────────┘
        [HttpPost("componentes")]
        public ActionResult<TrianguloComponentesResponse> CalcularComponentes(
            [FromBody] TrianguloComponentesRequest request)
        {
            // Validar que hipotenusa no sea 0
            if (request.Hipotenusa == 0)
            {
                return BadRequest(new TrianguloComponentesResponse
                {
                    Success = false,
                    Error = "La hipotenusa no puede ser 0"
                });
            }

            double compX = _operaciones.ComponeteX(
                request.FuerzaTotal, 
                request.CatetoAdyacente, 
                request. Hipotenusa);

            double compY = _operaciones. ComponenteY(
                request.FuerzaTotal, 
                request.CatetoOpuesto, 
                request.Hipotenusa);

            return Ok(new TrianguloComponentesResponse
            {
                ComponenteX = Math.Round(compX, 4),
                ComponenteY = Math.Round(compY, 4),
                Success = true,
                Error = null
            });
        }

        // ┌─────────────────────────────────────────────────────┐
        // │ POST /api/triangulo/angulo                          │
        // │ Calcula el ángulo resultante                        │
        // └─────────────────────────────────────────────────────┘
        [HttpPost("angulo")]
        public ActionResult<AnguloResponse> CalcularAngulo(
            [FromBody] AnguloRequest request)
        {
            // Validar que X no sea 0 (división por cero)
            if (request. FuerzaResultanteX == 0)
            {
                return BadRequest(new AnguloResponse
                {
                    Success = false,
                    Error = "FuerzaResultanteX no puede ser 0"
                });
            }

            double angulo = _operaciones.angulo(
                request.FuerzaResultanteX, 
                request. FuerzaResultanteY);

            return Ok(new AnguloResponse
            {
                Angulo = Math. Round(angulo, 4),
                Unidad = "grados",
                Success = true,
                Error = null
            });
        }
    }
}