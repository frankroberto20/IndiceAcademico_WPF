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
using IndiceAcademico.classes;
using IndiceAcademico.editwindows;
using System.IO;

namespace IndiceAcademico.mainwindows
{
	/// <summary>
	/// Interaction logic for CalificacionWindow.xaml
	/// </summary>
	public partial class CalificacionWindow : UserControl
	{
		ManejoArchivo archivo = new ManejoArchivo();
        public bool blockHandler = true;

		public CalificacionWindow()
		{
			InitializeComponent();
			
			ListEstudiantes.ItemsSource = EstudiantesWindow.estudiantesLST;
		}

		private void CalificacionesDataGrid_Selected(object sender, RoutedEventArgs e)
		{
            if (blockHandler)
            {


                if (ListEstudiantes.SelectedItem != null)
                {
                    Estudiante estudiante = (Estudiante)ListEstudiantes.SelectedItem;

                    MessageBoxResult result = MessageBox.Show("Desea eliminar la entrada?", "Eliminar", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        estudiante.Calificaciones.Remove((Calificacion)CalificacionesDataGrid.SelectedItem);
                    }

                    archivo.FilePath = Path.Combine(ProfesorMainWindow.Profesor.Nombre + "-RegistroCalificaciones", estudiante.Nombre + "-Calificaciones.csv");
                    archivo.OverWriteFile(estudiante.Calificaciones);

                    CalificacionesDataGrid.ItemsSource = null;
                    CalificacionesDataGrid.ItemsSource = estudiante.Calificaciones;
                }

            }
		}

		private void CalificacionesDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{
			if (e.PropertyName == "Nota")
				e.Column.Width = 100;
			if (e.PropertyName == "Asignatura")
				e.Column.Width = 450;
		}

		private void Agregar_Click(object sender, RoutedEventArgs e)
		{
			Window agregarCalificacion = new AgregarCalificacion();
			agregarCalificacion.ShowDialog();
		}

		private void Actualizar_Click(object sender, RoutedEventArgs e)
		{
			if (ListEstudiantes.SelectedItem != null)
			{
				Estudiante estudiante = (Estudiante)ListEstudiantes.SelectedItem;

				CalificacionesDataGrid.ItemsSource = null;
				CalificacionesDataGrid.ItemsSource = estudiante.Calificaciones;
			}
		}

		private void ListEstudiantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Estudiante estudiante = (Estudiante)ListEstudiantes.SelectedItem;
			CalificacionesDataGrid.ItemsSource = null;
			CalificacionesDataGrid.ItemsSource = estudiante.Calificaciones;
		}

	}
}
