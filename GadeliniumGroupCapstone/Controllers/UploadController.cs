using System;
using System.IO;
using System.Linq;
using GadeliniumGroupCapstone.Data;
using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GadeliniumGroupCapstone.Controllers
{
    public class UploadController : Controller
    {

        public PetAppDbContext _context;

        public UploadController(PetAppDbContext context)
        {
            _context = context;
        }

        // GET: UploadController
        public ActionResult Index()
        {
            var photos = _context.PhotoBins.ToList();
            return View(photos);
        }

        // GET: UploadController/Create
        public ActionResult AddImage()
        {
            PhotoBin p1 = new PhotoBin();

            return View(p1);
        }

        // POST: UploadController/Create
        [HttpPost("Upload/AddImage")]
        [ValidateAntiForgeryToken]
        public ActionResult AddImage(PhotoBin image, IFormFile upload)
        {
            using (var memoryStream = new MemoryStream())
            {
                upload.CopyToAsync(memoryStream);
                image.Content = memoryStream.ToArray();

                string Base64 = Convert.ToBase64String(image.Content);
                byte[] array = Convert.FromBase64String(Base64);
                _context.PhotoBins.Add(image);
                _context.SaveChanges();
                return View();
            }

        }
    }
}
