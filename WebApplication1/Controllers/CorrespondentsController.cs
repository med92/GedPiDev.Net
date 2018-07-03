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
using GedPiDev.Service.Interfaces;
using GedPiDev.Service.Implementation;

namespace GedPiDev.RestAPI.Controllers
{
    public class CorrespondentsController : ApiController
    {
        private ICorrespondantService corrService = new CorrespondentService();

        // GET: api/Correspondents
        public Task<List<Correspondent>> GetCorrespondents()
        {
            return corrService.GetAllAsync();
        }

        // GET: api/Correspondents/5
        [ResponseType(typeof(Correspondent))]
        public async Task<IHttpActionResult> GetCorrespondent(string id)
        {
            Correspondent correspondent = corrService.GetById(id);
            if (correspondent == null)
            {
                return NotFound();
            }

            return Ok(correspondent);
        }

        // PUT: api/Correspondents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCorrespondent(string id, Correspondent correspondent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != correspondent.CorrespondentId)
            {
                return BadRequest();
            }

            corrService.Update(correspondent);
            corrService.CommitAsync();

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

            corrService.Add(correspondent);
            corrService.CommitAsync();

            return CreatedAtRoute("DefaultApi", new { id = correspondent.CorrespondentId }, correspondent);
        }

        // DELETE: api/Correspondents/5
        [ResponseType(typeof(Correspondent))]
        public async Task<IHttpActionResult> DeleteCorrespondent(string id)
        {
            Correspondent correspondent = corrService.GetById(id);
            if (correspondent == null)
            {
                return NotFound();
            }

            corrService.Delete(correspondent); 

            return Ok(correspondent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                corrService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CorrespondentExists(string id)
        {
            return (corrService.GetById(id) != null);
        }
    }
}