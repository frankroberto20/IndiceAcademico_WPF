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

namespace IndiceAcademico
{
	/// <summary>
	/// Interaction logic for ProfesorMainWindow.xaml
	/// </summary>
	public partial class ProfesorMainWindow : Window
	{
		public ProfesorMainWindow()
		{
			InitializeComponent();
		}

		private void Calificacion_Click(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(uscCalificacion, 1);
			Panel.SetZIndex(uscIndice, 0);
		}

		private void Indice_Click(object sender, RoutedEventArgs e)
		{
			Panel.SetZIndex(uscCalificacion, 0);
			Panel.SetZIndex(uscIndice, 1);
		}
	}
}
