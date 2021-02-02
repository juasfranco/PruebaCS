using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketAPI.Models;
using MarketAPI.Models.Response;
using MarketAPI.Models.Request;

namespace MarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public IActionResult getClient()
        {
            Response responseObject = new Response();
            try
            {
                using (MarketManagementContext db = new MarketManagementContext())
                {
                    var clientslist = db.Clients.OrderByDescending(d => d.Id).ToList();
                    responseObject.Success = 1;
                    responseObject.Data = clientslist;
                }
            }
            catch (Exception error)
            {
                responseObject.Message = error.Message;
            }

            return Ok(responseObject);
        }

        [HttpPost]
        public IActionResult addClient(ClientRequest objectModel)
        {
            Response responseObject = new Response();
            try
            {
                using (MarketManagementContext db = new MarketManagementContext())
                {
                    Client objectClient = new Client();
                    objectClient.ClientName = objectModel.clientName;
                    objectClient.ClientEmail = objectModel.clientEmail;
                    objectClient.ClientAddress = objectModel.clientAddress;
                    objectClient.ClientPhone = objectModel.clientPhone;
                    objectClient.ClientStatus = objectModel.clientStatus;
                    db.Clients.Add(objectClient);
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
        public IActionResult editClient(ClientRequest objectModel)
        {
            Response responseObject = new Response();
            try
            {
                using (MarketManagementContext db = new MarketManagementContext())
                {
                    Client objectClient = db.Clients.Find(objectModel.id);
                    objectClient.ClientName = objectModel.clientName;
                    objectClient.ClientEmail = objectModel.clientEmail;
                    objectClient.ClientAddress = objectModel.clientAddress;
                    objectClient.ClientPhone = objectModel.clientPhone;
                    objectClient.ClientStatus = objectModel.clientStatus;
                    db.Entry(objectClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
        public IActionResult dropClient(long Id)
        {
            Response responseObject = new Response();
            try
            {
                using (MarketManagementContext db = new MarketManagementContext())
                {
                    Client objectClient = db.Clients.Find(Id);
                    db.Remove(objectClient);
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