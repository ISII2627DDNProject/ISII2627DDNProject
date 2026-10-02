public class Libro
{

    public Libro(){}

    public Libro (int id,string titulo, string tipolibro, string autor, decimal calificacionmedia, DateTime fechaLanzamiento, Editorial editorial, decimal precioReposicion, decimal precioCompra, int stock, Genero genero)
    {
        Id = id;
        Titulo = titulo;
        TipoLibro = tipolibro;
        Autor = autor;
        CalificacionMedia = calificacionmedia;
        FechaLanzamiento = fechaLanzamiento;
        Editorial = editorial;
        PrecioReposicion = precioReposicion;
        PrecioCompra = precioCompra;
        Stock = stock;
        Genero = genero;
    }


    [Key]
    public int Id { get; set; }

    public IList<ReposicionItem> ReposicionItems { get; set; }   

    public IList<ResenaItem> ResenaItems { get; set; } = new List<ResenaItem>();

    [StringLength(50, ErrorMessage = "El título no puede tener más de 50 caracteres.")]
    public string Titulo { get; set; }

    [StringLength(50, MinimumLength = 10,
    ErrorMessage = "El tipo de libro debe tener entre 10 y 50 caracteres.")]
    public string TipoLibro { get; set; }

    [StringLength(50, ErrorMessage = "El autor no puede tener más de 50 caracteres.")]
    public string Autor { get; set; }

    public decimal CalificacionMedia { get; set; }


    [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FechaLanzamiento { get; set; }


    [Range(0.5, float.MaxValue, ErrorMessage = "El precio de reposición debe ser mayor que 0.5")]
    [Precision(10, 2)]
    public decimal PrecioReposicion { get; set; }


    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
    public int Stock { get; set; }

    [Range(0, float.MaxValue, ErrorMessage = "El precio de compra debe ser mayor que 0")]
    [Precision(10, 2)]
    public decimal PrecioCompra { get; set; }

    public Genero Genero{ get; set; }

    //Relación con Editorial
    public Editorial Editorial { get; set; }

    //Relación con CompraItem
    public IList<CompraItem> CompraItems { get; set; } = new List<CompraItem>();


// Sobreescribir Equals() y GetHashCode()
}