public class Libro
{

    public Libro(){}

    public Libro (int id,string titulo, string autor, DateTime fechaLanzamiento, Editorial editorial, decimal precioReposicion, decimal precioCompra, int stock, Genero genero)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
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
    

    [StringLength(50, ErrorMessage = "El título no puede tener más de 50 caracteres.")]
    public string Titulo { get; set; }



    [StringLength(50, ErrorMessage = "El autor no puede tener más de 50 caracteres.")]
    public string Autor { get; set; }


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


// Sobreescribir Equals() y GetHashCode()
}