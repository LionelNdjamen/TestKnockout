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
            //var listCustomer = ClassConnection.GetCustomer(); 

            return ServiceCustomer.GetCustomer(); 
        }

        // GET: api/Customer/5
        [Route("{Id:int}")]
        public Customer Get(int id)
        {
            return ServiceCustomer.GetCustomerByid(id); 
        }

        // POST: api/Customer
        [Route("CreateCustomer")]
        public void Post([FromBody]Customer customer)
        {
            ServiceCustomer.CreateCustomer(customer); 
        }

        // PUT: api/Customer/5
        [Route("EditCustomer")]
        public void Put(int id, [FromBody]Customer customer)
        {
            customer.Id = id;
            ServiceCustomer.EditCustomer(customer); 
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
