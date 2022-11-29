using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tazweer.Data;
using Tazweer.Models;
using Tazweer.Models.ViewModels;

namespace Tazweer.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Documents.Include(d => d.DocumentsType).Include(d => d.passportinformations);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var documents = await _context.Documents
                .Include(d => d.DocumentsType)
                .Include(d => d.passportinformations)
                .FirstOrDefaultAsync(m => m.DocumentsId == id);
            if (documents == null)
            {
                return NotFound();
            }

            return View(documents);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            //عدلي الليست زي المطلوب منكم
            ViewData["DocumentsTypeId"] = new SelectList(_context.DocumentsType, "DocumentsTypeId", "DocumentsTypeId");
            ViewData["passportId"] = new SelectList(_context.LostPassportInformation, "passportId", "passportId");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( DocumentsVM documentsVM)
        {
            if (ModelState.IsValid)
            {
                var documents = new Documents()
                {
                    DocumentsId=documentsVM.DocumentsId,
                    DocumentsTypeId=documentsVM.DocumentsTypeId,
                    Filecon=documentsVM.Filecon,
                    Filename=documentsVM.Filename,
                    Filesize=documentsVM.Filesize,
                    Filetype=documentsVM.Filetype,
                    passportId=documentsVM.passportId
                };
                _context.Add(documents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocumentsTypeId"] = new SelectList(_context.DocumentsType, "DocumentsTypeId", "DocumentsTypeId", documentsVM.DocumentsTypeId);
            ViewData["passportId"] = new SelectList(_context.LostPassportInformation, "passportId", "passportId", documentsVM.passportId);
            return View(documentsVM);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var documents = await _context.Documents.FindAsync(id);
            if (documents == null)
            {
                return NotFound();
            }

            var documentsVM = new DocumentsVM()
            {
                DocumentsId = documents.DocumentsId,
                DocumentsTypeId = documents.DocumentsTypeId,
                Filecon = documents.Filecon,
                Filename = documents.Filename,
                Filesize = documents.Filesize,
                Filetype = documents.Filetype,
                passportId = documents.passportId
            };
            ViewData["DocumentsTypeId"] = new SelectList(_context.DocumentsType, "DocumentsTypeId", "DocumentsTypeId", documents.DocumentsTypeId);
            ViewData["passportId"] = new SelectList(_context.LostPassportInformation, "passportId", "passportId", documents.passportId);
            return View(documentsVM);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  DocumentsVM documentsVM)
        {
            if (id != documentsVM.DocumentsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var documents = new Documents()
                    {
                        DocumentsId = documentsVM.DocumentsId,
                        DocumentsTypeId = documentsVM.DocumentsTypeId,
                        Filecon = documentsVM.Filecon,
                        Filename = documentsVM.Filename,
                        Filesize = documentsVM.Filesize,
                        Filetype = documentsVM.Filetype,
                        passportId = documentsVM.passportId
                    };
                    _context.Update(documents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentsExists(documentsVM.DocumentsId))
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
            ViewData["DocumentsTypeId"] = new SelectList(_context.DocumentsType, "DocumentsTypeId", "DocumentsTypeId", documentsVM.DocumentsTypeId);
            ViewData["passportId"] = new SelectList(_context.LostPassportInformation, "passportId", "passportId", documentsVM.passportId);
            return View(documentsVM);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var documents = await _context.Documents
                .Include(d => d.DocumentsType)
                .Include(d => d.passportinformations)
                .FirstOrDefaultAsync(m => m.DocumentsId == id);
            if (documents == null)
            {
                return NotFound();
            }

            return View(documents);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Documents == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Documents'  is null.");
            }
            var documents = await _context.Documents.FindAsync(id);
            if (documents != null)
            {
                _context.Documents.Remove(documents);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentsExists(int id)
        {
          return _context.Documents.Any(e => e.DocumentsId == id);
        }
    }
}
