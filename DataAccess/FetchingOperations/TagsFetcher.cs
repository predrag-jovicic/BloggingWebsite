﻿using DataAccess.Models;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.FetchingOperations
{
    public class TagsFetcher
    {
        private BlogDbContext context;
        public TagsFetcher(BlogDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TagViewModel> GetPopularTags()
        {
            return this.context.Tags
                .OrderByDescending(t => t.PostTags.Count())
                .Select(t => new TagViewModel {
                    TagId = t.TagId,
                    Name = t.Name
                });
        }
    }
}