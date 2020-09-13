using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GadeliniumGroupCapstone.Models;
using GadeliniumGroupCapstone.Contracts;
using Microsoft.AspNetCore.Identity;
using GadeliniumGroupCapstone.NewsFeedService.Models;
using Microsoft.AspNetCore.Http;
using GadeliniumGroupCapstone.ViewModels;
using GadeliniumGroupCapstone.NewsFeedService;

namespace GadeliniumGroupCapstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepositoryWrapper _repo;
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private NewsfeedService _newsfeedService;
        public HomeController(ILogger<HomeController> logger, IRepositoryWrapper repo, SignInManager<User> signInManager, UserManager<User> userManager, NewsfeedService newsFeedService)
        {
            _logger = logger;
            _repo = repo;
            _signInManager = signInManager;
            _userManager = userManager;
            _newsfeedService = newsFeedService;
        }

        public IActionResult Index()
        {
            Console.WriteLine(User);

            if (User.IsInRole("Business Owner") && _signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Home", "Business");
            }
            else if (User.IsInRole("Pet Owner") && _signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Home", "PetAccounts");
            }


            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Newsfeed()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewsfeedPost(PostViewModel model)
        {

            if (model.UploadFile != null)
            {
                // Add to uploadfile service
            }

            if (model.Post.PosterType == PosterType.PetPoster)
            {
                model.Post.PosterId = _repo.PetAccount.GetPetAccountIdFromPetName(model.Post.PosterName);
            }
            _repo.Post.Create(model.Post);


            _repo.Save();

            Post addedPost = _repo.Post.GetLastPostAdded();

            _newsfeedService.AddPostToUserNewsfeed(addedPost);
            // Add post to poster newsfeed
            _repo.PostUser.Create(new PostUser() { PostId = model.Post.PostId, UserId = _userManager.GetUserId(User) });
            Task.WaitAll();
            _repo.Save();
            return RedirectToAction("Newsfeed");

        }

        [Route("Home/RemovePostFromFeed/{id:int}")]
        public IActionResult RemovePostFromFeed(int id)
        {
            var userId = _userManager.GetUserId(User);
            PostUser postUser = _repo.PostUser.GetPostUserEntry(userId, id);
            _repo.PostUser.Delete(postUser);
            _repo.Save();

            if (!_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index");
            }

            return View("Newsfeed");
        }

        [Route("Home/UserPostLikeToggle/{id:int}")]
        public IActionResult UserPostLikeToggle(int id)
        {
            var userId = _userManager.GetUserId(User);
            PostUser postUser = _repo.PostUser.GetPostUserEntry(userId, id);
            postUser.IsLiked = !postUser.IsLiked;
            _repo.PostUser.Update(postUser);
            _repo.Save();

            return View("Newsfeed");
        }

    }
}
