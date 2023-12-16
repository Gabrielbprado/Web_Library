using Microsoft.AspNetCore.Mvc;
using Web_Library.Data;
using Web_Library.Models;

namespace Web_Library.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly DataContext _context;
        public EmprestimoController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _context.Emprestimos;
            return View(emprestimos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
