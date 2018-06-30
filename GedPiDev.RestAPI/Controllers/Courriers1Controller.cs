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

namespace GedPiDev.RestAPI.Controllers
{
    public class Courriers1Controller : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Courriers1
        public IQueryable<Courrier> GetCourriers()
        {
            return db.Courriers;
        }

        // GET: api/Courriers1/5
        [ResponseType(typeof(Courrier))]
        public async Task<IHttpActionResult> GetCourrier(int id)
        {
            Courrier courrier = await db.Courriers.FindAsync(id);
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

            db.Entry(courrier).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourrierExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

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

            db.Courriers.Add(courrier);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = courrier.Id }, courrier);
        }

        // DELETE: api/Courriers1/5
        [ResponseType(typeof(Courrier))]
        public async Task<IHttpActionResult> DeleteCourrier(int id)
        {
            Courrier courrier = await db.Courriers.FindAsync(id);
            if (courrier == null)
            {
                return NotFound();
            }

            db.Courriers.Remove(courrier);
            await db.SaveChangesAsync();

            return Ok(courrier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourrierExists(int id)
        {
            return db.Courriers.Count(e => e.Id == id) > 0;
        }
    }
}