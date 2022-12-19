using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIWebApp.Entities;
using APIWebApp.Models;

namespace APIWebApp.Repositories
{
    // Interface เป็นการเขียนโครงร่าง เพื่อให้เอาไปเขียน Function,Method  ตามโครงร่างของ Interface
    public interface IProductRepository
    {
        // การตั้งชื่อ Method จะเอาอะไรให้ใช้ Verb นำหน้า
        IEnumerable<ProductSerial> GetProductsSerial(); // ถ้าต้องการข้อมูลที่เป็น Array จะใช้ Return type IQueryable => คือการเขียนให้โปรแกรมคืนมาในรูปแบบ Query ทำให้มีประโยชน์ในการใช้เงื่อนไข โดยการใส่ .และใส่ Where condition ได้
        IEnumerable<JoinTable> GetProductsJoin();
        // Product? GetProductById(String ProductId);
        ProductSerial? CreateProductSerial(ProductSerial productSerial);
        Product? CreateProduct(Product product);
        ProductSerial EditProductSerial(ProductSerial productSerial);
        Product EditProducts(Product productId);
        
        ProductSerial DeleteProductSerial(string id);
        Product DeleteProducts(string id);
    }
}