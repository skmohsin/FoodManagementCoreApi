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
    public class FoodController : ControllerBase
    {

        IFood _foodService;
        public FoodController(IFood foodService)
        {
            _foodService = foodService;
        }

        // GET api/user
        [HttpGet("category/{categoryID:int}")]
        public ActionResult<IEnumerable<Food>> Get(int? categoryID)
        {
            IEnumerable<Food> foods = _foodService.GetFood(categoryID);
            if (foods.Count() != 0)
                return Ok(new { data = foods, message = "Success", status = true });
            return Ok(new { data = foods, message = "No data available", status = true });
        }

        // POST api/user
        [HttpPost]
        public ActionResult<Food> Save(Food category)
        {
            return _foodService.Save(category);
        }
    }
}