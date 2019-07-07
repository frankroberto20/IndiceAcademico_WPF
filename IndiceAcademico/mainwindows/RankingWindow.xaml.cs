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
using System.Collections.Generic;

namespace IndiceAcademico.mainwindows
{
    /// <summary>
    /// Interaction logic for RankingWindow.xaml
    /// </summary>
    public partial class RankingWindow : Window
    {

        public class IndiceA
        {
            public int ID { get; set; }

            public string Nombre { get; set; }

            public string Carrera { get; set; }

            public double Indice { get; set; }
        }

        Estudiante estudiante;
        IndiceA index = new IndiceA();
        public List<IndiceA> indicesLST = new List<IndiceA>();
        List<IndiceA> SortedList;

        public RankingWindow()
        {
            InitializeComponent();
        }

        private void RankingLoaded(object sender, RoutedEventArgs e)
        {

            indicesLST.Clear();
      
            foreach (var estudiante in EstudiantesWindow.estudiantesLST)
            {
                IndiceCalc indice = new IndiceCalc();

                double IndiceGeneral = Math.Round(indice.CalcularIndice(estudiante), 2);

                indicesLST.Add(new IndiceA()
                {
                    ID = estudiante.GetID(),
                    Nombre = estudiante.ToString(),
                    Carrera = estudiante.GetCarrera(),
                    Indice = IndiceGeneral
                });
               
            }
            
            SortedList = indicesLST.OrderByDescending(o => o.Indice).ToList();
            DataGrid.ItemsSource = SortedList;

        }
    }
}
