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

		public void RecuperarLista()
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

		public static void OverWriteFile(List<Estudiante> list)
		{
			string[] datos = new string[AgregarEstudiante.GetID() - 1];
			int counter = 0;
			foreach (var estudiante in list)
			{
				datos[counter++] = estudiante.ToFile();
			}
			string[] header = { "ID,Nombre,Carrera" };
			File.WriteAllLines(filepathEs, header);
			File.AppendAllLines(filepathEs, datos);
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
			MessageBoxResult result = MessageBox.Show("Desea Eliminar la entrada?", "Eliminar", MessageBoxButton.YesNo);
			
			if (result == MessageBoxResult.Yes)
			{
				estudiantesLST.Remove((Estudiante)EstudiantesDataGrid.SelectedItem);
				OverWriteFile(estudiantesLST);
			}

			EstudiantesDataGrid.ItemsSource = null;
			EstudiantesDataGrid.ItemsSource = estudiantesLST;
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

		private void Actualizar_Click(object sender, RoutedEventArgs e)
		{
			EstudiantesDataGrid.ItemsSource = null;
			EstudiantesDataGrid.ItemsSource = estudiantesLST;
		}
	}
}
