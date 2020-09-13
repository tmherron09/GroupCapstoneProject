using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.NewsFeedService.Models;

namespace GadeliniumGroupCapstone.NewsFeedService
{
    public class NewsfeedService
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IRepositoryWrapper _repo;
        public NewsfeedService(UserManager<User> userManager, SignInManager<User> signInManager, IRepositoryWrapper repo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repo = repo;
        }


        public List<Post> GetUserNewsfeed(string userId)
        {
            var posts = _repo.Post.GetPostsForUser(userId);
            return posts;
        }

        public Task AddPostToUserNewsfeed(Post post)
        {
            return Task.Run(() =>
            {
                List<string> Subscribers = GetSubscribers(post);
                if (Subscribers.Count <= 0) { return; }

                foreach (var sub in Subscribers)
                {
                    try
                    {
                        PostUser postUser = new PostUser();

                        postUser.PostId = post.PostId;
                        postUser.UserId = sub;

                        _repo.PostUser.Create(postUser);
                    }
                    catch
                    {
                        // If implement ILogger later, log.
                        Console.WriteLine($"{sub} did not recieve {post.PostTitle}, #{post.PostId}.");
                    }
                }
                _repo.Save();
            });
        }

        private List<string> GetSubscribers(Post post)
        {
            // UserId strings
            List<string> subscribers = new List<string>();

            if (post.PosterType == PosterType.BusinessPoster)
            {
                subscribers = _repo.FavoriteBusiness.GetUserIdsThatLikeBusiness(post.PosterId);
            }
            else
            {
                // Get Friends (users)
            }
            return subscribers;
        }

        public bool HasUserLikedPost(int postId, string userId)
        {

            var post = _repo.PostUser.GetPostUserEntry(userId, postId);

            return post.IsLiked;
        }



    }
}
