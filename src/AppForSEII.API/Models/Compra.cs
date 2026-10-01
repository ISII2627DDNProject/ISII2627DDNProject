public class Compra
{
    public Compra(){}

    public Compra (int id, DateTime fecha, decimal precioTotal, string? codigoDescuento)
    {
        this.Id = id;
        this.Fecha = fecha;
        this.PrecioTotal = precioTotal;
        this.CodigoDescuento = codigoDescuento;
    }

    [Key]
    public int Id { get; set; }

    [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Fecha { get; set; }

    [Range(0.01, float.MaxValue, ErrorMessage = "El precio total debe ser mayor que 0")]
    [Precision(10, 2)]
    public decimal PrecioTotal{ get; set; }

    [StringLength(10, MinimumLength = 5, ErrorMessage = "El código de descuento debe tener entre 5 y 10 caracteres.")]
    public string? CodigoDescuento { get; set; }

    //Relación con CompraItem
    public IList<CompraItem> CompraItems { get; set; }


// Sobreescribir Equals() y GetHashCode()

}