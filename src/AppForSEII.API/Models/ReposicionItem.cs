
[PrimaryKey(nameof(LibroId), nameof(ReposicionId))]

public class ReposicionItem
{
    public ReposicionItem() { }

    public ReposicionItem(Libro libro, Reposicion reposicion, int cantidad)
    {
        Libro = libro;
        LibroId = libro.Id;
        Reposicion = reposicion;
        ReposicionId = reposicion.Id;
        Cantidad = cantidad;
        Precio = libro.PrecioReposicion;
    }

    public Libro Libro { get; set; }
    public int LibroId { get; set; }

    public Reposicion Reposicion { get; set; }
    public int ReposicionId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad a reponer debe ser mayor que cero.")]
    public int Cantidad { get; set; }

    [Range(0.5, float.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.5")]
    [Precision(10, 2)]
    public decimal Precio { get; set; }


    

    // Sobreescribir Equals() y GetHashCode()
}