using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePix.In.Model
{
    public class MotorAuxiliar : Base
    {
        [NotMapped]
        public List<Acao> acao { get; set; }
        public string Url { get; set; }
    }
}
