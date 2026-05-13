using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Classes.Parametricas;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir([], Idioma.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir([], Idioma.Ingles));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                FormaGeometrica.Imprimir([], Idioma.Italiano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnRosarigasino()
        {
            Assert.AreEqual("<h1>Lista vacígasía de formas!</h1>",
                FormaGeometrica.Imprimir([], Idioma.Rosarigasino));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new(FormaTipo.Cuadrado, 5)};

            var resumen = FormaGeometrica.Imprimir(cuadrados, Idioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadradosEnIngles()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new(FormaTipo.Cuadrado, 5),
                new(FormaTipo.Cuadrado, 1),
                new(FormaTipo.Cuadrado, 3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, Idioma.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnIngles()
        {
            var formas = new List<FormaGeometrica>
            {
                new(FormaTipo.Cuadrado, 5),
                new(FormaTipo.Circulo, 3),
                new(FormaTipo.TrianguloEquilatero, 4),
                new(FormaTipo.Cuadrado, 2),
                new(FormaTipo.TrianguloEquilatero, 9),
                new(FormaTipo.Circulo, 2.75m),
                new(FormaTipo.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Circles | Area 13,01 | Perimeter 18,06 <br/>2 Squares | Area 29 | Perimeter 28 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new(FormaTipo.Cuadrado, 5),
                new(FormaTipo.Circulo, 3),
                new(FormaTipo.TrianguloEquilatero, 4),
                new(FormaTipo.Cuadrado, 2),
                new(FormaTipo.TrianguloEquilatero, 9),
                new(FormaTipo.Circulo, 2.75m),
                new(FormaTipo.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>2 Cuadrados | Area 29 | Perimetro 28 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new(FormaTipo.Cuadrado, 5),
                new(FormaTipo.Circulo, 3),
                new(FormaTipo.TrianguloEquilatero, 4),
                new(FormaTipo.Cuadrado, 2),
                new(FormaTipo.TrianguloEquilatero, 9),
                new(FormaTipo.Circulo, 2.75m),
                new(FormaTipo.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto di forme</h1>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>2 Quadrati | Area 29 | Perimetro 28 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 forme Perimetro 97,66 Area 91,65",
                resumen);
        }
        [TestCase]
        public void TestResumenListaConMasTiposEnRosarigasino()
        {
            var formas = new List<FormaGeometrica>
            {
                new(FormaTipo.Cuadrado, 5),
                new(FormaTipo.Circulo, 3),
                new(FormaTipo.TrianguloEquilatero, 4),
                new(FormaTipo.Cuadrado, 2),
                new(FormaTipo.TrianguloEquilatero, 9),
                new(FormaTipo.Circulo, 2.75m),
                new(FormaTipo.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Rosarigasino);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cígasírculos | Area 13,01 | Perimetro 18,06 <br/>2 Cuadrados | Area 29 | Perimetro 28 <br/>3 Triágasángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }
        [TestCase]
        public void TestTrapecioIsosCastellano()
        {
            // Trapecio isósceles: BaseMayor=10, BaseMenor=6, Altura=5, Lado=5
            var trapecios = new List<FormaGeometrica>
            {
                new(FormaTipo.Trapecio, 10, 6, 5, 5)
            };

            var resumen = FormaGeometrica.Imprimir(trapecios, Idioma.Castellano);

            // Área = (10 + 6) * 5 / 2 = 40
            // Perímetro = 10 + 6 + 2*5 = 26
            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Area 40 | Perimetro 26 <br/>TOTAL:<br/>1 formas Perimetro 26 Area 40", resumen);
        }

        [TestCase]
        public void TestRectanguloIngles()
        {
            // Rectángulo: Ancho=8, Alto=6
            var rectangulos = new List<FormaGeometrica>
            {
                new(FormaTipo.Rectangulo, 8, 6)
            };

            var resumen = FormaGeometrica.Imprimir(rectangulos, Idioma.Ingles);

            // Área = 8 * 6 = 48
            // Perímetro = 2 * (8 + 6) = 28
            Assert.AreEqual("<h1>Shapes report</h1>1 Rectangle | Area 48 | Perimeter 28 <br/>TOTAL:<br/>1 shapes Perimeter 28 Area 48", resumen);
        }

        [TestCase]
        public void TestMezclaFormasNuevasItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new(FormaTipo.Trapecio, 8, 4, 4, 4),
                new(FormaTipo.Rectangulo, 5, 3),
                new(FormaTipo.Cuadrado, 2)
            };

            var resumen = FormaGeometrica.Imprimir(formas, Idioma.Italiano);

            // Trapecio: Area=(8+4)*4/2=24, Perímetro=8+4+2*4=20
            // Rectángulo: Area=5*3=15, Perímetro=2*(5+3)=16
            // Cuadrado: Area=2*2=4, Perímetro=2*4=8
            // Total: 3 forme, Perimetro=44, Area=43
            Assert.IsNotEmpty(resumen);
            Assert.IsTrue(resumen.Contains("Rapporto di forme"));
            Assert.IsTrue(resumen.Contains("1 Trapezi"));
            Assert.IsTrue(resumen.Contains("1 Rettangolo"));
            Assert.IsTrue(resumen.Contains("1 Quadrato"));
        }
    }
}