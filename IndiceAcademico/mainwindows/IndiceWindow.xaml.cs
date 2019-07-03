
using System.Windows;
using System.Windows.Controls;
using System;


namespace IndiceAcademico.mainwindows
{
	/// <summary>
	/// Interaction logic for IndiceWindow.xaml
	/// </summary>
	public partial class IndiceWindow : UserControl
	{

		private class Indice
		{
			public string Asignatura { get; set; }
			public string Creditos { get; set; }
			public string Nota { get; set; }
			public string ValorNota { get; set; }
			public string PuntosHonor { get; set; }
		}

		Estudiante estudiante;
		public IndiceWindow()
		{
			InitializeComponent();
			ListEstudiantes.ItemsSource = EstudiantesWindow.estudiantesLST;
		}

		private void ListEstudiantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			estudiante = (Estudiante)ListEstudiantes.SelectedItem;
		}

		private void Calcular_Click(object sender, RoutedEventArgs e)
		{
			ListaIndice.Items.Clear();

			if (ListEstudiantes.SelectedItem != null)
			{
				IndiceCalc indice = new IndiceCalc();

				double totalHonor = 0;
				int totalCreditos = 0;
				foreach (var calificacion in estudiante.Calificaciones)
				{
					totalCreditos += calificacion.Asignatura.Creditos;
					totalHonor += indice.CalcularPuntosHonor(calificacion);
					ListaIndice.Items.Add(new Indice { Asignatura = calificacion.Asignatura.ToString(), Creditos = calificacion.Asignatura.Creditos.ToString(), Nota = indice.LetraNota(calificacion), ValorNota = indice.ValorNota(calificacion).ToString(), PuntosHonor = indice.CalcularPuntosHonor(calificacion).ToString() });
				}

				TotalPuntosHonor.Content = totalHonor;
				TotalCreditos.Content = totalCreditos;
				IndiceGeneral.Content = Math.Round(indice.CalcularIndice(estudiante), 2);
			}

			

		}
	}
}
