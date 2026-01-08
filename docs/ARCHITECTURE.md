# 🏗️ Arquitectura de MomentumCalculator

## Visión General

MomentumCalculator está diseñado siguiendo separación por capas para permitir:
- ✅ Reutilización de código en múltiples interfaces (CLI, API, tests)
- ✅ Testing fácil y rápido
- ✅ Escalabilidad y mantenimiento
- ✅ Deployment con CI/CD y Terraform

---

## 📂 Estructura de Carpetas

```
MomentumCalculator/
├── MomentumCalculator.sln              # Solución que agrupa todos los proyectos
├── .github/
│   └── workflows/
│       └── ci-cd.yml                   # Pipeline de CI/CD (GitHub Actions)
├── docs/                               # Documentación técnica
│   ├── ARCHITECTURE.md                 # Este archivo
│   ├── CONTRIBUTING.md                 # Guía para contribuidores
│   ├── CURRENT_STATES.md               # Estado del proyecto durante la refactorizacion
│   ├── TECHNICAL_NOTES.md              # Análisis de algoritmos y optimizaciones
│   └── API_DESIGN.md                   # Diseño de endpoints (futuro)
├── src/                                # Código fuente
│   ├── MomentumCalculator.Core/        # ⭐ Lógica de negocio pura
│   │   ├── MomentumCalculator.Core.csproj
│   │   └── Operaciones.cs              # Clase principal con algoritmos
│   │
│   ├── MomentumCalculator.CLI/          # Interfaz por línea de comandos
│   │   ├── MomentumCalculator.CLI.csproj
│   │   └── Program.cs                   # Menús y entrada de usuario
│   │
│   └── MomentumCalculator.API/           # 🆕 NUEVO - La API
│      │
│      ├── Controllers/                   # Reciben las peticiones HTTP
│      │   ├── FuerzaController. cs       # Maneja /api/fuerza/*
│      │   ├── MomentumController.cs      # Maneja /api/momentum/*
│      │   ├── TrianguloController.cs     # Maneja /api/triangulo/*
│      │   └── HealthController. cs       # Maneja /api/health
│      │
│      ├── Models/                        # Definen estructura de datos
│      │   ├── FuerzaModels.cs            # Request/Response de fuerza
│      │   ├── MomentumModels.cs          # Request/Response de momentum
│      │   └── TrianguloModels. cs        # Request/Response de triángulo
│      └── MomentumCalculator.API.csproj  # Configuración del proyecto
│
├── test/                               # Pruebas unitarias
│   └── MomentumCalculator.Tests/
│       ├── MomentumCalculator.Tests.csproj
│       ├── scripts                     # Sicripts de automatizacion de tests
│       │   └── suite_testing.sh        # Suite de tests para poder desplegras todos los tests
│       ├── Unit_Tests.cs               # Test unitarios 
│       └── IntegrationTests.cs         # Tests de integración (futuro)
│
├── .gitignore                          # Archivos ignorados por Git
├── LICENSE                             # Licencia MIT
└── README.md                           # Documentación principal
```

---

## 🎯 Capas de Arquitectura

### **1️⃣ Capa de Negocio (Core)**

**Ubicación:** `src/MomentumCalculator.Core/`

**Responsabilidad:** Implementar lógica pura de cálculos físicos (momentum, fuerzas)

**Componentes:**

#### **Operaciones.cs**
```csharp
namespace Operations
{
    public class Create
    {
        //clase de validacion 0
        public void validacion(double n)
        {
            if (n == 0)
            {
                Console.WriteLine("[falla de validacion, {0} no puedes ser 0]", n);
            }
        }
        // constantes de conversion de angulos a radianes
        private const double DEG_TO_RAD = Math.PI / 180;
        private const double RAD_TO_DEG = 180 / Math.PI;
        
        //componentes x & y de la fuerza ejercida
        public double CompX(double F, double A) //fuerza ejercida en el eje x
        {
            double Fx = F * Math.Cos(A * DEG_TO_RAD);
            return (Fx);
        }
```

**Propósito:** Implementación actual de los cálculos.

---

### **2️⃣ Capa de Presentación (CLI)**

**Ubicación:** `src/MomentumCalculator.CLI/`

**Responsabilidad:** Interacción con usuario por terminal

**Componentes:**

#### **Program.cs**
- Menús
- Lectura de entrada
- Mostrar resultados
- Manejo de excepciones de UI

**Características:**
- ✅ Es **reemplazable** (se puede cambiar por web, mobile, etc.)
- ✅ No contiene lógica de negocio

