using System;
using System.IO;
using GadeliniumGroupCapstone.Data;
using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GadeliniumGroupCapstone.Controllers
{
    public class UploadController : Controller
    {

        public ApplicationDbContext db;

        public UploadController(DbContextOptions<ApplicationDbContext> options)
        {
            db = new ApplicationDbContext(options);
        }

        // GET: UploadController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UploadController/Create
        public ActionResult AddImage()
        {
            PhotoBin p1 = new PhotoBin();

            return View(p1);
        }

        // POST: UploadController/Create
        [HttpPost("AddImage")]
        [ValidateAntiForgeryToken]
        public ActionResult AddImage(PhotoBin image, IFormFile upload)
        {
            using (var memoryStream = new MemoryStream())
            {
                upload.CopyToAsync(memoryStream);
                image.Content = memoryStream.ToArray();

                string Base64 = Convert.ToBase64String(image.Content);
                byte[] array = Convert.FromBase64String(Base64);
                db.PhotoBins.Add(image);
                db.SaveChanges();
                return View();
            }

        }
    }
}
