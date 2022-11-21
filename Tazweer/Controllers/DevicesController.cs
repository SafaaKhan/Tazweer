using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tazweer.Data;
using Tazweer.Models;
using Tazweer.Models.ViewModels;

namespace Tazweer.Controllers
{
    public class DevicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            var devices = await _context.Devices.Include(d => d.Employee).ToListAsync();
            return View(devices);
        }

       
        // GET: Devices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Devices == null)
            {
                return NotFound();
            }

            var devices = await _context.Devices
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.DevicesId == id);
            if (devices == null)
            {
                return NotFound();
            }

            return View(devices);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "Name");
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( DevicesVM devicesVM)
        {
            if (ModelState.IsValid)
            {
                var devices = new Devices()
                {
                    EmployeeId = devicesVM.EmployeeId,
                    AddNote=devicesVM.AddNote,
                    NameDevice=devicesVM.NameDevice
                };
                _context.Add(devices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "Email", devicesVM.EmployeeId);
            return View(devicesVM);
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Devices == null)
            {
                return NotFound();
            }

            var devices = await _context.Devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }
            var devicesVM = new DevicesVM()
            {
                DevicesId=devices.DevicesId,
                EmployeeId = devices.EmployeeId,
                AddNote = devices.AddNote,
                NameDevice = devices.NameDevice
            };
            ViewData["EmployeeId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "Name", devices.EmployeeId);
            return View(devicesVM);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DevicesVM devicesVM)
        {
            if (id != devicesVM.DevicesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var devices = new Devices()
                    {
                        DevicesId=devicesVM.DevicesId,
                        EmployeeId = devicesVM.EmployeeId,
                        AddNote = devicesVM.AddNote,
                        NameDevice = devicesVM.NameDevice
                    };
                    _context.Update(devices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevicesExists(devicesVM.DevicesId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Set<Employee>(), "EmployeeId", "Name", devicesVM.EmployeeId);
            return View(devicesVM);
        }

        // GET: Devices/Delete/5
       // [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Devices == null)
            {
                return NotFound();
            }

            var devices = await _context.Devices
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.DevicesId == id);
            if (devices == null)
            {
                return NotFound();
            }

            return View(devices);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Devices == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Devices'  is null.");
            }
            var devices = await _context.Devices.FindAsync(id);
            if (devices != null)
            {
                _context.Devices.Remove(devices);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevicesExists(int id)
        {
          return _context.Devices.Any(x => x.DevicesId == id);
        }
    }
}