---

### **3️⃣ Capa de Tests**

**Ubicación:** `tests/MomentumCalculator.Tests/`

**Responsabilidad:** Verificar que Core funciona correctamente

**Componentes:**

#### **OperacionesTests.cs**
```csharp
[Clase de Prueba]
namespace Tests
{
    using Operations;
    [TestClass]
    internal class UnitTests
    {
        // Verificasion de comportamiento del metodo Validacion de Operations.cs
        [TestMethod]
        [Trait("Category", "Unit")]
        public void TestMethod_Validacion_input0()
        {
            double result = Operations.Validacion("1234567890");
            Assert.AreEqual(1234567890, result);
        }
```

**Características:**
- ✅ Usa mocks para aislar componentes
- ✅ Ejecuta rápido (sin dependencias externas)
- ✅ Cobertura mínima: 80%

---

### **4️⃣ Capa de API (Futuro)**

**Ubicación:** `src/MomentumCalculator.API/`

**Responsabilidad:** Exponer Core como REST API

**Ejemplo (pseudo-código):**
```csharp
[ApiController]
[Route("api/[controller]")]
public class MomentumController : ControllerBase
{
    private readonly ICalculator _calculator;
    
    public MomentumController(ICalculator calculator)
    {
        _calculator = calculator;
    }
    
    [HttpPost("component-x")]
    public IActionResult CalculateComponentX([FromBody] ForceRequest request)
    {
        var result = _calculator.CalculateComponentX(request.Force, request.Angle);
        if (!result.Success)
            return BadRequest(new { error = result.Message });
        return Ok(result);
    }
}
```

---

## 🔄 Flujo de Datos

```
┌─────────────────────────────┐
│   Usuario (Terminal)        │
│   Ingresa:  F=10, A=45°      │
└──────────────┬──────────────┘
               │ input
               ↓
┌─────────────────────────────┐
│  CLI (Program.cs)           │ ← Captura datos
│  Console.ReadLine()         │
└──────────────┬──────────────┘
               │
               ↓
┌─────────────────────────────┐
│  Operaciones. cs (Core)      │ ← Procesa cálculos
│  - CompX(10, 45)            │
│  - Math.Cos(), Math.Sin()   │
│  - Validaciones             │
│  Resultado: 7.07            │
└──────────────┬──────────────┘
               │
               ↓
┌─────────────────────────────┐
│  CLI (Program.cs)           │ ← Muestra resultado
│  Console.WriteLine("✅ 7.07")│
└─────────────────────────────┘
```

---

## 🧪 Testing Architecture

```
┌─────────────────────────────────────────────┐
│         GitHub Actions (CI/CD)              │
├─────────────────────────────────────────────┤
│ 1. dotnet build                             │
│ 2. dotnet test  ← Corre todos los tests     │
│ 3. Si pasan: empaquetar                     │
│ 4. Si fallan: DETENER y reportar error      │
└─────────────────────────────────────────────┘
         ↓
┌─────────────────────────────────────────────┐
│      MomentumCalculator.Tests               │
├─────────────────────────────────────────────┤
│ • Unit Tests (80%+ coverage)                │
│   - CalculateComponentX                     │
│   - CalculateComponentY                     │
│   - CalculateMomentumX                      │
│   - CalculateMomentumY                      │
│   - CalculateAngle                          │
│ • Edge Cases                                │
│   - Valores negativos                       │
│   - Ángulos fuera de rango                  │
│   - División por cero                       │
└─────────────────────────────────────────────┘
```

---

## 🔌 Dependencias Entre Proyectos

```
MomentumCalculator.Tests
    └─→ Referencia: MomentumCalculator.Core
    
MomentumCalculator.CLI
    └─→ Referencia: MomentumCalculator.Core

MomentumCalculator.API (futuro)
    └─→ Referencia: MomentumCalculator.Core

MomentumCalculator.sln (Solución)
    ├─→ MomentumCalculator.Core
    ├─→ MomentumCalculator.CLI
    ├─→ MomentumCalculator.Tests
    └─→ MomentumCalculator.API (futuro)
```

**Regla de Oro:** Core NO depende de nada. CLI y Tests dependen de Core.

---

## 📦 Decisiones de Diseño

### ¿Por qué separar CLI de Core?
- ✅ Core es reutilizable en API, web, mobile
- ✅ Testing de Core sin menús ni I/O
- ✅ Cambios en UI no afectan lógica
---
