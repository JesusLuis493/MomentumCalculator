#!/usr/bin/env bash
set -u

echo "Ejecutando tests unitarios"
echo "=========================="
echo ""

PASSED=0
FAILED=0
RESULTS_DIR="TestResults"
mkdir -p "$RESULTS_DIR"

UNIT_TESTS_PROJECT="test/MomentumCalculator.Tests.csproj"
INTEGRATION_TESTS_PROJECT="test/MomentumCalculator.API.Tests/MomentumCalculator.API.Tests.csproj"

run_tests()
{
    local test_project=$1
    local test_name=$2

    echo "Ejecutando: $test_name"

    # Generar reporte TRX
    if dotnet test "$test_project" \
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
run_tests "$UNIT_TESTS_PROJECT" "Tests Unitarios"

#ejecutando tests de integracion
echo "Ejecutando tests de integracion"
echo "=========================="
echo ""

run_tests "$INTEGRATION_TESTS_PROJECT" "Tests de Integracion"
# Resumen final
echo "=========================="
echo "Resultados de los tests de integracion"
echo "Pasaron:  $PASSED"
echo "Fallaron: $FAILED"
echo "Total: $((PASSED + FAILED))"
echo ""

if [ $FAILED -eq 0 ]; then
    echo "✅ Todos los tests de integracion pasaron"
    exit 0
else
    echo "❌ Algunos tests de integracion fallaron.  Revisa los logs arriba"
    exit 1
fi
