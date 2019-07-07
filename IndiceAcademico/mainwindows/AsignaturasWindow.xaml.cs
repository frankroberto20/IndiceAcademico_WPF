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
using IndiceAcademico.editwindows;
using IndiceAcademico.classes;
using System.IO;

namespace IndiceAcademico.mainwindows
{
	/// <summary>
	/// Interaction logic for AsignaturasWindow.xaml
	/// </summary>
	public partial class AsignaturasWindow : UserControl
	{

        public bool blockHandler = true;

		public static List<Asignatura> asignaturasLST = new List<Asignatura>();
		public static string filepathAsi = "Asignaturas.csv";
        ManejoArchivo archivo = new ManejoArchivo();

        public AsignaturasWindow()
		{
			InitializeComponent();

			

			AsignaturaDataGrid.ItemsSource = asignaturasLST;
		}

		private void AsignaturaDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{
			if (e.PropertyName == "Clave")
				e.Column.Width = 100;
			if (e.PropertyName == "Nombre")
				e.Column.Width = 330;
			if (e.PropertyName == "Creditos")
				e.Column.Width = 120;
		}

		private void AsignaturaDataGrid_Selected(object sender, RoutedEventArgs e)
		{
            if (blockHandler)
            {
                MessageBoxResult result = MessageBox.Show("Desea eliminar la entrada?", "Eliminar", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    asignaturasLST.Remove((Asignatura)AsignaturaDataGrid.SelectedItem);
                }

                archivo.OverWriteFile(asignaturasLST);

                AsignaturaDataGrid.ItemsSource = null;
                AsignaturaDataGrid.ItemsSource = asignaturasLST;
            }
		}

		private void Agregar_Click(object sender, RoutedEventArgs e)
		{
			Window agregarAsignatura = new AgregarAsignatura();
			agregarAsignatura.ShowDialog();
			
		}

		private void Actualizar_Click(object sender, RoutedEventArgs e)
		{
			AsignaturaDataGrid.ItemsSource = null;
			AsignaturaDataGrid.ItemsSource = asignaturasLST;
		}

		private void Editar_Click(object sender, RoutedEventArgs e)
		{
			Window editarAsignatura = new EditarAsignatura();
			editarAsignatura.ShowDialog();
		}

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            AsignaturaDataGrid.ItemsSource = null;
            AsignaturaDataGrid.ItemsSource = asignaturasLST;
        }
    }

}
