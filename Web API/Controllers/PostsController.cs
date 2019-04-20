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

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
