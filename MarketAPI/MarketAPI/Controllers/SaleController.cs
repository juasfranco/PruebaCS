using MarketAPI.Models;
using MarketAPI.Models.Request;
using MarketAPI.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Controllers
{
    public class SaleController : Controller
    {
        [HttpGet]
        public IActionResult getSale()
        {
            Response responseObject = new Response();
            try
            {
                using (MarketManagementContext db = new MarketManagementContext())
                {
                    var saleslist = db.Sales.OrderByDescending(d => d.Id).ToList();
                    responseObject.Success = 1;
                    responseObject.Data = saleslist;
                }
            }
            catch (Exception error)
            {
                responseObject.Message = error.Message;
            }

            return Ok(responseObject);
        }

        [HttpPost]
        public IActionResult addSale(SaleRequest objectModel)
        {
            Response responseObject = new Response();
            try
            {
                using (MarketManagementContext db = new MarketManagementContext())
                {
                    Sale objectSale = new Sale();
                    objectSale.ClientId = objectModel.ClientId;
                    objectSale.SaleDate = objectModel.SaleDate;
                    objectSale.SaleTotal = objectModel.SaleTotal;
                    objectSale.SaleStatus = objectModel.SaleStatus;
                    db.Sales.Add(objectSale);
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
        public IActionResult editSale(SaleRequest objectModel)
        {
            Response responseObject = new Response();
            try
            {
                using (MarketManagementContext db = new MarketManagementContext())
                {
                    Sale objectSale = db.Sales.Find(objectModel.Id);
                    objectSale.ClientId = objectModel.ClientId;
                    objectSale.SaleDate = objectModel.SaleDate;
                    objectSale.SaleTotal = objectModel.SaleTotal;
                    objectSale.SaleStatus = objectModel.SaleStatus;
                    db.Entry(objectSale).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public IActionResult dropSale(long Id)
        {
            Response responseObject = new Response();
            try
            {
                using (MarketManagementContext db = new MarketManagementContext())
                {
                    Sale objectSale = db.Sales.Find(Id);
                    db.Remove(objectSale);
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
