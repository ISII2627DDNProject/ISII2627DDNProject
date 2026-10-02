using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AppForSEII.API.Models;

[PrimaryKey(nameof(LibroId), nameof(ResenaId))]
public class ResenaItem
{
    public ResenaItem()
    {
    }

    public ResenaItem(Libro libro, Resena resena, string? descripcion, int calificacion)
    {
        Libro = libro;
        LibroId = libro.Id;
        Resena = resena;
        ResenaId = resena.Id;
        Descripcion = descripcion;
        Calificacion = calificacion;
    }

    public Libro Libro { get; set; }
    public int LibroId { get; set; }

    public Resena Resena { get; set; }
    public int ResenaId { get; set; }

    [StringLength(100, MinimumLength = 20,
        ErrorMessage = "La descripción debe tener entre 20 y 100 caracteres.")]
    public string? Descripcion { get; set; }

    [Range(1, 5,
        ErrorMessage = "La calificación debe estar entre 1 y 5.")]
    public int Calificacion { get; set; }

    // Sobreescribir Equals() y GetHashCode()
}