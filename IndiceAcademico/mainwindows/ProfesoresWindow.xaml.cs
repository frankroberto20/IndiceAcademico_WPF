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
using IndiceAcademico.editwindows;
using IndiceAcademico.classes;
using System.IO;

namespace IndiceAcademico.mainwindows
{
	/// <summary>
	/// Interaction logic for ProfesoresWindow.xaml
	/// </summary>
	public partial class ProfesoresWindow : UserControl
	{
		public static List<Profesor> profesoresLST = new List<Profesor>();
		public static string filepathPro = "Profesores.csv";
		ManejoArchivo archivo = new ManejoArchivo(filepathPro);

		public ProfesoresWindow()
		{
			InitializeComponent();

            //Recuperar asignaturas de cada profesor
            foreach (var profesor in profesoresLST)
            {
                archivo.FilePath = profesor.Nombre + "-Asignaturas.csv";
                if (File.Exists(profesor.Nombre + "-Asignaturas.csv"))
                {
                    archivo.RecuperarLista(profesor.Asignaturas);
                }

				archivo.FilePath = profesor.Nombre + "-Estudiantes.csv";
				if (File.Exists(profesor.Nombre + "-Estudiantes.csv"))
                {
                    archivo.RecuperarLista(profesor.Estudiantes);
                }

                foreach (var asignatura in profesor.Asignaturas)
                {
                    Asignatura tempAsignatura = AsignaturasWindow.asignaturasLST.Find(asi => asi.Clave == asignatura.Clave);
                    if (tempAsignatura != null)
                    {
                        tempAsignatura.IsInList = true;
                    }
                }
            }

            ProfesoresDataGrid.ItemsSource = profesoresLST;
		}

		private void ProfesoresDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{
			if (e.PropertyName == "ID")
				e.Column.Width = 100;
			if (e.PropertyName == "Nombre")
				e.Column.Width = 450;
		}

		private void ProfesoresDataGrid_Selected(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Desea eliminar la entrada?", "Eliminar", MessageBoxButton.YesNo);
			var profesor = (Profesor)ProfesoresDataGrid.SelectedItem;

			if (result == MessageBoxResult.Yes)
			{
				profesoresLST.Remove(profesor);
			}

			archivo.OverWriteFile(profesoresLST);
			File.WriteAllLines(LoginWindow.filepathUser, File.ReadLines(LoginWindow.filepathUser).Where(l => l != profesor.ToUser()).ToList());

			ProfesoresDataGrid.ItemsSource = null;
			ProfesoresDataGrid.ItemsSource = profesoresLST;
		}

		private void Agregar_Click(object sender, RoutedEventArgs e)
		{
			Window agregarProfesor = new AgregarProfesor();
			agregarProfesor.ShowDialog();
		}

		private void Actualizar_Click(object sender, RoutedEventArgs e)
		{
			ProfesoresDataGrid.ItemsSource = null;
			ProfesoresDataGrid.ItemsSource = profesoresLST;
		}

		private void Editar_Click(object sender, RoutedEventArgs e)
		{
			Window editarProfesor = new EditarProfesor();
			editarProfesor.ShowDialog();
		}

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            ProfesoresDataGrid.ItemsSource = null;
            ProfesoresDataGrid.ItemsSource = profesoresLST;
        }
    }
}
