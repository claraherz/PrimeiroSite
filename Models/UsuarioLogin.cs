using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeiroSite.Models
{
    public class UsuarioLogin
    {
        public int idPaciente { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
