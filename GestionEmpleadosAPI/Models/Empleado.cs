namespace GestionEmpleadosAPI.Models
{
    public class Empleado
    {
        public int empleado_id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string apellido { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string? telefono { get; set; }

        public int departamento_id { get; set; }
        public Departamento? Departamento { get; set; }
    }
}