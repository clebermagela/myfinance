//using Microsoft.AspNetCore.Mvc;
//using myfinance_web_dotnet.Domain;
//using myfinance_web_dotnet.Infrastructure;
//using myfinance_web_dotnet.Models;
//using myfinance_web_dotnet.Services;

using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;

namespace myfinance_web_dotnet.Controllers
{
    public class PessoaController : Controller
    {
        private readonly MyFinanceDbContext _context;

        public PessoaController(MyFinanceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pessoas = _context.Pessoa.ToList();
            return View(pessoas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pessoa model)
        {
            if (ModelState.IsValid)
            {
                _context.Pessoa.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
