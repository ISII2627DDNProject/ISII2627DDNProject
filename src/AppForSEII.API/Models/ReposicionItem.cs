
[PrimaryKey(nameof(LibroId), nameof(ReposicionId))]

public class ReposicionItem
{
    public ReposicionItem() { }

    public ReposicionItem(Libro libro, Reposicion reposicion, int cantidadReposicion)
    {
        Libro = libro;
        LibroId = libro.Id;
        Reposicion = reposicion;
        ReposicionId = reposicion.Id;
        CantidadReposicion = cantidadReposicion;
    }

    public Libro Libro { get; set; }
    public int LibroId { get; set; }

    public Reposicion Reposicion { get; set; }
    public int ReposicionId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad a reponer debe ser mayor que cero.")]
    public int CantidadReposicion { get; set; }

    

    // Sobreescribir Equals() y GetHashCode()
}