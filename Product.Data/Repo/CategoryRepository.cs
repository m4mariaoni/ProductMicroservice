using Dapper;
using ProductMicroservice.Data.Interface;
using ProductMicroservice.Data.Models;
using ProductMicroService.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProductMicroservice.Data.Repo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDatabaseConnnectionProvider _databaseConnnectionProvider;
        public CategoryRepository(IDatabaseConnnectionProvider databaseConnnectionProvider)
        {
            _databaseConnnectionProvider = databaseConnnectionProvider;
        }

        public int DeleteCategory(int id)
        {
            using (var connection = _databaseConnnectionProvider.GetDbConnection())
            {
                try
                {
                    var sql = "DELETE from Category where id = @id";
                    int ans = connection.Execute(sql, new { id });
                    if (ans <= 0)
                    {
                        return 0;
                    }
                    return ans;
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<Category> GetCategory()
        {
            IEnumerable<Category> allProducts = null;
            using (var connection = _databaseConnnectionProvider.GetDbConnection())
            {
               allProducts = connection.Query<Category>("Select * from category");
            }

            return allProducts;
        }

        public Category GetCategoryById(int id)
        {
            var category = new Category();
            using (var connection = _databaseConnnectionProvider.GetDbConnection())
            {
                try
                {
                    category = connection.QuerySingle<Category>("Select * from Category where id = @id", new { id });
                }
                catch (Exception)
                {
                    throw;
                }
                   
            }
            return category;
        }

        public int InsertCategory(Category category)
        {
            using (var connection = _databaseConnnectionProvider.GetDbConnection())
            {
                string insertQuery = @"INSERT INTO category(name,description) VALUES(@name,@description)";

                int id =  connection.Execute(insertQuery, category);
                if (id <= 0)
                {
                    return 0;
                }
                return id;
                
            }
        }

        public int UpdateCategory(Category category)
        {
            using (var connection = _databaseConnnectionProvider.GetDbConnection())
            {
                try
                {
                    var existingRecord =GetCategoryById(category.Id);
                    if(existingRecord == null)
                    {
                        return 0;
                    }
                    string updateQuery = @"UPDATE Category SET name=@name,description=@description WHERE id=@Id";
                    int id = connection.Execute(updateQuery, category);
                    if (id <= 0)
                    {
                        return 0;
                    }
                    return id;

                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
    }
}
