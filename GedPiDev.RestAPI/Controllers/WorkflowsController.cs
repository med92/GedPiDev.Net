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
    public class WorkflowsController : ApiController
    {
        private IWorkflowService workflowService = new WorkFlowService(); 

        // GET: api/Workflows
        public Task<List<Workflow>> GetWorkflows()
        {
            return workflowService.GetAllAsync();
        }

        // GET: api/Workflows/5
        [ResponseType(typeof(Workflow))]
        public async Task<IHttpActionResult> GetWorkflow(int id)
        {
            Workflow workflow = workflowService.GetById(id);
            if (workflow == null)
            {
                return NotFound();
            }

            return Ok(workflow);
        }

        // PUT: api/Workflows/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorkflow(int id, Workflow workflow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workflow.Id)
            {
                return BadRequest();
            }

            workflowService.Update(workflow);
            workflowService.CommitAsync();
            
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Workflows
        [ResponseType(typeof(Workflow))]
        public async Task<IHttpActionResult> PostWorkflow(Workflow workflow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            workflowService.Add(workflow);
            workflowService.CommitAsync();

            return CreatedAtRoute("DefaultApi", new { id = workflow.Id }, workflow);
        }

        // DELETE: api/Workflows/5
        [ResponseType(typeof(Workflow))]
        public async Task<IHttpActionResult> DeleteWorkflow(int id)
        {
            Workflow workflow = workflowService.GetById(id);
            if (workflow == null)
            {
                return NotFound();
            }

            workflowService.Delete(workflow);
            workflowService.CommitAsync();

            return Ok(workflow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                workflowService.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkflowExists(int id)
        {
            return (workflowService.GetById(id) != null);
        }
    }
}