﻿using GadeliniumGroupCapstone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private PetAppDbContext _context;
        private ITestRepository _test;
        private IAddressRepository _address;
        private IBoardingRepository _boarding;
        private IBusinessRepository _business;
        private IBusinessHourRepository _businessHour;
        private IFavoriteBusinessRepository _favoriteBusiness;
        private IGroomerRepository _groomer;
        private IMedicalRecordRepository _medicalRecord;
        private IOtherRepository _other;
        private IPetAccountRepository _petAccount;
        private IPetBioRepository _petBio;
        private IPetFriendListRepository _petFriendList;
        private IPhotoBinRepository _photo;
        private IPostRepository _post;
        private IPostUserRepository _postUser;
        private IUserRepository _user;
        private IServiceRepository _service;
        private ISitterRepository _sitter;
        private ITrainerRepository _trainer;
        private IVetRepository _vet;
        private IBlockedUserRepository _blockedUser;
        public ITestRepository Test
        {
            get
            {
                if (_test == null)
                {
                    _test = new TestRepository(_context);
                }
                return _test;
            }
        }

        public RepositoryWrapper(PetAppDbContext context)
        {
            _context = context;
        }

        public IAddressRepository Address
        {
            get
            {
                if (_address == null)
                {
                    _address = new AddressRepository(_context);
                }
                return _address;
            }
        }
        public IBoardingRepository Boarding
        {
            get
            {
                if (_boarding == null)
                {
                    _boarding = new BoardingRepository(_context);
                }
                return _boarding;
            }
        }

        public IBusinessRepository Business
        {
            get
            {
                if (_business == null)
                {
                    _business = new BusinessRepository(_context);
                }
                return _business;
            }
        }
        public IBusinessHourRepository BusinessHour
        {
            get
            {
                if (_businessHour == null)
                {
                    _businessHour = new BusinessHourRepository(_context);
                }
                return _businessHour;
            }
        }

        public IFavoriteBusinessRepository FavoriteBusiness
        {
            get
            {
                if (_favoriteBusiness == null)
                {
                    _favoriteBusiness = new FavoriteBusinessRepository(_context);
                }
                return _favoriteBusiness;
            }
        }

        public IGroomerRepository Groomer
        {
            get
            {
                if (_groomer == null)
                {
                    _groomer = new GroomerRepository(_context);
                }
                return _groomer;
            }
        }

        public IMedicalRecordRepository MedicalRecord
        {
            get
            {
                if (_medicalRecord == null)
                {
                    _medicalRecord = new MedicalRecordRepository(_context);
                }
                return _medicalRecord;
            }
        }

        public IOtherRepository Other
        {
            get
            {
                if (_other == null)
                {
                    _other = new OtherRepository(_context);
                }
                return _other;
            }
        }

        public IPetAccountRepository PetAccount
        {
            get
            {
                if (_petAccount == null)
                {
                    _petAccount = new PetAccountRepository(_context);
                }
                return _petAccount;
            }
        }
        public IPetFriendListRepository PetFriendList
        {
            get
            {
                if (_petFriendList == null)
                {
                    _petFriendList = new PetFriendListRepository(_context);
                }
                return _petFriendList;
            }
        }
        public IPetBioRepository PetBio
        {
            get
            {
                if (_petBio == null)
                {
                    _petBio = new PetBioRepository(_context);
                }
                return _petBio;
            }
        }
        public IPhotoBinRepository PhotoBin
        {
            get
            {
                if (_photo == null)
                {
                    _photo = new PhotoBinRepository(_context);
                }
                return _photo;
            }
        }

        public IPostRepository Post
        {
            get
            {
                if (_post == null)
                {
                    _post = new PostRepository(_context);
                }
                return _post;
            }
        }

        public IPostUserRepository PostUser
        {
            get
            {
                if (_postUser == null)
                {
                    _postUser = new PostUserRepository(_context);
                }
                return _postUser;
            }
        }


        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }

        public ISitterRepository Sitter
        {
            get
            {
                if (_sitter == null)
                {
                    _sitter = new SitterRepository(_context);
                }
                return _sitter;
            }
        }
        public IServiceRepository Service
        {
            get
            {
                if (_service == null)
                {
                    _service = new ServiceRepository(_context);
                }
                return _service;
            }
        }

        public ITrainerRepository Trainer
        {
            get
            {
                if (_trainer == null)
                {
                    _trainer = new TrainerRepository(_context);
                }
                return _trainer;
            }
        }

        public IVetRepository Vet
        {
            get
            {
                if (_vet == null)
                {
                    _vet = new VetRepository(_context);
                }
                return _vet;
            }
        }

        public IBlockedUserRepository BlockedUser
        {
            get
            {
                
                if (_blockedUser == null)
                {
                    _blockedUser = new BlockedUserRepository(_context);
                }
                return _blockedUser;
            }
        }

        public void Save()
        {

            _context.SaveChanges();
        }
    }
}
