using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IndiceAcademico.mainwindows;

namespace IndiceAcademico.classes
{
	public class ManejoArchivo
	{
		public string FilePath{ get; set; }

		public void RecuperarLista(List<Estudiante> lista)
		{
			foreach (var line in File.ReadLines(FilePath).Skip(1))
			{
				var data = line.Split(',');
				if (data.Length == 3)
				{
					Estudiante est = new Estudiante { ID = Convert.ToInt32(data[0]), Nombre = data[1], Carrera = data[2] };
					lista.Add(est);
				}

			}
		}

		public void RecuperarLista(List<Profesor> lista)
		{
			foreach (var line in File.ReadLines(FilePath).Skip(1))
			{
				var data = line.Split(',');
				if (data.Length == 2)
				{
					Profesor pro = new Profesor { ID = Convert.ToInt32(data[0]), Nombre = data[1]};
					lista.Add(pro);
				}

			}
		}

		public void RecuperarLista(List<Asignatura> lista)
		{
			foreach (var line in File.ReadLines(FilePath).Skip(1))
			{
				var data = line.Split(',');
				if (data.Length == 3)
				{
					Asignatura asi = new Asignatura { Clave = data[0], Nombre = data[1], Creditos = Convert.ToInt32(data[2]) };
					lista.Add(asi);
				}

			}
		}
		public void RecuperarLista(List<Calificacion> lista)
		{

			foreach (var line in File.ReadLines(FilePath).Skip(1))
			{
				var data = line.Split(',');

				if (data.Length == 2)
				{
					Calificacion cal = new Calificacion { Nota = Convert.ToDouble(data[0]), Asignatura = AsignaturasWindow.asignaturasLST.Find(a => a.Nombre == data[1])};
					lista.Add(cal);
				}

			}
		}

		public int GetID()
		{
			int temp = 1;
			foreach (var line in File.ReadLines(FilePath).Skip(1))
			{
				var data = line.Split(',');
				if (data.Length == 3)
				{
					temp = Convert.ToInt16(data[0]);
				}
			}
			return temp + 1;
		}

		public int GetIDProfesor()
		{
			int temp = 1;
			foreach (var line in File.ReadLines(FilePath).Skip(1))
			{
				var data = line.Split(',');
				if (data.Length == 2)
				{
					temp = Convert.ToInt16(data[0]);
				}
			}
			return temp + 1;
		}

		public void OverWriteFile(List<Estudiante> list)
		{
			string[] datos = new string[list.Count];
			int counter = 0;
			foreach (var estudiante in list)
			{
				datos[counter++] = estudiante.ToFile();
			}
			string[] header = { "ID,Nombre,Carrera" };
			File.WriteAllLines(FilePath, header);
			File.AppendAllLines(FilePath, datos);
		}
		public void OverWriteFile(List<Profesor> list)
		{
			string[] datos = new string[list.Count];
			int counter = 0;
			foreach (var profesor in list)
			{
				datos[counter++] = profesor.ToFile();
			}
			string[] header = { "ID,Nombre" };
			File.WriteAllLines(FilePath, header);
			File.AppendAllLines(FilePath, datos);
		}

		public void OverWriteFile(List<Asignatura> list)
		{
			string[] datos = new string[list.Count];
			int counter = 0;
			foreach (var asignatura in list)
			{
				datos[counter++] = asignatura.ToFile();
			}
			string[] header = { "Clave,Nombre,Creditos" };
			File.WriteAllLines(FilePath, header);
			File.AppendAllLines(FilePath, datos);
		}

		public void OverWriteFile(List<Calificacion> list)
		{
			string[] datos = new string[list.Count];
			int counter = 0;
			foreach (var calificacion in list)
			{
				datos[counter++] = calificacion.ToFile();
			}
			string[] header = { "Nota,Asignatura" };
			File.WriteAllLines(FilePath, header);
			File.AppendAllLines(FilePath, datos);
		}

		public ManejoArchivo(string filepath)
		{
			FilePath = filepath;
		}

		public ManejoArchivo() { }

	}
}
