using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class PlacementsController : ApiController
    {
        private readonly StatueContext db = new StatueContext();

        // GET: api/Placements
        public IQueryable<Placement> GetPlacements()
        {
            return db.Placements;
        }

        // GET: api/Placements/5
        [ResponseType(typeof(Placement))]
        public IHttpActionResult GetPlacement(int id)
        {
            var placement = db.Placements.Find(id);
            if (placement == null)
            {
                return NotFound();
            }

            return Ok(placement);
        }

        // PUT: api/Placements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlacement(int id, Placement placement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != placement.Id)
            {
                return BadRequest();
            }

            db.Entry(placement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlacementExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Placements
        [ResponseType(typeof(Placement))]
        public IHttpActionResult PostPlacement(Placement placement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Placements.Add(placement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = placement.Id}, placement);
        }

        // DELETE: api/Placements/5
        [ResponseType(typeof(Placement))]
        public IHttpActionResult DeletePlacement(int id)
        {
            var placement = db.Placements.Find(id);
            if (placement == null)
            {
                return NotFound();
            }

            db.Placements.Remove(placement);
            db.SaveChanges();

            return Ok(placement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlacementExists(int id)
        {
            return db.Placements.Count(e => e.Id == id) > 0;
        }
    }
}