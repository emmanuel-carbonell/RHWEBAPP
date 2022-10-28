using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RHWEBAPP2.Models
{
    public class Empleados
    {
        public int Id { get; set; }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public DateTime Fecha_Ingreso { get; set; }

        public string Departamento { get; set; }

        public string Puesto { get; set; }

        public string Salario_Mensual { get; set; }

        public string Estado { get; set; }

    }
}
