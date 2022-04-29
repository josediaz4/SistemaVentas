namespace CapaEntidad
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public Rol oRol { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public string FechaCreacion { get; set; }
    }
}
