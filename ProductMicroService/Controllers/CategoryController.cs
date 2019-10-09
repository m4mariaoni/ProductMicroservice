using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Data.Interface;
using ProductMicroService.Data.Models;

namespace ProductMicroService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/GetAllCategory
        [HttpGet]
        [ActionName("GetAllCategory")]
        [Route("GetAllCategory")]
        public IActionResult GetAllCategory()
        {
            try
            {
                var category = _categoryRepository.GetCategory();
                if (category == null)
                {
                    return new NotFoundObjectResult(category);
                }
               
                return new OkObjectResult(category);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
                
            }
            
        }

        [HttpGet]
        [ActionName("GetCategoryById")]
        [Route("GetCategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                
                var category = _categoryRepository.GetCategoryById(id);
                if (category == null)
                {
                    return new NotFoundObjectResult(category);
                }
              
                return new OkObjectResult(category);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);


            }

        }

    [HttpPost]
    [ActionName("AddCategory")]
    [Route("AddCategory/")]
    public IActionResult AddCategory(Category category)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(category);
                }
               int id = _categoryRepository.InsertCategory(category);
                return new OkObjectResult(id);

            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost]
        [ActionName("UpdateCategory")]
        [Route("UpdateCategory/")]
        public IActionResult UpdateCategory(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new BadRequestObjectResult(category);
                }
                int id = _categoryRepository.UpdateCategory(category);
                return new OkObjectResult(id);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet]
        [ActionName("DeleteCategory")]
        [Route("DeleteCategory")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {

                var category = _categoryRepository.DeleteCategory(id);
 
                return new OkObjectResult(category);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);


            }

        }
    }
}
