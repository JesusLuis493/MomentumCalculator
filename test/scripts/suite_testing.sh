#!/usr/bin/env bash
set -u

echo "Ejecutando tests unitarios"
echo "=========================="
echo ""

PASSED=0
FAILED=0
RESULTS_DIR="TestResults"
mkdir -p "$RESULTS_DIR"

run_tests()
{
    local test_category=$1
    local test_name=$2

    echo "Ejecutando: $test_name"

    # Generar reporte TRX
    if dotnet test \
        --filter "Category=$test_category" \
        --logger "trx;LogFileName=${test_name// /_}. trx" \
        --results-directory "$RESULTS_DIR" \
        --no-build; then
        ((PASSED++))
        echo "✅ $test_name PASÓ"
    else
        ((FAILED++))
        echo "❌ $test_name FALLÓ"
    fi

    echo ""
}

# Ejecutando tipos de tests
run_tests "Unit" "Tests Unitarios"

# Resumen final
echo "=========================="
echo "Resultados de los tests"
echo "Pasaron:  $PASSED"
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
