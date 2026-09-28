using DataType = System.ComponentModel.DataAnnotations.DataType;

public class Resena
{
    public Resena() { }

    public Resena(string titulo, DateTime fechaResena)
    {
        Titulo = titulo;
        FechaResena = fechaResena;
    }

    [Key]
    public int Id { get; set; }

    [StringLength(50, ErrorMessage = "El título no puede tener más de 50 caracteres.")]
    public string Titulo { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime FechaResena { get; set; }

    // Sobreescribir Equals() y GetHashCode()
}