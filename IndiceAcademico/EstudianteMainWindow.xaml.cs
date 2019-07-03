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
		public EstudianteMainWindow()
		{
			InitializeComponent();

			ManejoArchivo archivoEstudiante = new ManejoArchivo(EstudiantesWindow.filepathEs);
			archivoEstudiante.RecuperarLista(EstudiantesWindow.estudiantesLST);

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
	}
}
