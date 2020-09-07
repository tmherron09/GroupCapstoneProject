using GadeliniumGroupCapstone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SiteUserContext _context;
        private ITestRepository _test;
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
        public RepositoryWrapper(SiteUserContext context)
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
