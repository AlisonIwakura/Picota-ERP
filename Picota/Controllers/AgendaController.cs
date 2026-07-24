
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Picota.Models;


public class AgendaController : Controller
{
    private readonly Contexto _context;

    public AgendaController(Contexto context)
    {
        _context = context;
    }

    // GET: AGENDAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Agendas.ToListAsync());
    }

    // GET: AGENDAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var agenda = await _context.Agendas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (agenda == null)
        {
            return NotFound();
        }

        return View(agenda);
    }

    // GET: AGENDAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: AGENDAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Data,Cliente")] Agenda agenda)
    {
        if (ModelState.IsValid)
        {
            _context.Add(agenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(agenda);
    }

    // GET: AGENDAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var agenda = await _context.Agendas.FindAsync(id);
        if (agenda == null)
        {
            return NotFound();
        }
        return View(agenda);
    }

    // POST: AGENDAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Data,Cliente")] Agenda agenda)
    {
        if (id != agenda.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(agenda);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendaExists(agenda.Id))
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
        return View(agenda);
    }

    // GET: AGENDAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var agenda = await _context.Agendas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (agenda == null)
        {
            return NotFound();
        }

        return View(agenda);
    }

    // POST: AGENDAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var agenda = await _context.Agendas.FindAsync(id);
        if (agenda != null)
        {
            _context.Agendas.Remove(agenda);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AgendaExists(int? id)
    {
        return _context.Agendas.Any(e => e.Id == id);
    }
}
