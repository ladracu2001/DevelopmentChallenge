# Development Challenge - Refactorización con Patrones de Diseño

## Resumen de Cambios

Este proyecto ha sido refactorizado implementando dos patrones de diseño clave para mejorar la extensibilidad y mantenibilidad:

### 1. **Patrón Strategy** - Para las formas geométricas
- **Interfaz**: `IFormaGeometrica`
  - Métodos: `CalcularArea()`, `CalcularPerimetro()`, `ObtenerClaveForma()`
- **Implementaciones concretas**:
  - `CuadradoStrategy`
  - `CirculoStrategy`
  - `TrianguloEquilateroStrategy`
  - `TrapecioStrategy` *(Nuevo)* - Trapecio isósceles con 4 parámetros
  - `RectanguloStrategy` *(Nuevo)* - Rectángulo con ancho y alto

**Ventaja**: Agregar una nueva forma solo requiere implementar `IFormaGeometrica`, sin modificar código existente.

### 2. **Patrón Template Method** - Para generación de reportes
- **Clase base abstracta**: `GeneradorReporte`
  - Define el algoritmo común del reporte
  - Deja "hooks" para personalización por idioma
- **Implementaciones concretas**:
  - `GeneradorReporteCastellano`
  - `GeneradorReporteIngles`
  - `GeneradorReporteItaliano` *(Nuevo)*
  - `GeneradorReporteRosarigasino` *(Nuevo)*

**Ventaja**: Agregar un idioma solo requiere crear una subclase, sin duplicar lógica del reporte.

## Nuevas Características

### Formas Geométricas Agregadas
1. **Trapecio Isósceles** (`FormaTipo.Trapecio = 4`)
  - Constructor: `new FormaGeometrica(FormaTipo.Trapecio, baseMayor, baseMenor, altura, lado)`
   - Área: `(BaseMayor + BaseMenor) × Altura / 2`
   - Perímetro: `BaseMayor + BaseMenor + 2 × Lado`

2. **Rectángulo** (`FormaTipo.Rectangulo = 5`)
  - Constructor: `new FormaGeometrica(FormaTipo.Rectangulo, ancho, alto)`
   - Área: `Ancho × Alto`
   - Perímetro: `2 × (Ancho + Alto)`

### Idiomas Agregados
- **Italiano** (`Classes/Parametricas/Idioma.cs`)
- **Rosarigasino** (`Classes/Parametricas/Idioma.cs`)
  - Traducciones completas de títulos, formas y etiquetas en estilo rosarigasino
  - Casos cubiertos para listas vacías, mezclas de formas y reportes con nuevas figuras

## Archivo de Pruebas Unitarias

**Ubicación**: `Source/DevelopmentChallenge.Data.Tests/DataTests.cs`

**Nuevos tests añadidos**:
- `TestResumenListaVaciaFormasEnItaliano` - Validar lista vacía en italiano
- `TestResumenListaVaciaFormasEnRosarigasino` - Validar lista vacía en rosarigasino
- `TestTrapecioIsosCastellano` - Validar cálculo de trapecio
- `TestRectanguloIngles` - Validar cálculo de rectángulo
- `TestMezclaFormasNuevasItaliano` - Validar mezcla de formas en italiano
- `TestResumenListaConMasTiposEnRosarigasino` - Validar reporte mixto en rosarigasino

**Resultado**: ✅ **13 tests definidos en el proyecto actual**

## Compilación y Ejecución

### Compilar
```bash
dotnet build Source/DevelopmentChallenge.sln -c Debug
```

### Ejecutar Tests
```bash
# Opción recomendada: ejecuta todos los tests con dotnet
dotnet test Source/DevelopmentChallenge.sln -c Debug

# Opción alternativa: desde VS Code (Ctrl+Shift+B) o Terminal > Run Task
```

## Estructura de Archivos

```
Source/
├── DevelopmentChallenge.Data/
│   ├── Classes/
│   │   ├── FormaGeometrica.cs (Contexto del Strategy, coordina el reporte)
│   │   ├── IFormaGeometrica.cs (Interfaz Strategy)
│   │   ├── CuadradoStrategy.cs
│   │   ├── CirculoStrategy.cs
│   │   ├── TrianguloEquilateroStrategy.cs
│   │   ├── TrapecioStrategy.cs (NUEVO)
│   │   ├── RectanguloStrategy.cs (NUEVO)
│   │   ├── GeneradorReporte.cs (Clase base Template Method)
│   │   ├── GeneradorReporteCastellano.cs
│   │   ├── GeneradorReporteIngles.cs
│   │   └── GeneradorReporteItaliano.cs (NUEVO)
│   └── DevelopmentChallenge.Data.csproj
├── DevelopmentChallenge.Data.Tests/
│   └── DataTests.cs (13 tests unitarios)
└── DevelopmentChallenge.sln
```

## Principios de Diseño Aplicados

- ✅ **Single Responsibility Principle (SRP)**: Cada estrategia y cada generador tiene una única responsabilidad
- ✅ **Open/Closed Principle (OCP)**: Abierto para extensión (nuevas formas/idiomas), cerrado para modificación
- ✅ **Liskov Substitution Principle (LSP)**: Todas las estrategias son intercambiables vía `IFormaGeometrica`
- ✅ **Dependency Inversion**: Las clases dependen de abstracciones (`IFormaGeometrica`, `GeneradorReporte`)

## Notas de Implementación

- El proyecto usa **.NET 8.0**
- El código se apoya en las capacidades modernas del lenguaje disponibles en el target actual
- Se usa `CultureInfo.CurrentCulture` para formato de decimales (respeta configuración de locale)
- Todos los tests de backward-compatibility se mantienen pasando sin cambios en la API pública

---

**Fecha**: Mayo 12, 2026  
**Versión**: 1.0.0 (Refactorización con Patrones)
