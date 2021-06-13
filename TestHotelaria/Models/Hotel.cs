using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestHotelaria.Models
{
    public class Hotel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres ", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres ", MinimumLength = 2)]
        [DisplayName("Resumo do Hotel")]
        public string ResumoHotel { get; set; }

        [DisplayName("Avaliação")]
        public Avaliacao Avaliacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(300, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres ", MinimumLength = 1)]
        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres ", MinimumLength = 1)]
        public string Comodidade { get; set; }

        public Hotel()
        {
            Id = Guid.NewGuid();
        }
    }
}
