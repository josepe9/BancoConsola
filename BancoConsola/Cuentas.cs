using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoConsola
{
   public class Cuentas
    {
        public string? Cedula { get; set; }
        public string? Passwd { get; set; }
        public string Nombre { get; set; }
        public string Cuenta { get; set; }
        public decimal Saldo { get; set; }
        public int Puntos { get; set; }
    }
}
