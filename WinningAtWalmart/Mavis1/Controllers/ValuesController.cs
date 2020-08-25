using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mavis1.Models;
using Mavis1.DataLayer;
using Newtonsoft.Json;

namespace Mavis1.Controllers
{
    public class ValuesController : ApiController
    {
        DataBase db = new DataBase();
        // GET api/values
        public List<string> Get()
        {
            List<string> workers = new List<string>();
            List<Worker> _ = db.RetrieveAll();
            foreach (Worker w in _)
            {
                workers.Add(JsonConvert.SerializeObject(w));
            }
            return workers;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
