using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes.Reportes;

/// <summary>
/// Clase base abstracta que implementa el patrón Template Method.
/// Define el algoritmo común para generar reportes, dejando los detalles
/// de localización (textos) a las subclases.
/// </summary>
public abstract class GeneradorReporte
{
    public string Generar(List<FormaGeometrica> formas)
    {
        var sb = new StringBuilder();

        if (formas.Count == 0)
            sb.Append($"<h1>{ObtenerTituloVacio()}</h1>");
        else
        {
            sb.Append($"<h1>{ObtenerTituloReporte()}</h1>");

            // Agrupar formas por clave
            var gruposFormas = formas
                .GroupBy(f => f.ObtenerClaveForma())
                .OrderBy(g => g.Key)
                .ToList();

            decimal perimetroTotal = 0m;
            decimal areaTotal = 0m;

            foreach (var grupo in gruposFormas)
            {
                var cantidad = grupo.Count();
                var area = grupo.Sum(f => f.CalcularArea());
                var perimetro = grupo.Sum(f => f.CalcularPerimetro());

                sb.Append(ObtenerLinea(cantidad, area, perimetro, grupo.Key));

                perimetroTotal += perimetro;
                areaTotal += area;
            }

            sb.Append("TOTAL:<br/>");
            sb.Append($"{formas.Count} {ObtenerTextoFormas(formas.Count)} ");
            sb.Append($"{ObtenerTextoPerimetro()} {FormatearDecimal(perimetroTotal)} ");
            sb.Append($"Area {FormatearDecimal(areaTotal)}");
        }

        return sb.ToString();
    }

    /// <summary>
    /// Hook para obtener el título cuando la lista está vacía.
    /// </summary>
    protected abstract string ObtenerTituloVacio();

    /// <summary>
    /// Hook para obtener el título del reporte.
    /// </summary>
    protected abstract string ObtenerTituloReporte();

    /// <summary>
    /// Hook para obtener el texto "formas" o "shapes" según idioma.
    /// </summary>
    protected abstract string ObtenerTextoFormas(int cantidad);

    /// <summary>
    /// Hook para obtener el texto "Perímetro" o "Perimeter" según idioma.
    /// </summary>
    protected abstract string ObtenerTextoPerimetro();

    /// <summary>
    /// Hook para traducir el nombre de la forma (ej: "cuadrado" → "Cuadrado" o "Cuadrados").
    /// </summary>
    protected abstract string TraducirForma(string claveForma, int cantidad);

    /// <summary>
    /// Genera la línea de una forma específica en el reporte.
    /// </summary>
    private string ObtenerLinea(int cantidad, decimal area, decimal perimetro, string claveForma)
    {
        if (cantidad > 0)
        {
            var nombreForma = TraducirForma(claveForma, cantidad);
            return $"{cantidad} {nombreForma} | Area {FormatearDecimal(area)} | {ObtenerTextoPerimetro()} {FormatearDecimal(perimetro)} <br/>";
        }

        return string.Empty;
    }

    /// <summary>
    /// Formatea un número decimal respetando la cultura del sistema.
    /// Usa coma como separador decimal si está configurado.
    /// </summary>
    protected static string FormatearDecimal(decimal valor) => valor.ToString("0.##", CultureInfo.CurrentCulture);
}