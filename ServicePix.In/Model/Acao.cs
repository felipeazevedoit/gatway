using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePix.In.Model
{
    public class Acao : Base
    {
        public int idTipoAcao { get; set; }
        public string Caminho { get; set; }
        public Parametro parametro { get; set; }
    }
}
