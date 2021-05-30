using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopping.DataAccess;
using shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ShoppingDbContext dbcontext = new ShoppingDbContext();

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {


            List<Category> catag = (from x in dbcontext.Categories
                                    where x.isActive == true
                                    select x).ToList<Category>();
            return Ok(catag);

        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
                Category objCat = new Category();
                int ID = Convert.ToInt32(id);
                objCat = dbcontext.Categories.Find(ID);
              
                return Ok(objCat);
            
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Category obj)
        {
            dbcontext.Categories.Add(obj);
            dbcontext.SaveChanges();
           
            return Ok("Data inserted sucessfully");
          
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category obj)
        {
            var len = dbcontext.Categories.FirstOrDefault(x => x.Id == id);
            if(len != null)
            {
                len.wearType = obj.wearType;
                len.categoryName = obj.categoryName;

                len.isActive = obj.isActive;

                dbcontext.SaveChanges();
            }
            //dbcontext.Categories.Add(obj);

            return Ok("Data inserted sucessfully");

        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
