using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public class ProductController : ControllerBase
    {
        ShoppingDbContext dbcontext = new ShoppingDbContext();

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {

           var pro = (from tp in dbcontext.Products
             join tc in dbcontext.Categories
                on tp.categoryId equals tc.Id
             join tb in dbcontext.Brands on tp.brandId equals tb.id
             where (tb.isActive == true) && (tc.isActive == true) && (tp.isActive == true)
                      select new
             {
                 tp.id,
                 tp.productName,
                 tc.categoryName,
                 tb.brandName,
                 tp.price
             }).ToList();
          

            return Ok(pro);

        }
        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product objPro = new Product();
            int ID = Convert.ToInt32(id);
            objPro = dbcontext.Products.Find(ID);

            return Ok(objPro);

        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product obj)
        {
            dbcontext.Products.Add(obj);
            dbcontext.SaveChanges();

            return Ok("Data inserted sucessfully");

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product obj)
        {
            var len = dbcontext.Products.FirstOrDefault(x => x.id == id);
            if (len != null)
            {
                len.productName = obj.productName;
                len.categoryId = obj.categoryId;
                len.brandId = obj.brandId;
                len.price = obj.price;
                len.isActive = obj.isActive;

                dbcontext.SaveChanges();
            }

            return Ok("Data inserted sucessfully");

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
