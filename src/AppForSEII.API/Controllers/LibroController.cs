using AppForSEII.Shared.LibroDTOs;

namespace AppForSEII.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LibroController> _logger;

        public LibroController(ApplicationDbContext context, ILogger<LibroController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(IList<LibroParaReponerDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetLibrosParaReponer()
        {

            IList<LibroParaReponerDTO> selectLibros = await _context.Libros

                //join tabla libro y tabla genero
                .Include(l => l.Genero)

                //join tabla libro y tabla reposicionItems y tabla reposicion
                .Include(l => l.ReposicionItems).ThenInclude(ri => ri.Reposicion)

                .Where(l =>  l.Stock <=5) // Filtra los libros con stock menor o igual a 5

                .OrderBy(l => l.Titulo)

                .Select(l => new LibroParaReponerDTO(l.Id, 
                    l.Titulo, 
                    l.Genero.Nombre, 
                    l.Stock, 
                    l.FechaLanzamiento, 
                    l.ReposicionItems.Max(ri => (DateTime?)ri.Reposicion.FechaReposicion))) // Busca la fecha máxima de reposición (la última), o deja null si nunca se ha repuesto
                .ToListAsync();

            return Ok(selectLibros);
        }

    }
}