namespace CapaEntidad
{
    public class Detalle_Compra
    {
        public int IdDetalle_Compra { get; set; }
        public Producto oProducto { get; set; }
        public Proveedor oProveedor { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal MontoTotal { get; set; }
        public string FechaCreacion { get; set; }
    }
}
