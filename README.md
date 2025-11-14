# MomentumCalculator 🧮

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-purple.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)

Proyecto educativo desarrollado en C# para simplificar cálculos físicos básicos relacionados con la descomposición de fuerzas y el cálculo de momentum, diseñado para estudiantes de física y ciencias relacionadas.

## 📋 Tabla de Contenidos

- [Descripción](#-descripción)
- [Características](#-características)
- [Motivación](#-motivación)
- [Requisitos Previos](#-requisitos-previos)
- [Instalación](#-instalación)
- [Uso](#-uso)
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

## 🧠 Motivación

Como estudiante de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de México, Campus Nochistlán, desarrollé este proyecto personal para abordar una necesidad práctica en mis estudios de física. La motivación principal fue crear una herramienta confiable y rápida para validar cálculos manuales, reduciendo errores y tiempo invertido en operaciones matemáticas repetitivas. Este esfuerzo combina aprendizaje teórico con aplicación práctica, fomentando el desarrollo de habilidades en programación y resolución de problemas.

## 🔧 Requisitos Previos

- **Sistema Operativo**: Compatible con Windows, macOS o Linux.
- **.NET SDK**: Versión 8.0 o superior. Descárgalo desde [dotnet.microsoft.com](https://dotnet.microsoft.com/download).
- **Git**: Para clonar el repositorio (opcional, pero recomendado).

## 🚀 Instalación

1. **Clona el repositorio**:
   ```bash
   git clone https://github.com/JesusLuis493/MomentumCalculator.git
   cd MomentumCalculator
   ```

2. **Restaura las dependencias**:
   ```bash
   dotnet restore
   ```

3. **Compila el proyecto** (opcional, ya que `dotnet run` lo hace automáticamente):
   ```bash
   dotnet build
   ```

## 📖 Uso

Ejecuta la aplicación desde la terminal:

```bash
dotnet run
```

La aplicación presenta un menú interactivo con las siguientes opciones:

1. **Descomposición de Fuerzas**: Ingresa magnitud y ángulo para obtener componentes X e Y.
2. **Cálculo de Momentum**: Proporciona masa, velocidad y distancia de palanca.
3. **Triángulos Auxiliares**: Utiliza geometría para cálculos alternativos.
4. **Determinación de Ángulos**: Calcula ángulo a partir de componentes.

Sigue las instrucciones en pantalla para ingresar datos y obtener resultados. La aplicación valida entradas y proporciona retroalimentación educativa.

### Ejemplo de Salida

```
Bienvenido a MomentumCalculator
Selecciona una opción:
1. Descomponer fuerza
2. Calcular momentum
3. Usar triángulo auxiliar
4. Calcular ángulo
5. Salir

Opción: 1
Ingresa la magnitud de la fuerza: 100
Ingresa el ángulo en grados: 30

Componente X: 86.60
Componente Y: 50.00
```

## 📂 Estructura del Proyecto

```
MomentumCalculator/
├── .github/
│   └── workflows/
│       └── dotnet.yml          # Configuración de CI/CD con GitHub Actions
├── bin/
│   └── Debug/net8.0/           # Archivos compilados (generados automáticamente)
├── obj/                        # Archivos de objeto (generados automáticamente)
├── .gitignore                  # Archivos ignorados por Git
├── LICENSE                     # Licencia del proyecto
├── MomentumF.csproj            # Archivo de proyecto .NET
├── MomentumF.sln               # Solución de Visual Studio
├── Operaciones.cs              # Lógica de cálculos matemáticos y físicos
├── Program.cs                  # Punto de entrada y menú principal
└── README.md                   # Esta documentación
```

## 🛠️ Tecnologías Utilizadas

- **Lenguaje de Programación**: C# 12.0
- **Framework**: .NET 8.0 (SDK)
- **Entorno de Desarrollo**: Visual Studio Code en Linux Mint
- **Control de Versiones**: Git
- **CI/CD**: GitHub Actions (workflow básico para compilación y pruebas)

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
- **Correo Electrónico**: [jemanuelluisandoval@gmail.com]

---
