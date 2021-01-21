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
using System.Windows.Shapes;
using IndiceAcademico.classes;
using IndiceAcademico.mainwindows;

namespace IndiceAcademico.editwindows
{
	/// <summary>
	/// Interaction logic for EditarProfesor.xaml
	/// </summary>
	public partial class EditarProfesor : Window
	{
		ManejoArchivo archivo = new ManejoArchivo(ProfesoresWindow.filepathPro);

		public EditarProfesor()
		{
			InitializeComponent();
			ListaProfesores.ItemsSource = ProfesoresWindow.profesoresLST;
		}

		private void Guardar_Click(object sender, RoutedEventArgs e)
		{
			if (ListaProfesores.SelectedItem != null)
			{
				Profesor profesor = (Profesor)ListaProfesores.SelectedItem;
				
				Directory.Move(profesor.ID + profesor.Nombre + "RegistroCalificaciones", profesor.ID + inputNombre.Text + "RegistroCalificaciones");

				var oldProfesor = profesor.ToUser();
				profesor.Nombre = inputNombre.Text;

				archivo.OverWriteFile(ProfesoresWindow.profesoresLST);

				File.WriteAllLines(LoginWindow.filepathUser, File.ReadLines(LoginWindow.filepathUser).Where(l => l != oldProfesor).ToList());

				string[] usuario = { profesor.ToUser() };
				File.AppendAllLines(LoginWindow.filepathUser, usuario);

				MessageBox.Show("Cambios guardados exitosamente!");
				Close();
			}
			else
			{
				MessageBox.Show("Seleccione un profesor para editar");
			}
			
		}

		private void ListaProfesores_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Profesor profesor = (Profesor)ListaProfesores.SelectedItem;
			inputNombre.Text = profesor.Nombre;
		}

        private void AgregarEstudiante_Click(object sender, RoutedEventArgs e)
        {
            EditarEstudiantesProfesor editarEstudiantes = new EditarEstudiantesProfesor();
            editarEstudiantes.ShowDialog();
        }

        private void AgregarAsignatura_Click(object sender, RoutedEventArgs e)
        {
            EditarAsignaturasProfesor editarAsignaturas = new EditarAsignaturasProfesor();
            editarAsignaturas.ShowDialog();
        }
    }
}
