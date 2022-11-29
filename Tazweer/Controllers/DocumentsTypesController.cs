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
    public class DocumentsTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentsTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DocumentsTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.DocumentsType.ToListAsync());
        }

        // GET: DocumentsTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DocumentsType == null)
            {
                return NotFound();
            }

            var documentsType = await _context.DocumentsType
                .FirstOrDefaultAsync(m => m.DocumentsTypeId == id);
            if (documentsType == null)
            {
                return NotFound();
            }

            return View(documentsType);
        }

        // GET: DocumentsTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DocumentsTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(  DocumentsTypeVM documentsTypeVM)
        {
            if (ModelState.IsValid)
            {
                var documentsType = new DocumentsType()
                {
                    TypeName=documentsTypeVM.TypeName
                };
                _context.Add(documentsType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documentsTypeVM);
        }

        // GET: DocumentsTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DocumentsType == null)
            {
                return NotFound();
            }

            var documentsType = await _context.DocumentsType.FindAsync(id);
            if (documentsType == null)
            {
                return NotFound();
            }
            var documentsTypeVM = new DocumentsTypeVM()
            {
                DocumentsTypeId=documentsType.DocumentsTypeId,
                TypeName = documentsType.TypeName
            };
            return View(documentsTypeVM);
        }

        // POST: DocumentsTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DocumentsTypeVM documentsTypeVM)
        {
            if (id != documentsTypeVM.DocumentsTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var documentsType = new DocumentsType()
                    {
                        DocumentsTypeId=documentsTypeVM.DocumentsTypeId,
                        TypeName = documentsTypeVM.TypeName
                    };
                    _context.Update(documentsType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentsTypeExists(documentsTypeVM.DocumentsTypeId))
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
            return View(documentsTypeVM);
        }

        // GET: DocumentsTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DocumentsType == null)
            {
                return NotFound();
            }

            var documentsType = await _context.DocumentsType
                .FirstOrDefaultAsync(m => m.DocumentsTypeId == id);
            if (documentsType == null)
            {
                return NotFound();
            }

            return View(documentsType);
        }

        // POST: DocumentsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DocumentsType == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DocumentsType'  is null.");
            }
            var documentsType = await _context.DocumentsType.FindAsync(id);
            if (documentsType != null)
            {
                _context.DocumentsType.Remove(documentsType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentsTypeExists(int id)
        {
          return _context.DocumentsType.Any(e => e.DocumentsTypeId == id);
        }
    }
}
