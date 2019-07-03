using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiceAcademico
{
    public class Profesor
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

		public override string ToString()
		{
			return Nombre;
		}

		public string ToFile()
		{
			return (ID + "," + Nombre);
		}

		public string ToUser()
		{
			return ("P" + "," + ID + "_" + Nombre.Replace(" ", "").ToLower() + "," + "1234");
		}
	}
}
