using System;
using System.Collections.Generic;
using System.Text;

namespace MovilEmpleo.WebServices
{
    public class Reclutador
    {
        public int id_reclutador { get; set; }
        public int id_postulante { get; set; }
        public int id_empresa { get; set; }

        public string nombre { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
    }
}
