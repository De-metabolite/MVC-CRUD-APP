using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD_APP_MVC.Data;
using CRUD_APP_MVC.Entities;
using CRUD_APP_MVC.Models;

namespace CRUD_APP_MVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public async Task<IActionResult> Index()
        {
            return View(await _context.students.ToListAsync());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add([Bind("Id,Name,Email,Phone,Address")] StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                Student obj = new Student();
                obj.Id = student.Id;
                obj.Name = student.Name;
                obj.Email = student.Email;
                obj.Phone = student.Phone;
                obj.Address = student.Address;
                _context.Add(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); 

            }
            return View(student);   
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
                return NotFound();
            var student = await _context.students.FindAsync(Id);
            if (student == null)
                return NotFound();

            var model = new StudentViewModel();
            model.Id = student.Id;
            model.Name = student.Name;
            model.Email = student.Email;
            model.Phone = student.Phone;
            model.Address = student.Address;
            return View(model);


        }
        [HttpPost]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,Name,Email,Phone,Address")] StudentViewModel student)
        {
            if (Id != student.Id)
                return NotFound();
                        
            if (ModelState.IsValid)
            {
                var obj = new Student
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    Phone = student.Phone,
                    Address = student.Address,
                };
              ;
                _context.Update(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) 
        {
            var student = await  _context.students.FindAsync(id);
            if(student != null)
            {
                _context.students.Remove(student);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
