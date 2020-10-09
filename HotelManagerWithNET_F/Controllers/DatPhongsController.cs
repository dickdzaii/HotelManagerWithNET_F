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
    public class DatPhongsController : ApiController
    {
        private HotelEntities db = new HotelEntities();

        // GET: api/DatPhongs
        public IQueryable<DatPhong> GetDatPhong()
        {
            return db.DatPhong;
        }

        // GET: api/DatPhongs/5
        [ResponseType(typeof(DatPhong))]
        public IHttpActionResult GetDatPhong(int id)
        {
            DatPhong datPhong = db.DatPhong.Find(id);
            if (datPhong == null)
            {
                return NotFound();
            }

            return Ok(datPhong);
        }

        // PUT: api/DatPhongs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDatPhong(int id, DatPhong datPhong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != datPhong.MaDatPhong)
            {
                return BadRequest();
            }

            db.Entry(datPhong).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatPhongExists(id))
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

        // POST: api/DatPhongs
        [ResponseType(typeof(DatPhong))]
        public IHttpActionResult PostDatPhong(DatPhong datPhong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DatPhong.Add(datPhong);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = datPhong.MaDatPhong }, datPhong);
        }

        // DELETE: api/DatPhongs/5
        [ResponseType(typeof(DatPhong))]
        public IHttpActionResult DeleteDatPhong(int id)
        {
            DatPhong datPhong = db.DatPhong.Find(id);
            if (datPhong == null)
            {
                return NotFound();
            }

            db.DatPhong.Remove(datPhong);
            db.SaveChanges();

            return Ok(datPhong);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DatPhongExists(int id)
        {
            return db.DatPhong.Count(e => e.MaDatPhong == id) > 0;
        }
    }
}