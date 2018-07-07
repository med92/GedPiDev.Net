using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GedPiDev.Domain.Entities;
using GedPiDev.Service;

namespace GedPiDev.RestAPI.Controllers
{
    [Authorize]
    public class DepartmentsController : ApiController
    {
        private IDepartmentService depService = new DepartmentService();
        [Authorize(Roles = "user")]
        // GET: api/Departments
        public Task<List<Department>> GetDepartments()
        {
            return depService.GetAllAsync(); 
        }
        [Authorize(Roles = "user")]
        // GET: api/Departments/5
        [ResponseType(typeof(Department))]
        public async Task<IHttpActionResult> GetDepartment(string id)
        {
            Department department = depService.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }
        [Authorize(Roles = "canEdit,canAdd")]
        // PUT: api/Departments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDepartment(string id, Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != department.DepartementId)
            {
                return BadRequest();
            }

            depService.Update(department);
            depService.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
        [Authorize(Roles = "canAdd,canEdit")]
        // POST: api/Departments
        [ResponseType(typeof(Department))]
        public async Task<IHttpActionResult> PostDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            depService.Add(department);
            depService.CommitAsync();

            return CreatedAtRoute("DefaultApi", new { id = department.DepartementId }, department);
        }
        [Authorize(Roles = "Admin")]
        // DELETE: api/Departments/5
        [ResponseType(typeof(Department))]
        public async Task<IHttpActionResult> DeleteDepartment(string id)
        {
            Department department = depService.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            depService.Delete(department);
            depService.CommitAsync();

            return Ok(department);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                depService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentExists(string id)
        {
            return (depService.GetById(id) != null);
        }
    }
}