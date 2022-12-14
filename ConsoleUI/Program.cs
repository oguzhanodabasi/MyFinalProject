// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI // Note: actual namespace depends on the project name.
{
    //SOLID
    //Open Closed Principle
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //IoC
            //CategoryTest();
        }

        private static void CategoryTest()
        {

            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();

            if (result.Success == true)
            {
                foreach (var product in productManager.GetProductDetails().Data)
                {
                    Console.WriteLine("{0} / {1}", product.ProductName, product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
