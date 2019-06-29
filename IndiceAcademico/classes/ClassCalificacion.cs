using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiceAcademico
{
    public class Calificacion
    {
        public int Nota { get; set; }

        public Asignatura asignatura { get; set; }

        /*
         Si public Asignatura asignatura no sirve, pues use:
         public string Asignatura {get; set;}
         */

        

        
    }
}
