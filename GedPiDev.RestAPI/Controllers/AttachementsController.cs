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
    public class AttachementsController : ApiController
    {
        private IAttachementService attachmentService = new AttachmentService();

        // GET: api/Attachements
        public Task<List<Attachement>> GetAttachements()
        {
            return attachmentService.GetAllAsync();
        }

        // GET: api/Attachements/5
        [ResponseType(typeof(Attachement))]
        public async Task<IHttpActionResult> GetAttachement(int id)
        {
            Attachement attachement = attachmentService.GetById(id);
            if (attachement == null)
            {
                return NotFound();
            }

            return Ok(attachement);
        }

        // PUT: api/Attachements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAttachement(int id, Attachement attachement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attachement.Id)
            {
                return BadRequest();
            }

            attachmentService.Update(attachement);
            attachmentService.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Attachements
        [ResponseType(typeof(Attachement))]
        public async Task<IHttpActionResult> PostAttachement(Attachement attachement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            attachmentService.Add(attachement);
            attachmentService.CommitAsync();

            return CreatedAtRoute("DefaultApi", new { id = attachement.Id }, attachement);
        }

        // DELETE: api/Attachements/5
        [ResponseType(typeof(Attachement))]
        public async Task<IHttpActionResult> DeleteAttachement(int id)
        {
            Attachement attachement = attachmentService.GetById(id);
            if (attachement == null)
            {
                return NotFound();
            }

            attachmentService.Delete(attachement);
            attachmentService.CommitAsync(); 

            return Ok(attachement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                attachmentService.Dispose()
            }
            base.Dispose(disposing);
        }

        private bool AttachementExists(int id)
        {
            return (attachmentService.GetById(id) != null);
        }
    }
}