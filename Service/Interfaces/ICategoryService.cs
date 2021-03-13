using Quicker.Interfaces.Service;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface ICategoryService : ICloseServiceAsync<int, Category>
    {
    }
}
