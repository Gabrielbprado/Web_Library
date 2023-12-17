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

       

        [HttpPost]
        public IActionResult Create(EmprestimosModel model)
        {
            if(ModelState.IsValid)

            {
                _context.Emprestimos.Add(model);
                _context.SaveChanges();
                TempData["msgDeSucesso"] = "Emprestimo Cadastrado com Sucesso!";
                return RedirectToAction("Index");
                
            }

            return View(model);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            EmprestimosModel? emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null) { return NotFound(); }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Edit(EmprestimosModel model)
        {
            if(ModelState.IsValid)
            {
                _context.Emprestimos.Update(model);
                _context.SaveChanges();
                TempData["msgDeSucesso"] = "Emprestimo Atualizado com Sucesso!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            EmprestimosModel? emprestimo = _context.Emprestimos.FirstOrDefault(x => x.Id == id);

            if(emprestimo == null) { return NotFound(); }

            
            return View(emprestimo);
        }

        [HttpPost]
                public IActionResult Delete(EmprestimosModel model)
        {

                    _context.Emprestimos.Remove(model);
                    _context.SaveChanges();
            TempData["msgDeSucesso"] = "Emprestimo Removido com Sucesso!";
                 return RedirectToAction("Index");
        }




    }
}
