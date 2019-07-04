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
using IndiceAcademico.mainwindows;
using IndiceAcademico.classes;

namespace IndiceAcademico.editwindows
{
	/// <summary>
	/// Interaction logic for AgregarCalificacion.xaml
	/// </summary>
	public partial class AgregarCalificacion : Window
	{

		public AgregarCalificacion()
		{
			InitializeComponent();
			ListaAsignatura.ItemsSource = AsignaturasWindow.asignaturasLST;
			ListaEstudiantes.ItemsSource = EstudiantesWindow.estudiantesLST;

		}

		private void Guardar_Click(object sender, RoutedEventArgs e)
		{
			Estudiante estudiante = (Estudiante)ListaEstudiantes.SelectedItem;

			

			if (inputNota.Text != "" && ListaEstudiantes.SelectedItem != null && ListaAsignatura.SelectedItem != null)
			{
				if (!File.Exists(estudiante.Nombre + "-Calificaciones.csv"))
				{
					string[] lines = { "Nota,Asignatura" };
					File.AppendAllLines(estudiante.Nombre + "-Calificaciones.csv", lines);
				}

                List<Calificacion> tempLista = new List<Calificacion>();
                ManejoArchivo archivoCalificacion = new ManejoArchivo(estudiante.Nombre + "-Calificaciones.csv");
                archivoCalificacion.RecuperarLista(tempLista);

                if (tempLista.Where(calificacion => calificacion.Asignatura == (Asignatura)ListaAsignatura.SelectedItem).Count() == 0)
                {
                    Calificacion calificacion = new Calificacion { Nota = Convert.ToDouble(inputNota.Text) > 100 ? 100 : Convert.ToDouble(inputNota.Text), Asignatura = (Asignatura)ListaAsignatura.SelectedItem };
                    estudiante.Calificaciones.Add(calificacion);
                    string[] line = { calificacion.ToFile() };
                    File.AppendAllLines(estudiante.Nombre + "-Calificaciones.csv", line);

                    MessageBox.Show("Cambios guardados exitosamente!", "Informacion guardada", MessageBoxButton.OK, MessageBoxImage.Information);

                    Close();
                }
                else
                {
                    MessageBox.Show("La calificacion de esta asignatura ya ha sido registrada", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

				
			}
			else
			{
                MessageBox.Show("Debe llenar todas las casillas", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning); 
			}
			
		}

		private void InputNota_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if ((e.Text) == null || !(e.Text).All(char.IsDigit))
			{
				e.Handled = true;
			}
		}
	}
}
