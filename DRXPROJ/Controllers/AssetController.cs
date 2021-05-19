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
    public class AssetController : ControllerBase
    {
        IManage<Asset> _manage = Kernel.Instance.Get<IManage<Asset>>();
        // GET: api/<AssetController>
        [HttpGet]
        public List<Asset> Get()
        {
            return _manage.GetAll();
        }

        // GET api/<AssetController>/5
        [HttpGet("{id}")]
        public Asset Get(int id)
        {
            return _manage.GetById(id);
        }

        // POST api/<AssetController>
        [HttpPost]
        public void Post([FromBody] Asset value)
        {
            _manage.Add(value);
        }

        // PUT api/<AssetController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Asset value)
        {
            _manage.Update(value);
        }

        // DELETE api/<AssetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _manage.Remove(id);
        }
    }
}
