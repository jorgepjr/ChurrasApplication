using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Web.Models
{
    public class DetalharChurrasViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }

        public List<ParticipanteViewModel> ParticipanteViewModels { get; set; }
    }
}