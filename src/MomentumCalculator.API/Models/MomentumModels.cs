// ═══════════════════════════════════════════════════════════════
// MomentumModels.cs - Define la estructura de datos para /api/momentum
// ═══════════════════════════════════════════════════════════════

namespace MomentumCalculator.API.Models
{
    // ┌─────────────────────────────────────────────────────────┐
    // │ REQUEST - Momentum en eje X                             │
    // │ JSON: { "distanciaY": 5, "fuerzaX": 20 }                │
    // └───────────────��─────────────────────────────────────────┘
    public class MomentumXRequest
    {
        public double DistanciaY { get; set; }
        public double FuerzaX { get; set; }
    }

    // ┌─────────────────────────────────────────────────────────┐
    // │ REQUEST - Momentum en eje Y                             │
    // │ JSON: { "distanciaX": 3, "fuerzaY": 15 }                │
    // └─────────────────────────────────────────────────────────┘
    public class MomentumYRequest
    {
        public double DistanciaX { get; set; }
        public double FuerzaY { get; set; }
    }

    // ┌─────────────────────────────────────────────────────────┐
    // │ RESPONSE - Resultado del cálculo de momentum            │
    // │ JSON:  { "momentum": 100, "eje": "X", "success": true }  │
    // └─────────────────────────────────────────────────────────┘
    public class MomentumResponse
    {
        public double Momentum { get; set; }
        public string Eje { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string? Error { get; set; }
    }
}