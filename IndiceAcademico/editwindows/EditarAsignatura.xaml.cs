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
using System.IO;
using IndiceAcademico.classes;
using IndiceAcademico.mainwindows;

namespace IndiceAcademico.editwindows
{
	/// <summary>
	/// Interaction logic for EditarAsignatura.xaml
	/// </summary>
	public partial class EditarAsignatura : Window
	{
		ManejoArchivo archivo = new ManejoArchivo(AsignaturasWindow.filepathAsi);

		public EditarAsignatura()
		{
			InitializeComponent();
			ListaAsignaturas.ItemsSource = AsignaturasWindow.asignaturasLST;
		}

		private void ListaAsignaturas_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Asignatura asignatura = (Asignatura)ListaAsignaturas.SelectedItem;
			inputClave.Text = asignatura.Clave;
			inputNombre.Text = asignatura.Nombre;
			inputCreditos.Text = Convert.ToString(asignatura.Creditos);
		}

		private void Guardar_Click(object sender, RoutedEventArgs e)
		{
			if (ListaAsignaturas.SelectedItem != null)
			{
				Asignatura asignatura = (Asignatura)ListaAsignaturas.SelectedItem;
				asignatura.Clave = inputClave.Text;
				asignatura.Nombre = inputNombre.Text;
				asignatura.Creditos = Convert.ToInt32(inputCreditos.Text);

				archivo.OverWriteFile(AsignaturasWindow.asignaturasLST);

				ManejoArchivo archivoPro = new ManejoArchivo();
				foreach(var profesor in ProfesoresWindow.profesoresLST)
                {
					archivoPro.FilePath = profesor.ID + profesor.Nombre + "-Asignaturas.csv";
					if (File.Exists(archivoPro.FilePath))
                    {
						archivoPro.OverWriteFile(profesor.Asignaturas);
                    }
                }

				MessageBox.Show("Cambios guardados exitosamente!");
				Close();
			}
			else
			{
				MessageBox.Show("Seleccione una asignatura para editar");
			}
		}
	}
}
