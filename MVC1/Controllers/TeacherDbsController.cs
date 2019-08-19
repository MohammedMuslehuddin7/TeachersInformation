using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC1.Models;

namespace MVC1.Controllers
{
    public class TeacherDbsController : Controller
    {
        private readonly EmployeeDBContext _context;

        public TeacherDbsController(EmployeeDBContext context)
        {
            _context = context;
        }

        // GET: TeacherDbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeacherDb.ToListAsync());
        }

        // GET: TeacherDbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherDb = await _context.TeacherDb
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (teacherDb == null)
            {
                return NotFound();
            }

            return View(teacherDb);
        }

        // GET: TeacherDbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeacherDbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,TeacherName,TeacherDept")] TeacherDb teacherDb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacherDb);
        }

        // GET: TeacherDbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherDb = await _context.TeacherDb.FindAsync(id);
            if (teacherDb == null)
            {
                return NotFound();
            }
            return View(teacherDb);
        }

        // POST: TeacherDbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeacherId,TeacherName,TeacherDept")] TeacherDb teacherDb)
        {
            if (id != teacherDb.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherDbExists(teacherDb.TeacherId))
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
            return View(teacherDb);
        }

        // GET: TeacherDbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherDb = await _context.TeacherDb
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (teacherDb == null)
            {
                return NotFound();
            }

            return View(teacherDb);
        }

        // POST: TeacherDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherDb = await _context.TeacherDb.FindAsync(id);
            _context.TeacherDb.Remove(teacherDb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherDbExists(int id)
        {
            return _context.TeacherDb.Any(e => e.TeacherId == id);
        }
    }
}
