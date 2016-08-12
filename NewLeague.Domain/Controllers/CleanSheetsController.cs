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
    public class CleanSheetsController : ApiController
    {
        private DomainContext db = new DomainContext();

        // GET: api/CleanSheets
        public IQueryable<CleanSheet> GetCleanSheets()
        {
            return db.CleanSheets;
        }

        // GET: api/CleanSheets/5
        [ResponseType(typeof(CleanSheet))]
        public IHttpActionResult GetCleanSheet(int id)
        {
            CleanSheet cleanSheet = db.CleanSheets.Find(id);
            if (cleanSheet == null)
            {
                return NotFound();
            }

            return Ok(cleanSheet);
        }

        // PUT: api/CleanSheets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCleanSheet(int id, CleanSheet cleanSheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cleanSheet.Id)
            {
                return BadRequest();
            }

            db.Entry(cleanSheet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                SetInMatch(cleanSheet.MatchId, cleanSheet.PlayerId, cleanSheet.TeamId);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CleanSheetExists(id))
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

        // POST: api/CleanSheets
        [ResponseType(typeof(CleanSheet))]
        public IHttpActionResult PostCleanSheet(CleanSheet cleanSheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sheets = db.CleanSheets.AsNoTracking().Where(x => x.MatchId == cleanSheet.MatchId).ToList();
            foreach (var item in sheets)
            {
                if (item.TeamId == cleanSheet.TeamId)
                {
                    cleanSheet.Id = item.Id;
                    PutCleanSheet(item.Id, cleanSheet);
                    //var currentItem = db.CleanSheets.Find(item.Id);
                    //db.Entry(currentItem).CurrentValues.SetValues(cleanSheet);
                    //db.SaveChanges();
                    return CreatedAtRoute("DefaultApi", new { id = cleanSheet.Id }, cleanSheet);
                }
            }

            db.CleanSheets.Add(cleanSheet);
            db.SaveChanges();
            SetInMatch(cleanSheet.MatchId, cleanSheet.PlayerId, cleanSheet.TeamId);

            return CreatedAtRoute("DefaultApi", new { id = cleanSheet.Id }, cleanSheet);
        }

        // DELETE: api/CleanSheets/5
        [ResponseType(typeof(CleanSheet))]
        public IHttpActionResult DeleteCleanSheet(int id)
        {
            CleanSheet cleanSheet = db.CleanSheets.Find(id);
            if (cleanSheet == null)
            {
                return NotFound();
            }

            db.CleanSheets.Remove(cleanSheet);
            db.SaveChanges();

            return Ok(cleanSheet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CleanSheetExists(int id)
        {
            return db.CleanSheets.Count(e => e.Id == id) > 0;
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
                if (teamId == match.HomeId)
                {
                    match.HomeGoalkeeperId = playerId;
                }
                else if (teamId == match.AwayId)
                {
                    match.AwayGoalkeeperId = playerId;
                }

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