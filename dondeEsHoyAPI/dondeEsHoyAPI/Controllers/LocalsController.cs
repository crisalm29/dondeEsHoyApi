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
    public class LocalsController : ApiController
    {
        // POST: api/Locals/addEstablishment
        [Route("Locals/addLocal")]
        public HttpResponseMessage addLocal(addNewLocalModel model)
        {
            LocalsBusinessLayer businessObject = new LocalsBusinessLayer();
            bool result = false;
            int resultCode = 0;
            string message;
            try
            {
                businessObject.addNewLocal(model.establishment, model.google_key, model.zone, model.telefono);
                result = true;
                message = "Se ha registrado el local correctamente.";
                resultCode = 1;
            }
            catch (DbUpdateException ex)
            {
                message = (ex.HResult == -2146233087) ? "Ya existe un local con ese id." : "Ha ocurrido un error al guardar el local. Error code:" + ex.HResult;
                resultCode = -1;
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                message = "Error desconocido al crear el local.";
                resultCode = -2;
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { message = message, result = result, resultCode = resultCode });
        }

        // POST: api/Locals/infoById
        [Route("Locals/infoById")]
        public HttpResponseMessage infoById(InfoByIdLocalModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            LocalsBusinessLayer businessObject = new LocalsBusinessLayer();
            locals local = businessObject.localInfoById(model.id);
            var result = new { valido = valido, message = message };
            if (local != null)
            {
                valido = true;
                message = "Se obtuvo la info.";
                var result2 = new { valido = valido, message = message, result = local };
                return Request.CreateResponse(HttpStatusCode.OK, result2);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Locals/infoByGoogleKey
        [Route("Locals/infoByGoogleKey")]
        public HttpResponseMessage infoByGoogleKey(InfoByGoogleKeyLocalModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            LocalsBusinessLayer businessObject = new LocalsBusinessLayer();
            locals local = businessObject.localInfoByGoogleKey(model.google_key);
            var result = new { valido = valido, message = message };
            if (local != null)
            {
                valido = true;
                message = "Se obtuvo la info.";
                var result2 = new { valido = valido, message = message, result = local };
                return Request.CreateResponse(HttpStatusCode.OK, result2);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Locals/infoByEstablishment
        [Route("Locals/infoByEstablishment")]
        public HttpResponseMessage infoByEstablishment(InfoByEstablishmentLocalsModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            LocalsBusinessLayer businessObject = new LocalsBusinessLayer();
            List<locals> promosEvents = businessObject.localsInfoByEstablishment(model.establishment);
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

        // POST: api/Locals/infoByZone
        [Route("Locals/infoByZone")]
        public HttpResponseMessage infoByZone(InfoByZoneLocalsModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            LocalsBusinessLayer businessObject = new LocalsBusinessLayer();
            List<locals> promosEvents = businessObject.localsInfoByZone(model.zone);
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

        // POST: api/Locals/modifyLocal
        [Route("Locals/modifyLocal")]
        public HttpResponseMessage modifyLocal(ModifyLocalModel model)
        {
            LocalsBusinessLayer businessObject = new LocalsBusinessLayer();
            bool result = false;
            int resultCode = 0;
            string message;
            try
            {
                businessObject.modifyLocal(model.establishment, model.google_key, model.zone, model.telefono);
                result = true;
                message = "Se ha actualizar el local correctamente.";
                resultCode = 1;
            }
            catch (DbUpdateException ex)
            {
                message = (ex.HResult == -2146233087) ? "No se pudo actualizar." : "Ha ocurrido un error al guardar el local. Error code:" + ex.HResult;
                resultCode = -1;
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                message = "Error desconocido al actualizar el local.";
                resultCode = -2;
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { message = message, result = result, resultCode = resultCode });
        }

        // POST: api/Locals/removeLocal
        [Route("Locals/removeLocal")]
        public HttpResponseMessage removeLocal(DeleteLocalModel model)
        {
            LocalsBusinessLayer businessObject = new LocalsBusinessLayer();
            bool result = false;
            int resultCode = 0;
            string message;
            try
            {
                businessObject.deleteLocal(model.id);
                result = true;
                message = "Se ha eliminado el local correctamente.";
                resultCode = 1;
            }
            catch (DbUpdateException ex)
            {
                message = (ex.HResult == -2146233087) ? "No se pudo eliminar." : "Ha ocurrido un error al eliminar el local. Error code:" + ex.HResult;
                resultCode = -1;
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                message = "Error desconocido al eliminar el local.";
                resultCode = -2;
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { message = message, result = result, resultCode = resultCode });
        }

        // GET: api/Locals
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Locals/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Locals
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Locals/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Locals/5
        public void Delete(int id)
        {
        }
    }
}