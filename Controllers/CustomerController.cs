using ConnetcSQLBase_Azure.Connection;
using Microsoft.AspNetCore.Mvc;

namespace ConnetcSQLBase_Azure.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController
    {
        private readonly ConnectionToSQLBaseAzure _dbContext;
        public CustomerController(ConnectionToSQLBaseAzure dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost("Update")]
        public JsonResult UpdateCustomer([FromForm] Customer newData)
        {
            if (_dbContext.Customers == null)
                return new JsonResult("List of Customers aren`t exist!");

            _dbContext.Customers.Update(newData);
            if (_dbContext.SaveChanges() > 0)
                return new JsonResult($"Customer with Id={newData.ID} updated");
            else
                return new JsonResult("Customer wasn`t updated");
        }

        [HttpPost]
        [Route("AddCustomer")]
        public JsonResult AddCustomer([FromForm] Customer Customer)
        {
            _dbContext.Customers.Add(Customer);
            _dbContext.SaveChanges();

            return new JsonResult("Customer added");
        }

        [HttpGet]
        [Route("GetCustomers")]
        public JsonResult GetCustomers()
        {
            return new JsonResult(_dbContext.Customers.ToList());
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public JsonResult DeleteCustomer(int id)
        {
            if (_dbContext.Customers == null)
                return new JsonResult("List of Customers aren`t exist!");
            Customer Customer = _dbContext.Customers.FirstOrDefault(x => x.ID == id);
            _dbContext.Customers.Remove(Customer);
            if (_dbContext.SaveChanges() > 0)
                return new JsonResult("Deleted successfully");
            else
                return new JsonResult("Customer wasn`t deleted");
        }
    }
}
