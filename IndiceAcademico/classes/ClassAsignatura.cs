using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiceAcademico
{
    public class Asignatura
    {
        public string Clave { get; set; }

        public string Nombre { get; set; }

        public int Creditos { get; set; }

		public override string ToString()
		{
			return Nombre;
		}

		public string ToFile()
		{
			return (Clave + "," + Nombre + "," + Creditos);
		}


	}


}
