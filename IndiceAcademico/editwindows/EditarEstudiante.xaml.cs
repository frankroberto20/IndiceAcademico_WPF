using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using IndiceAcademico.classes;
using IndiceAcademico.mainwindows;

namespace IndiceAcademico.editwindows
{
	/// <summary>
	/// Interaction logic for EditarEstudiante.xaml
	/// </summary>
	public partial class EditarEstudiante : Window
	{

		ManejoArchivo archivo = new ManejoArchivo(EstudiantesWindow.filepathEs);

		public EditarEstudiante()
		{
			InitializeComponent();
			ListaEstudiantes.ItemsSource = EstudiantesWindow.estudiantesLST;
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Estudiante estudiante = (Estudiante)ListaEstudiantes.SelectedItem;
			inputNombre.Text = estudiante.Nombre;
			inputCarrera.Text = estudiante.Carrera;
		}

		private void Agregar_Click(object sender, RoutedEventArgs e)
		{
			if (ListaEstudiantes.SelectedItem != null)
			{
				Estudiante estudiante = (Estudiante)ListaEstudiantes.SelectedItem;

				foreach(var profesor in ProfesoresWindow.profesoresLST)
                {
					if (File.Exists(Path.Combine(profesor.ID + profesor.Nombre + "-RegistroCalificaciones", estudiante.ID + estudiante.Nombre + "-Calificaciones.csv")))
					File.Move(Path.Combine(profesor.ID + profesor.Nombre + "-RegistroCalificaciones", estudiante.ID + estudiante.Nombre + "-Calificaciones.csv"), Path.Combine(profesor.ID + profesor.Nombre + "-RegistroCalificaciones", estudiante.ID + inputNombre.Text + "-Calificaciones.csv"));
                }

				var oldEstudiante = estudiante.ToUser();
				estudiante.Nombre = inputNombre.Text;
				estudiante.Carrera = inputCarrera.Text;

				archivo.OverWriteFile(EstudiantesWindow.estudiantesLST);

				ManejoArchivo archivoPro = new ManejoArchivo();
				foreach(var profesor in ProfesoresWindow.profesoresLST)
                {
					archivoPro.FilePath = profesor.ID + profesor.Nombre + "-Estudiantes.csv";
					if (File.Exists(archivoPro.FilePath))
                    {
						archivoPro.OverWriteFile(profesor.Estudiantes);
                    }
                }

				File.WriteAllLines(LoginWindow.filepathUser, File.ReadLines(LoginWindow.filepathUser).Where(l => l != oldEstudiante).ToList());

				string[] usuario = { estudiante.ToUser() };
				File.AppendAllLines(LoginWindow.filepathUser, usuario);

				MessageBox.Show("Cambios guardados exitosamente!");
				Close();
			}

			else
			{
				MessageBox.Show("Seleccione un estudiante para editar");
			}
			
		}
	}
}
