using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class StatueTypeListsController : ApiController
    {
        private readonly StatueContext db = new StatueContext();

        // GET: api/StatueTypeLists
        public IQueryable<StatueTypeList> GetStatueTypeLists()
        {
            return db.StatueTypeLists;
        }

        // GET: api/StatueTypeLists/5
        [ResponseType(typeof(StatueTypeList))]
        public IHttpActionResult GetStatueTypeList(int id)
        {
            var statueTypeList = db.StatueTypeLists.Find(id);
            if (statueTypeList == null)
            {
                return NotFound();
            }

            return Ok(statueTypeList);
        }

        // PUT: api/StatueTypeLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatueTypeList(int id, StatueTypeList statueTypeList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statueTypeList.Id)
            {
                return BadRequest();
            }

            db.Entry(statueTypeList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatueTypeListExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StatueTypeLists
        [ResponseType(typeof(StatueTypeList))]
        public IHttpActionResult PostStatueTypeList(StatueTypeList statueTypeList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatueTypeLists.Add(statueTypeList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = statueTypeList.Id}, statueTypeList);
        }

        // DELETE: api/StatueTypeLists/5
        [ResponseType(typeof(StatueTypeList))]
        public IHttpActionResult DeleteStatueTypeList(int id)
        {
            var statueTypeList = db.StatueTypeLists.Find(id);
            if (statueTypeList == null)
            {
                return NotFound();
            }

            db.StatueTypeLists.Remove(statueTypeList);
            db.SaveChanges();

            return Ok(statueTypeList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatueTypeListExists(int id)
        {
            return db.StatueTypeLists.Count(e => e.Id == id) > 0;
        }
    }
}