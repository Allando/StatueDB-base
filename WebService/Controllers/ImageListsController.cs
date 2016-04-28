using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class ImageListsController : ApiController
    {
        private readonly StatueContext db = new StatueContext();

        // GET: api/ImageLists
        public IQueryable<ImageList> GetImageLists()
        {
            return db.ImageLists;
        }

        // GET: api/ImageLists/5
        [ResponseType(typeof(ImageList))]
        public IHttpActionResult GetImageList(int id)
        {
            var imageList = db.ImageLists.Find(id);
            if (imageList == null)
            {
                return NotFound();
            }

            return Ok(imageList);
        }

        // PUT: api/ImageLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImageList(int id, ImageList imageList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imageList.Id)
            {
                return BadRequest();
            }

            db.Entry(imageList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageListExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ImageLists
        [ResponseType(typeof(ImageList))]
        public IHttpActionResult PostImageList(ImageList imageList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ImageLists.Add(imageList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = imageList.Id}, imageList);
        }

        // DELETE: api/ImageLists/5
        [ResponseType(typeof(ImageList))]
        public IHttpActionResult DeleteImageList(int id)
        {
            var imageList = db.ImageLists.Find(id);
            if (imageList == null)
            {
                return NotFound();
            }

            db.ImageLists.Remove(imageList);
            db.SaveChanges();

            return Ok(imageList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImageListExists(int id)
        {
            return db.ImageLists.Count(e => e.Id == id) > 0;
        }
    }
}