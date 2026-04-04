# 📖 Notas Técnicas - MomentumCalculator

## Análisis de Algoritmos Actuales

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
## **8. Infrastructura**

### Configuracion global
- Espesifica el  proovedor de cloud y la version a utilizar de dicho proovedor.

### Configuracion de proovedor (Google)
- Espesifica datos como el proyecto, la zon ay la region del proovedor de cloud.
- Dicha informacion se maneja en variables creadas en su area correspondiente.

### Variables
- Inicializa las variables de entrada requeridas para optimizar el codigo y facilitar el amtenimiento a futuro.
- Las varibelas Inicialisadas son utilizadas dentro de los bloques de configuracion y recursos.

### Recurso API
- **API :**
Delimita unicamente caul sera el id del proyecto y el recurso a ulitizar devido al uso de API.

### Infrastructura
- **Artifacts :**
Uso de artifact registry para mejorar y complementar el uso de contenedores docker, aprovicionando un entorno de almacenamiento reproducible para las imagenes docker.

### Recurso para correr
- **Cloud :**
Hace uso de un servidor de google cloud, del tipo V2 mediante un contenedor de docker en el cual hace uso del API mediante el puerto establecido para accesar al codigo y llevar acabo las labores de CI/CD.

### Outputs

---

## 🔧 Optimizaciones Propuestas

### Optimización 1: Cachear Constante PI/180

**Problema Actual:**
```csharp
double Fx = F * Math.Cos(A * Math.PI / 180);  // Calcula π/180 cada vez
```

**Solución:**
```csharp
private const double DEG_TO_RAD = Math.PI / 180;
private const double RAD_TO_DEG = 180 / Math.PI;

public double CompX(double F, double A)
{
    return F * Math.Cos(A * DEG_TO_RAD);
}
```

**Beneficio:** ⚡ 2-3% más rápido (menos operaciones de punto flotante)

---

### Optimización 2: Usar Math.Atan2 en Lugar de Atan

**Problema Actual:**
```csharp
Math.Atan(Fry / Frx)  // Falla si Frx = 0
```

**Solución:**
```csharp
Math.Atan2(Fry, Frx)  // Maneja todos los cuadrantes automáticamente
```

**Beneficio:** ✅ Sin divisiones por cero, ✅ Ángulos en rango correcto (-π, π)

---

### Optimización 3: Validación Temprana

**Problema Actual:**
```csharp
public double CompX(double F, double A)
{
    return F * Math.Cos(A * Math.PI / 180);  // Valida al final
}
```

**Solución:**
```csharp
public CalculationResult CalculateComponentX(double force, double angle)
{
    if (force <= 0)
        return new CalculationResult(false, 0, "Fuerza debe ser > 0", "");
    
    if (angle < 0 || angle > 360)
        return new CalculationResult(false, 0, "Ángulo fuera de rango [0, 360]", "");
    
    double fx = force * Math.Cos(angle * DEG_TO_RAD);
    return new CalculationResult(true, fx, "Éxito", "N");
}
```

**Beneficio:** ✅ Errores claros, ✅ Fail-fast, ✅ No throws innecesarios

---

## 🎯 Precisión Numérica

### Problema: Errores de Punto Flotante

```csharp
// Ejemplo
double a = 0.1 + 0.2;
Console.WriteLine(a);  // Output: 0.30000000000000004 ❌
```

**Solución:**
```csharp
// Redondear a N decimales
public double Round(double value, int decimals = 2)
{
    return Math.Round(value, decimals);
}

// Uso
double result = Round(7.0714285714285714, 2);  // 7.07 ✅
```

**Recomendación:** Redondear a 2-3 decimales en resultados.

---

## 🧪 Casos de Prueba Críticos

### Caso 1: Valores Positivos Válidos
```
Input:  F=10, A=45°
Output: Fx=7.07, Fy=7.07 ✅
```

### Caso 2: Ángulo = 0°
```
Input:  F=10, A=0°
Output: Fx=10, Fy=0 ✅ (Fuerza pura en X)
```

### Caso 3: Ángulo = 90°
```
Input:  F=10, A=90°
Output: Fx≈0, Fy=10 ✅ (Fuerza pura en Y)
```

### Caso 4: Valor Cero (DEBE FALLAR)
```
Input:  F=0, A=45°
Output: Error ❌ (Fuerza nula)
```

### Caso 5: Valores Negativos (DEBE FALLAR)
```
Input:  F=-5, A=45°
Output: Error ❌ (Fuerza negativa)
```

---

## 📊 Complejidad Computacional

| Método | Complejidad | Operaciones |
|--------|-------------|-------------|
| CompX | O(1) | 1 multiplicación, 1 cos |
| CompY | O(1) | 1 multiplicación, 1 sin |
| MomentoX | O(1) | 1 multiplicación |
| Angulo | O(1) | 1 división, 1 atan, 1 multiplicación |

**Conclusión:** ✅ Todas son O(1) - Excelente para cualquier escala

---

## 🔐 Seguridad de Tipos

**Actual (C# - Seguro):**
```csharp
public double CompX(double F, double A)  // Tipos explícitos
```

**Problema (Python - No tipado):**
```python
def CompX(F, A):  # ¿Qué tipo es F?
    return F * math.cos(A * math.pi / 180)
```

**Ventaja C#:** Compilador previene errores de tipo en tiempo de compilación.

---

## 📌 Deuda Técnica Actual

| Problema | Prioridad | Solución |
|----------|-----------|----------|
| Sin validaciones estructuradas | 🔴 CRÍTICA | Implementar CalculationResult |
| Manejo de errores con try/catch | 🟡 ALTA | Uso de Result objects |
| Sin tests | 🔴 CRÍTICA | Crear suite de tests |
| Sin logging | 🟡 ALTA | Integrar ILogger |
| Métodos con nombres inconsistentes | 🟡 MEDIA | Refactorizar nombres (CompX → CalculateComponentX) |
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
