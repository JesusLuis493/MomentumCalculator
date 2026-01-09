# 📡 API REST - MomentumCalculator

Documentación de los endpoints disponibles en la API.

## 🌐 Base URL

```
Desarrollo: http://localhost:5277/api
Producción: https://tu-dominio.com/api
```

---

## 📋 Endpoints Disponibles

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/health` | Health check |
| `POST` | `/api/fuerza/componentes` | Calcula componentes X e Y |
| `POST` | `/api/momentum/x` | Calcula momentum en eje X |
| `POST` | `/api/momentum/y` | Calcula momentum en eje Y |
| `POST` | `/api/triangulo/componentes` | Componentes usando triángulo |
| `POST` | `/api/triangulo/angulo` | Calcula ángulo resultante |

---

## 🏥 Health Check

Verifica que la API está funcionando.  Usado por Terraform, Load Balancers y sistemas de monitoreo. 

### Request

```http
GET /api/health
```

### Response

```json
{
  "status": "healthy",
  "timestamp": "2026-01-09T15:30:00Z",
  "version": "1.0.0"
}
```

| Campo | Tipo | Descripción |
|-------|------|-------------|
| `status` | string | Estado de la API |
| `timestamp` | datetime | Hora del servidor (UTC) |
| `version` | string | Versión de la API |

---

## 💪 Fuerza

### POST /api/fuerza/componentes

Calcula los componentes X e Y de una fuerza dado su magnitud y ángulo.

**Fórmulas:**
- `Fx = F * cos(θ)`
- `Fy = F * sin(θ)`

### Request

```http
POST /api/fuerza/componentes
Content-Type: application/json
```

```json
{
  "fuerza": 100,
  "angulo": 45
}
```

| Campo | Tipo | Requerido | Descripción |
|-------|------|-----------|-------------|
| `fuerza` | double | ✅ | Magnitud de la fuerza (N) |
| `angulo` | double | ✅ | Ángulo en grados |

### Response (200 OK)

```json
{
  "componenteX": 70. 7107,
  "componenteY": 70.7107,
  "success": true,
  "error": null
}
```

### Response (400 Bad Request)

```json
{
  "componenteX": 0,
  "componenteY": 0,
  "success": false,
  "error": "La fuerza no puede ser negativa"
}
```

---

## 🔄 Momentum

### POST /api/momentum/x

Calcula el momentum en el eje X. 

**Fórmula:** `Mx = dY * Fx`

### Request

```http
POST /api/momentum/x
Content-Type: application/json
```

```json
{
  "distanciaY": 5,
  "fuerzaX": 20
}
```

| Campo | Tipo | Requerido | Descripción |
|-------|------|-----------|-------------|
| `distanciaY` | double | ✅ | Distancia en eje Y (m) |
| `fuerzaX` | double | ✅ | Fuerza en eje X (N) |

### Response (200 OK)

```json
{
  "momentum": 100,
  "eje":  "X",
  "success": true,
  "error":  null
}
```

---

### POST /api/momentum/y

Calcula el momentum en el eje Y. 

**Fórmula:** `My = dX * Fy`

### Request

```http
POST /api/momentum/y
Content-Type: application/json
```

```json
{
  "distanciaX":  3,
  "fuerzaY": 15
}
```

| Campo | Tipo | Requerido | Descripción |
|-------|------|-----------|-------------|
| `distanciaX` | double | ✅ | Distancia en eje X (m) |
| `fuerzaY` | double | ✅ | Fuerza en eje Y (N) |

### Response (200 OK)

```json
{
  "momentum": 45,
  "eje": "Y",
  "success":  true,
  "error": null
}
```

---

## 📐 Triángulo

### POST /api/triangulo/componentes

Calcula componentes X e Y usando relaciones de triángulo. 

**Fórmulas:**
- `Fx = F * (cateto_adyacente / hipotenusa)`
- `Fy = F * (cateto_opuesto / hipotenusa)`

### Request

```http
POST /api/triangulo/componentes
Content-Type: application/json
```

```json
{
  "fuerzaTotal": 50,
  "catetoAdyacente": 3,
  "catetoOpuesto": 4,
  "hipotenusa": 5
}
```

| Campo | Tipo | Requerido | Descripción |
|-------|------|-----------|-------------|
| `fuerzaTotal` | double | ✅ | Fuerza resultante (N) |
| `catetoAdyacente` | double | ✅ | Cateto adyacente |
| `catetoOpuesto` | double | ✅ | Cateto opuesto |
| `hipotenusa` | double | ✅ | Hipotenusa (≠ 0) |

### Response (200 OK)

```json
{
  "componenteX": 30,
  "componenteY": 40,
  "success":  true,
  "error": null
}
```

### Response (400 Bad Request)

```json
{
  "componenteX": 0,
  "componenteY": 0,
  "success": false,
  "error": "La hipotenusa no puede ser 0"
}
```

---

### POST /api/triangulo/angulo

Calcula el ángulo resultante dado las fuerzas en X e Y.

**Fórmula:** `θ = arctan(Fy / Fx)` (convertido a grados)

### Request

```http
POST /api/triangulo/angulo
Content-Type: application/json
```

```json
{
  "fuerzaResultanteX": 30,
  "fuerzaResultanteY": 40
}
```

| Campo | Tipo | Requerido | Descripción |
|-------|------|-----------|-------------|
| `fuerzaResultanteX` | double | ✅ | Componente X (≠ 0) |
| `fuerzaResultanteY` | double | ✅ | Componente Y |

### Response (200 OK)

```json
{
  "angulo": 53.1301,
  "unidad": "grados",
  "success":  true,
  "error": null
}
```

### Response (400 Bad Request)

```json
{
  "angulo": 0,
  "unidad": "grados",
  "success": false,
  "error": "FuerzaResultanteX no puede ser 0"
}
```

---

## 🔴 Códigos de Estado HTTP

| Código | Significado | Cuándo ocurre |
|--------|-------------|---------------|
| `200` | OK | Operación exitosa |
| `400` | Bad Request | Datos de entrada inválidos |
| `404` | Not Found | Endpoint no existe |
| `500` | Server Error | Error interno del servidor |

---

## 🧪 Ejemplos con cURL

### Health Check

```bash
curl http://localhost:5277/api/health
```

### Calcular Componentes de Fuerza

```bash
curl -X POST http://localhost:5277/api/fuerza/componentes \
  -H "Content-Type: application/json" \
  -d '{"fuerza":  100, "angulo": 45}'
```

### Calcular Momentum X

```bash
curl -X POST http://localhost:5277/api/momentum/x \
  -H "Content-Type:  application/json" \
  -d '{"distanciaY": 5, "fuerzaX":  20}'
```

### Calcular Ángulo

```bash
curl -X POST http://localhost:5277/api/triangulo/angulo \
  -H "Content-Type: application/json" \
  -d '{"fuerzaResultanteX":  30, "fuerzaResultanteY": 40}'
```

---

## 🛠️ Swagger UI

Para explorar la API interactivamente:

```
http://localhost:5277/swagger
```

---

## 📝 Notas

- Todos los ángulos están en **grados** (no radianes)
- Los resultados se redondean a **4 decimales**
- El campo `success` indica si la operación fue exitosa
- El campo `error` contiene el mensaje de error (si aplica)