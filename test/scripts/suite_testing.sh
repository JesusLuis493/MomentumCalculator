#!/usr/bin/env bash
# Suite para ejecutar todos los tipos de tests

set -u  # Error si usamos variables no definidas
set -e  # Salir si hay errores (opcional, depende de tu flujo)

echo "Ejecutando tests unitarios"
echo "=========================="
echo ""

TEST_DIR="$(dirname "$0")"
PASSED=0
FAILED=0

run_tests()
{
    local test_category=$1
    local test_name=$2

    echo "Ejecutando: $test_name"

    # Usar dotnet test con filtros
    if dotnet test --filter "Category=$test_category" --logger "console;verbosity=minimal" --no-build; then
        ((PASSED++))
        echo "✅ $test_name PASÓ"
    else
        ((FAILED++))
        echo "❌ $test_name FALLÓ"
    fi

    echo ""
}

# Asegurar que el proyecto esté compilado
echo "🔨 Compilando proyecto..."
if !  dotnet build --configuration Release; then
    echo "❌ Error al compilar el proyecto"
    exit 1
fi
echo ""

# Ejecutando tipos de tests
run_tests "Unit" "Tests Unitarios"
# Puedes agregar más categorías: 
# run_tests "Integration" "Tests de Integración"
# run_tests "Performance" "Tests de Rendimiento"

# Resumen final
echo "=========================="
echo "Resultados de los tests"
echo "Pasaron: $PASSED"
echo "Fallaron: $FAILED"
echo "Total: $((PASSED + FAILED))"
echo ""

if [ $FAILED -eq 0 ]; then
    echo "✅ Todos los tests pasaron"
    exit 0
else
    echo "❌ Algunos tests fallaron.  Revisa los logs arriba"
    exit 1
fi