using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace IndiceAcademico
{
	/// <summary>
	/// Interaction logic for AgregarEstudiante.xaml
	/// </summary>
	public partial class AgregarEstudiante : Window
	{

		public static int GetID()
		{
			int temp = 1;
			foreach (var line in File.ReadLines(EstudiantesWindow.filepathEs).Skip(1))
			{
				var data = line.Split(',');
				if (data.Length == 3)
				{
					temp = Convert.ToInt16(data[0]);
				}
			}
			return temp + 1;
		}

		static int idCounter = 1;

		public AgregarEstudiante()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{

			if (File.Exists(EstudiantesWindow.filepathEs))
			{
				idCounter = GetID();
			}
			else
			{
				string[] lines = { "ID,Nombre,Carrera" };
				File.AppendAllLines(EstudiantesWindow.filepathEs, lines);
			}

			Estudiante estudiante = new Estudiante { ID = idCounter++, Nombre = inputNombre.Text, Carrera = inputCarrera.Text };
			EstudiantesWindow.estudiantesLST.Add(estudiante);
			string[] line = { estudiante.ToFile() };
			File.AppendAllLines(EstudiantesWindow.filepathEs, line);

			this.Close();

		}
	}
}
