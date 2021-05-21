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
    public class CostcentersController : ControllerBase
    {
        IManage<Costcenters> _manage = Kernel.Instance.Get<IManage<Costcenters>>();
        // GET: api/<CostcentersController>
        [HttpGet]
        public List<Costcenters> Get()
        {
            return _manage.GetAll();
        }

        // GET api/<CostcentersController>/5
        [HttpGet("{id}")]
        public Costcenters Get(int id)
        {
            return _manage.GetById(id);
        }

        // POST api/<CostcentersController>
        [HttpPost]
        public Costcenters Post([FromBody] Costcenters value)
        {
            return _manage.Add(value);
        }

        // PUT api/<CostcentersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Costcenters value)
        {
            _manage.Update(value);
        }

        // DELETE api/<CostcentersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _manage.Remove(id);
        }
    }
}
