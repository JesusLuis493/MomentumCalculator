// ═══════════════════════════════════════════════════════════════
// HealthController.cs - Health check para DevOps/Terraform
// ═══════════════════════════════════════════════════════════════

using Microsoft.AspNetCore.Mvc;

namespace MomentumCalculator.API. Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        // ┌─────────────────────────────────────────────────────┐
        // │ GET /api/health                                     │
        // │ Verifica que la API está funcionando                │
        // │                                                     │
        // │ Usado por:                                           │
        // │ - Terraform (health checks)                         │
        // │ - Load Balancers (AWS ALB, Azure LB)                │
        // │ - Kubernetes (liveness/readiness probes)            │
        // │ - Sistemas de monitoreo                             │
        // └─────────────────────────────────────────────────────┘
        [HttpGet]
        public ActionResult GetHealth()
        {
            return Ok(new
            {
                Status = "healthy",
                Timestamp = DateTime.UtcNow,
                Version = "1.0. 0"
            });
        }
    }
}