using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Web.Interfaces;
using Web.Models;

namespace Web.Controllers
{
    public class ParticipanteController : Controller
    {
        private readonly IClientApi clientApi;
        private readonly IToastNotification toastNotification;

        public ParticipanteController(IClientApi clientApi, IToastNotification toastNotification)
        {
            this.clientApi = clientApi;
            this.toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Novo(Guid churrasId)
        {
            var churras = await clientApi.BuscarChurrasPorId(churrasId);
            var adicionarParticipanteNoChurrasViewModel = new AdicionarParticipanteNoChurrasViewModel
            {
                ChurrasId = churras.Id,
                NomeDoChurras = churras.Descricao
            };
            return View(adicionarParticipanteNoChurrasViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Salvar(AdicionarParticipanteNoChurrasViewModel adicionarParticipanteNoChurrasViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Novo));
            }
            await clientApi.CriarParticipante(adicionarParticipanteNoChurrasViewModel);
            this.toastNotification.AddSuccessToastMessage("Participante adicioado ao churras com sucesso!");

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(Guid? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Index));
            }
            await clientApi.ExcluirParticipante(id);
            this.toastNotification.AddWarningToastMessage("O participante foi removido da lista de contribuição");

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Buscar(string nome)
        {
            var participante = await clientApi.BuscarParticipantePorNome(nome);

            var contribuicaoViewModel = new ContribuicaoViewModel
            {
                ParticipanteId = participante.Id,
                ChurrasId = participante.ChurrasId,
                NomeDoParticipante = participante.Nome,
                ValorSugerido = participante.ValorSugerido,
            };

            return View(contribuicaoViewModel);
        }
    }
}
