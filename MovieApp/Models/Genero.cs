using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public enum Genero
    {
        [Display(Name = "Ação")]
        Acao,

        [Display(Name = "Comédia")]
        Comedia,

        Drama,

        [Display(Name = "Ficção Científica")]
        FiccaoCientifica,

        [Display(Name = "Documentário")]
        Documentario,

        Terror,

        Romance,

        [Display(Name = "Animação")]
        Animacao
    }
}