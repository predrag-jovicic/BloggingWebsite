using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        UnitOfWork unitOfWork;
        public PostsController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [Route("postspreview/{page?}")]
        [HttpGet]
        public IActionResult GetRecentPosts(int? page)
        {
            var posts = this.unitOfWork.PostsFetcher.GetRecentPostsPreview(page);
            return Ok(posts);
        }
        
        [Route("postspreview/category/{category}/{page?}")]
        [HttpGet]
        public IActionResult GetRecentPostsByCategory(int category, int? page)
        {
            var posts = this.unitOfWork.PostsFetcher.GetRecentPostsPreviewByCategory(page,category);
            return Ok(posts);
        }

        [Route("postspreview/tag/{tag}/{page?}")]
        [HttpGet]
        public IActionResult GetRecentPostsByTag(int tag, int? page)
        {
            var posts = this.unitOfWork.PostsFetcher.GetRecentPostsPreviewByTag(page, tag);
            return Ok(posts);
        }

        public IActionResult SearchPosts(string example)
        {
            var posts = this.unitOfWork.PostsFetcher.GetPostsByASearch(example);
            return Ok(posts);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var post = this.unitOfWork.PostsRepository.GetPostById(id);
            if (post == null)
                return NotFound();
            else
            {
                PostViewModel vm = new PostViewModel
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Text = post.Text,
                    PostedOn = post.PostedOn,
                    NumberOfViews = post.NumberOfViews,
                    ReadTime = post.ReadTime,
                    UserId = post.UserId,
                    AuthorFirstName = post.User.FirstName,
                    AuthorLastName = post.User.LastName,
                    AuthorBiography = post.User.Biography
                };
                vm.Comments = this.unitOfWork.CommentsFetcher.GetCommentsByPostId(id);
                vm.RecommendedPosts = this.unitOfWork.PostsFetcher.GetRecommendedPosts(id);
                return Ok(vm);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
