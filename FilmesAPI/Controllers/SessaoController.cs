using AutoMapper;
using FilmesAPI.Data.Dto;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class SessaoController : ControllerBase
    {

        private FilmeContext _context;
        private IMapper _mapper;



        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarSessao([FromBody] CreateSessaoDto sessaoDto)
        {

            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ExibirSessaoPorId), new
            { filmeId = sessao.FilmeId , cinemaId = sessao.Cinema  }, sessao);



        }

        [HttpGet]
        public IEnumerable<ReadSessaoDto> ExibirSessao()
        {
            return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes);
        }

        [HttpGet("{filmeId }/{cinemaId}")]

        public IActionResult ExibirSessaoPorId(int filmeId, int cinemaId)
        {
            var sessoes = _context.Sessoes.FirstOrDefault(x => x.FilmeId == filmeId && x.CinemaId == cinemaId);
            if (sessoes == null)
            {
                return NotFound();
            }
            return Ok(sessoes);
        }
    }
}