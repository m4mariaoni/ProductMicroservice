using Dapper;
using ProductMicroservice.Data.Interface;
using ProductMicroservice.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProductMicroservice.Data.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly string db;
        public ProductRepository(string connectionString)
        {
            this.db = connectionString;
        }
        public void DeleteProduct(int ProductId)
        {
            //var product = _dbContext.Products.Find(productId);
            //_dbContext.Products.Remove(product);
            //Save();
        }

        public Products GetProductById(int ProductId)
        {
            return null;//_dbContext.Products.Find(productId);
        }

        public IEnumerable<Products> GetProducts()
        {
            IEnumerable<Products> allProducts = null;
            using (var connection = new SqlConnection(db))
            {
                allProducts = connection.Query<Products>("Select * from Product");
            }

            return allProducts;
        }

        public void InsertProduct(Products Product)
        {
            using (var connection = new SqlConnection(db))
            {
                var sql = "INSERT INTO Product(Name,Description,Price,CategoryId) VALUES(@Name, @Description, @Price, @CategoryId);" +
             "SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = connection.Query<int>(sql, Product);
            }


        }



        public void Save()
        {

            //contact.Id = id;

        }

        public void UpdateProduct(Products Product)
        {
            //_dbContext.Entry(product).State = EntityState.Modified;
            //Save();
        }
    }
}
