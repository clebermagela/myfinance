using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;

namespace myfinance_web_dotnet.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly MyFinanceDbContext _context;

        public TransacaoController(MyFinanceDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            ViewBag.Pessoas = _context.Pessoa.ToList();
            ViewBag.PlanoContas = _context.PlanoConta.ToList();
            return View();
        }
        public IActionResult Index()
        {
            var transacoes = _context.Transacao
                .Include(t => t.Pessoa)
                .Include(t => t.PlanoConta)
                .ToList();
            return View(transacoes);
        }

        [HttpPost]
        public IActionResult Create(Transacao model)
        {
            if (ModelState.IsValid)
            {
                _context.Transacao.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pessoas = _context.Pessoa.ToList();
            ViewBag.PlanoContas = _context.PlanoConta.ToList();
            return View(model);
        }

    }
}
