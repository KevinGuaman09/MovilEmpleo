using System;
using System.Collections.Generic;
using System.Text;

namespace MovilEmpleo
{
    public interface Mensaje
    {
        void LongAlert(string mensaje);
        void ShortAlert(string mensaje);
    }
}
