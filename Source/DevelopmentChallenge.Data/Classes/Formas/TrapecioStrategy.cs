namespace DevelopmentChallenge.Data.Classes.Formas;

/// <summary>
/// Trapecio isósceles con base mayor, base menor, altura y lados iguales.
/// Área = (BaseMayor + BaseMenor) * Altura / 2
/// Perímetro = BaseMayor + BaseMenor + 2 * Lado
/// </summary>
public class TrapecioStrategy(decimal baseMayor, decimal baseMenor, decimal altura, decimal lado) : IFormaGeometrica
{
    private readonly decimal _baseMayor = baseMayor;
    private readonly decimal _baseMenor = baseMenor;
    private readonly decimal _altura = altura;
    private readonly decimal _lado = lado;
    private const decimal CantidadLadosIguales = 2m;

    public decimal CalcularArea() => (_baseMayor + _baseMenor) * _altura / CantidadLadosIguales;

    public decimal CalcularPerimetro() => _baseMayor + _baseMenor + CantidadLadosIguales * _lado;

    public string ObtenerClaveForma() => "trapecio";
}