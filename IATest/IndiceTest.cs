using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndiceAcademico;

namespace IATest
{
    [TestClass]
    public class IndiceTest
    {
        [TestClass]
        public class ManejoNotas
        {
            [TestMethod]
            public void ValorNota_Test()
            {
                IndiceCalc index = new IndiceCalc();
                Calificacion cal = new Calificacion();
                cal.Nota = 90.00;
                double expected = 4;
                double value = index.ValorNota(cal);

                Assert.AreEqual(value, expected);

            }

            [TestMethod]
            public void LetraNota_Test()
            {
                IndiceCalc index = new IndiceCalc();
                Calificacion cal = new Calificacion();
                cal.Nota = 80.00;
                string letraNota = index.LetraNota(cal);
                string expected = "B";

                Assert.AreEqual(letraNota, expected);

            }

        }
        [TestClass]
        public class Calculos
        {
            [TestMethod]
            public void CalcularPuntosHonor_Test()
            {
                IndiceCalc index = new IndiceCalc();
                Calificacion cal = new Calificacion();
                Asignatura asignatura = new Asignatura { Creditos = 4 };

                cal.Asignatura = asignatura;
                cal.Nota = 86.00;

                double value = index.CalcularPuntosHonor(cal);
                double expected = 14;

                Assert.AreEqual(value, expected);

            }

            [TestMethod]
            public void ObtenerCreditos_Test()
            {
                IndiceCalc index = new IndiceCalc();
                Calificacion cal1 = new Calificacion();
                Asignatura asignatura = new Asignatura() { Creditos = 4 };

                cal1.Asignatura = asignatura;


                double expected = 4;
                double value = index.ObtenerCreditos(cal1);


                Assert.AreEqual(value, expected);

            }

            [TestMethod]
            public void ClasificarHonor_Test()
            {
                Estudiante est = new Estudiante();
                IndiceCalc index = new IndiceCalc();
                Asignatura asignatura = new Asignatura() { Creditos = 4 };
                Calificacion cal1 = new Calificacion() { Nota = 90, Asignatura = asignatura };
                est.Calificaciones.Add(cal1);

                string resultadoEsperado = "Summa Cum Laude";
                string honor;

                honor = index.ClasificarHonor(est);
                Assert.AreEqual(honor, resultadoEsperado);

            }



        }
    }
}
