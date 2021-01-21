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

                if (profesor.Asignaturas.Where(asi => asi.Clave == asignatura.Clave).Count() == 0)
                {
                    if (!asignatura.IsInList)
                    {
                        profesor.Asignaturas.Add(asignatura);
                        asignatura.IsInList = true;
                        ManejoArchivo archivo = new ManejoArchivo(profesor.ID + profesor.Nombre + "-Asignaturas.csv");
                        archivo.OverWriteFile(profesor.Asignaturas);

                        GridAsignaturas.ItemsSource = null;
                        GridAsignaturas.ItemsSource = profesor.Asignaturas;
                    }
                    else
                    {
                        MessageBox.Show("Esta asignatura ya pertenece a otro profesor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }

                else
                {
                    MessageBox.Show("Esta asignatura ya ha sido registrada", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ListaProfesores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Profesor profesor = (Profesor)ListaProfesores.SelectedItem;
            GridAsignaturas.ItemsSource = null;
            GridAsignaturas.ItemsSource = profesor.Asignaturas;
        }
    }
}
