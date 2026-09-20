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
│
├── .github/
│   └── workflows/
│       └── ci-cd.yml                   # Pipeline de CI/CD (GitHub Actions)
│
├── docs/                               # Documentación técnica
│   ├── ARCHITECTURE.md                 # Este archivo
│   ├── CONTRIBUTING.md                 # Guía para contribuidores
│   ├── CURRENT_STATES.md               # Estado actual del proyecto
│   ├── TECHNICAL_NOTES.md              # Análisis de algoritmos y optimizaciones
│   └── API_DESSIGN.md                  # Diseño de endpoints 
│
├── infrastructure
│   └── terraform
│       └── main.tf
│
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
│      │   └── TrianguloModels.cs         # Request/Response de triángulo
│      │
│      ├── Properties/                    # Propiedades
│      │   └── LaunchSettings.json
│      │
│      └── MomentumCalculator.API.csproj  # Configuración del proyecto
│
├── test/                                 # Pruebas unitarias
│   └── MomentumCalculator.Tests/
│       ├── MomentumCalculator.Tests.csproj
│       ├── MomentumCalculator.Tests/
│       │   └── Unit_Tests.cs             # Test unitarios 
│       ├── MomentumCalculator.API.Tests/
│       │   ├── GlobalUsings.cs
│       │   └── IntegrationTests.cs       # Tests de integración
│       │   └── MomentumCalculator.API.Tets.csproj 
│       └── scripts/                      # Sicripts de automatizacion de tests
│           └── suite_testing.sh          # Suite de tests para poder desplegras todos los test
│
├── .dockerignore                       # Archivos ignorados por docker
├── .gitignore                          # Archivos ignorados por Git
├── LICENSE                             # Licencia MIT
├── README.md                           # Documentación principal
└── dockerfile
```

---

## 🎯 Capas de Arquitectura

### **1️⃣ Capa de Negocio (Core)**

**Ubicación:** `src/MomentumCalculator.Core/`

**Responsabilidad:** Implementar lógica pura de cálculos físicos (momentum, fuerzas)

**Componentes:**

### **Operaciones.cs**
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

### **Program.cs**
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

### **UnitTests.cs**
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
---

### **IntegrationsTests.cs**
```csharp
using Microsoft.AspNetCore.Mvc. Testing;
using System.Net;
using System.Net.Http.Json;

namespace MomentumCalculator.API. Tests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task Health_ReturnsOk()
        {
            var response = await _client. GetAsync("/api/health");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
```

**Características:**
- ✅ Usa mocks para aislar componentes
- ✅ Ejecuta rápido (sin dependencias externas)
- ✅ Cobertura mínima: 80%
- ✅ Cobertura Real: 100%

--- 

### **4️⃣ Capa de API **

**Ubicación:** `src/MomentumCalculator.API/`

**Responsabilidad:** Exponer Core como REST API

**Ejemplo**
```csharp
var builder = WebApplication. CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (app.Environment. IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```
**Características:**
- ✅ Usa de swagger para verificar los endpoints
- ✅ Requiere de un solo tipo de tests
---

### 5️⃣ Capa de Infraestructura y Despliegue

**Docker**
Ubicación: `dockerfile` (raíz)
Propósito: empaquetar la API en una imagen ejecutable.

**Terraform**
Ubicación: `infrastructure/terraform/main.tf`
Propósito: provisionar el entorno cloud (IaC).

**CI/CD**
Ubicación: `.github/workflows/`
Propósito: build + test automáticos.


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
