using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndiceAcademico.classes;

namespace IndiceAcademico
{
    public class IndiceCalc
    {
        public double ValorNota(Calificacion calificacion)
        {
            double nota = 0;
            if (calificacion.Nota >= 90.00 && calificacion.Nota <= 100.00)
             {
               nota = 4;
            }
            else if (calificacion.Nota >= 85.00 && calificacion.Nota < 90.00 )
            {
               nota = 3.5;
            }
            else if (calificacion.Nota >= 80 && calificacion.Nota < 85)
            {
                nota = 3;

            }
            else if (calificacion.Nota >= 75 && calificacion.Nota < 80)
            {
                nota = 2.5;
            }
            else if (calificacion.Nota >= 70 && calificacion.Nota < 75)
            {
                nota = 2;
            }

            else if (calificacion.Nota >= 60 && calificacion.Nota < 70)
            {
                nota = 1;
            }

            else if (calificacion.Nota < 60)
            {
                nota = 0;
            }

            return nota;

        }

		public string LetraNota(Calificacion calificacion)
		{
			string letra = "";

			if (ValorNota(calificacion) == 4)
				letra = "A";
			if (ValorNota(calificacion) == 3.5)
				letra = "B+";
			if (ValorNota(calificacion) == 3)
				letra = "B";
			if (ValorNota(calificacion) == 2.5)
				letra = "C+";
			if (ValorNota(calificacion) == 2)
				letra = "C";
			if (ValorNota(calificacion) == 1)
				letra = "D";
			if (ValorNota(calificacion) == 0)
				letra = "F";

			return letra;
		}

        public double CalcularPuntosHonor(Calificacion calificacion)
        {
            double nota = ValorNota(calificacion);
            double creditos = ObtenerCreditos(calificacion);
            nota = creditos * nota;

            return nota;
        }


        public double ObtenerCreditos(Calificacion calificacion)
        {
            double creditos = calificacion.Asignatura.Creditos;
            creditos = Convert.ToDouble(creditos);
            return creditos;
        }


		public double CalcularIndice(Estudiante estudiante)
		{
			int totalCreditos = 0;
			double totalPuntos = 0;
			foreach(var calificacion in estudiante.Calificaciones)
			{
				totalCreditos += calificacion.Asignatura.Creditos;
				totalPuntos += CalcularPuntosHonor(calificacion);
			}

			return totalPuntos / (double)totalCreditos;
		}
	}
}
