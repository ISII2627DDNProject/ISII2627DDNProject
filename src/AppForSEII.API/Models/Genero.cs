

[Index(nameof(Nombre), IsUnique= true)] // dos géneros no pueden tener el mismo nombre
public class Genero
{
    public Genero()
    {
        
    }

    public Genero(string nombre)
    {
        Nombre = nombre;
    }
    [Key]
    public int Id { get; set; }
    

    [StringLength(50, ErrorMessage = "El nombre del género no puede tener más de 50 caracteres.")]
    public string Nombre { get; set; }

    public List<Libro> Libros { get; set; }


    // sobreescribir Equals() y GetHashCode()
}