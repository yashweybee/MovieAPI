using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.DTOs;
using MovieAPI.Entities;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class GenreController : Controller
    {

        private readonly ILogger<GenreController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenreController(ILogger<GenreController> logger, ApplicationDbContext context, IMapper mapper)
        {

            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        [HttpGet("list")]
        [HttpGet("/GetGenre")]
        //[ResponseCache(Duration = 60)]
        //[ServiceFilter(typeof(MyActionFilter))]
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {

            var genres = await context.genres.ToListAsync();
            var genreDTOs = mapper.Map<List<GenreDTO>>(genres);
            return genreDTOs;
        }


        [HttpGet("{Id:int}", Name = "getGenre")]
        public async Task<ActionResult<GenreDTO>> Get(int Id)
        {

            var genre = context.genres.FirstOrDefault(x => x.Id == Id);
            var genreDTOs = mapper.Map<GenreDTO>(genre);

            return genreDTOs;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreation)
        {
            var genre = mapper.Map<Genre>(genreCreation);
            context.Add(genre);
            await context.SaveChangesAsync();
            var genreDTO = mapper.Map<GenreDTO>(genre);
            return new CreatedAtRouteResult("getGenre", new { Id = genre.Id }, genre);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> Put(int Id, [FromBody] GenreCreationDTO genreCreation)
        {
            var genre = mapper.Map<Genre>(genreCreation);
            genre.Id = Id;
            context.Entry(genre).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {

            var exist = await context.genres.AnyAsync(x => x.Id == Id);
            if (!exist)
            {
                return NotFound();
            }
            context.Remove(new Genre() { Id = Id });
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
