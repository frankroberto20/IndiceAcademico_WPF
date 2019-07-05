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
using IndiceAcademico.classes;
using IndiceAcademico.mainwindows;

namespace IndiceAcademico.editwindows
{
    /// <summary>
    /// Interaction logic for EditarEstudiantesProfesor.xaml
    /// </summary>
    public partial class EditarEstudiantesProfesor : Window
    {
        public EditarEstudiantesProfesor()
        {
            InitializeComponent();

            ListaProfesores.ItemsSource = ProfesoresWindow.profesoresLST;
            ListaEstudiantes.ItemsSource = EstudiantesWindow.estudiantesLST;
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (ListaProfesores.SelectedItem != null && ListaEstudiantes.SelectedItem != null)
            {
                Profesor profesor = (Profesor)ListaProfesores.SelectedItem;
                Estudiante estudiante = (Estudiante)ListaEstudiantes.SelectedItem;

                if (profesor.Estudiantes.Where(est => est == estudiante).Count() == 0)
                {
                    profesor.Estudiantes.Add(estudiante);
                    ManejoArchivo archivo = new ManejoArchivo(profesor.Nombre + "-Estudiantes.csv");
                    archivo.OverWriteFile(profesor.Estudiantes);
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todas las casillas", "Infromacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ListaProfesores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Profesor profesor = (Profesor)ListaProfesores.SelectedItem;
            GridEstudiantes.ItemsSource = profesor.Asignaturas;
        }
    }
}
