using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RHWEBAPP2.Models
{
    public class Experiencia_Laboral
    {
        public int Id { get; set; }

        public string Empresa { get; set; }

        public string Puesto_Ocupado { get; set; }

        public DateTime Fecha_Desde { get; set; }

        public DateTime Fecha_Hasta { get; set; }

        public string Salario { get; set; }
    }
}
