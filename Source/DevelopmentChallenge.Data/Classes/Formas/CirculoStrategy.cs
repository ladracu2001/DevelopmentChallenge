using System;

namespace DevelopmentChallenge.Data.Classes.Formas;

public class CirculoStrategy(decimal diametro) : IFormaGeometrica
{
    private readonly decimal _diametro = diametro;
    private const decimal FactorDiametroARadio = 2m;

    public decimal CalcularArea() => (decimal)Math.PI * (_diametro / FactorDiametroARadio) * (_diametro / FactorDiametroARadio);

    public decimal CalcularPerimetro() => (decimal)Math.PI * _diametro;

    public string ObtenerClaveForma() => "circulo";
}