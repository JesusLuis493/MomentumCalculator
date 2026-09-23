# MomentumCalculator 🧮

[![Build & test .NET app](https://github.com/JesusLuis493/MomentumCalculator/workflows/Build%20&%20test%20.NET%20app/badge.svg)](https://github.com/JesusLuis493/MomentumCalculator/actions)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-purple.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Terraform](https://img.shields.io/badge/Terraform-1.x-7B42BC.svg)](https://www.terraform.io/)
[![Docker](https://img.shields.io/badge/Docker-27.x-2496ED.svg)](https://www.docker.com/)

Proyecto educativo desarrollado en C# para simplificar cálculos físicos básicos relacionados con la descomposición de fuerzas y el cálculo de momentum, diseñado para estudiantes de física y ciencias relacionadas.

## 📋 Tabla de Contenidos

- [Descripción](#-descripción)
- [Características](#-Características)
- [Motivación](#-motivación)
- [Requisitos Previos](#-requisitos-previos)
- [Instalación](#-instalación)
- [Estructura del Proyecto](#-estructura-del-proyecto)
- [Tecnologías Utilizadas](#-tecnologías-utilizadas)
- [Contribuciones](#-contribuciones)
- [Licencia](#-licencia)
- [Autor](#-autor)
- [Contacto](#-contacto)

## 📌 Descripción

MomentumCalculator es una aplicación de consola desarrollada con el objetivo de agilizar y facilitar cálculos físicos elementales. Permite la descomposición de fuerzas en sus componentes cartesianas (X e Y) utilizando ángulos e hipotenusas, así como el cálculo de momentum lineal considerando distancias de palanca. Incluye funcionalidades adicionales como la determinación de ángulos a partir de componentes y el uso de triángulos auxiliares para cálculos alternativos.

Este proyecto refleja conocimientos adquiridos en cursos de Física General y Estructura de Datos, sirviendo como herramienta práctica para validar resultados y ahorrar tiempo en operaciones repetitivas.

## ⚙️ Características

- **Descomposición de Fuerzas**: Calcula componentes X e Y de una fuerza dada su magnitud y ángulo.
- **Cálculo de Momentum**: Determina el momentum en direcciones X e Y utilizando distancias de palanca.
- **Triángulos Auxiliares**: Opción para cálculos utilizando geometría triangular.
- **Determinación de Ángulos**: Calcula el ángulo de una fuerza a partir de sus componentes cartesianas.
- **Interfaz Intuitiva**: Menú de consola claro y educativo, con validación de entradas.
- **Notas Importantes**: Incluye advertencias sobre el alcance limitado del software (no resuelve problemas físicos completos ni determina sentidos de fuerzas automáticamente).

## 📋 Resumen: Stack Final
Código:        C# / .NET 8                                   
API:           ASP.NET Core + Swagger                                                             
Tests:         xUnit + suite_testing.sh                               
CI/CD:         GitHub Actions                                          
Infra:         Terraform                       
Contenedor:    Docker
Cloud:         Google Cloud (Free Tier)                                         
Monitoreo:     Health endpoint + logs nativos                                     

## 🧠 Motivación

Este proyecto fue creado **100% por mí** como estudiante del Instituto Tecnológico de México, Campus Nochistlán. Surge de la necesidad de tener una herramienta rápida y confiable para validar cálculos durante clases, tareas o prácticas. Está pensado para estudiantes que buscan **automatizar cálculos básicos sin depender de software complejo**.

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
## 🚀 Instalación

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
---

## 🚀 Ejecución

Para correr el programa desde la terminal:

```bash
dotnet run
```
---

## 📂 Estructura del proyecto

```
MomentumCalculator/
├── .github/
│   └── workflows/
│       └── dotnet.yml                    # Pipeline de CI/CD (GitHub Actions)
│
├── docs/                                 # Documentación técnica
│   ├── API_DESSIGN.md
│   ├── ARCHITECTURE.md
│   ├── CONTRIBUTING.md
│   ├── CURRENT_STATES.md
│   └── TECHNICAL_NOTES.md
│
├── infrastructure
│   └── terraform
│       └── main.tf
│
├── src/
│   ├── MomentumCalculator.API/
│   │  │
│   │  ├── Controllers/                   # Reciben las peticiones HTTP
│   │  │   ├── FuerzaController. cs
│   │  │   ├── HealthController.cs
│   │  │   ├── MomentumController.cs
│   │  │   └── TrianguloController.cs
│   │  │
│   │  ├── Models/                        # Definen estructura de datos
│   │  │   ├── FuerzaModels.cs
│   │  │   ├── MomentumModels.cs
│   │  │   └── TrianguloModels.cs
│   │  │
│   │  ├── Properties/
│   │  │   └── LaunchSettings.json
│   │  │
│   │  └── MomentumCalculator.API.csproj  # Configuración del proyecto
│   │
│   ├── MomentumCalculator.CLI/          
│   │   ├── MomentumCalculator.CLI.csproj
│   │   └── Program.cs                         # Menús y entrada de usuario por terminal
│   │
│   └── MomentumCalculator.Core/
│       ├── MomentumCalculator.Core.csproj
│       └── Operaciones.cs                    # Clase principal con algoritmos
│
├── test/
│   ├── MomentumCalculator.API.Tests/
│   │   ├── GlobalUsings.cs
│   │   ├── IntegrationTests.cs
│   │   └── MomentumCalculator.API.Tets.csproj
│   │
│   ├── MomentumCalculator.Tests/
│   │   └── Unit_Tests.cs
│   │
│   ├── scripts/
│   │   ├── TestsResults/
│   │   └── suite_testing.sh
│   │
│   └── MomentumCalculator.Tests.csproj
│
├── .dockerignore
├── .gitignore
├── dockerfile
├── LICENSE
├── MomentumCalculator.sln                # Solución que agrupa todos los proyectos
└── README.md
``` 
---

## 🧰 Tecnologías utilizadas

- **Lenguaje de Programación**: C# 12.0
- **Framework**: .NET 8.0 (SDK)
- **Entorno de Desarrollo**: Visual Studio Code en Linux base Debian
- **Control de Versiones**: Git
- **CI/CD**: GitHub Actions (workflow básico para compilación y pruebas)
- **Infraestructura**: Terraform (IaC)

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas! Este proyecto es educativo y abierto a mejoras. Áreas de interés incluyen:

- Mejora en la validación de entradas de usuario.
- Implementación de visualizaciones gráficas (e.g., diagramas de fuerzas).
- Expansión a otras operaciones físicas (e.g., cinemática, energía).
- Traducciones a otros idiomas.
- Optimización del código y mejores prácticas.

Para contribuir:

1. Haz un fork del repositorio.
2. Crea una rama para tu feature (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y commitea (`git commit -am 'Agrega nueva funcionalidad'`).
4. Haz push a la rama (`git push origin feature/nueva-funcionalidad`).
5. Abre un Pull Request.

## 📜 Licencia

Este proyecto está licenciado bajo la [Licencia MIT](LICENSE). Consulta el archivo `LICENSE` para más detalles. Eres libre de usar, modificar y distribuir este software, siempre y cuando se incluya el aviso de copyright original.

## 👤 Autor

**Jesus Emmanuel Luis Sandoval**  
Estudiante de Ingeniería en Sistemas Computacionales  
Instituto Tecnológico de México, Campus Nochistlán  

Apasionado por el desarrollo de software, DevOps, scripting y la accesibilidad tecnológica. Este proyecto forma parte de mi portafolio personal.

## 📞 Contacto

- **GitHub**: [JesusLuis493](https://github.com/JesusLuis493)
- **Correo Electrónico**: [jesusluis.dev@gmail.com]