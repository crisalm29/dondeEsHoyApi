using BusinessLayer.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Entities;
using dondeEsHoyAPI.Models;

namespace dondeEsHoyAPI.Controllers
{
    public class EstablishmentsController : ApiController
    {
        // POST: api/Establishments/addEstablishment
        [Route("Establishments/addEstablishment")]
        public HttpResponseMessage addEstablishment(RegisterEstablishmentModel model)
        {
            EstablishmentsBusinessLayer businessObject = new EstablishmentsBusinessLayer();
            bool result = false;
            int resultCode = 0;
            string message;
            try
            {
                businessObject.registerEstablishment(model.name, model.establishment_type, model.imagebase64, model.telefono);
                result = true;
                message = "Se ha registrado el usuario correctamente.";
                resultCode = 1;
            }
            catch (DbUpdateException ex)
            {
                message = (ex.HResult == -2146233087) ? "Ya existe un usario con ese correo electronico." : "Ha ocurrido un error al guardar el usuario. Error code:" + ex.HResult;
                resultCode = -1;
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                message = "Error desconocido al crear el usuario.";
                resultCode = -2;
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { message = message, result = result, resultCode = resultCode });
        }

        // POST: api/Establishments/infoById
        [Route("Establishments/infoById")]
        public HttpResponseMessage infoById(InfoByIdUserModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            EstablishmentsBusinessLayer businessObject = new EstablishmentsBusinessLayer();
            establishments establishment = businessObject.establishmentInfoById(model.id);
            var result = new { valido = valido, message = message };
            if (establishment != null)
            {
                valido = true;
                message = "Se obtuvo la info.";
                var result2 = new { valido = valido, message = message, result = establishment };
                return Request.CreateResponse(HttpStatusCode.OK, result2);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Establishments/infoByName
        [Route("Establishments/infoByName")]
        public HttpResponseMessage infoByName(InfoByNameEstablishmentModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            EstablishmentsBusinessLayer businessObject = new EstablishmentsBusinessLayer();
            establishments establishment = businessObject.establishmentInfoByName(model.name);
            var result = new { valido = valido, message = message };
            if (establishment != null)
            {
                valido = true;
                message = "Se obtuvo la info.";
                var result2 = new { valido = valido, message = message, result = establishment };
                return Request.CreateResponse(HttpStatusCode.OK, result2);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Establishments/allEstablishmentsInfo
        [Route("Establishments/allEstablishmentsInfo")]
        public HttpResponseMessage allEstablishmentsInfo()
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            EstablishmentsBusinessLayer businessObject = new EstablishmentsBusinessLayer();
            List<establishments> establishments = businessObject.allEstablishmentsInfo();
            var result = new { valido = valido, message = message };
            if (establishments != null)
            {
                valido = true;
                message = "Se obtuvo la info.";
                var result2 = new { valido = valido, message = message, result = establishments };
                return Request.CreateResponse(HttpStatusCode.OK, result2);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/Establishments
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Establishments/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Establishments
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Establishments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Establishments/5
        public void Delete(int id)
        {
        }
    }
}