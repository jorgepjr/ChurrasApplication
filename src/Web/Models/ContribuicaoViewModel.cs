using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace Web.Models
{
    public class ContribuicaoViewModel
    {
        [HiddenInput]
        public Guid? ChurrasId { get; set; }
        [HiddenInput]
        public Guid ParticipanteId { get; set; }

        [DisplayName("Valor sugerido")]
        public double ValorSugerido { get; set; }

        [DisplayName("Quero pagar")]
        public double ValorPago { get; set; }

        [DisplayName("Bedida incluída ?")]
        public bool ComBebida { get; set; }

        [DisplayName("Participante")]
        public string NomeDoParticipante { get; set; }

    }
}