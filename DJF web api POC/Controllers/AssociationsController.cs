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
using DJF_web_api_POC.Models;

namespace DJF_web_api_POC.Controllers
{
    public class AssociationsController : ApiController
    {
        private DJF_web_api_POCContext db = new DJF_web_api_POCContext();

        // GET: api/Associations
        public IQueryable<Association> GetAssociations()
        {
            return db.Associations;
        }

        // GET: api/Associations/5
        [ResponseType(typeof(Association))]
        public async Task<IHttpActionResult> GetAssociation(Guid id)
        {
            Association association = await db.Associations.FindAsync(id);
            if (association == null)
            {
                return NotFound();
            }

            return Ok(association);
        }

        // PUT: api/Associations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAssociation(Guid id, Association association)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != association.Id)
            {
                return BadRequest();
            }

            db.Entry(association).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociationExists(id))
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

        // POST: api/Associations
        [ResponseType(typeof(Association))]
        public async Task<IHttpActionResult> PostAssociation(Association association)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Associations.Add(association);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AssociationExists(association.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = association.Id }, association);
        }

        // DELETE: api/Associations/5
        [ResponseType(typeof(Association))]
        public async Task<IHttpActionResult> DeleteAssociation(Guid id)
        {
            Association association = await db.Associations.FindAsync(id);
            if (association == null)
            {
                return NotFound();
            }

            db.Associations.Remove(association);
            await db.SaveChangesAsync();

            return Ok(association);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssociationExists(Guid id)
        {
            return db.Associations.Count(e => e.Id == id) > 0;
        }
    }
}