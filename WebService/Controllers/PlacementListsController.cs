using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class PlacementListsController : ApiController
    {
        private readonly StatueContext db = new StatueContext();

        // GET: api/PlacementLists
        public IQueryable<PlacementList> GetPlacementLists()
        {
            return db.PlacementLists;
        }

        // GET: api/PlacementLists/5
        [ResponseType(typeof(PlacementList))]
        public IHttpActionResult GetPlacementList(int id)
        {
            var placementList = db.PlacementLists.Find(id);
            if (placementList == null)
            {
                return NotFound();
            }

            return Ok(placementList);
        }

        // PUT: api/PlacementLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlacementList(int id, PlacementList placementList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != placementList.Id)
            {
                return BadRequest();
            }

            db.Entry(placementList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlacementListExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PlacementLists
        [ResponseType(typeof(PlacementList))]
        public IHttpActionResult PostPlacementList(PlacementList placementList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlacementLists.Add(placementList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = placementList.Id}, placementList);
        }

        // DELETE: api/PlacementLists/5
        [ResponseType(typeof(PlacementList))]
        public IHttpActionResult DeletePlacementList(int id)
        {
            var placementList = db.PlacementLists.Find(id);
            if (placementList == null)
            {
                return NotFound();
            }

            db.PlacementLists.Remove(placementList);
            db.SaveChanges();

            return Ok(placementList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlacementListExists(int id)
        {
            return db.PlacementLists.Count(e => e.Id == id) > 0;
        }
    }
}