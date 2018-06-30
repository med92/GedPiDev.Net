﻿using System;
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
using GedPiDev.Service.Implementation;
using GedPiDev.Service.Interfaces;

namespace GedPiDev.RestAPI.Controllers
{
    public class DocumentsController : ApiController
    {
        private IDocumentService docService = new DocumentService();

        // GET: api/Documents
        public IQueryable<Document> GetDocuments()
        {
            return docService.GetAllAsync(); 
        }

        // GET: api/Documents/5
        [ResponseType(typeof(Document))]
        public async Task<IHttpActionResult> GetDocument(int id)
        {
            Document document = docService.GetById(id);
            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        // PUT: api/Documents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDocument(int id, Document document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != document.Id)
            {
                return BadRequest();
            }

            docService.Update(document);
            docService.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Documents
        [ResponseType(typeof(Document))]
        public async Task<IHttpActionResult> PostDocument(Document document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            docService.Add(document);
            docService.CommitAsync();

            return CreatedAtRoute("DefaultApi", new { id = document.Id }, document);
        }

        // DELETE: api/Documents/5
        [ResponseType(typeof(Document))]
        public async Task<IHttpActionResult> DeleteDocument(int id)
        {
            Document document = docService.GetById(id);
            if (document == null)
            {
                return NotFound();
            }

            docService.Delete(document);
            docService.CommitAsync();

            return Ok(document);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                docService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocumentExists(int id)
        {
            return (docService.GetById(id) != null);
        }
    }
}