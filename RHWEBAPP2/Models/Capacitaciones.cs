using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RHWEBAPP2.Models
{
    public class Capacitaciones
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public Nivel Nivel { get; set; }

        public DateTime Fecha_Desde { get; set; }

        public DateTime Fecha_Hasta { get; set; }

        public string Institucion { get; set; }

    }
}
