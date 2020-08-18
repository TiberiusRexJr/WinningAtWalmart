using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;
using WinningAtWalmart.DataLayer;
using WinningAtWalmart.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WinningAtWalmart
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudApi : ControllerBase
    {
        // GET: api/<CrudApi>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CrudApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CrudApi>
        [HttpPost]
        public void Post([FromBody] Worker worker)
        {
            DataBase db = new DataBase();
            string status=db.Create(worker);
            return JsonResult(worker);
            /*return Json(worker, new Newtonsoft.Json.JsonSerializerSettings());*/
            
            
        }

        // PUT api/<CrudApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CrudApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
