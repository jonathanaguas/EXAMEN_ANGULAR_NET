namespace GestionEmpleadosAPI.Models
{
    public class Departamento
    {
        public int departamento_id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string? ubicacion { get; set; }
        public string? jefe_departamento { get; set; }
        public string? extension { get; set; }

        public ICollection<Empleado>? Empleados { get; set; }
    }
}