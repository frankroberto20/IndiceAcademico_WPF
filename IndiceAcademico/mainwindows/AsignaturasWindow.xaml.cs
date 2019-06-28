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

namespace IndiceAcademico
{
	/// <summary>
	/// Interaction logic for AsignaturasWindow.xaml
	/// </summary>
	public partial class AsignaturasWindow : UserControl
	{
		public AsignaturasWindow()
		{
			InitializeComponent();
			asignaturasLST.Add(new Asignatura() { Clave = "CBF210", Nombre = "Fisica Mecanica I", Creditos = 4 });
			AsignaturaDataGrid.ItemsSource = asignaturasLST;
		}

		public List<Asignatura> asignaturasLST = new List<Asignatura>();

		private void AsignaturaDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{
			if (e.PropertyName == "Clave")
				e.Column.Width = 130;
			if (e.PropertyName == "Nombre")
				e.Column.Width = 330;
			if (e.PropertyName == "Creditos")
				e.Column.Width = 100;
		}

		private void Asignatura_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{

		}

		private void AsignaturaDataGrid_Selected(object sender, RoutedEventArgs e)
		{
		}
	}

	public class Asignatura
	{
		public string Clave { get; set; }
		public string Nombre { get; set; }
		public int Creditos { get; set; }

	}

}
