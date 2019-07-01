﻿using System;
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

namespace IndiceAcademico
{
	/// <summary>
	/// Interaction logic for AgregarEstudiante.xaml
	/// </summary>
	public partial class AgregarEstudiante : Window
	{
		static int idCounter = 1;
		ManejoArchivo archivo = new ManejoArchivo(EstudiantesWindow.filepathEs);

		public AgregarEstudiante()
		{
			InitializeComponent();
		}

		private void Guardar_Click(object sender, RoutedEventArgs e)
		{

			if (File.Exists(EstudiantesWindow.filepathEs))
			{
				idCounter = archivo.GetID();
			}
			else
			{
				string[] lines = { "ID,Nombre,Carrera" };
				File.AppendAllLines(EstudiantesWindow.filepathEs, lines);
			}

			Estudiante estudiante = new Estudiante { ID = idCounter++, Nombre = inputNombre.Text, Carrera = inputCarrera.Text };
			EstudiantesWindow.estudiantesLST.Add(estudiante);
			string[] line = { estudiante.ToFile() };
			File.AppendAllLines(EstudiantesWindow.filepathEs, line);

			this.Close();

		}
	}
}
