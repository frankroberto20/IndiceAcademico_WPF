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
using IndiceAcademico.mainwindows;
using IndiceAcademico.classes;

namespace IndiceAcademico.editwindows
{
    /// <summary>
    /// Interaction logic for EditarEstudiantesProfesor.xaml
    /// </summary>
    public partial class EditarAsignaturasProfesor : Window
    {
        public EditarAsignaturasProfesor()
        {
            InitializeComponent();

            ListaProfesores.ItemsSource = ProfesoresWindow.profesoresLST;
            ListaAsignaturas.ItemsSource = AsignaturasWindow.asignaturasLST;
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (ListaProfesores.SelectedItem != null && ListaAsignaturas.SelectedItem != null)
            {
                Profesor profesor = (Profesor)ListaProfesores.SelectedItem;
                Asignatura asignatura = (Asignatura)ListaAsignaturas.SelectedItem;

                if (profesor.Asignaturas.Where(asi => asi == asignatura).Count() == 0)
                {
                    profesor.Asignaturas.Add(asignatura);
                    ManejoArchivo archivo = new ManejoArchivo(profesor.Nombre + "-Asignaturas.csv");
                    archivo.OverWriteFile(profesor.Asignaturas);
                }
            }
        }

        private void ListaProfesores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Profesor profesor = (Profesor)ListaProfesores.SelectedItem;
            GridEstudiantes.ItemsSource = profesor.Asignaturas;
        }
    }
}
