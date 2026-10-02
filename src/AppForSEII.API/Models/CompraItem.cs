 [PrimaryKey(nameof(CompraId), nameof(LibroId))]

public class CompraItem
{
    public CompraItem() { }

    public CompraItem(int cantidad, int libroId, int compraId)
    {
        Cantidad = cantidad;
        LibroId = libroId;
        CompraId = compraId;
    }

   [Range(2, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 1.")]
    public int Cantidad { get; set; }

    public int LibroId { get; set; }

    public int CompraId { get; set; }

    //Luego habrá que sobreescribir Equals() y GetHashCode()

}