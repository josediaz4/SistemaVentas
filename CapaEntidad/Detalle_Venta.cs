namespace CapaEntidad
{
    public class Detalle_Venta
    {
        public int IdDetalle_Venta { get; set; }
        public Producto oProducto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal SubTotal { get; set; }
        public string FechaCreacion { get; set; }
    }
}
