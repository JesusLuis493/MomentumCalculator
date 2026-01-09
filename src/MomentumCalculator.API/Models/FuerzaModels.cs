// ═══════════════════════════════════════════════════════════════
// FuerzaModels.cs - Define la estructura de datos para /api/fuerza
// ═══════════════════════════════════════════════════════════════

namespace MomentumCalculator.API.Models
{
    // ┌─────────────────────────────────────────────────────────┐
    // │ REQUEST - Lo que el cliente ENVÍA                       │
    // │                                                         │
    // │ Cuando alguien hace POST /api/fuerza/componentes        │
    // │ con body: { "fuerza": 100, "angulo": 45 }               │
    // │                                                         │
    // │ ASP.NET automáticamente crea este objeto:                │
    // │ FuerzaComponentesRequest { Fuerza = 100, Angulo = 45 }  │
    // └─────────────────────────────────────────────────────────┘
    public class FuerzaComponentesRequest
    {
        public double Fuerza { get; set; }
        public double Angulo { get; set; }
    }

    // ┌─────────────────────────────────────────────────────────┐
    // │ RESPONSE - Lo que tu API RESPONDE                       │
    // │                                                         │
    // │ Tu código crea este objeto y ASP.NET lo convierte a:     │
    // │ { "componenteX": 70.71, "componenteY": 70.71, ...  }     │
    // └─────────────────────────────────────────────────────────┘
    public class FuerzaComponentesResponse
    {
        public double ComponenteX { get; set; }
        public double ComponenteY { get; set; }
        public bool Success { get; set; }
        public string?  Error { get; set; }
    }
}