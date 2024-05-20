using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModuloAPI.Entities
{
    public class Contato
    {
        [Key]
        public int IdContato { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        
    }
}