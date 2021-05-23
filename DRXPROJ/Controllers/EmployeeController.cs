using DRXPROJ.CustomInjections;
using DRXPROJ.Manage.Interface;
using DRXPROJ.Models;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DRXPROJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IManage<Employee> _manage = Kernel.Instance.Get<IManage<Employee>>();

        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            return _manage.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _manage.GetById(id);
        }

        [HttpGet("GetBy", Name = "GetByTwoStrings")]
        public Employee Get(string username, string password)
        {
            return  _manage.GetAll().Where(x => x.UserName.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
        } 

        [HttpGet("Exists", Name = "ValidateTheUsername")]
        public bool Get(string username)
        {
            var employee = _manage.GetAll().Where(x => x.UserName.Equals(username));
            if (employee != null) return true;
            return false;
        }



        // POST api/<EmployeeController>
        [HttpPost]
        public Employee Post([FromBody] Employee value)
        {    
            return _manage.Add(value);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public Employee Put(int id, [FromBody] Employee value)
        {
           return  _manage.Update(value);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _manage.Remove(id);
        }
    }
}
