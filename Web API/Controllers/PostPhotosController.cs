using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels.Input;
using DataAccess;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    public class PostPhotosController : Controller
    {
        private IHostingEnvironment hostingEnvironment;
        private IUnitOfWork unitOfWork;
        public PostPhotosController(IHostingEnvironment hostingEnvironment, IUnitOfWork unitOfWork)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.unitOfWork = unitOfWork;
        }

        // Get all post photos
        [HttpGet("post/{postId}")]
        [ActionName("PostPhotos")]
        public IActionResult Get(long postId)
        {
            var photos = this.unitOfWork.PostPhotosRepository.GetByPostId(postId);
            return Ok(photos);
        }

        [Authorize(Roles = "Blogger")]
        [HttpPost]
        public async Task<IActionResult> Post(PhotosViewModel vm)
        {
            var post = this.unitOfWork.PostsRepository.GetById(vm.PostId);
            if (post == null)
                return BadRequest("The post does not exist.");
            if (post.UserId != User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value)
                return Forbid();
            var numberOfFiles = vm.Files.Count;
            if (numberOfFiles > 8) {
                ModelState.AddModelError("size", "Number of images can't exceed 8.");
                return BadRequest(ModelState);
            }
            foreach(var file in vm.Files)
            {
                string type = file.ContentType.Split("/")[0];
                if (type != "image")
                {
                    ModelState.AddModelError("type", "Invalid type");
                    return BadRequest(ModelState);
                }
                else if (file.Length > 2145728)
                {
                    ModelState.AddModelError("size", "Image size must be lower than 2MB");
                    return BadRequest(ModelState);
                }
                else
                {
                    string currentFileName = file.FileName.Trim('"');
                    string fileExtension = Path.GetExtension(currentFileName);
                    string newFileName = Guid.NewGuid().ToString() + fileExtension;
                    string filePath = Path.Combine(this.hostingEnvironment.WebRootPath, "images", "posts", newFileName);
                    string dbPath = Path.Combine("images", "posts", newFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        stream.Flush();
                    }
                    PostPhoto newPhoto = new PostPhoto
                    {
                        Source = dbPath,
                        Alt = "Post photo",
                        PostId = vm.PostId
                    };
                    this.unitOfWork.PostPhotosRepository.Add(newPhoto);
                }
            }
            await this.unitOfWork.Save();
            return Created("PostPhotos",new { id = vm.PostId });
        }

        [Authorize(Roles = "Blogger")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var postPhoto = this.unitOfWork.PostPhotosRepository.GetById(id);
            if (postPhoto == null)
                return BadRequest();
            var post = this.unitOfWork.PostsRepository.GetById(postPhoto.PostId);
            if (post.UserId != User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value)
                return Forbid();
            else
            {
                postPhoto.Source = postPhoto.Source.Substring(1);
                var path = Path.Combine(this.hostingEnvironment.WebRootPath, postPhoto.Source);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                this.unitOfWork.PostPhotosRepository.Delete(postPhoto);
                await this.unitOfWork.Save();
                return NoContent();
            }
        }
    }
}
