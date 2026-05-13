namespace DevelopmentChallenge.Data.Classes.Formas;

public class CuadradoStrategy(decimal lado) : IFormaGeometrica
{
    private readonly decimal _lado = lado;
    private const decimal CantidadLados = 4m;

    public decimal CalcularArea() => _lado * _lado;

    public decimal CalcularPerimetro() => _lado * CantidadLados;

    public string ObtenerClaveForma() => "cuadrado";
}