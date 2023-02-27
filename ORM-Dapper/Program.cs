using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            #region Department Section
            //var myDepartmentRepo = new DapperDepartmentRepository(conn);

            //myDepartmentRepo.InsertDepartment("Jacks New Department");

            //var departments = myDepartmentRepo.GetAllDepartments();

            //foreach (var department in departments)
            //{
            //    Console.WriteLine(department.DepartmentID);
            //    Console.WriteLine(department.Name);
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}
            #endregion

            var myProductRepository = new DapperProductRepository(conn);

            //myProductRepository.CreateProduct("Js New Product", 77.77, 9);

            var myProductToUpdate = myProductRepository.GetProductById(942); //We creaeted a new product in SQL Workbench directly with product ID = 942

            //What we want to change with product (Below)
            myProductToUpdate.Name = "UPDATE TEST";
            myProductToUpdate.Price = 99.99;
            myProductToUpdate.CategoryID = 1;
            myProductToUpdate.OnSale = false;
            myProductToUpdate.StockLevel = 99;

            myProductRepository.UpdateProduct(myProductToUpdate);

            var products = myProductRepository.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
