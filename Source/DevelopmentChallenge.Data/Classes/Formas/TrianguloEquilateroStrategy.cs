using System;

namespace DevelopmentChallenge.Data.Classes.Formas;

public class TrianguloEquilateroStrategy(decimal lado) : IFormaGeometrica
{
    private readonly decimal _lado = lado;
    private const decimal CantidadLados = 3m;

    public decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;

    public decimal CalcularPerimetro() => _lado * CantidadLados;

    public string ObtenerClaveForma() => "triangulo";
}