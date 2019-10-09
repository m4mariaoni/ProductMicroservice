using System;
using System.Collections.Generic;
using System.Text;
using ProductMicroservice.Data.Models;
using ProductMicroService.Data.Models;

namespace ProductMicroservice.Data.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategory();
        Category GetCategoryById(int CategoryId);
        int InsertCategory(Category category);
        int DeleteCategory(int CategoryId);
        int UpdateCategory(Category category);
    }
}
