using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using GadeliniumGroupCapstone.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.UploadImage
{
    public class UploadImageService
    {
        private IRepositoryWrapper _repo;

        public UploadImageService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        public int UploadImageGetPhotoBinId(IFormFile uploadFile)
        {

            return 0;
        }

        public async Task UploadImageCreateRegisterEditBusinessViewModel(RegisterEditBusinessViewModel model)
        {
            using (var memoryStream = new MemoryStream())
            {
                await model.UploadFile.CopyToAsync(memoryStream);
                model.PhotoBin.Content = memoryStream.ToArray();

                string Base64 = Convert.ToBase64String(model.PhotoBin.Content);
                byte[] array = Convert.FromBase64String(Base64);
                _repo.PhotoBin.Create(model.PhotoBin);
                _repo.Save();
            }
            model.Business.PhotoBinId = _repo.PhotoBin.LastPhotoAddedId();
        }

    }
}
