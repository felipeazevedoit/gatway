using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePix.In.Model
{
    public class Parametro : Base
    {
        public int Ordem { get; set; }
        public string Tipo { get; set; }
        public int AcaoID { get; set; }
    }
}
 