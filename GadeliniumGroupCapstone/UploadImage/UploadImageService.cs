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

        public async Task RegisterBusinessUploadImage(RegisterEditBusinessViewModel model)
        {
            if (model.UploadFile == null)
            {
                await RegisterBusinessNullUploadImage(model);
                return;
            }

            using (var memoryStream = new MemoryStream())
            {
                await model.UploadFile.CopyToAsync(memoryStream);
                model.PhotoBin.Content = memoryStream.ToArray();

                _repo.PhotoBin.Create(model.PhotoBin);
                _repo.Save();
            }
            // Return new photobin id to model
            model.Business.PhotoBinId = _repo.PhotoBin.LastPhotoAddedId();
        }

        public async Task RegisterBusinessNullUploadImage(RegisterEditBusinessViewModel model)
        {

            byte[] imgdata = await System.IO.File.ReadAllBytesAsync(@"wwwroot\images\Default\default_logo.png");
            PhotoBin logo = new PhotoBin();
            logo.Content = imgdata;
            _repo.PhotoBin.Create(logo);
            _repo.Save();
            // Return new photobin id to model
            model.Business.PhotoBinId = _repo.PhotoBin.LastPhotoAddedId();
        }

        public async Task EditBusinessUploadImage(RegisterEditBusinessViewModel model)
        {
            if (model.UploadFile == null)
            {
                return;
            }

            using (var memoryStream = new MemoryStream())
            {
                await model.UploadFile.CopyToAsync(memoryStream);
                model.PhotoBin.Content = memoryStream.ToArray();

                model.PhotoBin.PhotoId = (int)model.Business.PhotoBinId;

                _repo.PhotoBin.Update(model.PhotoBin);
                _repo.Save();
            }

        }

        public async Task CreateServiceUploadImage(ServiceWithPhotoUpload model)
        {
            if (model.UploadFile == null)
            {
                await CreateServiceNullUploadImage(model);
                return;
            }

                using (var memoryStream = new MemoryStream())
                {
                    await model.UploadFile.CopyToAsync(memoryStream);
                    model.Service.ServiceThumbnail = new PhotoBin();
                    model.Service.ServiceThumbnail.Content = memoryStream.ToArray();

                    _repo.PhotoBin.Create(model.Service.ServiceThumbnail);
                    _repo.Save();

                }
            // Retrieve photoid just saved to put into service model.
            model.Service.PhotoBinId = _repo.PhotoBin.LastPhotoAddedId();
        }

        public async Task CreateServiceNullUploadImage(ServiceWithPhotoUpload model)
        {
            byte[] imgdata = await System.IO.File.ReadAllBytesAsync(@"wwwroot\images\Default\default_servicethumbnail.png");
            PhotoBin logo = new PhotoBin();
            logo.Content = imgdata;
            _repo.PhotoBin.Create(logo);
            _repo.Save();

            // Retrieve photoid just saved to put into service model.
            model.Service.PhotoBinId = _repo.PhotoBin.LastPhotoAddedId();
        }

        public async Task EditServiceUploadImage(ServiceWithPhotoUpload model)
        {
            if (model.UploadFile == null)
            {
                return;
            }

            using (var memoryStream = new MemoryStream())
            {
                await model.UploadFile.CopyToAsync(memoryStream);
                model.Service.ServiceThumbnail = new PhotoBin();
                model.Service.ServiceThumbnail.Content = memoryStream.ToArray();

                model.Service.ServiceThumbnail.PhotoId = (int)model.Service.PhotoBinId;

                _repo.PhotoBin.Update(model.Service.ServiceThumbnail);
                _repo.Save();
            }
        }


    }
}
