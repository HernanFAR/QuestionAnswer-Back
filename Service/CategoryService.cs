using Quicker.Abstracts.Service;
using Repository.Models;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class CategoryService : CloseServiceAsync<int, Category>, ICategoryService
    {
        public CategoryService(IServiceProvider service) : 
            base(service) { }
    }
}
