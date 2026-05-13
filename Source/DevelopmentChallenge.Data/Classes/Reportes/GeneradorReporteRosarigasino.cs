namespace DevelopmentChallenge.Data.Classes.Reportes;

public class GeneradorReporteRosarigasino : GeneradorReporte
{
    protected override string ObtenerTituloVacio() => "Lista vacígasía de formas!";

    protected override string ObtenerTituloReporte() => "Reporte de Formas";

    protected override string ObtenerTextoFormas(int cantidad) => "formas";

    protected override string ObtenerTextoPerimetro() => "Perimetro";

    protected override string TraducirForma(string claveForma, int cantidad)
    {
        return claveForma switch
        {
            "cuadrado" => cantidad == 1 ? "Cuadrado" : "Cuadrados",
            "circulo" => cantidad == 1 ? "Cígasírculo" : "Cígasírculos",
            "triangulo" => cantidad == 1 ? "Triágasángulo" : "Triágasángulos",
            "trapecio" => cantidad == 1 ? "Trapecio" : "Trapecios",
            "rectangulo" => cantidad == 1 ? "Rectágasángulo" : "Rectágasángulos",
            _ => "",
        };
    }
}