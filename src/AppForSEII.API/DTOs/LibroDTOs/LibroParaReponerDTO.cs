using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppForSEII.Shared.LibroDTOs
{
    public class LibroParaReponerDTO
    {
        public LibroParaReponerDTO()
        {
        }

        public LibroParaReponerDTO(int id, string titulo, string genero, int stock, DateTime fechaLanzamiento)
        {
            FechaLanzamiento = fechaLanzamiento;
            Id = id;
            Titulo = titulo;
            Genero = genero;
            Stock = stock;

        }

        public LibroParaReponerDTO(int id, string titulo, string genero, int stock, DateTime fechaLanzamiento, DateTime? ultimaReposicion) : this(id, titulo, genero, stock, fechaLanzamiento)
        {
            UltimaReposicion = ultimaReposicion;
        }

        public int Id { get; set; }

        [StringLength(50,ErrorMessage = "El titulo no puede tener más de 50 caracteres.")]
        public string Titulo { get; set; }

        [StringLength(50, ErrorMessage = "El género no puede tener más de 50 caracteres.", MinimumLength = 4)]
        public string Genero { get; set; }

        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        public DateTime FechaLanzamiento { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }

        public DateTime? UltimaReposicion {  get; set; }

        public override bool Equals(object? obj)
        {
            return obj is LibroParaReponerDTO dTO &&
                   Id == dTO.Id &&
                   Titulo == dTO.Titulo &&
                   Genero == dTO.Genero &&
                   FechaLanzamiento == dTO.FechaLanzamiento &&
                   Stock == dTO.Stock &&
                   UltimaReposicion == dTO.UltimaReposicion;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Titulo, Genero, FechaLanzamiento, Stock, UltimaReposicion);
        }
    }
}