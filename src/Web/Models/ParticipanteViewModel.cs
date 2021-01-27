using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Web.Models
{
    public class ParticipanteViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [HiddenInput]
        public Guid ChurrasId { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Valor sugerido")]
        public double ValorSugerido { get; set; }
        public double ValorPago { get; set; }

        [DisplayName("Bebida incluída ?")]
        public bool ComBebida { get; set; }
        public string DescricaoDoChurras { get; set; }
    }
}