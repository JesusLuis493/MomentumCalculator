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

Copilot said: Buena pregunta. Déjame explicar brutalmente por qué

Buena pregunta. Déjame explicar brutalmente por qué necesitas CONTRIBUTING.md.
🎯 ¿Para Qué Sirve CONTRIBUTING.md?
Corta:

Es una guía que dice cómo contribuir al proyecto (para otros desarrolladores o para ti en el futuro).
📋 La Realidad: ¿Por Qué Lo Necesitas?
Escenario 1: En Pasantías/Trabajo

Entras a un proyecto en la empresa:
Code

Tú: "¿Cómo hago pull request?"
Senior: "Lee CONTRIBUTING.md"

Sin CONTRIBUTING.md:

    ❌ Haces PR mal
    ❌ No pasas code review
    ❌ Pierdes tiempo

Con CONTRIBUTING.md:

    ✅ Sabes exactamente qué hacer
    ✅ Tu PR pasa a la primera
    ✅ Eres profesional

Escenario 2: Proyecto Open Source

Si alguien quiere contribuir a tu repo:
Code

Contribuidor: "¿Cómo ayudo?"
GitHub: (busca CONTRIBUTING.md)

Sin CONTRIBUTING.md:

    ❌ No saben qué hacer
    ❌ Hacen PRs basura
    ❌ Rechazas todo

Con CONTRIBUTING.md:

    ✅ Contribuciones de calidad
    ✅ Menos rechazos
    ✅ Comunidad fuerte

Escenario 3: Tu Futuro Yo

En 6 meses vuelves al proyecto:
Code

Tú (futuro): "¿Cómo lanzo cambios a producción?"
Tú (presente): "Lee CONTRIBUTING.md"

Sin CONTRIBUTING.md:

    ❌ No recuerdas los pasos
    ❌ Subes código incorrecto
    ❌ Todo se rompe

Con CONTRIBUTING.md:

    ✅ Pasos claros documentados
    ✅ Evitas errores
    ✅ Productivo

📝 Qué Debe Contener CONTRIBUTING.md

Para TU PROYECTO ACTUAL, necesita:
Markdown

1. Requisitos Previos
   - Versión .NET requerida
   - Herramientas necesarias

2. Configuración Local
   - Cómo clonar
   - Cómo instalar dependencias
   - Cómo correr el proyecto

3. Workflow de Desarrollo
   - Qué rama usar
   - Cómo hacer commits
   - Naming conventions

4. Testing
   - Cómo correr tests
   - Cobertura mínima requerida

5. Antes de Push
   - Checklist
   - Code standards

6. Pull Request Process
   - Cómo hacer PR
   - Qué esperar en review

✅ CONTRIBUTING.md para tu Proyecto

Voy a crearlo. En tu Codespaces, crea el archivo CONTRIBUTING.md en la raíz (no en docs/):
🚀 Configuración Local
1. Clona el Repositorio
bash

git clone https://github.com/JesusLuis493/MomentumCalculator.git
cd MomentumCalculator

2. Abre en Codespaces o Local

Opción A: Codespaces (Recomendado)
bash

# GitHub abre automáticamente el ambiente
# En el navegador: github.dev/...

Opción B: Local
bash

code .  # Abre en Visual Studio Code

3. Restaura Dependencias
bash

dotnet restore

4. Verifica que Todo Funciona
bash

dotnet build
dotnet run --project src/MomentumCalculator.CLI

Deberías ver el menú de la calculadora.
🌿 Workflow de Desarrollo
Paso 1: Crea una Rama
bash

# Siempre desde develop
git checkout develop
git pull origin develop

# Crea rama con nombre descriptivo
git checkout -b feature/nombre-descriptivo
# O para bugs:
git checkout -b fix/descripcion-del-bug

Naming convention:

    feature/nueva-funcionalidad
    fix/nombre-del-bug
    docs/actualizacion-doc
    refactor/nombre-componente

Paso 2: Haz Cambios

Edita el código. Ejemplos:
bash

# Modificar Operaciones.cs
vim src/MomentumCalculator.Core/Operaciones.cs

# Agregar test
vim test/MomentumCalculator.Tests/OperacionesTests.cs

