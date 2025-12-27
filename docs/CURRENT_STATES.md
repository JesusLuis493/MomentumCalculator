# Estado actual - MomentumCalculator

## Funcionalidad actual
**Versión:** 1.0.0
**Fecha:** 2025-12-27

Este documento describe el estado actual del proyecto `MomentumCalculator`, detallando la funcionalidad implementada, la cobertura de pruebas y el estado de la documentación técnica.

- [Lógica](#-Logica)
- [Tests](#-Test)
- [Documentación](#-Documentacion)
--- 

### Lógica

La versión `1.0.0` establece la base de la calculadora, permitiendo a los usuarios realizar cálculos de momento y componentes de fuerza a partir de datos de entrada.
El núcleo de la aplicación, contenido en `Operaciones.cs`, implementa las siguientes fórmulas físicas:

-   **Cálculo de Componentes de Fuerza (usando ángulo):**
    -   `Fx = F × cos(A°)`
    -   `Fy = F × sin(A°)`
-   **Cálculo de Componentes de Fuerza (usando triángulo notable):**
    -   `Fx = F * (Cateto Adyacente / Hipotenusa)`
    -   `Fy = F * (Cateto Opuesto / Hipotenusa)`
-   **Cálculo de Momento:**
    -   `Mx = Fx × dY`
    -   `My = Fy × dX`
-   **Cálculo de Ángulo.**
-   **Validación de Entradas:** Se asegura que los valores de entrada no sean cero para prevenir errores de cálculo y lógicos.

--- 

### Tests

Los tests unitarios se integraron al proyecto por medio de un workflow que ejecuta la suite de tests en las labores de CI, el proyecto en total consta de 8 tests unitarios, los cuales cubren el 100% de la lógica actual de proyecto, alojada en ``Operaciones.cs``, esto garantiza una detección mas eficiente en errores de calculo al momento del despliegue y abre la posibilidad a expandir la suite de testing, asegurando la escalabilidad desde el punto de vista técnico.

### UnitTests
- ``Validacion_input0()`` : Antes de realizar cualquier calculo se realiza una verificasion para asegurar que los números ingresados no sean 0 y evitar errores de lógica.
- ``CompX_correctCalculo()`` : Siguiendo la formula de ``Fx = F × cos(A°)``, se cargan valores predeterminados dentro del test para llevar acabo el calculo y detectar errores.
- ``CompY_correctCalculo()`` : Siguiendo la formula de ``Fy = F × sin(A°)``, se cargan valores predeterminados dentro del test para llevar acabo el calculo y detectar errores.
- ``MomentoX_correctCalculo()`` : Usando como base la formula ``Mx = Fx × dY``, se usa el mismo concepto de introducir valores desde dentro del método de test para verificar la correcta funcionalidad para el usuario.
- ``MomentoY_correctCalculo()`` : Usando como base la formula ``My = Fy × dX``, se usa el mismo concepto de introducir valores desde dentro del método de test para verificar la correcta funcionalidad para el usuario.
- ``ComponenteX_correctCalculo()`` : En este caso se explora una variante de calculo basada en otro método igual de relevante en problemas de física, usando como referente un triangulo de medidas ya conocidas y la formula ``Fx = F * (catAd / Hip)``.
- ``ComponenteY_correctCalculo()`` : En este caso se explora una variante de calculo basada en otro método igual de relevante en problemas de física, usando como referente un triangulo de medidas ya conosidas y la formula ``Fy = F * (catOp / Hip)``.
- ``Angulo_correctCalculo()`` : Utilizando valores predeterminados cargados dentro del test hace uso del método ``public double angulo`` para verificar su funcionamiento tomando como criterio un resultado pre-asignado.

--- 

### Documentación 

El apartado de la documentación es algo vital dentro de cualquier proyecto, tomando en cuenta las necesidades del colaborador al llegar al proyecto, se esta trvajando en actualizar y corregir documentos, los cuales son clave para el correcto entendimiento de todo el proyecto.
Los documentos a continuación serán revisados y adaptados, debido a que su implementación data de una fase muy temprana del proyecto, por ende estan desactualizados y caresen de serias inconsistencias debido a la refactorizacion pre-producción.

### Documentos a corregir
- ``TECHNICAL_NOTES.md`` : Carencia de información referente al funcionamiento interno de la lógica.
- ``ARCHITECTURE.md`` :  Revisión y adaptación de información presentada.
