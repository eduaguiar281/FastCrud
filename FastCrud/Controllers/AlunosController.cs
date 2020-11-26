using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FastCrud.Models;

namespace FastCrud.Controllers
{
    public class AlunosController : Controller
    {
        private readonly EscolaContext _context;

        public AlunosController(EscolaContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            var model = new AlunosViewModel(await _context.Alunos.ToListAsync());
            if ((TempData["UltimoAluno"] != null))
                ViewData["TempDataQueVemDoEdit"] = TempData["UltimoAluno"];
            if (ViewData["UltimoAluno"] != null)
                ViewData["ViewDataQueVemDoEdit"] = ViewData["UltimoAluno"];
            return View(model);
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunos = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunos == null)
            {
                return NotFound();
            }

            return View(alunos);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,DataNascimento,DataCadastro,Matricula,Ativo")] Alunos alunos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alunos);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunos = await _context.Alunos.FindAsync(id);
            if (alunos == null)
            {
                return NotFound();
            }
            return View(alunos);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,DataNascimento,DataCadastro,Matricula,Ativo")] Alunos alunos)
        {
            if (id != alunos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunosExists(alunos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["UltimoAluno"] = $"{alunos.Id}- {alunos.Nome}";
                ViewData["UltimoAluno"] = $"{alunos.Id}- {alunos.Nome}";
                return RedirectToAction(nameof(Index));
            }
            return View(alunos);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunos = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunos == null)
            {
                return NotFound();
            }

            return View(alunos);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alunos = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(alunos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunosExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
