using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class PostPhotosRepository : IPostPhotosRepository
    {
        private BlogDbContext dbContext;
        public PostPhotosRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(PostPhoto postPhoto)
        {
            this.dbContext.PostPhotos.Add(postPhoto);
        }

        public void Delete(PostPhoto postPhoto)
        {
            this.dbContext.PostPhotos.Remove(postPhoto);
        }

        public PostPhoto GetById(int id)
        {
            return this.dbContext.PostPhotos.SingleOrDefault(p => p.PhotoId == id);
        }

        public IEnumerable<PostPhoto> GetByPostId(long id)
        {
            return this.dbContext.PostPhotos
                .Where(p => p.PostId == id);
        }
    }
}
