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
		}

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

}
