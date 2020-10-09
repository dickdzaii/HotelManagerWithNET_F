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
    public class KhachHangsController : ApiController
    {
        private HotelEntities db = new HotelEntities();

        // GET: api/KhachHangs
        public IQueryable<KhachHang> GetKhachHang()
        {
            return db.KhachHang;
        }

        // GET: api/KhachHangs/5
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult GetKhachHang(int id)
        {
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return Ok(khachHang);
        }

        // PUT: api/KhachHangs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKhachHang(int id, KhachHang khachHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != khachHang.MaKhachHang)
            {
                return BadRequest();
            }

            db.Entry(khachHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhachHangExists(id))
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

        // POST: api/KhachHangs
        [ResponseType(typeof(KhachHang))]
        public int PostKhachHang(KhachHang khachHang)
        {
            //nếu return 0 là thêm thất bại, nếu là 1 là thêm thành công
            if (!ModelState.IsValid)
            {
                return 0;
            }

            var kq=db.ThemKhachHang(khachHang.TenKhachHang, khachHang.NgaySinh, khachHang.GioiTinh, khachHang.DiaChi, khachHang.SoDienThoai, khachHang.Cmt);
           
            db.SaveChanges();

            //nếu return 0 là thêm thất bại, nếu là 1 là thêm thành công
            return kq;
        }

        // DELETE: api/KhachHangs/5
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult DeleteKhachHang(int id)
        {
            KhachHang khachHang = db.KhachHang.Find(id);
            if (khachHang == null)
            {
                return NotFound();
            }

            db.KhachHang.Remove(khachHang);
            db.SaveChanges();

            return Ok(khachHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KhachHangExists(int id)
        {
            return db.KhachHang.Count(e => e.MaKhachHang == id) > 0;
        }
    }
}