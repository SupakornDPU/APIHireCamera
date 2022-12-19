using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWebApp.Entities;
using APIWebApp.Repositories;
using APIWebApp.Models;

namespace APIWebApp.Services
{
    public class ProductService : IProductService
    {
        // ! new object เพื่อเอา Service ไปต่อกับ Repository
        private readonly IProductRepository productRepository; // ตัวแปรที่ประกาศ readonly จะถูก Assign ค่าได้แค่ครั้งเดียวเท่านั้นตอน new object คนที่มีอำนาจในการ Assign ค่าได้คือ Constructor
        
        public ProductService(IProductRepository productRepository) // ประกาศ Constructor
        {
            this.productRepository = productRepository;
        }

        public ProductSerial? CreateProductSerial(ProductSerial productSerial)
        {
            return productRepository.CreateProductSerial(productSerial);
        }

        public Product? CreateProduct(Product product)
        {
            return productRepository.CreateProduct(product);
        }

        public Product DeleteProducts(string id)
        {
            return productRepository.DeleteProducts(id);
        }

        public ProductSerial DeleteProductSerial(string id)
        {
            return productRepository.DeleteProductSerial(id);
        }

        public Product EditProducts(Product productId)
        {
            return productRepository.EditProducts(productId);
        }

        public ProductSerial EditProductSerial(ProductSerial productSerial)
        {
            return productRepository.EditProductSerial(productSerial);
        }

        // public Product? GetProductById(string ProductId)
        // {
        //     return productRepository.GetProductById(ProductId);
        // }

        public IEnumerable<ProductSerial> GetProductsSerial()
        {
            return productRepository.GetProductsSerial(); // ต้องใช้ .ToList() เพราะ Method GetProducts()ที่อยู่ใน Repository เป็น IQueryable
            // ถ้าต้องการแบบมีเงื่อนไขให้ใช้ return productRepository.GetProducts().Where(w => w.Product_Id == 1).ToList();
        }

        public IEnumerable<JoinTable> GetProductsJoin()
        {
            return productRepository.GetProductsJoin();
        }
    }
}