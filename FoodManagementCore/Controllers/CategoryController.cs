using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodManagementCore.Models;
using FoodManagementCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodManagementCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategory _categoryService;
        public CategoryController(ICategory categoryService)
        {
            _categoryService = categoryService;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            IEnumerable<Category> categories = _categoryService.GetCategory();
            if (categories.Count() != 0)
                return Ok(new { data = categories, message = "Success", status = true });
            return Ok(new { data = categories, message = "No data available", status = true });
        }

        // POST api/user
        [HttpPost]
        public ActionResult<Category> Save(Category category)
        {
            return _categoryService.Save(category);
        }
    }
}