using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mswebtechAssignment1.Models;

namespace mswebtechAssignment1.Controllers
{
    public class BPMeasurementController : Controller
    {
        private readonly BPMeasurementsContext _context;

        public BPMeasurementController(BPMeasurementsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.BPMeasurements.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bPMeasurement = await _context.BPMeasurements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bPMeasurement == null)
            {
                return NotFound();
            }

            return View(bPMeasurement);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Systolic,Diastolic,DateTaken,Position")] BPMeasurement bPMeasurement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bPMeasurement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bPMeasurement);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bPMeasurement = await _context.BPMeasurements.FindAsync(id);
            if (bPMeasurement == null)
            {
                return NotFound();
            }
            return View(bPMeasurement);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Systolic,Diastolic,DateTaken,Position")] BPMeasurement bPMeasurement)
        {
            if (id != bPMeasurement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bPMeasurement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BPMeasurementExists(bPMeasurement.Id))
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
            return View(bPMeasurement);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bPMeasurement = await _context.BPMeasurements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bPMeasurement == null)
            {
                return NotFound();
            }

            return View(bPMeasurement);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bPMeasurement = await _context.BPMeasurements.FindAsync(id);
            if (bPMeasurement != null)
            {
                _context.BPMeasurements.Remove(bPMeasurement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BPMeasurementExists(int id)
        {
            return _context.BPMeasurements.Any(e => e.Id == id);
        }
        public string GetCategoryClass(string category)
        {
            switch (category)
            {
                case "Normal":
                    return "badge-success";
                case "Elevated":
                    return "badge-primary";
                case "Hypertension Stage 1":
                    return "badge-warning";
                case "Hypertension Stage 2":
                    return "badge-danger";
                case "Hypertensive Crisis":
                    return "badge-dark";
                default:
                    return "badge-secondary";
            }
        }

    }
}
