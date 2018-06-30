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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using GedPiDev.Domain.Entities;
using GedPiDev.RestAPI.Models;

namespace GedPiDev.RestAPI.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using GedPiDev.Domain.Entities;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Courrier>("Courriers");
    builder.EntitySet<Traceability>("Traceabilities"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CourriersController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/Courriers
        [EnableQuery]
        public IQueryable<Courrier> GetCourriers()
        {
            return db.Courriers;
        }

        // GET: odata/Courriers(5)
        [EnableQuery]
        public SingleResult<Courrier> GetCourrier([FromODataUri] int key)
        {
            return SingleResult.Create(db.Courriers.Where(courrier => courrier.Id == key));
        }

        // PUT: odata/Courriers(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Courrier> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Courrier courrier = await db.Courriers.FindAsync(key);
            if (courrier == null)
            {
                return NotFound();
            }

            patch.Put(courrier);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourrierExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(courrier);
        }

        // POST: odata/Courriers
        public async Task<IHttpActionResult> Post(Courrier courrier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courriers.Add(courrier);
            await db.SaveChangesAsync();

            return Created(courrier);
        }

        // PATCH: odata/Courriers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Courrier> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Courrier courrier = await db.Courriers.FindAsync(key);
            if (courrier == null)
            {
                return NotFound();
            }

            patch.Patch(courrier);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourrierExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(courrier);
        }

        // DELETE: odata/Courriers(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Courrier courrier = await db.Courriers.FindAsync(key);
            if (courrier == null)
            {
                return NotFound();
            }

            db.Courriers.Remove(courrier);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Courriers(5)/traceability
        [EnableQuery]
        public SingleResult<Traceability> Gettraceability([FromODataUri] int key)
        {
            return SingleResult.Create(db.Courriers.Where(m => m.Id == key).Select(m => m.traceability));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourrierExists(int key)
        {
            return db.Courriers.Count(e => e.Id == key) > 0;
        }
    }
}
