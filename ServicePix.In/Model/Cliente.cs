using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePix.In.Model
{
    public class Cliente : Base
    {
        [StringLength(150)]
        public string CNPJ { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(150)]
        public string Url { get; set; }
    }
}
