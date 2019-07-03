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
using System.IO;
using IndiceAcademico.classes;
using IndiceAcademico.mainwindows;

namespace IndiceAcademico.editwindows
{
	/// <summary>
	/// Interaction logic for AgregarProfesor.xaml
	/// </summary>
	public partial class AgregarProfesor : Window
	{
		static int idCounter = 1;
		ManejoArchivo archivo = new ManejoArchivo(ProfesoresWindow.filepathPro);

		public AgregarProfesor()
		{
			InitializeComponent();
		}

		private void Guardar_Click(object sender, RoutedEventArgs e)
		{
			if (File.Exists(ProfesoresWindow.filepathPro))
			{
				idCounter = archivo.GetIDProfesor();
			}
			else
			{
				string[] lines = { "ID,Nombre" };
				File.AppendAllLines(ProfesoresWindow.filepathPro, lines);
			}

			if (inputNombre.Text != "")
			{
				Profesor profesor = new Profesor { ID = idCounter++, Nombre = inputNombre.Text };
				ProfesoresWindow.profesoresLST.Add(profesor);
				string[] line = { profesor.ToFile() };
				File.AppendAllLines(ProfesoresWindow.filepathPro, line);

				string[] usuario = { profesor.ToUser() };
				File.AppendAllLines(LoginWindow.filepathUser, usuario);

				MessageBox.Show("Cambios guardados exitosamente!");

				this.Close();
			}
			else
			{
				MessageBox.Show("Debe llenar todas las casillas");
			}
			
		}
	}
}
