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
    public class AssetEmployeeController : ControllerBase
    {
        IManage<AssetEmployee> _manage = Kernel.Instance.Get<IManage<AssetEmployee>>();
        // GET: api/<AssetEmployeeController>
        [HttpGet]
        public List<AssetEmployee> Get()
        {
            return _manage.GetAll();
        }

        // GET api/<AssetEmployeeController>/5
        [HttpGet("GetBy", Name = "GetByTwoIds")]
        public AssetEmployee Get(int id,int id2)
        {
            return _manage.GetById(id,id2);
        }

        // POST api/<AssetEmployeeController>
        [HttpPost]
        public AssetEmployee Post([FromBody] AssetEmployee value)
        {
            return _manage.Add(value);
        }

        // PUT api/<AssetEmployeeController>/5
        [HttpPut("{id}")]
        public AssetEmployee Put(int id, [FromBody] AssetEmployee value)
        {
            return _manage.Update(value);
        }

        // DELETE api/<AssetEmployeeController>/5
        [HttpDelete("delete", Name = "APIDelete")]
        public void Delete(int id,int id2)
        {
            _manage.Remove(id,id2);
        }
    }
}
