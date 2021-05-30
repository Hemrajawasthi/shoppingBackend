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
    public class BrandController : ControllerBase
    {
        ShoppingDbContext dbcontext = new ShoppingDbContext();
        // GET: api/<BrandController>
        [HttpGet]
        public IActionResult Get()
        {
            var bra = (from tp in dbcontext.Brands
                       join tc in dbcontext.Categories
                          on tp.categoryId equals tc.Id
                        where (tc.isActive == true) && (tp.isActive == true)
                       select new
                       {
                           tc.categoryName,
                           tp.brandName,
                           tp.code,
                           tp.id,
                           tp.isActive
                       }).ToList();
           
            return Ok(bra);

        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Brand objBrand = new Brand();
            int ID = Convert.ToInt32(id);
            objBrand = dbcontext.Brands.Find(ID);
          
            return Ok(objBrand);

        }

        // POST api/<BrandController>
        [HttpPost]
        public IActionResult Post([FromBody] Brand obj)
        {
            dbcontext.Brands.Add(obj);
            dbcontext.SaveChanges();


            return Ok("Data inserted sucessfully");

        }
      

        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Brand obj)
        {
            var len = dbcontext.Brands.FirstOrDefault(x => x.id == id);
            if (len != null)
            {
                len.brandName = obj.brandName;
                len.code = obj.code;
                len.isActive = obj.isActive;
                len.categoryId = obj.categoryId;


                dbcontext.SaveChanges();
            }
           

            return Ok("Data inserted sucessfully");

        }


        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
