using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Controllers
{
    [Route("PlanoConta")]
    public class PlanoContaController(IPlanoContaService planoContaService) : Controller
    {

        [Route("Index")]
        public ActionResult Index()
        {
            ViewBag.Lista = planoContaService.ListarRegistros();
            return View();
        }

        [HttpGet]
        [HttpPost]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public ActionResult Cadastro(PlanoContaModel? model, int? id)
        {
            if(id != null && !ModelState.IsValid)
            {
                var registro = planoContaService.BuscarRegistro((int) id);

                var planoContaModel = new PlanoContaModel
                {
                    Id = registro.Id,
                    Nome = registro.Nome,
                    Tipo = registro.Tipo
                };

                return View(planoContaModel);
            }

            if (model != null && ModelState.IsValid)
            {
                var planoConta = new PlanoConta
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    Tipo = model.Tipo
                };

                planoContaService.Salvar(planoConta);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public ActionResult Excluir(int id)
        {
            planoContaService.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}
