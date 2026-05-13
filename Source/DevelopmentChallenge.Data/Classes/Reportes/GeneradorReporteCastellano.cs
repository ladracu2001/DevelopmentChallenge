namespace DevelopmentChallenge.Data.Classes.Reportes;

public class GeneradorReporteCastellano : GeneradorReporte
{
    protected override string ObtenerTituloVacio() => "Lista vacía de formas!";

    protected override string ObtenerTituloReporte() => "Reporte de Formas";

    protected override string ObtenerTextoFormas(int cantidad) => "formas";

    protected override string ObtenerTextoPerimetro() => "Perimetro";

    protected override string TraducirForma(string claveForma, int cantidad)
    {
        return claveForma switch
        {
            "cuadrado" => cantidad == 1 ? "Cuadrado" : "Cuadrados",
            "circulo" => cantidad == 1 ? "Círculo" : "Círculos",
            "triangulo" => cantidad == 1 ? "Triángulo" : "Triángulos",
            "trapecio" => cantidad == 1 ? "Trapecio" : "Trapecios",
            "rectangulo" => cantidad == 1 ? "Rectángulo" : "Rectángulos",
            _ => "",
        };
    }
}