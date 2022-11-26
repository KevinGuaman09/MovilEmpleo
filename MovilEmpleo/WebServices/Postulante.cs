using System;
using System.Collections.Generic;
using System.Text;

namespace MovilEmpleo.WebServices
{
    public class Postulante
    {
        public int id_postulante { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string instruccion { get; set; }
        public string email { get; set; }

        public int edad { get; set; }

        public string identificacion { get; set; }

        public string descripcion { get; set; }

        public string experiencia { get; set; }


    }
}
