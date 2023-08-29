using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CinemaController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]

        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetornaCinemaPorId), new
            {id = cinema.Id},cinema);
        }

        [HttpGet]
        public IEnumerable<ReadCinemaDto> RetornarCinemas()
        {
            return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
        }

        [HttpGet("{id}")]

        
        public IActionResult RetornaCinemaPorId(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(x=>x.Id==id);

            if (cinema == null)
            {
                return NotFound();
            }
            return Ok(cinema);


        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            var cinema = _context.Filmes.FirstOrDefault(x => x.Id == id);
            if (cinema == null) return NotFound();
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCiname(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(x => x.Id==id);
            if (cinema == null) return NotFound();
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
      


    }
}
