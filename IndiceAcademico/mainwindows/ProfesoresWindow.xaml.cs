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

namespace IndiceAcademico
{
	/// <summary>
	/// Interaction logic for ProfesoresWindow.xaml
	/// </summary>
	public partial class ProfesoresWindow : UserControl
	{
		public ProfesoresWindow()
		{
			InitializeComponent();
		}

		private void ProfesoresDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{

		}

		private void ProfesoresDataGrid_Selected(object sender, RoutedEventArgs e)
		{

		}

		private void Agregar_Click(object sender, RoutedEventArgs e)
		{
			Window agregarProfesor = new AgregarProfesor();
			agregarProfesor.Show();
		}
	}
}
