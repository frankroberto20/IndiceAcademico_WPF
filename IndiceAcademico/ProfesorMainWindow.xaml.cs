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
	/// Interaction logic for ProfesorMainWindow.xaml
	/// </summary>
	public partial class ProfesorMainWindow : Window
	{
		public ProfesorMainWindow(string user)
		{
			InitializeComponent();

            List<Profesor> tempLista = new List<Profesor>();
            ManejoArchivo archivo = new ManejoArchivo(ProfesoresWindow.filepathPro);
            if (File.Exists(ProfesoresWindow.filepathPro))
                archivo.RecuperarLista(tempLista);

            Profesor Profesor = tempLista.Find(profesor => profesor.ToUser() == user);

            ManejoArchivo archivoEstudiante = new ManejoArchivo(EstudiantesWindow.filepathEs);
            EstudiantesWindow.estudiantesLST = Profesor.Estudiantes;


			ManejoArchivo archivoAsignatura = new ManejoArchivo(AsignaturasWindow.filepathAsi);
			if (File.Exists(AsignaturasWindow.filepathAsi))
				archivoAsignatura.RecuperarLista(AsignaturasWindow.asignaturasLST);



			ManejoArchivo archivoCalificacion = new ManejoArchivo();

			foreach (var estudiante in EstudiantesWindow.estudiantesLST)
			{
				archivoCalificacion.FilePath = estudiante.Nombre + "-Calificaciones.csv";
				if (File.Exists(estudiante.Nombre + "-Calificaciones.csv"))
				{
					archivoCalificacion.RecuperarLista(estudiante.Calificaciones);
				}
			}

		}

		private void Calificacion_Click(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(uscCalificacion, 1);
			Panel.SetZIndex(uscIndice, 0);
		}

		private void Indice_Click(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(uscCalificacion, 0);
			Panel.SetZIndex(uscIndice, 1);
		}
	}
}
