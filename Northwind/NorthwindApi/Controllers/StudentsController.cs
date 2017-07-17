using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreDemo.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EfCoreDemo;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace NorthwindApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Students")]
    public class StudentsController : Controller
    {
        private readonly DemoDbContext _dbCtx;

        public StudentsController(DemoDbContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _dbCtx.Students.ToListAsync();
        }


        [HttpGet("find/{id}")]
        public async Task<Student> FindStudent([FromRoute] int id)
        {
            return await _dbCtx.Students.FindAsync(id);
        }


        [HttpGet("all-from-set")]
        public async Task<IEnumerable<Student>> GetStudentsFromSet()
        {
            return await _dbCtx.Set<Student>().ToListAsync();
        }


        [HttpGet("all-no-tracking")]
        public async Task<IEnumerable<Student>> GetStudentsNoTracking()
        {
            return await _dbCtx.Students
                .AsNoTracking()
                .ToListAsync();
        }


        /// <summary>
        /// WARNING this will crash
        /// </summary>
        /// <returns></returns>
        [HttpGet("all-including-enrollments")]
        public async Task<IEnumerable<Student>> GetStudentsIncludingEnrollments()
        {
            return await _dbCtx.Students
                .Include(s => s.Enrollments)
                .ToListAsync();
        }


        [HttpGet("all-projected")]
        public async Task<IEnumerable<Student>> GetStudentsAndEnrollmentsProjected()
        {
            return await _dbCtx.Students
                .Include(s => s.Enrollments)
                .Select(s => new Student()
                {
                    Id = s.Id,
                    Firstname = s.Firstname,
                    Lastname = s.Lastname,
                    Enrollments = s.Enrollments.Select(e => new Enrollment()
                    {
                        Id = e.Id,
                        CourseId = e.CourseId,
                        StudentId = e.StudentId
                    }).ToList()
                })
                .ToListAsync();
        }



        /// <summary>
        /// This is bad!
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("update")]
        public async Task<Student> UpdateStudent(Student model)
        {
            _dbCtx.Students.Update(model);
            await _dbCtx.SaveChangesAsync();

            return model;
        }


        [HttpPost("save")]
        public async Task<Student> SaveStudent(Student model)
        {
            var entity = await _dbCtx.FindAsync<Student>(model.Id)
                ?? new Student();

            entity.Firstname = model.Firstname;
            entity.Lastname = model.Lastname;

            if (entity.Id == 0)
            {
                await _dbCtx.AddAsync(entity);
            }
            await _dbCtx.SaveChangesAsync();

            return entity;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var entity = await _dbCtx.Students.FindAsync(id);
            if (entity == null) return new NotFoundResult();

            _dbCtx.Students.Remove(entity);
            await _dbCtx.SaveChangesAsync();

            return new NoContentResult();
        }

    }
}