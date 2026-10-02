public class Compra
{
    public Compra(){}

    public Compra (int id, DateTime fecha, decimal precioTotal, string? codigoDescuento, MetodoPago metodoPago)
    {
        this.Id = id;
        this.FechaCompra = fecha;
        this.PrecioTotal = precioTotal;
        this.CodigoDescuento = codigoDescuento;
        this.MetodoPago = metodoPago;
    }

    [Key]
    public int Id { get; set; }

    [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FechaCompra { get; set; }

    [Range(0.01, float.MaxValue, ErrorMessage = "El precio total debe ser mayor que 0")]
    [Precision(10, 2)]
    public decimal PrecioTotal{ get; set; }

    [StringLength(10, MinimumLength = 5, ErrorMessage = "El código de descuento debe tener entre 5 y 10 caracteres.")]
    public string? CodigoDescuento { get; set; }

    //Relación con CompraItem
    public IList<CompraItem> CompraItems { get; set; }

    //Relacion con MetodoPago
    public MetodoPago MetodoPago { get; set; }

    //Relacion con ApplicationUser
    public ApplicationUser ApplicationUser { get; set; }

// Sobreescribir Equals() y GetHashCode()

}