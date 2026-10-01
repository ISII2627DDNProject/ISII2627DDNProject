public class Editorial
{
    public Editorial() { }

    public Editorial(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;

    }

    [Key]
    public int Id { get; set; }

    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    public string Nombre { get; set; }

    //Relación con libros
    public IList<Libro> Libros { get; set; }

    //Luego habrá que sobreescribir Equals() y GetHashCode()

}