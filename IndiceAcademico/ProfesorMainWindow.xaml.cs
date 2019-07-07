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
using IndiceAcademico.classes;
using IndiceAcademico.mainwindows;
using System.IO;

namespace IndiceAcademico
{
	/// <summary>
	/// Interaction logic for ProfesorMainWindow.xaml
	/// </summary>
	public partial class ProfesorMainWindow : Window
	{
        public static Profesor Profesor;
        bool closingBlock;

        public void DisableAgregarAsignatura()
        {
            uscAsignaturas.btnAgregar.Visibility = Visibility.Hidden;
            uscAsignaturas.btnEditar.Visibility = Visibility.Hidden;
            uscAsignaturas.blockHandler = false;
        }

        public ProfesorMainWindow(string user)
		{
			InitializeComponent();

            closingBlock = true;

            List<Profesor> tempLista = new List<Profesor>();
            ManejoArchivo archivo = new ManejoArchivo(ProfesoresWindow.filepathPro);
            if (File.Exists(ProfesoresWindow.filepathPro))
                archivo.RecuperarLista(tempLista);

            Profesor = tempLista.Find(profesor => profesor.ToUser() == user);

            ManejoArchivo archivoEstudiante = new ManejoArchivo(Profesor.Nombre + "-Estudiantes.csv");
            if (File.Exists(archivoEstudiante.FilePath))
                archivoEstudiante.RecuperarLista(EstudiantesWindow.estudiantesLST);


			ManejoArchivo archivoAsignatura = new ManejoArchivo(Profesor.Nombre + "-Asignaturas.csv");
			if (File.Exists(archivoAsignatura.FilePath))
				archivoAsignatura.RecuperarLista(AsignaturasWindow.asignaturasLST);



			ManejoArchivo archivoCalificacion = new ManejoArchivo();

			foreach (var estudiante in EstudiantesWindow.estudiantesLST)
			{
				archivoCalificacion.FilePath = Path.Combine(Profesor.Nombre + "-RegistroCalificaciones", estudiante.Nombre + "-Calificaciones.csv");
				if (File.Exists(archivoCalificacion.FilePath))
				{
					archivoCalificacion.RecuperarLista(estudiante.Calificaciones);
				}
			}

		}

		private void Calificacion_Click(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(uscCalificacion, 1);
            Panel.SetZIndex(uscAsignaturas, 0);
		}

        private void Asignaturas_Click(object sender, RoutedEventArgs e)
        {
            Panel.SetZIndex(uscCalificacion, 0);
            Panel.SetZIndex(uscAsignaturas, 1);
        }

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Estas seguro que quieres cerrar la sesion?", "Cerrar Sesion", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                closingBlock = false;
                EstudiantesWindow.estudiantesLST.Clear();
                ProfesoresWindow.profesoresLST.Clear();
                AsignaturasWindow.asignaturasLST.Clear();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                Close();
            }
                    
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (closingBlock)
            {
                MessageBoxResult result = MessageBox.Show("Esta seguro que quiere salir de la aplicacion?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                    e.Cancel = true;
            }
        }

    }
}
