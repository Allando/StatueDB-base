using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class ZipcodesController : ApiController
    {
        private readonly StatueContext db = new StatueContext();

        // GET: api/Zipcodes
        public IQueryable<Zipcode> GetZipcodes()
        {
            return db.Zipcodes;
        }

        // GET: api/Zipcodes/5
        [ResponseType(typeof(Zipcode))]
        public IHttpActionResult GetZipcode(string id)
        {
            var zipcode = db.Zipcodes.Find(id);
            if (zipcode == null)
            {
                return NotFound();
            }

            return Ok(zipcode);
        }

        // PUT: api/Zipcodes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZipcode(string id, Zipcode zipcode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zipcode.Zipcode1)
            {
                return BadRequest();
            }

            db.Entry(zipcode).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZipcodeExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Zipcodes
        [ResponseType(typeof(Zipcode))]
        public IHttpActionResult PostZipcode(Zipcode zipcode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zipcodes.Add(zipcode);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ZipcodeExists(zipcode.Zipcode1))
                {
                    return Conflict();
                }
                throw;
            }

            return CreatedAtRoute("DefaultApi", new {id = zipcode.Zipcode1}, zipcode);
        }

        // DELETE: api/Zipcodes/5
        [ResponseType(typeof(Zipcode))]
        public IHttpActionResult DeleteZipcode(string id)
        {
            var zipcode = db.Zipcodes.Find(id);
            if (zipcode == null)
            {
                return NotFound();
            }

            db.Zipcodes.Remove(zipcode);
            db.SaveChanges();

            return Ok(zipcode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZipcodeExists(string id)
        {
            return db.Zipcodes.Count(e => e.Zipcode1 == id) > 0;
        }
    }
}