namespace DevelopmentChallenge.Data.Classes.Reportes;

public class GeneradorReporteIngles : GeneradorReporte
{
    protected override string ObtenerTituloVacio() => "Empty list of shapes!";

    protected override string ObtenerTituloReporte() => "Shapes report";

    protected override string ObtenerTextoFormas(int cantidad) => "shapes";

    protected override string ObtenerTextoPerimetro() => "Perimeter";

    protected override string TraducirForma(string claveForma, int cantidad)
    {
        return claveForma switch
        {
            "cuadrado" => cantidad == 1 ? "Square" : "Squares",
            "circulo" => cantidad == 1 ? "Circle" : "Circles",
            "triangulo" => cantidad == 1 ? "Triangle" : "Triangles",
            "trapecio" => cantidad == 1 ? "Trapezoid" : "Trapezoids",
            "rectangulo" => cantidad == 1 ? "Rectangle" : "Rectangles",
            _ => "",
        };
    }
}