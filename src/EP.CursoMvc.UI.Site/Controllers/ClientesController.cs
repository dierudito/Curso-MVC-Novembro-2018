using System;
using System.Web.Mvc;
using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Application.ViewModels;
using EP.CursoMvc.Infra.CrossCutting.Filters;

namespace EP.CursoMvc.UI.Site.Controllers
{
    [Authorize]
    [RoutePrefix("area-administrativa/gestao-clientes")]
    public class ClientesController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [Route("")]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }

        //[ClaimsAuthorize("Clientes", "DE")]
        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            var clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        //[ClaimsAuthorize("Clientes", "IN")]
        [Route("criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        //[ClaimsAuthorize("Clientes", "IN")]
        [Route("criar-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEndereco)
        {
            if (!ModelState.IsValid) return View(clienteEndereco);

            clienteEndereco = _clienteAppService.Adicionar(clienteEndereco);

            if (clienteEndereco.Cliente.ValidationResult.IsValid) return RedirectToAction("Index");

            PopularModelStateComErros(clienteEndereco.Cliente.ValidationResult);
            return View(clienteEndereco);
        }

        //[ClaimsAuthorize("Clientes", "ED")]
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            var clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        //[ClaimsAuthorize("Clientes", "ED")]
        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            _clienteAppService.Atualizar(clienteViewModel);

            return RedirectToAction("Index");
        }

        //[ClaimsAuthorize("Clientes", "EX")]
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            var clienteViewModel = _clienteAppService.ObterPorId(id);

            if (clienteViewModel == null) return HttpNotFound();

            return View(clienteViewModel);
        }

        //[ClaimsAuthorize("Clientes", "EX")]
        [Route("{id:guid}/excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _clienteAppService.Dispose();
        }
    }
}
