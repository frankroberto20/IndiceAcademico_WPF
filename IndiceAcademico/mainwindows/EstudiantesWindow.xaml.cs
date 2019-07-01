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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IndiceAcademico.editwindows;
using IndiceAcademico.classes;
using System.IO;

namespace IndiceAcademico
{
	/// <summary>
	/// Interaction logic for EstudiantesWindow.xaml
	/// </summary>
	public partial class EstudiantesWindow : UserControl
	{

		public static List<Estudiante> estudiantesLST = new List<Estudiante>();
		public static string filepathEs = "Estudiantes.csv";

		public static void RecuperarLista()
		{
			foreach (var line in File.ReadLines(filepathEs).Skip(1))
			{
				var data = line.Split(',');
				if (data.Length == 3)
				{
					Estudiante est = new Estudiante { ID = Convert.ToInt32(data[0]), Nombre = data[1], Carrera = data[2]};
					estudiantesLST.Add(est);
				}

			}
		}

		public EstudiantesWindow()
		{
			InitializeComponent();

			if (File.Exists(filepathEs))
				RecuperarLista();

			EstudiantesDataGrid.ItemsSource = estudiantesLST;
		}

		private void EstudiantesDataGrid_Selected(object sender, RoutedEventArgs e)
		{
			Estudiante estudiante = (Estudiante)EstudiantesDataGrid.SelectedItem;

		}

		private void EstudiantesDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{
			if (e.PropertyName == "ID")
				e.Column.Width = 130;
			if (e.PropertyName == "Nombre")
				e.Column.Width = 330;
			if (e.PropertyName == "Carrera")
				e.Column.Width = 100;
		}

		private void Agregar_Click(object sender, RoutedEventArgs e)
		{
			Window agregarEstudiante = new AgregarEstudiante();
			agregarEstudiante.Show();
		}
	}
}
