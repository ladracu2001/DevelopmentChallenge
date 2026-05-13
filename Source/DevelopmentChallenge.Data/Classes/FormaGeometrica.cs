using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes.Factories;
using DevelopmentChallenge.Data.Classes.Formas;
using DevelopmentChallenge.Data.Classes.Parametricas;
using DevelopmentChallenge.Data.Classes.Reportes;

namespace DevelopmentChallenge.Data.Classes;

public class FormaGeometrica
{
    private readonly IFormaGeometrica _estrategia;

    public FormaGeometrica(FormaTipo tipo, decimal ancho)
    {
        _estrategia = FormaStrategyFactory.Crear(tipo, ancho);
    }

    public FormaGeometrica(FormaTipo tipo, decimal param1, decimal param2, decimal param3 = 0, decimal param4 = 0)
    {
        _estrategia = FormaStrategyFactory.Crear(tipo, param1, param2, param3, param4);
    }

    public decimal CalcularArea() => _estrategia.CalcularArea();

    public decimal CalcularPerimetro() => _estrategia.CalcularPerimetro();

    public string ObtenerClaveForma() => _estrategia.ObtenerClaveForma();

    public static void RegistrarForma(FormaTipo tipoForma, Func<decimal[], IFormaGeometrica> creador) => FormaStrategyFactory.Registrar(tipoForma, creador);

    public static void RegistrarIdioma(Idioma idioma, Func<GeneradorReporte> creador) => GeneradorReporteFactory.Registrar(idioma, creador);

    public static string Imprimir(List<FormaGeometrica> formas, Idioma idioma)
    {
        var generador = GeneradorReporteFactory.Crear(idioma);
        return generador.Generar(formas);
    }
}