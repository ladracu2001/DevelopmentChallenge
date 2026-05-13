namespace DevelopmentChallenge.Data.Classes.Formas;

/// <summary>
/// Rectángulo con ancho y alto específicos.
/// Área = Ancho * Alto
/// Perímetro = 2 * (Ancho + Alto)
/// </summary>
public class RectanguloStrategy(decimal ancho, decimal alto) : IFormaGeometrica
{
    private readonly decimal _ancho = ancho;
    private readonly decimal _alto = alto;
    private const decimal FactorPerimetro = 2m;

    public decimal CalcularArea() => _ancho * _alto;

    public decimal CalcularPerimetro() => FactorPerimetro * (_ancho + _alto);

    public string ObtenerClaveForma() => "rectangulo";
}