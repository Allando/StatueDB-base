using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class GPSLocationsController : ApiController
    {
        private readonly StatueContext db = new StatueContext();

        // GET: api/GPSLocations
        public IQueryable<GPSLocation> GetGPSLocations()
        {
            return db.GPSLocations;
        }

        // GET: api/GPSLocations/5
        [ResponseType(typeof(GPSLocation))]
        public IHttpActionResult GetGPSLocation(int id)
        {
            var GPSLocation = db.GPSLocations.Find(id);
            if (GPSLocation == null)
            {
                return NotFound();
            }

            return Ok(GPSLocation);
        }

        // PUT: api/GPSLocations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGPSLocation(int id, GPSLocation GPSLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != GPSLocation.Id)
            {
                return BadRequest();
            }

            db.Entry(GPSLocation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GPSLocationExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GPSLocations
        [ResponseType(typeof(GPSLocation))]
        public IHttpActionResult PostGPSLocation(GPSLocation GPSLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GPSLocations.Add(GPSLocation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = GPSLocation.Id}, GPSLocation);
        }

        // DELETE: api/GPSLocations/5
        [ResponseType(typeof(GPSLocation))]
        public IHttpActionResult DeleteGPSLocation(int id)
        {
            var GPSLocation = db.GPSLocations.Find(id);
            if (GPSLocation == null)
            {
                return NotFound();
            }

            db.GPSLocations.Remove(GPSLocation);
            db.SaveChanges();

            return Ok(GPSLocation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GPSLocationExists(int id)
        {
            return db.GPSLocations.Count(e => e.Id == id) > 0;
        }
    }
}