using dondeEsHoyAPI.Models;
using googlePlacesClient.GooglePlaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dondeEsHoyAPI.Controllers
{
    public class GooglePlacesController : ApiController
    {
        [Route("googlePlaces")]
        public HttpResponseMessage login(LatLngModel model)
        {
            GoogleClient client = new GoogleClient();

            List<JToken> result = client.obtenerLocales(model.lat, model.lng);
            
            return Request.CreateResponse(HttpStatusCode.OK, new { message = "success", result = result });
        }
    }
}
