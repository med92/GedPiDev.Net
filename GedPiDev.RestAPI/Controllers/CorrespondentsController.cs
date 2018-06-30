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
    public class CorrespondentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Correspondents
        public IQueryable<Correspondent> GetCorrespondents()
        {
            return db.Correspondents;
        }

        // GET: api/Correspondents/5
        [ResponseType(typeof(Correspondent))]
        public async Task<IHttpActionResult> GetCorrespondent(int id)
        {
            Correspondent correspondent = await db.Correspondents.FindAsync(id);
            if (correspondent == null)
            {
                return NotFound();
            }

            return Ok(correspondent);
        }

        // PUT: api/Correspondents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCorrespondent(int id, Correspondent correspondent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != correspondent.Id)
            {
                return BadRequest();
            }

            db.Entry(correspondent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorrespondentExists(id))
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

        // POST: api/Correspondents
        [ResponseType(typeof(Correspondent))]
        public async Task<IHttpActionResult> PostCorrespondent(Correspondent correspondent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Correspondents.Add(correspondent);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = correspondent.Id }, correspondent);
        }

        // DELETE: api/Correspondents/5
        [ResponseType(typeof(Correspondent))]
        public async Task<IHttpActionResult> DeleteCorrespondent(int id)
        {
            Correspondent correspondent = await db.Correspondents.FindAsync(id);
            if (correspondent == null)
            {
                return NotFound();
            }

            db.Correspondents.Remove(correspondent);
            await db.SaveChangesAsync();

            return Ok(correspondent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CorrespondentExists(int id)
        {
            return db.Correspondents.Count(e => e.Id == id) > 0;
        }
    }
}