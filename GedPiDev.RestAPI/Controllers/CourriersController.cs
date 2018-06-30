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
using GedPiDev.RestAPI.Models;
using GedPiDev.Service.Interfaces;
using GedPiDev.Service.Implementation;

namespace GedPiDev.RestAPI.Controllers
{
    public class CourriersController : ApiController
    {
        private ICourrierService courrierService = new CourrierService();

        // GET: api/Courriers1
        public Task<List<Courrier>> GetCourriers()
        {
            return courrierService.GetAllAsync();
        }

        // GET: api/Courriers1/5
        [ResponseType(typeof(Courrier))]
        public async Task<IHttpActionResult> GetCourrier(int id)
        {
            Courrier courrier = courrierService.GetById(id); 
            if (courrier == null)
            {
                return NotFound();
            }

            return Ok(courrier);
        }

        // PUT: api/Courriers1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCourrier(int id, Courrier courrier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courrier.Id)
            {
                return BadRequest();
            }

            courrierService.Update(courrier);
            courrierService.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Courriers1
        [ResponseType(typeof(Courrier))]
        public async Task<IHttpActionResult> PostCourrier(Courrier courrier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            courrierService.Add(courrier);
            courrierService.CommitAsync();

            return CreatedAtRoute("DefaultApi", new { id = courrier.Id }, courrier);
        }

        // DELETE: api/Courriers1/5
        [ResponseType(typeof(Courrier))]
        public async Task<IHttpActionResult> DeleteCourrier(int id)
        {
            Courrier courrier = courrierService.GetById(id);
            if (courrier == null)
            {
                return NotFound();
            }

            courrierService.Delete(courrier);
            courrierService.CommitAsync();

            return Ok(courrier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                courrierService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourrierExists(int id)
        {
            return (courrierService.GetById(id) != null);
;        }
    }
}