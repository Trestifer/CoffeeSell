using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.ObjClass
{
    public class Category
    {
        private int CategoryID { get; set; }
        private string CategoryName { get; set; }

        public Category(int categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
        }

        public Category()
        {
        }
        public int GetCategoryID()  => CategoryID;
        public string GetCategoryName() => CategoryName;
    }
}
