using Microsoft.EntityFrameworkCore;
using GestionEmpleadosAPI.Models;

namespace GestionEmpleadosAPI.Data
{
    public class GestionContext : DbContext
    {
        public GestionContext(DbContextOptions<GestionContext> options) : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
    }
}