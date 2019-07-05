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
using IndiceAcademico.classes;
using IndiceAcademico.mainwindows;
using System.IO;

namespace IndiceAcademico
{
	/// <summary>
	/// Interaction logic for EstudianteMainWindow.xaml
	/// </summary>
	public partial class EstudianteMainWindow : Window
	{

        public EstudianteMainWindow(string user)
		{
			InitializeComponent();

            

            List<Estudiante> tempLista = new List<Estudiante>();
            ManejoArchivo archivo = new ManejoArchivo(EstudiantesWindow.filepathEs);
            if (File.Exists(EstudiantesWindow.filepathEs))
                archivo.RecuperarLista(tempLista);

            Estudiante Estudiante = tempLista.Find(estudiante => estudiante.ToUser() == user);


            EstudiantesWindow.estudiantesLST.Add(Estudiante);

			if (File.Exists(AsignaturasWindow.filepathAsi))
            {
                ManejoArchivo archivoAsignatura = new ManejoArchivo(AsignaturasWindow.filepathAsi);
                archivoAsignatura.RecuperarLista(AsignaturasWindow.asignaturasLST);
            }
				
			if (File.Exists(Estudiante.Nombre + "-Calificaciones.csv"))
			{
                ManejoArchivo archivoCalificacion = new ManejoArchivo();
                archivoCalificacion.FilePath = Estudiante.Nombre + "-Calificaciones.csv";
                archivoCalificacion.RecuperarLista(Estudiante.Calificaciones);
			}
		}

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Estas seguro que quieres cerrar la sesion?", "Cerrar Sesion", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                EstudiantesWindow.estudiantesLST.Clear();
                ProfesoresWindow.profesoresLST.Clear();
                AsignaturasWindow.asignaturasLST.Clear();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                Close();
            }

        }

    }
}
