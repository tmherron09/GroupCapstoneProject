using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class PhotoBinRepository : RepositoryBase<PhotoBin>, IPhotoBinRepository
    {

        public PhotoBinRepository(PetAppDbContext petAppDbContext) : base(petAppDbContext)
        {

        }

        public void CreatePhoto(PhotoBin photoBin)
        {
            throw new NotImplementedException();
        }

        public PhotoBin GetPhoto(int photoId) =>
            FindAllByCondition(p => p.PhotoId == photoId).SingleOrDefault();
    }
}
