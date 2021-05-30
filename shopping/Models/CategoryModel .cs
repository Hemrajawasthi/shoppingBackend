using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shopping.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string categoryName { get; set; }

        public string wearType { get; set; }

        public Boolean isActive { get; set; }



    }

    public class Brand
    {
        [Key]

        public int id { get; set; }

        public string brandName { get; set; }

        public string code { get; set; }
        public Boolean isActive { get; set; }
        public int categoryId { get;  set; }
    }
    public class Product
    {
        [Key]

        public int id { get; set; }

        public string productName { get; set; }

        public int categoryId { get; set; }
        public int brandId { get; set; }
        public int price { get; set; }

        public Boolean isActive { get; set; }

     

    }

}
