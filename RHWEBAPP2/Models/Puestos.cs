using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RHWEBAPP2.Models
{
    public class Puestos
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public NivelDeRiesgo NivelDeRiesgo { get; set; }

        public string Nivel_Minimo_Salario { get; set; }

        public string Nivel_Maximo_Salario { get; set; }

        public string Estado { get; set; }
    }
}
