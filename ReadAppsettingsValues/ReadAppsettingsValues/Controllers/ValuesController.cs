using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace ReadAppsettingsValues.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class valuesController : Controller
    {
        //public IConfiguration config;
        private  IOptions<POCO> appSettings;
       //HttpContext Context;
        public valuesController(IOptions<POCO> app)
        {
            appSettings = app;
           


        }
        public void Requestdata(HttpContext Context)
        {
            var request = Context.Request;
            var response = Context.Response;
            var requestHeaders = request.Headers;
           // Dictionary<string, IEnumerable<string>> ss= requestHeaders.ToDictionary(a => a.Key, a => a.Value);
           //var dicitionari = requestHeaders.ToDictionary<string, string>(a => a.Key, a => a.Value);
           // Console.WriteLine(typeof(requestHeaders));

            
        }
        //GET api/values
        
        [HttpGet]
        public ActionResult Get()
        {
            Requestdata(this.HttpContext);
          

            var dbValue = appSettings.Value.DbConnection;
            var list = new List<string>();
            list.Add("santhosh");
            list.Add("Manda");
            list.Add(dbValue);
            return Ok(list);
            // return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
