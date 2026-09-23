# 🤝 Guía de Contribución - MomentumCalculator

Gracias por interesarte en contribuir a MomentumCalculator. Esta guía te dirá exactamente qué hacer.

---

## 📋 Requisitos Previos

Antes de empezar, asegúrate de tener:

- **Sistema Operativo:** Linux, macOS o Windows
- **.NET SDK 8.0+** - [Descargar](https://dotnet.microsoft.com/download)
- **Git** - [Descargar](https://git-scm.com/)
- **Editor:** Visual Studio Code o Visual Studio
- **Terminal:** PowerShell, Bash o Zsh

**Verifica instalación:**
```bash
dotnet --version
git --version
```
## 🚀 Configuración Local

***1. Clona el Repositorio***
``` bash
git clone https://github.com/JesusLuis493/MomentumCalculator.git
cd MomentumCalculator
```

***2. Abre en Codespaces o Local***

Opción A: Codespaces (Recomendado)
```bash
# GitHub abre automáticamente el ambiente
# En el navegador: github.dev/...
```

Opción B: Local
```bash
code .  # Abre en Visual Studio Code
```

***3. Restaura Dependencias***

```bash
dotnet restore
```
***4. Verifica que Todo Funciona***

```bash
dotnet build
dotnet run --project src/MomentumCalculator.CLI
```
Deberías ver el menú de la calculadora.

--- 

## 🌿 Workflow de Desarrollo
***Paso 1: Crea una Rama***

```bash
# Siempre desde develop
git checkout develop
git pull origin develop

# Crea rama con nombre descriptivo
git checkout -b feature/nombre-descriptivo
# O para bugs:
git checkout -b fix/descripcion-del-bug
```

Naming convention:

- ```feature/nueva-funcionalidad```
- ```fix/nombre-del-bug```
- ```docs/actualizacion-doc```
- ```refactor/nombre-componente```

***Paso 2: Haz Cambios***

Edita el código. Ejemplos:
```bash
# Modificar Operaciones.cs
vim src/MomentumCalculator.Core/Operaciones.cs

# Agregar test
vim test/MomentumCalculator.Tests/OperacionesTests.cs
```

***Paso 3: Commitea Cambios***
```bash
# Ver qué cambió
git status

# Agregar cambios
git add .

# Hacer commit con mensaje claro
git commit -m "feat: agregar validación de ángulos negativos"
```
***Mensaje de commit:***

- ```feat:``` Para nuevas funcionalidades
- ```fix:``` Para bugs
- ```docs:``` Para documentación
- ```refactor:``` Para limpieza de código
- ```test:``` Para agregar tests

***Ejemplo de mensaje BUENO:***
```Code
feat: implementar CalculationResult en CompX

- Agregar modelo CalculationResult
- Refactorizar CompX para devolver CalculationResult
- Agregar validaciones de fuerza
```
***Ejemplo de mensaje MALO:***
```Code
arreglo algo
cambios varios
```

--- 

## 🧪 Testing (OBLIGATORIO)
***Antes de Push, Corre Tests***
```bash
# Corre todos los tests
dotnet test

# Corre tests de un proyecto específico
dotnet test tests/MomentumCalculator.Tests

# Corre tests con output detallado
dotnet test --verbosity detailed

# Corre tests y genera cobertura
dotnet test /p:CollectCoverage=true
```

***Requisitos de Testing***

- ✅ Mínimo 80% cobertura de código
- ✅ Todos los tests PASAN (green)
- ✅ Sin warnings en build

***Escribir un Test (Ejemplo)***
```C#
// tests/MomentumCalculator.Tests/OperacionesTests.cs
using Xunit;
using MomentumCalculator.Core;

public class OperacionesTests
{
    [Fact]
    public void CalculateComponentX_WithValidInput_ReturnsSuccess()
    {
        // Arrange
        ICalculator calculator = new Operaciones();
        
        // Act
        var result = calculator.CalculateComponentX(10, 45);
        
        // Assert
        Assert.True(result.Success);
        Assert.Equal(7.07, result.Value, 2);
        Assert.Equal("N", result.Unit);
    }
    
    [Fact]
    public void CalculateComponentX_WithZeroForce_ReturnsFail()
    {
        // Arrange
        ICalculator calculator = new Operaciones();
        
        // Act
        var result = calculator.CalculateComponentX(0, 45);
        
        // Assert
        Assert.False(result.Success);
        Assert.Contains("error", result.Message.ToLower());
    }
}
```

--- 

## ✅ Checklist Antes de Push

Antes de hacer ```git push```, verifica:

- [ ] dotnet build pasa sin errores
- [ ] dotnet test pasa 100%
- [ ] Sin warnings
- [ ] Cobertura >= 80%
- [ ] Commits con mensajes claros
- [ ] Rama actualizada con develop:

```bash
git pull origin develop --rebase
```

- [ ] Documentación actualizada (si cambias API)
- [ ] README.md actualizado (si es cambio importante)

--- 

## 🔄 Pull Request (PR)
***Paso 1: Sube tu Rama***
```bash
git push origin feature/tu-rama
```
***Paso 2: Crea Pull Request en GitHub***

1. Ve a https://github.com/JesusLuis493/MomentumCalculator
2. Haz clic en "Pull Requests"
3. Haz clic en "New Pull Request"
4. Selecciona:
   - Base: develop
   - Compare: feature/tu-rama
5. Agrega título y descripción

***Título del PR:***
```Code
feat: agregar validación de ángulos negativos
```

***Descripción del PR:***
```Code
## Descripción
Implementa validación para rechazar ángulos negativos en CompX y CompY.

## Cambios
- Agregar validación de ángulo >= 0
- Devolver CalculationResult con error si ángulo es negativo
- Agregar tests para casos con ángulos negativos

## Testing
- ✅ Todos los tests pasan
- ✅ Cobertura: 82%
- ✅ Testeado manualmente con valores negativos

## Checklist
- [x] Código compilado sin errores
- [x] Tests pasan
- [x] Cobertura >= 80%
- [x] Documentación actualizada
```

***Paso 3: Espera Review***

- El PM/Tech Lead revisa tu código
- Puede pedir cambios
- Una vez aprobado: ✅ Merge automático a develop

--- 

## 🏗️ Estándares de Código
***Naming***

- Clases: PascalCase - CalculationResult
- Métodos: PascalCase - CalculateComponentX()
- Variables: camelCase - forceValue, angleInDegrees
- Constantes: UPPER_SNAKE_CASE - DEG_TO_RAD

***Estructura***
```C#
// ✅ BIEN
public class Operaciones : ICalculator
{
    private const double DEG_TO_RAD = Math.PI / 180;
    
    public CalculationResult CalculateComponentX(double force, double angle)
    {
        // Validar
        if (force <= 0)
            return new CalculationResult(false, 0, "Error", "");
        
        // Calcular
        double result = force * Math.Cos(angle * DEG_TO_RAD);
        
        // Retornar
        return new CalculationResult(true, result, "Éxito", "N");
    }
}

// ❌ MAL
public class Operaciones : ICalculator
{
    public double CompX(double f, double a) // Nombres cortos
    {
        return f * Math.Cos(a * 3.14159 / 180); // Constante hardcoded
    }
}
```

***Documentación***
```C#
/// <summary>
/// Calcula el componente en X de una fuerza.
/// </summary>
/// <param name="force">Magnitud de la fuerza en Newtons (N > 0)</param>
/// <param name="angle">Ángulo respecto al eje X en grados (0-360)</param>
/// <returns>CalculationResult con componente Fx o error</returns>
public CalculationResult CalculateComponentX(double force, double angle)
{
    // Implementación
}
```

--- 

## 🐛 Reportar Bugs

Si encuentras un bug:

1. Abre una Issue en GitHub
2. Título: Descripción clara del problema
3. Descripción:

```Code
## Descripción
[Qué sucede]

## Pasos para Reproducir
1. [Paso 1]
2. [Paso 2]

## Comportamiento Esperado
[Qué debería pasar]

## Comportamiento Actual
[Qué pasa realmente]

## Environment
- SO: [Windows/Mac/Linux]
- .NET Version: [8.0.x]
```

--- 

## ❓ ¿Preguntas?

- Lee docs/ARCHITECTURE.md para entender la estructura
- Lee docs/TECHNICAL_NOTES.md para entender algoritmos
- Abre una Issue si tienes dudas
- Contacta al PM (@JesusLuis493)

--- 

## 👤 Autor

**Jesus Emmanuel Luis Sandoval**  
Estudiante de Ingeniería en Sistemas Computacionales  
Instituto Tecnológico de México, Campus Nochistlán  

Apasionado por el desarrollo de software, DevOps, scripting y la accesibilidad tecnológica. Este proyecto forma parte de mi portafolio personal.

## 📞 Contacto

- **GitHub**: [JesusLuis493](https://github.com/JesusLuis493)
- **Correo Electrónico**: [jesusluis.dev@gmail.com]