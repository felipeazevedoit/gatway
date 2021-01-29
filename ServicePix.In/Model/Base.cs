using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServicePix.In.Model
{
    public class Base
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }
        
        [StringLength(150)]
        public string Descricao { get; set; }
        
        public DateTime DataCriacao { get; set; }
        public DateTime DateAlteracao { get; set; }
        public int UsuarioCriacao { get; set; }
        public int UsuarioEdicao { get; set; }
        public bool Ativo { get; set; }
        public int Status { get; set; }
        public int idCliente { get; set; }
    }
}
