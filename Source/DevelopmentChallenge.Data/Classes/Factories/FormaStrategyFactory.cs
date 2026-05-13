using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes.Formas;
using DevelopmentChallenge.Data.Classes.Parametricas;

namespace DevelopmentChallenge.Data.Classes.Factories;

public static class FormaStrategyFactory
{
    private static readonly Dictionary<FormaTipo, Func<decimal[], IFormaGeometrica>> Registro = [];

    static FormaStrategyFactory()
    {
        Registrar(FormaTipo.Cuadrado, parametros => new CuadradoStrategy(parametros[0]));
        Registrar(FormaTipo.Circulo, parametros => new CirculoStrategy(parametros[0]));
        Registrar(FormaTipo.TrianguloEquilatero, parametros => new TrianguloEquilateroStrategy(parametros[0]));
        Registrar(FormaTipo.Trapecio, parametros => new TrapecioStrategy(parametros[0], parametros[1], parametros[2], parametros[3]));
        Registrar(FormaTipo.Rectangulo, parametros => new RectanguloStrategy(parametros[0], parametros[1]));
    }

    public static void Registrar(FormaTipo tipoForma, Func<decimal[], IFormaGeometrica> creador)
    {
        ArgumentNullException.ThrowIfNull(creador);

        Registro[tipoForma] = creador;
    }

    public static IFormaGeometrica Crear(FormaTipo tipoForma, params decimal[] parametros)
    {
        if (!Registro.TryGetValue(tipoForma, out var creador))
            throw new ArgumentOutOfRangeException(nameof(tipoForma), "Tipo de forma desconocida");
        
        return creador(parametros ?? []);
    }
}