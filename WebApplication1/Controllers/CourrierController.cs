using GedPiDev.Domain.Entities;
using GedPiDev.Service.Implementation;
using GedPiDev.Service.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class CourrierController : ApiController
    {
        private ICourrierService courrierService = new CourrierService();

        // GET: api/Courriers
        [Authorize(Roles = "user")]
        public Task<List<Courrier>> GetCourrier()
        {
            return courrierService.GetAllAsync();
        }
        [Authorize(Roles = "user")]
        // GET: api/Courriers/5
        [ResponseType(typeof(Courrier))]
        public async Task<IHttpActionResult> GetCourrier(string id)
        {
            Courrier courrier = courrierService.GetById(id);
            if (courrier == null)
            {
                return NotFound();
            }

            return Ok(courrier);
        }
        [Authorize(Roles = "canEdit,canAdd")]
        // PUT: api/Courriers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCourrier(string id, Courrier Courrier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Courrier.CourrierId)
            {
                return BadRequest();
            }

            courrierService.Update(Courrier);
            courrierService.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
        [Authorize(Roles = "canAdd,canEdit")]
        // POST: api/Courriers
        [ResponseType(typeof(Courrier))]
        public async Task<IHttpActionResult> PostCourrier(Courrier Courrier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            courrierService.Add(Courrier);
            courrierService.CommitAsync();

            return CreatedAtRoute("DefaultApi", new { id = Courrier.CourrierId }, Courrier);
        }
        [Authorize(Roles = "Admin")]
        // DELETE: api/Courriers/5
        [ResponseType(typeof(Courrier))]
        public async Task<IHttpActionResult> DeleteCourrier(string id)
        {
            Courrier Courrier = courrierService.GetById(id);
            if (Courrier == null)
            {
                return NotFound();
            }

            courrierService.Delete(Courrier);
            courrierService.CommitAsync();

            return Ok(Courrier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                courrierService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttachementExists(int id)
        {
            return (courrierService.GetById(id) != null);
        }
    }

}

