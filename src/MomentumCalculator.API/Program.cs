// ═══════════════════════════════════════════════════════════════
// Program.cs - El punto de entrada de tu API
// Aquí se configura TODO:  servicios, rutas, middleware, etc. 
// ═══════════════════════════════════════════════════════════════

var builder = WebApplication. CreateBuilder(args);

// ┌─────────────────────────────────────────────────────────────┐
// │ PASO 1: Registrar servicios (dependencias)                  │
// │ Todo lo que tu API necesita para funcionar                  │
// └─────────────────────────────────────────────────────────────┘

// Agregar controllers (los que manejan las peticiones HTTP)
builder.Services.AddControllers();

// Agregar documentación automática (Swagger) - útil para probar tu API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ┌─────────────────────────────────────────────────────────────┐
// │ PASO 2: Construir la aplicación                             │
// └─────────────────────────────────────────────────────────────┘

var app = builder.Build();

// ┌─────────────────────────────────────────────────────────────┐
// │ PASO 3: Configurar el pipeline de HTTP                      │
// │ (qué pasa con cada petición que llega)                      │
// └─────────────────────────────────────────────────────────────┘

// Si estamos en desarrollo, mostrar Swagger (interfaz visual para probar)
if (app.Environment. IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirigir HTTP a HTTPS (seguridad)
app.UseHttpsRedirection();

// Habilitar los controllers para que reciban peticiones
app.MapControllers();

// ┌─────────────────────────────────────────────────────────────┐
// │ PASO 4: ¡Arrancar el servidor!                              │
// └─────────────────────────────────────────────────────────────┘

app.Run();  // La API empieza a escuchar en http://localhost:5000