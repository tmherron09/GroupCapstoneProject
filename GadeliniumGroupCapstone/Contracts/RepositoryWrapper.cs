using GadeliniumGroupCapstone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private ITestRepository _test;
        private IAccountRepository _account;
        private IBoardingRepository _boarding;
        private IBusinessRepository _business;
        private IGroomerRepository _groomer;
        private IMedicalRecordRepository _medicalRecord;
        private IOtherRepository _other;
        private IPetAccountRepository _petAccount;
        private IPetBioRepository _petBio;
        private ISiteUserRepository _siteUser;
        private ISitterRepository _sitter;
        private ITrainerRepository _trainer;
        private IVetRepository _vet;
        public ITestRepository Test
        {
            get
            {
                if(_test == null)
                {
                    _test = new TestRepository(_context);
                }
                return _test;
            }
        }
        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_context);
                }
                return _account;
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

        public IMedicalRecordRepository MedicalRecord {
            get
            {
                if ( _medicalRecord == null)
                {
                    _medicalRecord = new MedicalRecordRepository(_context);
    }
                return _medicalRecord;
            }
        }

        public IOtherRepository Other {
            get
            {
                if (_other == null)
                {
                    _other = new OtherRepository(_context);
    }
                return _other;
            }
        }

        public IPetAccountRepository PetAccount {
            get
            {
                if (_petAccount == null)
                {
                    _petAccount = new PetAccountRepository(_context);
    }
                return _petAccount;
            }
        }

        public ISiteUserRepository SiteUser {
            get
            {
                if (_siteUser == null)
                {
                    _siteUser = new SiteUserRepository(_context);
    }
                return _siteUser;
            }
        }

        public ISitterRepository Sitter {
            get
            {
                if (_sitter == null)
                {
                    _sitter = new SitterRepository(_context);
    }
                return _sitter;
            }
        }

        public ITrainerRepository Trainer {
            get
            {
                if (_trainer == null)
                {
                    _trainer = new TrainerRepository(_context);
    }
                return _trainer;
            }
        }

        public IVetRepository Vet {
            get
            {
                if (_vet == null)
                {
                    _vet = new VetRepository(_context);
    }
                return _vet;
            }
        }

        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            //_context.SaveChangesAsync();
            _context.SaveChanges();
        }
    }
}
