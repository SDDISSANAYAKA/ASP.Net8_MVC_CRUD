using DotNet8_MVC_CRUD.Data;
using DotNet8_MVC_CRUD.Models;
using DotNet8_MVC_CRUD.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet8_MVC_CRUD.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return View();


        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
           var students = await dbContext.Students.ToListAsync();
            return View(students );
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
           var student = await dbContext.Students.FindAsync(viewModel.Id);

            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Subscribed = viewModel.Subscribed;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Students");
        }
        
    }
}
