using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nhom04_Jewelry.Models;

namespace Nhom04_Jewelry.ApiControllers
{
    public class CategoryController : ApiController
    {
        ProductDB db = new ProductDB();
        public List<Category> Get()
        {
           
            List<Category> categories = db.Categories.ToList();
            return categories;
        }
        public Category GetCategoryID(long Id)
        {
            Category category = db.Categories.Where(p => p.CategoryID == Id).FirstOrDefault();
            return category;
        }
        public void PostCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            
        }
        public void PutCaregory(Category category)
        {
            Category category1 = db.Categories.Where(p => p.CategoryID == category.CategoryID).FirstOrDefault();
            category1.CategoryName = category.CategoryName;
            db.SaveChanges();
        }
        
    }
}
