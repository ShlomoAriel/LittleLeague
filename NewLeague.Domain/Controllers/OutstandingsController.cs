using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NewLeague.Domain.Models;
using NewLeague.Domain.Models.NewLeague;
using NewLeague.Models;

namespace NewLeague.Domain.Controllers
{
    public class OutstandingsController : ApiController
    {
        private DomainContext db = new DomainContext();

        // GET: api/Outstandings
        public IQueryable<Outstanding> GetOutstandings()
        {
            return db.Outstandings;
        }

        // GET: api/Outstandings/5
        [ResponseType(typeof(Outstanding))]
        public IHttpActionResult GetOutstanding(int id)
        {
            Outstanding outstanding = db.Outstandings.Find(id);
            if (outstanding == null)
            {
                return NotFound();
            }

            return Ok(outstanding);
        }

        // PUT: api/Outstandings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOutstanding(int id, Outstanding outstanding)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != outstanding.Id)
            {
                return BadRequest();
            }

            db.Entry(outstanding).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                SetInMatch(outstanding.MatchId, outstanding.PlayerId, outstanding.TeamId);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OutstandingExists(id))
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

        // POST: api/Outstandings
        [ResponseType(typeof(Outstanding))]
        public IHttpActionResult PostOutstanding(Outstanding outstanding)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var old = db.Outstandings.FirstOrDefault(x=>x.MatchId==outstanding.MatchId);
            if(old!=null)
            {
                db.Outstandings.Remove(old);
            }
                db.Outstandings.Add(outstanding);
                db.SaveChanges();
                SetInMatch(outstanding.MatchId, outstanding.PlayerId, outstanding.TeamId);
            
            

            return CreatedAtRoute("DefaultApi", new { id = outstanding.Id }, outstanding);
        }

        // DELETE: api/Outstandings/5
        [ResponseType(typeof(Outstanding))]
        public IHttpActionResult DeleteOutstanding(int id)
        {
            Outstanding outstanding = db.Outstandings.Find(id);
            if (outstanding == null)
            {
                return NotFound();
            }

            db.Outstandings.Remove(outstanding);
            db.SaveChanges();

            return Ok(outstanding);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OutstandingExists(int id)
        {
            return db.Outstandings.Count(e => e.Id == id) > 0;
        }
        public void SetInMatch(int matchId, int playerId, int teamId)
        {
            Match match;
            using (var ctx = new DomainContext())
            {
                match = ctx.Matches.FirstOrDefault(x => x.Id == matchId);
            }
            if (match != null)
            {
                match.OutstandingId = playerId;
            }
            using (var dbCtx = new DomainContext())
            {
                //3. Mark entity as modified
                dbCtx.Entry(match).State = System.Data.Entity.EntityState.Modified;

                //4. call SaveChanges
                dbCtx.SaveChanges();
            }
        }
    }
}