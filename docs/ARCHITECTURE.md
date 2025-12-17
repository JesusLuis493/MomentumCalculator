# 🏗️ Arquitectura de MomentumCalculator

## Visión General

MomentumCalculator está diseñado siguiendo principios **SOLID** y separación de capas para permitir:
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
│   ├── TECHNICAL_NOTES.md              # Análisis de algoritmos y optimizaciones
│   └── API_DESIGN.md                   # Diseño de endpoints (futuro)
├── src/                                # Código fuente
│   ├── MomentumCalculator.Core/        # ⭐ Lógica de negocio pura
│   │   ├── MomentumCalculator.Core.csproj
│   │   ├── Operaciones.cs              # Clase principal con algoritmos
│   │   ├── Models/                     # Modelos de datos
│   │   │   └── CalculationResult.cs    # Respuesta estándar
│   │   └── Interfaces/                 # Contratos
│   │       └── ICalculator.cs          # Interfaz de cálculos
│   │
│   ├── MomentumCalculator.CLI/         # Interfaz por línea de comandos
│   │   ├── MomentumCalculator.CLI.csproj
│   │   └── Program.cs                  # Menús y entrada de usuario
│   │
│   └── MomentumCalculator.API/         # ⏳ API REST (futuro)
│       ├── MomentumCalculator.API.csproj
│       ├── Controllers/
│       │   └── MomentumController.cs
│       └── Startup.cs
│
├── tests/                              # Pruebas unitarias
│   └── MomentumCalculator.Tests/
│       ├── MomentumCalculator.Tests.csproj
│       ├── OperacionesTests.cs         # Tests de lógica
│       └── IntegrationTests.cs         # Tests de integración (futuro)
│
├── .gitignore                          # Archivos ignorados por Git
├── LICENSE                             # Licencia MIT
├── README.md                           # Documentación principal
└── CONTRIBUTING.md                     # Guía para contribuidores
```

---

## 🎯 Capas de Arquitectura

### **1️⃣ Capa de Negocio (Core)**

**Ubicación:** `src/MomentumCalculator.Core/`

**Responsabilidad:** Implementar lógica pura de cálculos físicos (momentum, fuerzas)

**Componentes:**

#### **Interfaces/ICalculator.cs**
```csharp
public interface ICalculator
{
    CalculationResult CalculateComponentX(double force, double angle);
    CalculationResult CalculateComponentY(double force, double angle);
    CalculationResult CalculateMomentumX(double distance, double forceX);
    CalculationResult CalculateMomentumY(double distance, double forceY);
    CalculationResult CalculateAngle(double forceX, double forceY);
}
```

**Propósito:** Define el contrato que TODA implementación debe cumplir.

#### **Operaciones.cs**
```csharp
public class Operaciones : ICalculator
{
    public CalculationResult CalculateComponentX(double force, double angle) { ... }
    public CalculationResult CalculateComponentY(double force, double angle) { ... }
    // ... más métodos
}
```

**Propósito:** Implementación actual de los cálculos.

#### **Models/CalculationResult.cs**
```csharp
public class CalculationResult
{
    public bool Success { get; }
    public double Value { get; }
    public string Message { get; }
    public string Unit { get; }
}
```

**Propósito:** Respuesta estructurada para TODOS los cálculos (éxito/error, valor, contexto).

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
- ✅ Depende de `ICalculator` (no de `Operaciones`)
- ✅ Es **reemplazable** (se puede cambiar por web, mobile, etc.)
- ✅ No contiene lógica de negocio

---

### **3️⃣ Capa de Tests**

**Ubicación:** `tests/MomentumCalculator.Tests/`

**Responsabilidad:** Verificar que Core funciona correctamente

**Componentes:**

#### **OperacionesTests.cs**
```csharp
[Fact]
public void CalculateComponentX_WithValidInput_ReturnsExpectedValue()
{
    // Arrange
    ICalculator calculator = new Operaciones();
    
    // Act
    var result = calculator.CalculateComponentX(10, 45);
    
    // Assert
    Assert.True(result.Success);
    Assert.Equal(7.07, result.Value, 2); // 2 decimales de precisión
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
│      Usuario (Terminal)     │
└──────────────┬──────────────┘
               │ input: F=10, A=45°
               ↓
┌─────────────────────────────┐
│    CLI (Program.cs)         │ ← Lee entrada, valida UI
│  - Menús                    │
│  - Lectura stdin            │
└──────────────┬──────────────┘
               │ Fx = 10, Fy = 20
               ↓
┌─────────────────────────────┐
│   ICalculator (Interface)   │ ← Contrato
│  CalculateComponentX()      │
└──────────────┬──────────────┘
               │
               ↓
┌─────────────────────────────┐
│  Operaciones (Core)         │ ← Implementación real
│  - Math.Cos()               │
│  - Math.Sin()               │
│  - Validaciones             │
└──────────────┬──────────────┘
               │
               ↓
┌─────────────────────────────┐
│  CalculationResult          │ ← Respuesta estructurada
│  {                          │
│    Success: true,           │
│    Value: 7.07,             │
│    Message: "Éxito",        │
│    Unit: "N"                │
│  }                          │
└──────────────┬──────────────┘
               │
               ↓
┌─────────────────────────────┐
│    CLI (Program.cs)         │ ← Muestra resultado
│  Print "✅ 7.07 N"          │
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

### ¿Por qué ICalculator?
- ✅ Permite múltiples implementaciones (Operaciones, OptimizedOperaciones, MockOperaciones)
- ✅ Facilita testing sin tocar código de producción
- ✅ Inyección de dependencias para desacoplamiento

### ¿Por qué CalculationResult?
- ✅ Estructura uniforme de respuestas
- ✅ Manejo consistente de errores
- ✅ Facilita logging y monitoreo
- ✅ Compatible con APIs REST (JSON)

### ¿Por qué separar CLI de Core?
- ✅ Core es reutilizable en API, web, mobile
- ✅ Testing de Core sin menús ni I/O
- ✅ Cambios en UI no afectan lógica

---

## 🚀 Fases de Implementación

| Fase | Fecha | Tarea | Estado |
|------|-------|-------|--------|
| 0 | Hoy | Documentación | ⏳ En progreso |
| 1 | +2h | Estructura de carpetas | ⏳ Por hacer |
| 2 | +3h | Refactorización Core | ⏳ Por hacer |
| 3 | +4h | Tests unitarios | ⏳ Por hacer |
| 4 | +4h | API REST | ⏳ Por hacer |
| 5 | +2h | CI/CD | ⏳ Por hacer |

---

## 📚 Referencias

- [SOLID Principles](https://en.wikipedia.org/wiki/SOLID)
- [Dependency Injection](https://en.wikipedia.org/wiki/Dependency_injection)
- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)