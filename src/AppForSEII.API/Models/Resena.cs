using DataType = System.ComponentModel.DataAnnotations.DataType;

public class Resena
{
    public Resena() { }

    public Resena(string titulo, DateTime fechaResena, ApplicationUser usuario)
{
    Titulo = titulo;
    FechaResena = fechaResena;
    Usuario = usuario;
    UsuarioId = usuario.Id;
}
    [Key]
    public int Id { get; set; }

    [StringLength(20, MinimumLength = 10,
    ErrorMessage = "El título de la reseña debe tener entre 10 y 20 caracteres.")]
public string Titulo { get; set; }

public IList<ResenaItem> ResenaItems { get; set; } = new List<ResenaItem>();

public ApplicationUser Usuario { get; set; }
public string UsuarioId { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FechaResena { get; set; }

    // Sobreescribir Equals() y GetHashCode()
}