namespace DevelopmentChallenge.Data.Classes.Formas;

/// <summary>
/// Interfaz Strategy para representar diferentes formas geométricas.
/// Cada forma implementa su propia lógica de cálculo de área y perímetro.
/// </summary>
public interface IFormaGeometrica
{
    /// <summary>Calcula el área de la forma.</summary>
    decimal CalcularArea();

    /// <summary>Calcula el perímetro de la forma.</summary>
    decimal CalcularPerimetro();

    /// <summary>Retorna la clave (identificador) de la forma para traducciones.</summary>
    string ObtenerClaveForma();
}