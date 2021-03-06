using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Web.Models;

namespace Web.Interfaces
{
    public interface IClientApi
    {
        [Get("/churras")]
        Task<List<ChurrasViewModel>> ListarChurras();

        [Post("/churras")]
        Task CriarChurras(ChurrasViewModel churrasViewModel);

        [Get("/churras/{churrasId}")]
        Task<ChurrasViewModel> BuscarChurrasPorId(Guid churrasId);

        [Post("/participante")]
        Task CriarParticipante(AdicionarParticipanteNoChurrasViewModel adicionarParticipanteNoChurrasViewModel);

        [Delete("/participante/{participanteId}")]
        Task ExcluirParticipante(Guid? participanteId);


        [Get("/contribuicao/{churrasId}")]
        Task<ChurrasViewModel> BuscarContribuicao(Guid churrasId);


         [Get("/participante/{nome}")]
        Task<ParticipanteViewModel> BuscarParticipantePorNome(string nome);

        [Patch("/contribuicao")]
        Task PagarChurras(ContribuicaoViewModel contribuicaoViewModel);
    }
}