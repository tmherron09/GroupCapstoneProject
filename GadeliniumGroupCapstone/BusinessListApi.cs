using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GadeliniumGroupCapstone
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessListApi : ControllerBase
    {
        private IRepositoryWrapper _repo;
        private IAuthorizationService _authorizationService;
        private UserManager<User> _userManager;

        public BusinessListApi(IRepositoryWrapper repo, IAuthorizationService authorizationService, UserManager<User> userManager)
        {
            _repo = repo;
            _authorizationService = authorizationService;
            _userManager = userManager;
        }


        // GET: api/<BusinessListApi>
        [HttpGet]
        public List<Business> Get()
        {
            return _repo.Business.GetAllBusinesses();
        }

        // GET api/<BusinessListApi>/5
        [HttpGet("{id}")]
        public Business Get(int id)
        {
            return _repo.Business.GetBusiness(id);
        }

        // POST api/<BusinessListApi>
        [HttpPost]
        public List<Business> Post([FromBody] string value)
        {

            return _repo.Business.SearchByName(value);

        }

        // PUT api/<BusinessListApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BusinessListApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
