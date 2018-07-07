using GedPiDev.Domain.Entities;
using GedPiDev.Service.Implementation;
using GedPiDev.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication1.Controllers
{   [Authorize]
    public class AdresseController : ApiController
    {
        private IAdresseService AdresseService = new AdresseService();

        [Authorize(Roles = "user")]
        // GET: api/Adresses
        public Task<List<Adresse>> GetAdresse()
        {
            return AdresseService.GetAllAsync();
        }
        [Authorize(Roles = "user")]
        // GET: api/Adresses/5
        [ResponseType(typeof(Adresse))]
        public async Task<IHttpActionResult> GetAdresse(string id)
        {
            Adresse Adresse = AdresseService.GetById(id);
            if (Adresse == null)
            {
                return NotFound();
            }

            return Ok(Adresse);
        }
        [Authorize(Roles = "canEdit,CanAdd")]
        // PUT: api/Adresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdresse(string id, Adresse Adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Adresse.AdresseId)
            {
                return BadRequest();
            }

            AdresseService.Update(Adresse);
            AdresseService.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
        [Authorize(Roles = "canAdd,canEdit")]
        // POST: api/Adresses
        [ResponseType(typeof(Adresse))]
        public async Task<IHttpActionResult> PostAdresse(Adresse Adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AdresseService.Add(Adresse);
            AdresseService.CommitAsync();

            return CreatedAtRoute("DefaultApi", new { id = Adresse.AdresseId }, Adresse);
        }
        [Authorize(Roles = "Admin")]
        // DELETE: api/Adresse/5
        [ResponseType(typeof(Adresse))]
        public async Task<IHttpActionResult> DeleteAdresse(string id)
        {
            Adresse Adresse = AdresseService.GetById(id);
            if (Adresse == null)
            {
                return NotFound();
            }

            AdresseService.Delete(Adresse);
            AdresseService.CommitAsync();

            return Ok(Adresse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                AdresseService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttachementExists(int id)
        {
            return (AdresseService.GetById(id) != null);
        }
    }
}
