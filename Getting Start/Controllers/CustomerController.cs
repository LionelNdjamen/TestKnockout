using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using Getting_Start.Helpers;
using Getting_Start.Models;

namespace Getting_Start.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        [Route("GetCustomer")]
        public List<Customer> Get()
        {
            //var MesCustomers = new JavaScriptSerializer().Serialize(ClassConnection.GetCustomer());
            //var listCustomer = ClassConnection.GetCustomer(); GetCustomer

            return ServiceCustomer.GetCustomer(); 
        }

        // GET: api/Customer/5
        //[Route("{Id:int}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Customer
        [Route("EditCustomer")]
        public void Post([FromBody]Customer customer)
        {
            ServiceCustomer.EditCustomer(customer);
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        [Route("DeleteCustomer")]
        [HttpGet]
        public void Delete(int id)
        {
            ServiceCustomer.DeleteCustomer(id); 
        }
    }
}
