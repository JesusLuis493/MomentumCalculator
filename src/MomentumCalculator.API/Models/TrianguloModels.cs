// ═══════════════════════════════════════════════════════════════
// TrianguloModels.cs - Define la estructura de datos para /api/triangulo
// ═══════════════════════════════════════════════════════════════

namespace MomentumCalculator.API.Models
{
    // ┌─────────────────────────────────────────────────────────┐
    // │ REQUEST - Calcular componentes usando triángulo         │
    // │ JSON: { "fuerzaTotal": 50, "catetoAdyacente": 3, ...  }  │
    // └─────────────────────────────────────────────────────────┘
    public class TrianguloComponentesRequest
    {
        public double FuerzaTotal { get; set; }
        public double CatetoAdyacente { get; set; }
        public double CatetoOpuesto { get; set; }
        public double Hipotenusa { get; set; }
    }

    // ┌─────────────────────────────────────────────────────────┐
    // │ RESPONSE - Componentes calculados                       │
    // │ JSON: { "componenteX": 30, "componenteY":  40, ...  }     │
    // └─────────────────────────────────────────────────────────┘
    public class TrianguloComponentesResponse
    {
        public double ComponenteX { get; set; }
        public double ComponenteY { get; set; }
        public bool Success { get; set; }
        public string? Error { get; set; }
    }

    // ┌─────────────────────────────────────────────────────────┐
    // │ REQUEST - Calcular ángulo                               │
    // │ JSON: { "fuerzaResultanteX": 30, "fuerzaResultanteY":  40 }│
    // └─────────────────────────────────────────────────────────┘
    public class AnguloRequest
    {
        public double FuerzaResultanteX { get; set; }
        public double FuerzaResultanteY { get; set; }
    }

    // ��─────────────────────────────────────────────────────────┐
    // │ RESPONSE - Ángulo calculado                             │
    // │ JSON: { "angulo": 53.13, "unidad": "grados", ... }      │
    // └─────────────────────────────────────────────────────────┘
    public class AnguloResponse
    {
        public double Angulo { get; set; }
        public string Unidad { get; set; } = "grados";
        public bool Success { get; set; }
        public string? Error { get; set; }
    }
}