namespace DevelopmentChallenge.Data.Classes.Reportes;

public class GeneradorReporteItaliano : GeneradorReporte
{
    protected override string ObtenerTituloVacio() => "Elenco vuoto di forme!";

    protected override string ObtenerTituloReporte() => "Rapporto di forme";

    protected override string ObtenerTextoFormas(int cantidad) => "forme";

    protected override string ObtenerTextoPerimetro() => "Perimetro";

    protected override string TraducirForma(string claveForma, int cantidad)
    {
        return claveForma switch
        {
            "cuadrado" => cantidad == 1 ? "Quadrato" : "Quadrati",
            "circulo" => cantidad == 1 ? "Cerchio" : "Cerchi",
            "triangulo" => cantidad == 1 ? "Triangolo" : "Triangoli",
            "trapecio" => cantidad == 1 ? "Trapezio" : "Trapezi",
            "rectangulo" => cantidad == 1 ? "Rettangolo" : "Rettangoli",
            _ => "",
        };
    }
}