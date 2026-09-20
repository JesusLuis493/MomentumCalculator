# Estado actual - MomentumCalculator

## 1. Resumen general
**Versión:** 1.1.0
**Ultima actualizacion:** 2026-09-20

Este proyecto se encuentra en preparacion para dar el siguiente paso a produccion, anteriormente se establecio de manera solida el apartado de **Logica**, **Tests**, y **Documentacion** en la version `1.0.0`, desde entonses se agregaron mas apartados para subir a produccion, hasta el momento solo se tiene preparativos parciales de `Docker` y `Terraform`, Miestras se esta en proseso de actualizacion de documentacion para que coinsida con el estado actual del proyecto.

--- 
## 2. Estado por componente
| Componente        | Estado      | Notas                                  |
|-------------------|-------------|-----------------------------------------|
| Core (lógica)     | ✅ Completo | 6 formulas fisicas + validacion de resultados|
| CLI               | ✅ Completo | ...                                     |
| API (ASP.NET Core)| ✅ Completo | Swagger configurado                     |
| Tests             | ✅ Completo | Cobertura 100% (dentro de la logica)|
| Docker            | 🟡 Parcial  | Imagen construida, falta probar local   |
| Terraform / IaC   | 🟡 Parcial  | main.tf sin terminar para [proveedor]   |
| CI/CD (deploy)    | 🔴 Pendiente| Solo build+test automatizado            |
| Documentación     | 🟡 En progreso | Este mismo archivo                   |

--- 
## 3. Desiciones tomadas
| Decisión                  | Fecha | Motivo |
|----------------------------|-------|--------|
| Proveedor de nube: [Google]|24-12-2025|Free Tier|
| Auditoria y consultoria: [Mantenimiento]|20-90-2026|Abandono general |
| Limpieza tecnica: [bin/ obj/]|24-12-2025|Conflictos en git push|

--- 

## 4. Problemas conocidos / deuda técnica
- [ ] Estructuracion defisiente del contenedor docker
- [ ] Documentacion desactualizada
- [ ] Estado dudoso del workflow
- [ ] Abandono en `Main.tf`

---

## 5. Próximos pasos
1. Actualizar `CURRENT_STATES`
2. Revisar y corregir `ARCHITECTURE.md`
3. Trabajar la capa de Infrastructura

## 6. Métricas rápidas
- Commits: 82
- Cobertura de tests: 100%
- Issues abiertos: 1
- Última build en CI: ✅

