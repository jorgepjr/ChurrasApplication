using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Web.Interfaces;
using Web.Models;

namespace Web.Controllers
{
    public class ChurrasController : Controller
    {
        private readonly IClientApi clientApi;
         private readonly IToastNotification toastNotification;

        public ChurrasController(IClientApi clientApi, IToastNotification toastNotification)
        {
            this.clientApi = clientApi;
            this.toastNotification = toastNotification;
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
            toastNotification.AddSuccessToastMessage("Churras criado com sucesso!");

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
            toastNotification.AddSuccessToastMessage("Sua contribuição foi registrada com sucesso!");
            return RedirectToAction(nameof(Index));
        }
    }
}
