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
using DJF_web_api_POC.Models;

namespace DJF_web_api_POC.Controllers
{
    public class MembersController : ApiController
    {
        private DJF_web_api_POCContext db = new DJF_web_api_POCContext();

        // GET: api/Members
        public IQueryable<Member> GetMembers()
        {
            return db.Members;
        }

        // GET: api/Members/5
        [ResponseType(typeof(Member))]
        public async Task<IHttpActionResult> GetMember(Guid id)
        {
            Member member = await db.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // PUT: api/Members/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMember(Guid id, Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != member.Id)
            {
                return BadRequest();
            }

            db.Entry(member).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // POST: api/Members
        [ResponseType(typeof(Member))]
        public async Task<IHttpActionResult> PostMember(Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Members.Add(member);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MemberExists(member.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = member.Id }, member);
        }

        // DELETE: api/Members/5
        [ResponseType(typeof(Member))]
        public async Task<IHttpActionResult> DeleteMember(Guid id)
        {
            Member member = await db.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            db.Members.Remove(member);
            await db.SaveChangesAsync();

            return Ok(member);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemberExists(Guid id)
        {
            return db.Members.Count(e => e.Id == id) > 0;
        }
    }
}