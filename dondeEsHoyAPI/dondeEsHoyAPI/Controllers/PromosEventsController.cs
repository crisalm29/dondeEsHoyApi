using BusinessLayer.BusinessLogic;
using dondeEsHoyAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Entities;

namespace dondeEsHoyAPI.Controllers
{
    public class PromosEventsController : ApiController
    {

        // POST: api/PromosEvents/promosEventsToday
        [Route("PromosEvents/promosEventsToday")]
        public HttpResponseMessage promoEventsToday()
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            PromosEventsBusinessLayer businessObject = new PromosEventsBusinessLayer();
            dynamic[] promosEvents = businessObject.promosEventsToday();
            var result = new { valido = valido, message = message };
            if (promosEvents != null)
            {
                valido = true;
                message = "Se obtuvo la info.";
                var result2 = new { valido = valido, message = message, result= promosEvents };
                return Request.CreateResponse(HttpStatusCode.OK, result2);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/PromosEvents/promosEventsThisMoth
        [Route("PromosEvents/promosEventsThisMoth")]
        public HttpResponseMessage promosEventsThisMoth()
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            PromosEventsBusinessLayer businessObject = new PromosEventsBusinessLayer();
            dynamic[] promosEvents = businessObject.promosEventsThisMoth();
            var result = new { valido = valido, message = message };
            if (promosEvents != null)
            {
                valido = true;
                message = "Se obtuvo la info.";
                var result2 = new { valido = valido, message = message, result = promosEvents };
                return Request.CreateResponse(HttpStatusCode.OK, result2);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/PromosEvents/promosEventsByEstablishment
        [Route("PromosEvents/promosEventsByEstablishment")]
        public HttpResponseMessage promosEventsByEstablishment(PromosEventsByEstablishmentPromosEventsModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            PromosEventsBusinessLayer businessObject = new PromosEventsBusinessLayer();
            dynamic[] promosEvents = businessObject.promosEventsByEstablishment(model.establishment);
            var result = new { valido = valido, message = message };
            if (promosEvents != null)
            {
                valido = true;
                message = "Se obtuvo la info.";
                var result2 = new { valido = valido, message = message, result = promosEvents };
                return Request.CreateResponse(HttpStatusCode.OK, result2);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/PromosEvents
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PromosEvents/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PromosEvents
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PromosEvents/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PromosEvents/5
        public void Delete(int id)
        {
        }
    }
}