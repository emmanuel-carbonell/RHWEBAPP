using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RHWEBAPP2.Models;

namespace RHWEBAPP2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RHWEBAPP2.Models.Competencias> Competencias { get; set; }
        public DbSet<RHWEBAPP2.Models.Idiomas> Idiomas { get; set; }
        public DbSet<RHWEBAPP2.Models.Capacitaciones> Capacitaciones { get; set; }
        public DbSet<RHWEBAPP2.Models.Puestos> Puestos { get; set; }
        public DbSet<RHWEBAPP2.Models.Candidatos> Candidatos { get; set; }
        public DbSet<RHWEBAPP2.Models.Experiencia_Laboral> Experiencia_Laboral { get; set; }
        public DbSet<RHWEBAPP2.Models.Empleados> Empleados { get; set; }
    }
}
