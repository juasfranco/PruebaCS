using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketAPI.Models.Response;
using MarketAPI.Models.Request;
using MarketAPI.Models;

namespace MarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult getProduct()
        {
            Response responseObject = new Response();
            try
            {
                using (MarketManagementContext db = new MarketManagementContext())
                {
                    var productslist = db.Products.OrderByDescending(d => d.Id).ToList();
                    responseObject.Success = 1;
                    responseObject.Data = productslist;
                }
            }
            catch (Exception error)
            {
                responseObject.Message = error.Message;
            }

            return Ok(responseObject);
        }

        [HttpPost]
        public IActionResult addProduct(ProductRequest objectModel)
        {
            Response responseObject = new Response();
            try
            {
                using (MarketManagementContext db = new MarketManagementContext())
                {
                    Product objectProduct = new Product();
                    objectProduct.ProductName = objectModel.productName;
                    objectProduct.ProductUnitValue = objectModel.productUnitValue;
                    objectProduct.ProductFinalCost = objectModel.productFinalCost;
                    objectProduct.ProductStock = objectModel.productStock;
                    objectProduct.ProductStatus = objectModel.productStatus;
                    db.Products.Add(objectProduct);
                    db.SaveChanges();
                    responseObject.Success = 1;
                }
            }
            catch (Exception error)
            {
                responseObject.Message = error.Message;
            }

            return Ok(responseObject);
        }

        [HttpPut]
        public IActionResult editProduct(ProductRequest objectModel)
        {
            Response responseObject = new Response();
            try
            {
                using (MarketManagementContext db = new MarketManagementContext())
                {
                    Product objectProduct = db.Products.Find(objectModel.id);
                    objectProduct.ProductName = objectModel.productName;
                    objectProduct.ProductUnitValue = objectModel.productUnitValue;
                    objectProduct.ProductFinalCost = objectModel.productFinalCost;
                    objectProduct.ProductStock = objectModel.productStock;
                    objectProduct.ProductStatus = objectModel.productStatus;
                    db.Entry(objectProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    responseObject.Success = 1;
                }
            }
            catch (Exception error)
            {
                responseObject.Message = error.Message;
            }

            return Ok(responseObject);
        }

        [HttpDelete("{Id}")]
        public IActionResult dropProduct(long Id)
        {
            Response responseObject = new Response();
            try
            {
                using (MarketManagementContext db = new MarketManagementContext())
                {
                    Product objectProduct = db.Products.Find(Id);
                    db.Remove(objectProduct);
                    db.SaveChanges();
                    responseObject.Success = 1;
                }
            }
            catch (Exception error)
            {
                responseObject.Message = error.Message;
            }

            return Ok(responseObject);
        }
    }
}