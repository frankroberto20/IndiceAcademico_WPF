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

namespace IndiceAcademico.editwindows
{
	/// <summary>
	/// Interaction logic for AgregarAsignatura.xaml
	/// </summary>
	public partial class AgregarAsignatura : Window
	{
		ManejoArchivo archivo = new ManejoArchivo(AsignaturasWindow.filepathAsi);

		public AgregarAsignatura()
		{
			InitializeComponent();
		}

		private void Guardar_Click(object sender, RoutedEventArgs e)
		{
			if (!File.Exists(AsignaturasWindow.filepathAsi))
			{
				string[] lines = { "Clave,Nombre,Creditos" };
				File.AppendAllLines(AsignaturasWindow.filepathAsi, lines);
			}

			if (inputNombre.Text != "" && inputClave.Text != "" && inputCreditos.Text != "")
			{
				Asignatura asignatura = new Asignatura { Clave = inputClave.Text, Nombre = inputNombre.Text, Creditos = Convert.ToInt32(inputCreditos.Text) };
				AsignaturasWindow.asignaturasLST.Add(asignatura);
				string[] line = { asignatura.ToFile() };
				File.AppendAllLines(AsignaturasWindow.filepathAsi, line);

				MessageBox.Show("Cambios guardados exitosamente!");

				Close();
			}
			else
			{
				MessageBox.Show("Debe llenar todas las casillas");
			}
			
		}

		private void InputCreditos_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if ((e.Text) == null || !(e.Text).All(char.IsDigit))
			{
				e.Handled = true;
			}
		}
	}
}
