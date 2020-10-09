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
using HotelManagerWithNET_F.Models;

namespace HotelManagerWithNET_F.Controllers
{
    public class DichVuRiengsController : ApiController
    {
        private HotelEntities db = new HotelEntities();

        // GET: api/DichVuRiengs
        public IQueryable<DichVuRieng> GetDichVuRieng()
        {
            return db.DichVuRieng;
        }

        // GET: api/DichVuRiengs/5
        [ResponseType(typeof(DichVuRieng))]
        public IHttpActionResult GetDichVuRieng(int id)
        {
            DichVuRieng dichVuRieng = db.DichVuRieng.Find(id);
            if (dichVuRieng == null)
            {
                return NotFound();
            }

            return Ok(dichVuRieng);
        }

        // PUT: api/DichVuRiengs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDichVuRieng(int id, DichVuRieng dichVuRieng)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dichVuRieng.MaDichVu)
            {
                return BadRequest();
            }

            db.Entry(dichVuRieng).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DichVuRiengExists(id))
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

        // POST: api/DichVuRiengs
        [ResponseType(typeof(DichVuRieng))]
        public IHttpActionResult PostDichVuRieng(DichVuRieng dichVuRieng)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DichVuRieng.Add(dichVuRieng);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dichVuRieng.MaDichVu }, dichVuRieng);
        }

        // DELETE: api/DichVuRiengs/5
        [ResponseType(typeof(DichVuRieng))]
        public IHttpActionResult DeleteDichVuRieng(int id)
        {
            DichVuRieng dichVuRieng = db.DichVuRieng.Find(id);
            if (dichVuRieng == null)
            {
                return NotFound();
            }

            db.DichVuRieng.Remove(dichVuRieng);
            db.SaveChanges();

            return Ok(dichVuRieng);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DichVuRiengExists(int id)
        {
            return db.DichVuRieng.Count(e => e.MaDichVu == id) > 0;
        }
    }
}