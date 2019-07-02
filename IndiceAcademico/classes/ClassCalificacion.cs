using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiceAcademico
{
    public class Calificacion
    {
        public double Nota { get; set; }

        public Asignatura Asignatura { get; set; }

		public string ToFile()
		{
			return Convert.ToString(Nota) + "," + Asignatura.Nombre;
		}
        /*
         Si public Asignatura asignatura no sirve, pues use:
         public string Asignatura {get; set;}
         */

        /*
         por si se necesita agregar una propiedad de Estudiante:
         
        public Estudiante estudiante {get; set;}

        o

        public string EstudianteNombre{get; set;}
        */
        
    }
}
