using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;
using Web.Models;

namespace Web.Controllers
{
    public class ParticipanteController : Controller
    {
        private readonly IClientApi clientApi;

        public ParticipanteController(IClientApi clientApi)
        {
            this.clientApi = clientApi;
        }

        public IActionResult Index => View();

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

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(Guid? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Index));
            }
            await clientApi.ExcluirParticipante(id);

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
