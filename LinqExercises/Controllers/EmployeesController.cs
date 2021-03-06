﻿using LinqExercises.Infrastructure;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace LinqExercises.Controllers
{
    public class EmployeesController : ApiController
    {
        private NORTHWNDEntities _db;

        public EmployeesController()
        {
            _db = new NORTHWNDEntities();
        }

        // GET: api/employees
        [HttpGet, Route("api/employees"), ResponseType(typeof(IQueryable<Employee>))]
        public IHttpActionResult GetEmployees()
        {
            var emplyee = from p in _db.Employees
                         select p;
           return Ok(emplyee);


           // throw new NotImplementedException("Write a query to return all employees");
        }

        // GET: api/employees/title/Sales Manager
        [HttpGet, Route("api/employees/title/{title}"), ResponseType(typeof(IQueryable<Employee>))]
        public IHttpActionResult GetEmployeesByTitle(string title)
        {
              var employeeTitel = from p in _db.Employees
                               where p.Title.Contains(title)
                              select p;
              return Ok(employeeTitel);

            //var employeeTitelLambda = _db.Employees.Where(n => n.Title.Contains(title));
            //return Ok(employeeTitelLambda);
            //throw new NotImplementedException("Write a query to return all employees with the given Title");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
    }
}
