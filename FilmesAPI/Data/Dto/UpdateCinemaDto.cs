using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dto
{
    public class UpdateCinemaDto
    {
       
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Nome { get; set; }
    }
}
