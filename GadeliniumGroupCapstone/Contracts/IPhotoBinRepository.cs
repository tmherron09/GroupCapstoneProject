using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IPhotoBinRepository : IRepositoryBase<PhotoBin>
    {
        PhotoBin GetPhoto(int photoId);
        void CreatePhoto(PhotoBin photoBin);
    }
}
