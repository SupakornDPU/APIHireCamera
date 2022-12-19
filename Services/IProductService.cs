using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWebApp.Entities;
using APIWebApp.Models;

namespace APIWebApp.Services
{
    public interface IProductService
    {
        // GET ProductSerial
        IEnumerable<ProductSerial> GetProductsSerial();

        // GET ProductJoinTable
        IEnumerable<JoinTable> GetProductsJoin();

        // POST ProductSerial
        ProductSerial? CreateProductSerial(ProductSerial product);

        // POST Product
        Product? CreateProduct(Product product);

        // PUT ProductSerial
        ProductSerial EditProductSerial(ProductSerial productSerial);

        // PUT Product
        Product EditProducts(Product productId);

        // DELETE ProductSerial
        ProductSerial DeleteProductSerial(string id);

        // DELETE Product
        Product DeleteProducts(string id);

        // Product? GetProductById(String ProductId);

    }
}