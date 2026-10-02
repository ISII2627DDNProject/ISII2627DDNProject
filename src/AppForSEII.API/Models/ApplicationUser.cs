using Microsoft.AspNetCore.Identity;

namespace AppForSEII.API.Models;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
    }
    public ApplicationUser(string id, string nombre, string apellidos, string userName, string direccion, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Apellidos = apellidos;
        UserName = userName;
        Email = userName;
        Direccion = direccion;
        Telefono = telefono;

    }

    [StringLength(50)]
    public string? Nombre {get;set;}

    [StringLength(50)]
    public string? Apellidos {get;set;}

    [StringLength(100)]
    public string? Direccion {get;set;}

    [StringLength(9)]
    public string? Telefono {get;set;}

    //Relación con Compra
    public IList<Compra> Compras { get; set; } = new List<Compra>(); //inicializamos por defecto

    public IList<Resena> Resenas { get; set; } = new List<Resena>();    
    
}
