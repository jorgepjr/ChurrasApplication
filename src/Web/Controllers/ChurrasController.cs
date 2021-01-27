using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;
using Web.Models;

namespace Web.Controllers
{
    public class ChurrasController : Controller
    {
        private readonly IClientApi clientApi;

        public ChurrasController(IClientApi clientApi)
        {
            this.clientApi = clientApi;
        }

        public async Task<IActionResult> Index()
        {
            var churras = await clientApi.ListarChurras();

            ViewData["Participantes"] = churras.Count;

            return View(churras);
        }

        public IActionResult Novo()
        {
            var churrasViewModel = new ChurrasViewModel();
            return View(churrasViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Salvar(ChurrasViewModel churrasViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Novo));
            }
            await clientApi.CriarChurras(churrasViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhes(Guid churrasId)
        {
            var churras = await clientApi.BuscarContribuicao(churrasId);

            ViewData["TotalArrecadado"] = churras.Participantes.Sum(x=>x.ValorPago);
            
            var churrasViewModel = new DetalharChurrasViewModel
            {
                Data = churras.Data,
                Descricao = churras.Descricao,
                Observacao = churras.Observacao,
                ParticipanteViewModels = churras.Participantes
            };
            return View(churrasViewModel);
        }

        public async Task<IActionResult> Pagar(ContribuicaoViewModel contribuicaoViewModel)
        {
            await clientApi.PagarChurras(contribuicaoViewModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
