using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RHWEBAPP2.Models
{
    public class Candidatos
    {
        public int Id { get; set; }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Puesto_Al_Que_Aspira { get; set; }

        public string Departamento { get; set; }

        public string Salario_Al_Que_Aspira { get; set; }

        public string Principales_Competencias { get; set; }

        public string Principales_Capacitaciones { get; set; }

        public string Experiencia_Laboral { get; set; }

        public string Recomendado_Por { get; set; }

    }
}
