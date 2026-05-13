using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes.Parametricas;
using DevelopmentChallenge.Data.Classes.Reportes;

namespace DevelopmentChallenge.Data.Classes.Factories;

public static class GeneradorReporteFactory
{
    private static readonly Dictionary<Idioma, Func<GeneradorReporte>> Registro = [];

    static GeneradorReporteFactory()
    {
        Registrar(Idioma.Castellano, () => new GeneradorReporteCastellano());
        Registrar(Idioma.Ingles, () => new GeneradorReporteIngles());
        Registrar(Idioma.Italiano, () => new GeneradorReporteItaliano());
        Registrar(Idioma.Rosarigasino, () => new GeneradorReporteRosarigasino());
    }

    public static void Registrar(Idioma idioma, Func<GeneradorReporte> creador)
    {
        ArgumentNullException.ThrowIfNull(creador);

        Registro[idioma] = creador;
    }

    public static GeneradorReporte Crear(Idioma idioma)
    {
        if (!Registro.TryGetValue(idioma, out var creador))
            throw new ArgumentOutOfRangeException(nameof(idioma), "Idioma desconocido");
     
        return creador();
    }
}