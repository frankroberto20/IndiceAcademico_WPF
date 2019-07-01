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
		ManejoArchivo archivo = new ManejoArchivo(filepathEs);

		public EstudiantesWindow()
		{
			InitializeComponent();

			if (File.Exists(filepathEs))
				archivo.RecuperarLista(estudiantesLST);

			EstudiantesDataGrid.ItemsSource = estudiantesLST;
		}

		private void EstudiantesDataGrid_Selected(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Desea eliminar la entrada?", "Eliminar", MessageBoxButton.YesNo);
			
			if (result == MessageBoxResult.Yes)
			{
				estudiantesLST.Remove((Estudiante)EstudiantesDataGrid.SelectedItem);
			}

			archivo.OverWriteFile(estudiantesLST);

			EstudiantesDataGrid.ItemsSource = null;
			EstudiantesDataGrid.ItemsSource = estudiantesLST;
		}

		private void EstudiantesDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{
			if (e.PropertyName == "ID")
				e.Column.Width = 100;
			if (e.PropertyName == "Nombre")
				e.Column.Width = 330;
			if (e.PropertyName == "Carrera")
				e.Column.Width = 120;
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

		private void Editar_Click(object sender, RoutedEventArgs e)
		{
			Window editarEstudiante = new EditarEstudiante();
			editarEstudiante.Show();
		}
	}
}
