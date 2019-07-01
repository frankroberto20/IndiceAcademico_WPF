using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiceAcademico.classes
{
	public interface IManejoArchivo
	{
		void Agregar();
		void Sobrescribir();
		void Borrar();
		void RecuperarLista();
	}
}
