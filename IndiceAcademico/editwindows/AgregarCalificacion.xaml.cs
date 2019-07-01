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

namespace IndiceAcademico.editwindows
{
	/// <summary>
	/// Interaction logic for AgregarCalificacion.xaml
	/// </summary>
	public partial class AgregarCalificacion : Window
	{
		static List<Asignatura> asignaturas = new List<Asignatura>();
		Asignatura asignatura = new Asignatura { Clave = "INS222", Nombre = "Tecnicas", Credito = 5 };

		public AgregarCalificacion()
		{
			InitializeComponent();
			asignaturas.Add(asignatura);
			ListaAsignatura.ItemsSource = asignaturas; 
		}

	}
}
