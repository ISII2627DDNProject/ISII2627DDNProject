
[PrimaryKey(nameof(LibroId), nameof(ReposicionId))]

public class ReposicionItem
{
    public ReposicionItem() { }

    public ReposicionItem(int libroId, int reposicionId, int cantidadReposicion)
    {
        LibroId = libroId;
        ReposicionId = reposicionId;
        CantidadReposicion = cantidadReposicion;
    }

    public int LibroId { get; set; }

    public int ReposicionId { get; set; }

    public int CantidadReposicion { get; set; }

    

    // Sobreescribir Equals() y GetHashCode()
}