public class Reposicion
{
    public Reposicion()
    {
        
    }

    public Reposicion(int id, DateTime fechaReposicion, decimal precioTotal, string comentario)
    {
        Id = id;
        FechaReposicion = fechaReposicion;
        PrecioTotal = precioTotal;
        Comentario = comentario;
    }

    public Reposicion(int id, DateTime fechaReposicion, decimal precioTotal)
    {
        Id = id;
        FechaReposicion = fechaReposicion;
        PrecioTotal = precioTotal;
    }

    [Key]
    public int Id { get; set; }

    public IList<ReposicionItem> ReposicionItems { get; set; } 

    [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FechaReposicion { get; set; }


    [Range(0.5, float.MaxValue, ErrorMessage = "El precio total debe ser mayor que 0.5")]
    [Precision(10, 2)]
    public decimal PrecioTotal { get; set; }



    [StringLength(100, MinimumLength = 20, ErrorMessage = "El comentario debe tener entre 20 y 100 caracteres.")]    
    public string? Comentario { get; set; }

    public MetodoPago MetodoPago { get; set; }

    // Sobreescribir Equals() y GetHashCode()
}