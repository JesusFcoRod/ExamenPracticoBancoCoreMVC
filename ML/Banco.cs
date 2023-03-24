using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Banco
    {
        public int IdBanco { get; set; }
        public string Nombre { get; set; }
        public int NoEmpleado { get; set; }
        public int NoSucursales { get; set; }
        public int Capital { get; set; }
        public int NoClientes { get; set; }

        public ML.Pais Pais { get; set; }
        public ML.RazonSocial RazonSocial { get; set; }

        public List<Object> Bancos { get; set; }
    }
}
