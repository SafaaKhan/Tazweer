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
    public class LostPassportInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LostPassportInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LostPassportInformations
        public async Task<IActionResult> Index()
        {
            var lostPassPortInformation = await _context.LostPassportInformation.ToListAsync();
              return View(lostPassPortInformation);
        }

        // GET: LostPassportInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LostPassportInformation == null)
            {
                return NotFound();
            }

            var lostPassportInformation = await _context.LostPassportInformation
                .FirstOrDefaultAsync(m => m.passportId == id);
            if (lostPassportInformation == null)
            {
                return NotFound();
            }

            return View(lostPassportInformation);
        }

        // GET: LostPassportInformations/Create
        public IActionResult Create()
        {
            ViewBag.seccuss = "";
            return View();
        }

        // POST: LostPassportInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LostPassportInformationVM lostPassportInformationVM)
        {

            if (ModelState.IsValid)
            {
                var lostPassportInformation = new LostPassportInformation()
                {
                    Dateofloss = lostPassportInformationVM.Dateofloss,
                    DepartmentId = lostPassportInformationVM.DepartmentId,
                    Nationality = lostPassportInformationVM.Nationality,
                    passportId = lostPassportInformationVM.passportId,
                    PassportOwnerName = lostPassportInformationVM.PassportOwnerName,
                    PassportType = lostPassportInformationVM.PassportType,
                    Thecommandbasedonit = lostPassportInformationVM.Thecommandbasedonit,
                    Thenote = lostPassportInformationVM.Thenote,
                    Thereasonofdelete = lostPassportInformationVM.Thenote
                };
                _context.Add(lostPassportInformation);
                await _context.SaveChangesAsync();
                ViewBag.seccuss = "the data has been saved seccussfully";
                return View(lostPassportInformationVM);

                //return RedirectToAction(nameof(Index));
            }
            ViewBag.seccuss = "";
            return View(lostPassportInformationVM);
        }

        // GET: LostPassportInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LostPassportInformation == null)
            {
                return NotFound();
            }

            var lostPassportInformation = await _context.LostPassportInformation.FindAsync(id);
            if (lostPassportInformation == null)
            {
                return NotFound();
            }
            var lostPassportInformationVM = new LostPassportInformationVM()
            {
                Dateofloss = lostPassportInformation.Dateofloss,
                DepartmentId = lostPassportInformation.DepartmentId,
                Nationality = lostPassportInformation.Nationality,
                passportId = lostPassportInformation.passportId,
                PassportOwnerName = lostPassportInformation.PassportOwnerName,
                PassportType = lostPassportInformation.PassportType,
                Thecommandbasedonit = lostPassportInformation.Thecommandbasedonit,
                Thenote = lostPassportInformation.Thenote,
                Thereasonofdelete = lostPassportInformation.Thenote
            };

            return View(lostPassportInformationVM);
        }

        // POST: LostPassportInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LostPassportInformationVM lostPassportInformationVM)
        {
            if (id != lostPassportInformationVM.passportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var lostPassportInformation = new LostPassportInformation()
                    {
                        Dateofloss = lostPassportInformationVM.Dateofloss,
                        DepartmentId = lostPassportInformationVM.DepartmentId,
                        Nationality = lostPassportInformationVM.Nationality,
                        passportId = lostPassportInformationVM.passportId,
                        PassportOwnerName = lostPassportInformationVM.PassportOwnerName,
                        PassportType = lostPassportInformationVM.PassportType,
                        Thecommandbasedonit = lostPassportInformationVM.Thecommandbasedonit,
                        Thenote = lostPassportInformationVM.Thenote,
                        Thereasonofdelete = lostPassportInformationVM.Thenote
                    };
                    _context.Update(lostPassportInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LostPassportInformationExists(lostPassportInformationVM.passportId))
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
            return View(lostPassportInformationVM);
        }

        // GET: LostPassportInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LostPassportInformation == null)
            {
                return NotFound();
            }

            var lostPassportInformation = await _context.LostPassportInformation
                .FirstOrDefaultAsync(m => m.passportId == id);
            if (lostPassportInformation == null)
            {
                return NotFound();
            }

            return View(lostPassportInformation);
        }

        // POST: LostPassportInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LostPassportInformation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LostPassportInformation'  is null.");
            }
            var lostPassportInformation = await _context.LostPassportInformation.FindAsync(id);
            if (lostPassportInformation != null)
            {
                _context.LostPassportInformation.Remove(lostPassportInformation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LostPassportInformationExists(int id)
        {
          return _context.LostPassportInformation.Any(e => e.passportId == id);
        }
    }
}
