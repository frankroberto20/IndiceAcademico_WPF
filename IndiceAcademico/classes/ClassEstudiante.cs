using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiceAcademico
{
    public class Estudiante
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Carrera { get; set; }

		public List<Calificacion> Calificaciones;

		public override string ToString()
		{
			return Nombre;
		}

		public string ToFile()
		{
			return (ID + "," + Nombre + "," + Carrera);
		}

		public string ToUser()
		{
			return ("E" + "," + ID + "_" + Nombre.Replace(" ", "").ToLower() + "," + "4321"); 
		}

		public Estudiante()
		{
			Calificaciones = new List<Calificacion>();
		}
	}
}
