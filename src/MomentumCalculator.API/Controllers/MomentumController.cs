// ═══════════════════════════════════════════════════════════════
// MomentumController.cs - Maneja todas las peticiones a /api/momentum
// ═══════════════════════════════════════════════════════════════

using Microsoft.AspNetCore.Mvc;
using MomentumCalculator.API.Models;
using Operations;

namespace MomentumCalculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MomentumController : ControllerBase
    {
        private readonly Create _operaciones = new Create();

        // ┌─────────────────────────────────────────────────────┐
        // │ POST /api/momentum/x                                │
        // │ Calcula momentum en el eje X                        │
        // └─────────────────────────────────────────────────────┘
        [HttpPost("x")]
        public ActionResult<MomentumResponse> CalcularMomentumX(
            [FromBody] MomentumXRequest request)
        {
            double momentum = _operaciones.MomentoX(request. DistanciaY, request.FuerzaX);

            return Ok(new MomentumResponse
            {
                Momentum = Math.Round(momentum, 4),
                Eje = "X",
                Success = true,
                Error = null
            });
        }

        // ┌─────────────────────────────────────────────────────┐
        // │ POST /api/momentum/y                                │
        // │ Calcula momentum en el eje Y                        │
        // └─────────────────────────────────────────────────────┘
        [HttpPost("y")]
        public ActionResult<MomentumResponse> CalcularMomentumY(
            [FromBody] MomentumYRequest request)
        {
            double momentum = _operaciones. MomentoY(request.DistanciaX, request. FuerzaY);

            return Ok(new MomentumResponse
            {
                Momentum = Math.Round(momentum, 4),
                Eje = "Y",
                Success = true,
                Error = null
            });
        }
    }
}