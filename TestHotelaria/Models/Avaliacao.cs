using System.ComponentModel.DataAnnotations;

namespace TestHotelaria.Models
{
    public enum Avaliacao
    {
        [Display(Name = "1 estrelas")]
        Um = 1,
        [Display(Name = "2 estrelas")]
        Duas,
        [Display(Name = "3 estrelas")]
        Tres,
        [Display(Name = "4 estrelas")]
        Quatro,
        [Display(Name = "5 estrelas")]
        Cinco
    }
}
