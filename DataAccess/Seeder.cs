using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Seeder
    {
        public static async Task Initialize(BlogDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.Migrate();
            if (!context.Roles.Any())
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Administrator"
                };
                await roleManager.CreateAsync(role);
                role = new IdentityRole
                {
                    Name = "Moderator"
                };
                await roleManager.CreateAsync(role);
                role = new IdentityRole
                {
                    Name = "Blogger"
                };
                await roleManager.CreateAsync(role);
            }
            if (!context.Users.Any())
            {
                User user = new User
                {
                    FirstName = "Predrag",
                    LastName = "Jovicic",
                    Biography = "I am a blogger.",
                    Email = "predragjovicic333@gmail.com",
                    UserName = "peksi",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, "P@ssWord3!");
                await userManager.AddToRoleAsync(user, "Blogger");
                user = new User
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Biography = "I am an entrepreneur.",
                    Email = "johndoe@mail.com",
                    UserName = "janedoe",
                    EmailConfirmed = true,
                    UrlLinkedIn = "www.linkedin.com/johndoe"
                };
                await userManager.CreateAsync(user, "P@ssWord3!");
                await userManager.AddToRoleAsync(user, "Moderator");

                var post = new Post
                {
                    CategoryId = 1,
                    Title = "Common cold virus targets, and kills, bladder cancer in exciting early human trial",
                    Text = "An early-stage study has found a strain of the common cold virus can effectively target and destroy bladder cancer cells.\nThis phase 1 human trial suggests the virus directly induces tumor cell death, and if verified by larger trials could be used in conjunction with other novel immunotherapy treatments. An oncolytic virus is a class of virus known to target and kill cancer cells in one of two ways, either by directly hunting and eliminating tumor cells, or by helping the immune system better home in on a cancer by lighting up a cancer cell.\nOngoing oncolytic research has revealed the zika virus attacking brain cancers, and the herpes virus attacking skin cancers. Non-muscle invasive bladder cancer(NMIBC) is the most common type of bladder cancer and it is challenging to treat.Current treatments can involve a variety of either surgery, chemotherapy or immunotherapy, and still result in high rates of recurrence.",
                    ReadTime = 2,
                    User = user,
                    PostedOn = new DateTime(2019, 5, 5, 13, 11, 29)
                };

                context.Posts.Add(post);

                var postTags = new List<PostTag>
                {
                    new PostTag
                    {
                        Post = post,
                        TagId = 1
                    },
                    new PostTag
                    {
                        Post = post,
                        TagId = 3
                    },
                    new PostTag
                    {
                        Post = post,
                        TagId = 5
                    }
                };

                context.PostTags.AddRange(postTags);

                var comment = new Comment
                {
                    Approved = true,
                    Text = "This is the first comment",
                    UserName = "Milos",
                    PostedOn = new DateTime(2019, 7, 5, 11, 10, 5),
                    Post = post
                };

                context.Comments.Add(comment);

                comment = new Comment
                {
                    Approved = true,
                    Text = "This is the second comment",
                    UserName = "Nikola",
                    PostedOn = new DateTime(2019, 7, 5, 12, 0, 4),
                    Post = post
                };

                context.Comments.Add(comment);

                post = new Post
                {
                    CategoryId = 2,
                    Title = "Blood test may predict risk of recurrence for breast cancer patients",
                    Text = "A special blood test may one day predict if a newly diagnosed breast cancer patient will likely relapse years later, a City of Hope study suggests.'This is the first success linking a solid tumor with blood biomarkers—an indicator of whether a patient will remain in remission,' said Peter P. Lee, M.D.,\n chair of the Department of Immuno-Oncology at City of Hope and corresponding author of the study. 'When patients are first diagnosed with cancer, it is important to identify those at higher risk for relapse for more aggressive treatments and monitoring. Staging and new tests based on genomics analysis of the tumor are currently available for risk stratification.\n However, a predictive blood test would be even more attractive but is not yet available. We are trying to change the status quo.'",
                    ReadTime = 2,
                    User = user,
                    PostedOn = new DateTime(2019, 4, 6, 12, 0, 3)
                };

                context.Posts.Add(post);

                comment = new Comment
                {
                    Approved = true,
                    Text = "This is a comment",
                    UserName = "Strahinja",
                    PostedOn = new DateTime(2019, 7, 5, 12, 0, 4),
                    Post = post
                };

                context.Comments.Add(comment);

                postTags = new List<PostTag>
                {
                    new PostTag
                    {
                        Post = post,
                        TagId = 2
                    },
                    new PostTag
                    {
                        Post = post,
                        TagId = 3
                    },
                    new PostTag
                    {
                        Post = post,
                        TagId = 5
                    }
                };

                context.PostTags.AddRange(postTags);

                post = new Post
                {
                    CategoryId = 6,
                    Title = "Newly Identified Mutation May Result in Venetoclax Resistance in Follicular Lymphoma",
                    Text = "Researchers have identified a novel candidate resistance mutation that reduced venetoclax binding in a patient with relapsed/refractory follicular lymphoma treated with venetoclax. Although the male patient, aged 55 years, initially responded to venetoclax as part of a phase 1 clinical trial, after 29 months on therapy, his disease recurred. Biopsy samples of the lymphoma were taken prior to venetoclax treatment and after progression. In addition to mutations in CREBBP, KMT2D, and EZH2, there was an aberrant somatic hypermutation of the BCL2 gene with the presence of multiple mutations in the 5ʹ untranslated region and the first coding exon.",
                    ReadTime = 1,
                    User = user,
                    PostedOn = new DateTime(2019, 7, 1, 13, 5, 1)
                };

                context.Posts.Add(post);

                postTags = new List<PostTag>{
                    new PostTag
                    {
                        Post = post,
                        TagId = 1
                    },
                    new PostTag
                    {
                        Post = post,
                        TagId = 3
                    },
                    new PostTag
                    {
                        Post = post,
                        TagId = 6
                    },
                };
                context.PostTags.AddRange(postTags);
                context.SaveChanges();
            }
        }
    }
}
