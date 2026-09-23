# 📖 Notas Técnicas - MomentumCalculator


## **Lógica**

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

### 1. Cálculo de Componentes en X (CompX)

**Fórmula:** `Fuerza en x = Fuerza × coseno(Angulo°)`

```csharp
public double CompX(double F, double A)
{
    Fx = F * Math.Cos(A * Math.PI / 180);
    return Fx;
}
```

**Explicación:**
- `F` = Fuerza aplicada (magnitud)
- `A` = Ángulo respecto al eje X (en grados)
- `A * Math.PI / 180` = Conversión de grados a radianes
- `Math.Cos()` = Función coseno (proyección en X)

**Ejemplo:**
- F = 10 N, A = 45°
- Fx = 10 × cos(45°) = 10 × 0.707 = **7.07 N**

**Validaciones Necesarias:**
- ❌ F no puede ser negativo (no hay fuerza negativa)
- ❌ F no puede ser 0 (fuerza nula)
- ✅ A puede ser negativo (ángulo en sentido horario)

---

### 2. Cálculo de Componentes en Y (CompY)

**Fórmula:** `Fuerza en y = Fuerza × seno(Angulo°)`

```csharp
public double CompY(double F, double A)
{
    Fy = F * Math.Sin(A * Math.PI / 180);
    return Fy;
}
```

**Explicación:**
- Idéntica a CompX pero con `Math.Sin()`
- Sin(A) da la proyección en eje Y

**Ejemplo:**
- F = 10 N, A = 45°
- Fy = 10 × sin(45°) = 10 × 0.707 = **7.07 N**

---

### 3. Cálculo de Momentum (MomentoX)

**Fórmula:** `Momentum en x = Fuerza en x × distancia en Y`

```csharp
public double MomentoX(double dY, double Fx)
{
    return Fx * dY;
}
```

**Explicación:**
- `Fx` = Componente de fuerza en X
- `dY` = Distancia de palanca en Y
- Momentum (torque) = Fuerza × Distancia perpendicular

**Ejemplo:**
- Fx = 7.07 N, dY = 2 m
- Mx = 7.07 × 2 = **14.14 N·m** (Newton-metro)

**Validaciones Necesarias:**
- ❌ dY no puede ser 0 (sin distancia, sin momentum)

--- 

### 4. Cálculo de Momentum (MomentoY)

**Fórmula:** `Momentum en y = Fuerza en y × distancia en X`

```csharp
public double MomentoY(double dX, double Fy)
{
    return Fy * dX;
}
```

**Explicación:**
- `Fy` = Componente de fuerza en Y
- `dX` = Distancia de palanca en X
- Momentum (torque) = Fuerza × Distancia perpendicular

**Validaciones Necesarias:**
- ❌ dX no puede ser 0 (sin distancia, sin momentum)

---

### 5. Cálculo de Componente X (A partir de otro triangulo)

**Fórmula:** ` Fuerza en x = (Fuerza o hipotenusa del triangulo de referencia * (cateto adyasente / hipotenusa))`

```csharp
public double ComponeteX(double Fh, double catad, double hip1) 
{
    double Fx = (Fh * ((double)catad / hip1));
    return (Fx);
}
```

**Explicación:**
- `Fx`= Componente de fueerza en X
- `Fh`= Hipotenusa del triangulo de referencia (generalmente una fuerza)
- `catad`= Cateto adyasente
- `hip1`= Hipotenusa del triangulo

--- 

### 6. Cálculo de Componente Y (A partir de otro triangulo)

**Fórmula:** ` Fuerza en y = (Fuerza o hipotenusa del triangulo de referencia * (cateto opuesto / hipotenusa))`

```csharp
public double ComponeteX(double Fh, double catop, double hip1) 
{
    double Fy = (Fh * ((double)catop / hip1));
    return (Fy);
}
```

**Explicación:**
- `Fy`= Componente de fueerza en Y
- `Fh`= Hipotenusa del triangulo de referencia (generalmente una fuerza)
- `catop`= Cateto opuesto
- `hip1`= Hipotenusa del triangulo

--- 

### 7. Cálculo de Ángulo Resultante

**Fórmula:** `angulo = Tangente^-1(Fuerza en y / Fuerza en x)`

```csharp
public double angulo(double Frx, double Fry)
{
    ang = Math.Atan(Fry / Frx) * (180 / Math.PI);
    return ang;
}
```

**Explicación:**
- `Atan()` = Arcotangente (inversa de tangente)
- `180/π` = cinversion de radianes a grados
- Calcula el ángulo a partir de componentes X e Y
- Conversión radianes a grados

**Ejemplo:**
- Frx = 7.07 N, Fry = 7.07 N
- A = arctan(7.07 / 7.07) = arctan(1) = **45°**

