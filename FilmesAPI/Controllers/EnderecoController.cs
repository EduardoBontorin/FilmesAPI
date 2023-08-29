using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EnderecoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ExibirEnderecoPorId), new { id = endereco.Id },endereco);
            //TODO: Ajustar para mostrar o onjeto criado
            //TODO: Ajustar para receber um DTO

     

        }

        [HttpGet]

        public IEnumerable<ReadEnderecoDto> ExibirEndereco()
        {

            return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos);


        }
        
        [HttpGet("{id}")]
        public IActionResult ExibirEnderecoPorId(int id)
        {
            if (id == null) return NotFound();

            var endereco = _context.Enderecos.FirstOrDefault(x => x.Id== id);
            return Ok(endereco);

            //TODO: Adicionar interface DTO

        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            var endereco = _context.Filmes.FirstOrDefault(x => x.Id == id);
            if (endereco == null) return NotFound();
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null) return NotFound();
            var endereco = _context.Enderecos.First(x => x.Id == id);
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return Ok(endereco);
        }


       
    }
}
