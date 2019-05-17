using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class BlogDbContext : IdentityDbContext<User>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollAnswer> PollAnswers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostPoll> PostPolls { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<View> Views { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VotingGroup> VotingGroups { get; set; }
        public DbSet<PostPhoto> PostPhotos { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(c => c.Name);
            modelBuilder.Entity<Tag>().HasIndex(t => t.Name);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Bladder Cancer"},
                new Category { CategoryId = 2, Name = "Breast Cancer"},
                new Category { CategoryId = 3, Name = "Colorectal Cancer"},
                new Category { CategoryId = 4, Name = "Kidney Cancer"},
                new Category { CategoryId = 5, Name = "Lung Cancer"},
                new Category { CategoryId = 6, Name = "Lymphoma Cancer"},
                new Category { CategoryId = 7, Name = "Melanoma Cancer"},
                new Category { CategoryId = 8, Name = "Oral and Oropharyngeal Cancer"},
                new Category { CategoryId = 9, Name = "Pancreatic Cancer"},
                new Category { CategoryId = 10, Name = "Prostate Cancer"},
                new Category { CategoryId = 11, Name = "Thyroid Cancer"},
                new Category { CategoryId = 12, Name = "Uterine Cancer"},
                new Category { CategoryId = 13, Name = "Bone Cancer"}
                );
            modelBuilder.Entity<Tag>().HasData(
                new Tag { TagId = 1, Name = "Childhood" },
                new Tag { TagId = 2, Name = "Young" },
                new Tag { TagId = 3, Name = "Prevention" },
                new Tag { TagId = 4, Name = "Early_Phase" },
                new Tag { TagId = 5, Name = "Tumor" },
                new Tag { TagId = 6, Name = "Cancer" },
                new Tag { TagId = 7, Name = "Leukemia" }
                );
        }
    }
}