**⚠️ PROBLEMA CRÍTICO:**
```
Si Frx = 0 → División por cero → ERROR ❌
```

**Solución Recomendada:**
```csharp
if (Frx == 0)
    return Fry > 0 ? 90 : -90;  // Casos especiales

return Math.Atan2(Fry, Frx) * (180 / Math.PI);  // Mejor: Atan2
```

## **Tests**

Los tests unitarios se integraron al proyecto por medio de un workflow que ejecuta la suite de tests en las labores de CI, el proyecto en total consta de 8 tests unitarios, los cuales cubren el 100% de la lógica actual de proyecto, alojada en ``Operaciones.cs``, en caso de requerise mas test se tiene previsto expandir la suite.

- **Validacion_input0()**
    - Antes de realizar cualquier calculo se realiza una verificasion para asegurar que los números ingresados no sean 0 y evitar errores de lógica.
  
- **CompX_correctCalculo()** 
    - Siguiendo la formula de ``Fx = F × cos(A°)``, se cargan valores predeterminados dentro del test para llevar acabo el calculo y detectar errores.
  
- **CompY_correctCalculo()** 
    - Siguiendo la formula de ``Fy = F × sin(A°)``, se cargan valores predeterminados dentro del test para llevar acabo el calculo y detectar errores.
  
- **MomentoX_correctCalculo()** 
    - Usando como base la formula ``Mx = Fx × dY``, se usa el mismo concepto de introducir valores desde dentro del método de test para verificar la correcta funcionalidad para el usuario.
  
- **MomentoY_correctCalculo()** 
    - Usando como base la formula ``My = Fy × dX``, se usa el mismo concepto de introducir valores desde dentro del método de test para verificar la correcta funcionalidad para el usuario.
  
- **ComponenteX_correctCalculo()** 
    - En este caso se explora una variante de calculo basada en otro método igual de relevante en problemas de física, usando como referente un triangulo de medidas ya conocidas y la formula ``Fx = F * (catAd / Hip)``.
  
- **ComponenteY_correctCalculo()** 
    - En este caso se explora una variante de calculo basada en otro método igual de relevante en problemas de física, usando como referente un triangulo de medidas ya conosidas y la formula ``Fy = F * (catOp / Hip)``.
  
- **Angulo_correctCalculo()** 
    - Utilizando valores predeterminados cargados dentro del test hace uso del método ``public double angulo`` para verificar su funcionamiento tomando como criterio un resultado pre-asignado.

## **Infrastructura**

### Configuracion global
- Espesifica el  proovedor de cloud y la version a utilizar de dicho proovedor.
``` terraform
required_providers {
    google = {
      source = "hashicorp/google"
      version = "7.17.0"
    }
  }
```
### Configuracion de proovedor (Google)
- Espesifica datos como el proyecto, la zon ay la region del proovedor de cloud.
- Dicha informacion se maneja en variables creadas en su area correspondiente.

### Variables
- Inicializa las variables de entrada requeridas para optimizar el codigo y facilitar el amtenimiento a futuro.
- Las varibelas Inicialisadas son utilizadas dentro de los bloques de configuracion y recursos.

### Recurso API
- **API :**
Delimita unicamente caul sera el id del proyecto y el recurso a ulitizar devido al uso de API.
``` terraform 
resource "google_project_service" "artifact_registry_api" {
  project = var.proyecto_id
  service = "artifactregistry.googleapis.com"
  disable_on_destroy = false
}
``` 

### Recursos de infra
- **Artifacts :**
Uso de artifact registry para mejorar y complementar el uso de contenedores docker, aprovicionando un entorno de almacenamiento reproducible para las imagenes docker.

### Recurso para correr
- **Cloud :**
Hace uso de un servidor de google cloud, del tipo V2 mediante un contenedor de docker en el cual hace uso del API mediante el puerto establecido para accesar al codigo y llevar acabo las labores de CI/CD.


---

## 📌 Deuda Técnica Actual

| Problema | Prioridad | Solución |
|----------|-----------|----------|
| Sin validaciones estructuradas | 🔴 CRÍTICA | Implementar CalculationResult |
| Manejo de errores con try/catch | 🟡 ALTA | Uso de Result objects |
| Sin logging | 🟡 ALTA | Integrar ILogger |
| Sin versionamiento de API | 🟡 MEDIA | Documentar versión actual |

---

## 🚀 Siguientes Pasos

1. ✅ Completar este documento
2. ⏳ Implementar CalculationResult
3. ⏳ Refactorizar Operaciones.cs con ICalculator
4. ⏳ Crear tests unitarios con casos críticos
5. ⏳ Agregar logging
6. ⏳ API REST con validaciones
7. ⏳ CI/CD con code coverage
