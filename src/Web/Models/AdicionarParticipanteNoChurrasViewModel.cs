using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Web.Models
{
    public class AdicionarParticipanteNoChurrasViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [HiddenInput]
        public Guid ChurrasId { get; set; }

        public string NomeDoChurras { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Valor sugerido")]
        public double ValorSugerido { get; set; }
    }
}