﻿using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Core.Entities;
using JobSearch.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Repositories.Implements
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(JobSearchContext context) : base(context)
        {
        }
    }
}