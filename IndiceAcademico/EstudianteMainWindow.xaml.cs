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
	/// Interaction logic for EstudianteMainWindow.xaml
	/// </summary>
	public partial class EstudianteMainWindow : Window
	{

        bool closingBlock;

        public void DisableRanking()
        {
            uscIndice.btnRanking.Visibility = Visibility.Hidden;
        }

        public EstudianteMainWindow(string user)
		{
			InitializeComponent();

            closingBlock = true;

            List<Estudiante> tempLista = new List<Estudiante>();
            ManejoArchivo archivo = new ManejoArchivo(EstudiantesWindow.filepathEs);
            if (File.Exists(EstudiantesWindow.filepathEs))
                archivo.RecuperarLista(tempLista);

            Estudiante Estudiante = tempLista.Find(estudiante => estudiante.ToUser() == user);

            EstudiantesWindow.estudiantesLST.Add(Estudiante);

            NombreEstudiante.Content = Estudiante.Nombre;

            ManejoArchivo archivoProfesores = new ManejoArchivo(ProfesoresWindow.filepathPro);
            if (File.Exists(archivoProfesores.FilePath))
                archivoProfesores.RecuperarLista(ProfesoresWindow.profesoresLST);

			if (File.Exists(AsignaturasWindow.filepathAsi))
            {
                ManejoArchivo archivoAsignatura = new ManejoArchivo(AsignaturasWindow.filepathAsi);
                archivoAsignatura.RecuperarLista(AsignaturasWindow.asignaturasLST);
            }

            ManejoArchivo archivoCalificaciones = new ManejoArchivo();
            foreach (var profesor in ProfesoresWindow.profesoresLST)
            {
                archivoCalificaciones.FilePath = Path.Combine(profesor.ID + profesor.Nombre + "-RegistroCalificaciones", Estudiante.ID + Estudiante.Nombre + "-Calificaciones.csv");
                if (File.Exists(archivoCalificaciones.FilePath))
                {
                    archivoCalificaciones.RecuperarLista(Estudiante.Calificaciones);
                }
            }
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
