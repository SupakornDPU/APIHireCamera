using System.IO.Pipes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using APIWebApp.Entities;
using APIWebApp.Models;
using Microsoft.Data.SqlClient;

namespace APIWebApp.Repositories
{
    // ProductRepository : IProductRepository เป็นการ inheritance ไปที่ Interface
    public class ProductRepository : IProductRepository
    {
        private DatabaseContext databaseContext; // ประกาศตัวแปร DatabaseContext เพื่อเก็บ Connection ของ database

        public ProductRepository(DatabaseContext databaseContext) // ประกาศ Constructor เพื่อรับ Connection String เข้ามาเพื่อทำการ new object
        {
            this.databaseContext = databaseContext; //this. ใช้ในกรณีที่ชื่อตัวแปรที่เราจะ assign กับชื่อ parameter เป็นชื่อเดียวกันเท่านั้น
        }

        // ! Method : GET ProductSerial
        public IEnumerable<ProductSerial> GetProductsSerial() 
        {
            //นำข้อมูลที่อยู่ใน database คืนไปให้ user
            // return databaseContext.Products; // ไม่ว่าจะเขียน Class repository อะไรก็ตาม ต้องเอาชื่อ databaseContext ที่เราตั้งขึ้นก่อนแล้ว .ตามด้วยชื่อ table ที่ต้องการคืนให้ User
            string queryString = "SELECT * FROM [dbo].[Product_Serial]";
            string connectionString = "Server=hirecamera.cdr9roqknuqa.ap-southeast-1.rds.amazonaws.com,1433;Initial Catalog=hirecamera;User ID=admin;Password=admin1234";
            var items = new List<ProductSerial>();

            using (SqlConnection connection = new SqlConnection(connectionString)) // คิดว่าน่าจะเป็นการนำตัวแปร connection มาเก็บ ConnectionString เพื่อเชื่อมต่อกับ database
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    items.Add(new ProductSerial
                    {
                        ProductSerialnumber = (String)reader["ProductSerialnumber"],
                        ProductName = (string)reader["ProductName"],
                        ProductPrice = (int)reader["ProductPrice"],
                    });
                }
                return items;
            }
        }

        // ! Method : GET ProductJoin
        public IEnumerable<JoinTable> GetProductsJoin()
        {
            string queryString = "SELECT Product.Product_Id, Product.Product_Serialnumber, Product_Serial.Product_Name, Product_Serial.Product_Price, Category.Category_Name " +
                                    "FROM [dbo].[Product] " + 
                                    "INNER JOIN [dbo].[Product_Serial] ON Product.Product_Serialnumber = Product_Serial.Product_Serialnumber " + 
                                    "INNER JOIN [dbo].[Category] ON Product.Category_Id = Category.Category_Id ";
            string connectionString = "Server=hirecamera.cdr9roqknuqa.ap-southeast-1.rds.amazonaws.com,1433;Initial Catalog=hirecamera;User ID=admin;Password=admin1234";

            using (SqlConnection connection = new SqlConnection(connectionString)) // คิดว่าน่าจะเป็นการนำตัวแปร connection มาเก็บ ConnectionString เพื่อเชื่อมต่อกับ database
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                List<JoinTable> joinTables = new List<JoinTable>();
                while (reader.Read())
                {
                    JoinTable joinTable = new JoinTable
                    {
                        ProductId = (string)reader["ProductId"],
                        ProductSerialnumber = (string)reader["ProductSerialnumber"],
                        ProductName = (string)reader["ProductName"],
                        ProductPrice = (int)reader["ProductPrice"],
                        CategoryName = (string)reader["CategoryName"]
                    };
                    joinTables.Add(joinTable);
                }
                return joinTables;
            }
            
        }

        // ! Method : POST ProductSerial
        public ProductSerial? CreateProductSerial(ProductSerial productSerial)
        {
            // databaseContext.ProductSerial.Add(productSerial);
            // databaseContext.SaveChanges();
            // return productSerial;

            string queryString = "INSERT INTO [dbo].[Product_Serial] (Product_Serialnumber, Product_Name, Product_Price) VALUES (@ProductSerialnumber, @ProductName, @ProductPrice)";
            string connectionString = "Server=hirecamera.cdr9roqknuqa.ap-southeast-1.rds.amazonaws.com,1433;Initial Catalog=hirecamera;User ID=admin;Password=admin1234";
            
            using (SqlConnection connection = new SqlConnection(connectionString)) // คิดว่าน่าจะเป็นการนำตัวแปร connection มาเก็บ ConnectionString เพื่อเชื่อมต่อกับ database
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ProductSerialnumber", productSerial.ProductSerialnumber);
                command.Parameters.AddWithValue("@ProductName", productSerial.ProductName);
                command.Parameters.AddWithValue("@ProductPrice", productSerial.ProductPrice);
                connection.Open();
                command.ExecuteNonQuery();

            }
            return productSerial;
            
        }

        // ! Method : POST Product
        public Product? CreateProduct(Product product)
        {
            string queryString = "INSERT INTO [dbo].[Product] (Product_Id, Product_Serialnumber, Admin_Id ,Category_Id) VALUES (@ProductId, @ProductSerialnumber,@AdminId,@CategoryId)";
            string connectionString = "Server=hirecamera.cdr9roqknuqa.ap-southeast-1.rds.amazonaws.com,1433;Initial Catalog=hirecamera;User ID=admin;Password=admin1234";
            
            using (SqlConnection connection = new SqlConnection(connectionString)) // คิดว่าน่าจะเป็นการนำตัวแปร connection มาเก็บ ConnectionString เพื่อเชื่อมต่อกับ database
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ProductId", product.ProductId);
                command.Parameters.AddWithValue("@ProductSerialnumber", product.ProductSerialnumber);
                command.Parameters.AddWithValue("@AdminId", product.AdminId);
                command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return product;
        }

        // ! Method : PUT ProductSerial
        public ProductSerial EditProductSerial(ProductSerial productSerial)
        {
            string queryString = "UPDATE [dbo].[Product_Serial] SET Product_Name = @ProductName, Product_Price = @ProductPrice WHERE Product_Serialnumber = @ProductSerialnumber";
            string connectionString = "Server=hirecamera.cdr9roqknuqa.ap-southeast-1.rds.amazonaws.com,1433;Initial Catalog=hirecamera;User ID=admin;Password=admin1234";
            
            using (SqlConnection connection = new SqlConnection(connectionString)) // คิดว่าน่าจะเป็นการนำตัวแปร connection มาเก็บ ConnectionString เพื่อเชื่อมต่อกับ database
            {

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ProductSerialnumber", productSerial.ProductSerialnumber);
                command.Parameters.AddWithValue("@ProductName", productSerial.ProductName);
                command.Parameters.AddWithValue("@ProductPrice", productSerial.ProductPrice);
                connection.Open();
                command.ExecuteNonQuery();

            }
            return productSerial;
        }

        public Product EditProducts(Product productId) //Medthod PUT
        {   
            
            string queryString = " UPDATE [dbo].[Product] SET Product_Serialnumber = @ProductSerialnumber, Category_Id = @CategoryId, Admin_Id = @AdminId WHERE Product_Id = @productId";
            string connectionString = "Server=hirecamera.cdr9roqknuqa.ap-southeast-1.rds.amazonaws.com,1433;Initial Catalog=hirecamera;User ID=admin;Password=admin1234";
            
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ProductId", productId.ProductId);
                command.Parameters.AddWithValue("@ProductSerialnumber", productId.ProductSerialnumber);
                command.Parameters.AddWithValue("@AdminId", productId.AdminId);
                command.Parameters.AddWithValue("@CategoryId", productId.CategoryId);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return productId;
        }

        // ! Method : DELETE ProductSerial
        public ProductSerial DeleteProductSerial(string id)
        {
            string queryString = "DELETE FROM [dbo].[Product_Serial] WHERE Product_Serialnumber = @id";
            string connectionString = "Server=hirecamera.cdr9roqknuqa.ap-southeast-1.rds.amazonaws.com,1433;Initial Catalog=hirecamera;User ID=admin;Password=admin1234";

            using (SqlConnection connection = new SqlConnection(connectionString)) // คิดว่าน่าจะเป็นการนำตัวแปร connection มาเก็บ ConnectionString เพื่อเชื่อมต่อกับ database
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
            return null;
        }

        // ! Method : DELETE Product
        public Product DeleteProducts(string id) //Medthod Delete
        {
            string queryString = " DELETE FROM [dbo].[Product] WHERE Product_Id = @ProductIds ";
            string connectionString = "Server=hirecamera.cdr9roqknuqa.ap-southeast-1.rds.amazonaws.com,1433;Initial Catalog=hirecamera;User ID=admin;Password=admin1234";

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ProductIds", id);
                command.ExecuteNonQuery();
                
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
                return null;
        }

        // public Product? GetProductById(String ProductId)
        // {
        //     string queryString = "SELECT * FROM [dbo].[Product] WHERE Product_Id = @ProductId";
        //     string connectionString = "Server=hirecamera.cdr9roqknuqa.ap-southeast-1.rds.amazonaws.com,1433;Initial Catalog=hirecamera;User ID=admin;Password=admin1234";

        //     using (SqlConnection connection = new SqlConnection(connectionString)) // คิดว่าน่าจะเป็นการนำตัวแปร connection มาเก็บ ConnectionString เพื่อเชื่อมต่อกับ database
        //     {
        //         SqlCommand command = new SqlCommand(queryString, connection);
        //         command.Parameters.AddWithValue("@ProductId", ProductId);
        //         connection.Open();
        //         SqlDataReader reader = command.ExecuteReader();
                
        //         while(reader.Read())
        //         {
        //             var product = new Product()
        //             {
        //                 ProductId = reader.GetString("ProductId"),
        //                 ProductSerialnumber = reader.GetString("ProductSerialnumber"),
        //                 AdminId = reader.GetString("AdminId"),
        //                 CategoryId = reader.GetString("CategoryId")
        //             };

        //             connection.Close();

        //             return product;
        //         }
        //         return null;
        //     }
        // }

        // public Product CreateProduct(Product product)
        // {
        //     databaseContext.Products.Add(product);
        //     databaseContext.SaveChanges();
        //     return product;
        // }

        // public Product DeleteProducts(string id)
        // {
        //     string queryString = "DELETE FROM [dbo].[Product_Serial] WHERE Product_Serialnumber = @id";
        //     string connectionString = "Server=hirecamera.cdr9roqknuqa.ap-southeast-1.rds.amazonaws.com,1433;Initial Catalog=hirecamera;User ID=admin;Password=admin1234";

        //     using (SqlConnection connection = new SqlConnection(connectionString)) // คิดว่าน่าจะเป็นการนำตัวแปร connection มาเก็บ ConnectionString เพื่อเชื่อมต่อกับ database
        //     {
        //         connection.Open();
        //         SqlCommand command = new SqlCommand(queryString, connection);
        //         command.Parameters.AddWithValue("@ProductId", id);
        //         command.ExecuteNonQuery();
                
        //         SqlDataReader reader = command.ExecuteReader();
        //         connection.Close();
        //     }
        //         return null;
        // }
    }
}