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
using System.Windows.Shapes;
using IndiceAcademico.mainwindows;

namespace IndiceAcademico
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Estudiantes_ButtonClick(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(uscEstudiantes, 1);
			Panel.SetZIndex(uscProfesores, 0);
			Panel.SetZIndex(uscAsignaturas, 0);
			Panel.SetZIndex(uscCalificaciones, 0);
		}

		private void Asignaturas_ButtonClick(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(uscEstudiantes, 0);
			Panel.SetZIndex(uscProfesores, 0);
			Panel.SetZIndex(uscAsignaturas, 1);
			Panel.SetZIndex(uscCalificaciones, 0);
		}

		private void Profesores_ButtonClick(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(uscEstudiantes, 0);
			Panel.SetZIndex(uscProfesores, 1);
			Panel.SetZIndex(uscAsignaturas, 0);
			Panel.SetZIndex(uscCalificaciones, 0);
		}

		private void Calificacion_ButtonClick(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(uscEstudiantes, 0);
			Panel.SetZIndex(uscProfesores, 0);
			Panel.SetZIndex(uscAsignaturas, 0);
			Panel.SetZIndex(uscCalificaciones, 1);
		}
	}
}
