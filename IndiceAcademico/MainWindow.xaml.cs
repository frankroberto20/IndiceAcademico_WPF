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
using IndiceAcademico.mainwindows;
using IndiceAcademico.classes;
using System.IO;

namespace IndiceAcademico
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        public void DisableAgregarCalificacion()
        {
            uscCalificaciones.btnAgregar.Visibility = Visibility.Hidden;
            uscCalificaciones.blockHandler = false;
        }


		public MainWindow()
		{
			InitializeComponent();

            ManejoArchivo archivo = new ManejoArchivo();

            foreach (var profesor in ProfesoresWindow.profesoresLST)
            {
                foreach (var estudiante in EstudiantesWindow.estudiantesLST)
                {
                    archivo.FilePath = Path.Combine(profesor.Nombre + "-RegistroCalificaciones", estudiante.Nombre + "-Calificaciones.csv");
                    if (File.Exists(archivo.FilePath))
                    {
                        archivo.RecuperarLista(estudiante.Calificaciones);
                    }
                }
            }

        }

		private void Estudiantes_ButtonClick(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(uscEstudiantes, 1);
			Panel.SetZIndex(uscProfesores, 0);
			Panel.SetZIndex(uscAsignaturas, 0);
			Panel.SetZIndex(uscCalificaciones, 0);
			Panel.SetZIndex(uscIndice, 0);
		}

		private void Asignaturas_ButtonClick(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(uscEstudiantes, 0);
			Panel.SetZIndex(uscProfesores, 0);
			Panel.SetZIndex(uscAsignaturas, 1);
			Panel.SetZIndex(uscCalificaciones, 0);
			Panel.SetZIndex(uscIndice, 0);
		}

		private void Profesores_ButtonClick(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(uscEstudiantes, 0);
			Panel.SetZIndex(uscProfesores, 1);
			Panel.SetZIndex(uscAsignaturas, 0);
			Panel.SetZIndex(uscCalificaciones, 0);
			Panel.SetZIndex(uscIndice, 0);
		}

		private void Calificacion_ButtonClick(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(uscEstudiantes, 0);
			Panel.SetZIndex(uscProfesores, 0);
			Panel.SetZIndex(uscAsignaturas, 0);
			Panel.SetZIndex(uscCalificaciones, 1);
			Panel.SetZIndex(uscIndice, 0);
		}

		private void Indice_ButtonClick(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(uscEstudiantes, 0);
			Panel.SetZIndex(uscProfesores, 0);
			Panel.SetZIndex(uscAsignaturas, 0);
			Panel.SetZIndex(uscCalificaciones, 0);
			Panel.SetZIndex(uscIndice, 1);
		}
        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Estas seguro que quieres cerrar la sesion?", "Cerrar Sesion", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                EstudiantesWindow.estudiantesLST.Clear();
                ProfesoresWindow.profesoresLST.Clear();
                AsignaturasWindow.asignaturasLST.Clear();
                uscCalificaciones.blockHandler = true;
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                Close();
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Esta seguro que quiere salir de la aplicacion?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }
    }
}
