using BusinessLayer.BusinessLogic;
using dondeEsHoyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace dondeEsHoyAPI.Controllers
{
    public class UsersController : ApiController
    {

        // POST: api/Users/login
        [Route("login")]
        public HttpResponseMessage SetPassword(LoginUserModel model)
        {
            UsersBusinessLayer businessObject = new UsersBusinessLayer();
            bool result = businessObject.login(model.email,model.password);


            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Users
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
