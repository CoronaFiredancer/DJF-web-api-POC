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
    public class AssociationCommitteesController : ApiController
    {
        private DJF_web_api_POCContext db = new DJF_web_api_POCContext();

        // GET: api/AssociationCommittees
        public IQueryable<AssociationCommittee> GetAssociationCommittees()
        {
            return db.AssociationCommittees;
        }

        // GET: api/AssociationCommittees/5
        [ResponseType(typeof(AssociationCommittee))]
        public async Task<IHttpActionResult> GetAssociationCommittee(Guid id)
        {
            AssociationCommittee associationCommittee = await db.AssociationCommittees.FindAsync(id);
            if (associationCommittee == null)
            {
                return NotFound();
            }

            return Ok(associationCommittee);
        }

        // PUT: api/AssociationCommittees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAssociationCommittee(Guid id, AssociationCommittee associationCommittee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != associationCommittee.Id)
            {
                return BadRequest();
            }

            db.Entry(associationCommittee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociationCommitteeExists(id))
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

        // POST: api/AssociationCommittees
        [ResponseType(typeof(AssociationCommittee))]
        public async Task<IHttpActionResult> PostAssociationCommittee(AssociationCommittee associationCommittee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssociationCommittees.Add(associationCommittee);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AssociationCommitteeExists(associationCommittee.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = associationCommittee.Id }, associationCommittee);
        }

        // DELETE: api/AssociationCommittees/5
        [ResponseType(typeof(AssociationCommittee))]
        public async Task<IHttpActionResult> DeleteAssociationCommittee(Guid id)
        {
            AssociationCommittee associationCommittee = await db.AssociationCommittees.FindAsync(id);
            if (associationCommittee == null)
            {
                return NotFound();
            }

            db.AssociationCommittees.Remove(associationCommittee);
            await db.SaveChangesAsync();

            return Ok(associationCommittee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssociationCommitteeExists(Guid id)
        {
            return db.AssociationCommittees.Count(e => e.Id == id) > 0;
        }
    }
}