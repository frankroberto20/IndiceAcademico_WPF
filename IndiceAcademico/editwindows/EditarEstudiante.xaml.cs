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

namespace IndiceAcademico.editwindows
{
	/// <summary>
	/// Interaction logic for EditarEstudiante.xaml
	/// </summary>
	public partial class EditarEstudiante : Window
	{
		
		List<Estudiante> estudiantes = new List<Estudiante>();

		public EditarEstudiante()
		{
			InitializeComponent();
			estudiantes.Add(new Estudiante { ID = 1, Nombre = "Pedro", Carrera = "INS" });
			ListaEstudiantes.ItemsSource = estudiantes;
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Estudiante estudiante = (Estudiante)ListaEstudiantes.SelectedItem;
			inputNombre.Text = estudiante.Nombre;
			inputCarrera.Text = estudiante.Carrera;
		}
	}
}
