﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O titulo do filme é obrigatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Genero do filme é obrigatorio")]
        [MaxLength(500,ErrorMessage ="O tamanho máximo e de 500 caracteres")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "A duração do filme é obrigatorio")]
        [Range(70,600,ErrorMessage ="A duração do filme deve ser de 70 a 600 min")]
        public int Duracao { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}
