using MovieApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O ano é obrigatório")]
        [Range(1888, 3000, ErrorMessage = "O ano deve ser no mínimo 1888.")]
        public int Ano { get; set; }

        // Requisito: Usar tipo 'Data'
        [Required(ErrorMessage = "A data é obrigatória")]
        [Display(Name = "Data em que assistiu")]
        [DataType(DataType.Date)]
        public DateTime DataAssistido { get; set; }

        // Requisito: Usar 'Enum' 
        [Required(ErrorMessage = "O gênero é obrigatório")]
        [Display(Name = "Gênero")]
        public Genero Genero { get; set; }

        [Range(1, 5, ErrorMessage = "A nota deve ser entre 1 e 5")]
        public int Nota { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Review { get; set; }

        [Display(Name = "URL do Pôster")]
        [DataType(DataType.ImageUrl)]
        public string? PosterUrl { get; set; } // '?' permite que seja nulo
    }
}