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
			Profesor profesor = (Profesor)ListaProfesores.SelectedItem;
			profesor.Nombre = inputNombre.Text;

			archivo.OverWriteFile(ProfesoresWindow.profesoresLST);

			MessageBox.Show("Cambios guardados exitosamente!");
			Close();
		}

		private void ListaProfesores_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Profesor profesor = (Profesor)ListaProfesores.SelectedItem;
			inputNombre.Text = profesor.Nombre;
		}
	}
}
