using Microsoft.AspNetCore.Identity;

namespace AppForSEII.API.Models;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
    }
    public ApplicationUser(string id, string nombre, string apellidos, string direccion, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Apellidos = apellidos;
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



}
