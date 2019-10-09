using System;
using System.Collections.Generic;
using System.Text;
using ProductMicroservice.Data.Models;

namespace ProductMicroservice.Data.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetProducts();
        Products GetProductById(int ProductId);
        void InsertProduct(Products Product);
        void DeleteProduct(int ProductId);
        void UpdateProduct(Products Product);
        void Save();
    }
}
