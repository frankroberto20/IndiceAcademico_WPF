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
using IndiceAcademico.editwindows;
using IndiceAcademico.classes;
using System.IO;

namespace IndiceAcademico.mainwindows
{
	/// <summary>
	/// Interaction logic for EstudiantesWindow.xaml
	/// </summary>
	public partial class EstudiantesWindow : UserControl
	{

		public static List<Estudiante> estudiantesLST = new List<Estudiante>();
		public static string filepathEs = "Estudiantes.csv";
        ManejoArchivo archivo = new ManejoArchivo(filepathEs);

        public void ReloadDataGrid()
        {
            EstudiantesDataGrid.ItemsSource = null;
            EstudiantesDataGrid.ItemsSource = estudiantesLST;
        }

		public EstudiantesWindow()
		{
			InitializeComponent();

			EstudiantesDataGrid.ItemsSource = estudiantesLST;
		}

		private void EstudiantesDataGrid_Selected(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Desea eliminar la entrada?", "Eliminar", MessageBoxButton.YesNo);

			Estudiante estudiante = (Estudiante)EstudiantesDataGrid.SelectedItem;

			if (result == MessageBoxResult.Yes)
			{
				estudiantesLST.Remove(estudiante);

				foreach(var profesor in ProfesoresWindow.profesoresLST)
				{
					profesor.Estudiantes.Remove(estudiante);

					archivo.FilePath = profesor.ID + profesor.Nombre + "-Estudiantes.csv";
					if (File.Exists(archivo.FilePath))
					{
						archivo.OverWriteFile(profesor.Estudiantes);
					}
				
					archivo.FilePath = Path.Combine(profesor.ID + profesor.Nombre + "-RegistroCalificaciones.csv", estudiante.ID + estudiante.Nombre + "-Calificaciones.csv");
					if (File.Exists(archivo.FilePath))
					{
						File.Delete(archivo.FilePath);
					}
				}

				archivo.OverWriteFile(estudiantesLST);
				File.WriteAllLines(LoginWindow.filepathUser, File.ReadLines(LoginWindow.filepathUser).Where(l => l != estudiante.ToUser()).ToList());
			}

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
			agregarEstudiante.ShowDialog();
		}

		private void Actualizar_Click(object sender, RoutedEventArgs e)
		{
			EstudiantesDataGrid.ItemsSource = null;
			EstudiantesDataGrid.ItemsSource = estudiantesLST;
		}

		private void Editar_Click(object sender, RoutedEventArgs e)
		{
			Window editarEstudiante = new EditarEstudiante();
			editarEstudiante.ShowDialog();
		}

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            EstudiantesDataGrid.ItemsSource = null;
            EstudiantesDataGrid.ItemsSource = estudiantesLST;
        }
    }
}