Paso 3: Commitea Cambios
bash

# Ver qué cambió
git status

# Agregar cambios
git add .

# Hacer commit con mensaje claro
git commit -m "feat: agregar validación de ángulos negativos"

Mensaje de commit:

    feat: Para nuevas funcionalidades
    fix: Para bugs
    docs: Para documentación
    refactor: Para limpieza de código
    test: Para agregar tests

Ejemplo de mensaje BUENO:
Code

feat: implementar CalculationResult en CompX

- Agregar modelo CalculationResult
- Refactorizar CompX para devolver CalculationResult
- Agregar validaciones de fuerza

Ejemplo de mensaje MALO:
Code

arreglo algo
cambios varios

🧪 Testing (OBLIGATORIO)
Antes de Push, Corre Tests
bash

# Corre todos los tests
dotnet test

# Corre tests de un proyecto específico
dotnet test tests/MomentumCalculator.Tests

# Corre tests con output detallado
dotnet test --verbosity detailed

# Corre tests y genera cobertura
dotnet test /p:CollectCoverage=true

Requisitos de Testing

    ✅ Mínimo 80% cobertura de código
    ✅ Todos los tests PASAN (green)
    ✅ Sin warnings en build

Escribe un Test (Ejemplo)
C#

// tests/MomentumCalculator.Tests/OperacionesTests.cs
Uso de Xunit;
Uso de MomentumCalculator.Core;

Pruebas de clase pública Operaciones
{
    [Hecho]
    public void CalcularComponentX_WithValidInput_ReturnsSuccess()
    {
        // Organizar
        Calculadora ICalculadora = nuevo Operaciones();

        // Actuar
        var resultado = calculator.CalculateComponentX(10, 45);

        // Afirmar
        Assert.True(result.Success);
        Assert.Equal(7.07, result.Value, 2);
        Assert.Equal("N", resultado.Unidad);
    }

    [Hecho]
    public void CalcularComponentX_WithZeroForce_DevolucionesFail()
    {
        // Organizar
        Calculadora ICalculadora = nuevo Operaciones();

        // Actuar
        resultado var = calculator.CalculateComponentX(0, 45);

        // Afirmar
        Assert.False(result.Success);
        Assert.Contains("error", result.Message.ToLower());
    }
}

✅ Checklist Antes de Push

Antes de hacer git push, verifica:

    dotnet build pasa sin errores
    dotnet test pasa 100%
    Sin warnings
    Cobertura >= 80%
    Commits con mensajes claros
    Rama actualizada con develop:
    bash

    git pull origin develop --rebase

    Documentación actualizada (si cambias API)
    README.md actualizado (si es cambio importante)

🔄 Pull Request (PR)
Paso 1: Sube tu Rama
bash

git push origin feature/tu-rama

Paso 2: Crea Pull Request en GitHub

    Ve a https://github.com/JesusLuis493/MomentumCalculator
    Haz clic en "Pull Requests"
    Haz clic en "New Pull Request"
    Selecciona:
        Base: develop
        Compare: feature/tu-rama
    Agrega título y descripción

Título del PR:
Code

feat: agregar validación de ángulos negativos

Descripción del PR:
Code

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

Paso 3: Espera Review

    El PM/Tech Lead revisa tu código
    Puede pedir cambios
    Una vez aprobado: ✅ Merge automático a develop

🏗️ Estándares de Código
Naming

    Clases: PascalCase - CalculationResult
    Métodos: PascalCase - CalculateComponentX()
    Variables: camelCase - forceValue, angleInDegrees
    Constantes: UPPER_SNAKE_CASE - DEG_TO_RAD

Estructura
C#

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

Documentación
C#

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

🐛 Reportar Bugs

Si encuentras un bug:

    Abre una Issue en GitHub
    Título: Descripción clara del problema
    Descripción:
    Code

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

❓ ¿Preguntas?

    Lee docs/ARCHITECTURE.md para entender la estructura
    Lee docs/TECHNICAL_NOTES.md para entender algoritmos
    Abre una Issue si tienes dudas
    Contacta al PM (@JesusLuis493)

## 📜 Licencia

Al contribuir, aceptas que tu código se comparta bajo licencia MIT.