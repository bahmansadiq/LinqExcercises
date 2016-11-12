using LinqExercises.Infrastructure;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace LinqExercises.Controllers
{
    public class CustomersController : ApiController
    {
        private NORTHWNDEntities _db;

        public CustomersController()
        {
            _db = new NORTHWNDEntities();
        }

        // GET: api/customers/city/London
        [HttpGet, Route("api/customers/city/{city}"), ResponseType(typeof(IQueryable<Customer>))]
        public IHttpActionResult GetAll(string city)
        {
            var specificCustomers = from customer in _db.Customers
                                    where customer.City.Contains(city)
                                    select customer;

            return Ok(specificCustomers);
            //var specificCustomersLambda = _db.Customers.Where(n => n.City.Contains(city));
            //return Ok(specificCustomersLambda);
            //   throw new NotImplementedException("Write a query to return all customers in the given city");
        }

        // GET: api/customers/mexicoSwedenGermany
        [HttpGet, Route("api/customers/mexicoSwedenGermany"), ResponseType(typeof(IQueryable<Customer>))]
        public IHttpActionResult GetAllFromMexicoSwedenGermany()
        {
            var cities = from customer in _db.Customers
                         where (customer.Country == "Mexico" || customer.Country== "Sweden" || customer.Country== "Germany")
                         select customer;
            return Ok(cities);

            //var citiesLambda = _db.Customers.Where(n => n.Country == "Mexico" || n.Country == "Sweden" || n.Country == "Germany");
            //return Ok(citiesLambda);

           // throw new NotImplementedException("Write a query to return all customers from Mexico, Sweden and Germany.");
        }

        // GET: api/customers/shippedUsing/Speedy Express
        [HttpGet, Route("api/customers/shippedUsing/{shipperName}"), ResponseType(typeof(IQueryable<Customer>))]
        public IHttpActionResult GetCustomersThatShipWith(string shipperName)
        {
            var custList = from customer in _db.Customers
                          // where customer.Orders.Contains(shipperName)        
                           select customer;
            return Ok(custList);
            
                        
             
          //  throw new NotImplementedException("Write a query to return all customers with orders that shipped using the given shipperName.");
        }

        // GET: api/customers/withoutOrders
        [HttpGet, Route("api/customers/withoutOrders"), ResponseType(typeof(IQueryable<Customer>))]
        public IHttpActionResult GetCustomersWithoutOrders()
        {

            var listCustomersWithoutOrders = from customer in _db.Customers
                                             where customer.Orders.Equals(null)
                                             select customer;
            return Ok(listCustomersWithoutOrders);
            //throw new NotImplementedException("Write a query to return all customers with no orders in the Orders table.");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
    }
}
