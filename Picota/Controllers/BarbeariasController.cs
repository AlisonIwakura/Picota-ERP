
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Picota.Models;

public class BarbeariasController : Controller
{
    private readonly Contexto _context;

    public BarbeariasController(Contexto context)
    {
        _context = context;
    }

    // GET: BARBEARIAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Barbearia.ToListAsync());
    }

    // GET: BARBEARIAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var barbearia = await _context.Barbearia
            .FirstOrDefaultAsync(m => m.Id == id);
        if (barbearia == null)
        {
            return NotFound();
        }

        return View(barbearia);
    }

    // GET: BARBEARIAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BARBEARIAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,Clientes,Agendas")] Barbearia barbearia)
    {
        if (ModelState.IsValid)
        {
            _context.Add(barbearia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(barbearia);
    }

    // GET: BARBEARIAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var barbearia = await _context.Barbearia.FindAsync(id);
        if (barbearia == null)
        {
            return NotFound();
        }
        return View(barbearia);
    }

    // POST: BARBEARIAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nome,Telefone,Clientes,Agendas")] Barbearia barbearia)
    {
        if (id != barbearia.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(barbearia);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarbeariaExists(barbearia.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(barbearia);
    }

    // GET: BARBEARIAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var barbearia = await _context.Barbearia
            .FirstOrDefaultAsync(m => m.Id == id);
        if (barbearia == null)
        {
            return NotFound();
        }

        return View(barbearia);
    }

    // POST: BARBEARIAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var barbearia = await _context.Barbearia.FindAsync(id);
        if (barbearia != null)
        {
            _context.Barbearia.Remove(barbearia);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BarbeariaExists(int? id)
    {
        return _context.Barbearia.Any(e => e.Id == id);
    }
}
