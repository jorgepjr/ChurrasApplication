using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class ChurrasViewModel
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Data")]
        public DateTime Data { get; set; } = DateTime.Now.Date;

        [DisplayName("Observação")]
        public string Observacao { get; set; }
        public List<ParticipanteViewModel> Participantes { get;  set; } = new List<ParticipanteViewModel>();
    }
}