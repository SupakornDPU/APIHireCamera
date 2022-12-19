using System.Data;
using APIWebApp.Entities;
using APIWebApp.Models;
using APIWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace APIWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
   private readonly IProductService productService;
   public ProductsController(IProductService productService)
   {
      this.productService = productService;
   }

   // GET ProductSerial
   [HttpGet("ProductSerial")]
   public IActionResult GetProductsSerial()
   {
      var response =  productService.GetProductsSerial();
      return Ok(response);
   }

   // GET Product
   [HttpGet("ProductJoin")]
   public IActionResult GetProductsJoin()
   {
      var response =  productService.GetProductsJoin();
      return Ok(response);
   }

   // [HttpGet("{ProductId}")]
   // public IActionResult GetProduct(String ProductId)
   // {
   //    var response =  productService.GetProduct(ProductId);
   //    return Ok(response);
   // }

   // [HttpGet("ProductById/{ProductId}")]
   // public IActionResult GetProductById(String ProductId)
   // {
   //    var response =  productService.GetProductById(ProductId);
   //    return Ok(response);
   // }

   // POST ProductSerial
   [HttpPost]
   public IActionResult CreateProduct(ProductRequest product)
   {
      Product _product = new Product();
      _product.ProductId = product.ProductId;
      _product.ProductSerialnumber = product.ProductSerialnumber;
      _product.AdminId = "AD001";
      _product.CategoryId = product.CategoryId;

      var response =  productService.CreateProduct(_product);
      return Ok(response);
   }

   // POST ProductSerial
   [HttpPost("ProductSerialsPost")]
   public IActionResult CreateProductSerial(ProductSerialsRequest productSerial)
   {
      ProductSerial _productSerials = new ProductSerial();
      _productSerials.ProductSerialnumber = productSerial.ProductSerialnumber;
      _productSerials.ProductName = productSerial.ProductName;
      _productSerials.ProductPrice = productSerial.ProductPrice;

      var response =  productService.CreateProductSerial(_productSerials);
      return Ok(response);
   }

   // PUT ProductSerial
   [HttpPut("EditProductSerials")]
   public IActionResult EditProductSerial(ProductSerialEdit productSerialEdit)
   {
      ProductSerial _productSerial = new ProductSerial();
      _productSerial.ProductSerialnumber = productSerialEdit.ProductSerialnumber;
      _productSerial.ProductName = productSerialEdit.ProductName;
      _productSerial.ProductPrice = productSerialEdit.ProductPrice;

      var response = productService.EditProductSerial(_productSerial);
      return Ok(response);
   }

   // PUT Product
   [HttpPut("EditProducts")]
   public IActionResult EditProducts(ProductsEdit productsEdit)
   {
      Product _products = new Product();
      _products.ProductId = productsEdit.ProductId;
      _products.ProductSerialnumber = productsEdit.ProductSerialnumber;
      _products.AdminId = "AD001";
      _products.CategoryId = productsEdit.CategoryId;

      var response = productService.EditProducts(_products);
      return Ok(response);
   }

   // DELETE ProductSerial
   [HttpDelete("DeleteProductSerials")]
   public IActionResult DeleteProductSerial(string id)
   {
      var response = productService.DeleteProductSerial(id);
      return Ok(response);
   }

   // DELETE Product
   [HttpDelete("DeleteProducts")]
   public IActionResult DeleteProducts(string id)
   {
      var response = productService.DeleteProducts(id);
      return Ok(response);
   }

}
