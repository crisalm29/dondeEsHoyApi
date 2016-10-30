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
        
        // POST: api/PromosEvents/addNewPromoEvent
        [Route("PromosEvents/addNewPromoEvent")]
        public HttpResponseMessage addNewPromoEvent(RegisterPromosEventsModel model)
        {
            PromosEventsBusinessLayer businessObject = new PromosEventsBusinessLayer();
            bool result = false;
            int resultCode = 0;
            string message;
            try
            {
                businessObject.addNewPromoEvent(model.name, model.local, model.start_date, model.due_date, model.description, model.imagebase64, model.is_general);
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

        // POST: api/PromosEvents/InfoById
        [Route("PromosEvents/InfoById")]
        public HttpResponseMessage InfoById(InfoByIdPromosEventsModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            PromosEventsBusinessLayer businessObject = new PromosEventsBusinessLayer();
            promos_events promosEvents = businessObject.promoEventInfoById(model.id);
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

        // POST: api/PromosEvents/InfoByLocal
        [Route("PromosEvents/InfoByLocal")]
        public HttpResponseMessage InfoByLocal(InfoByLocalPromosEventsModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            PromosEventsBusinessLayer businessObject = new PromosEventsBusinessLayer();
            List<promos_events> promosEvents = businessObject.promoEventInfoByLocal(model.local);
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

        // POST: api/PromosEvents/generalPromosEvents
        [Route("PromosEvents/generalPromosEvents")]
        public HttpResponseMessage generalPromosEvents()
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            PromosEventsBusinessLayer businessObject = new PromosEventsBusinessLayer();
            List<promos_events> promosEvents = businessObject.generalPromosEvents();
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

        // POST: api/PromosEvents/promosEventsToday
        [Route("PromosEvents/promosEventsToday")]
        public HttpResponseMessage promoEventsToday()
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            PromosEventsBusinessLayer businessObject = new PromosEventsBusinessLayer();
            IEnumerable<dynamic> promosEvents = businessObject.promosEventsToday();
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

        // POST: api/PromosEvents/promosEventsThisWeek
        [Route("PromosEvents/promosEventsThisWeek")]
        public HttpResponseMessage promosEventsThisWeek()
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            PromosEventsBusinessLayer businessObject = new PromosEventsBusinessLayer();
            IEnumerable<dynamic> promosEvents = businessObject.promosEventsThisWeek();
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

        // POST: api/PromosEvents/promosEventsThisMoth
        [Route("PromosEvents/promosEventsThisMoth")]
        public HttpResponseMessage promosEventsThisMoth()
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            PromosEventsBusinessLayer businessObject = new PromosEventsBusinessLayer();
            IEnumerable<dynamic> promosEvents = businessObject.promosEventsThisMoth();
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

        // POST: api/PromosEvents/promosEventsThisMothByEstablishment
        [Route("PromosEvents/promosEventsThisMothByEstablishment")]
        public HttpResponseMessage promosEventsThisMothByEstablishment(PromosEventsThisMothByEstablishment model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            PromosEventsBusinessLayer businessObject = new PromosEventsBusinessLayer();
            IEnumerable<dynamic> promosEvents = businessObject.promosEventsThisMothByEstablishment(model.establishment);
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

        // POST: api/PromosEvents/validPromosEventsByEstablishment
        [Route("PromosEvents/validPromosEventsByEstablishment")]
        public HttpResponseMessage promosEventsThisMothByEstablishment(ValidPromosEventsByEstablishment model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            PromosEventsBusinessLayer businessObject = new PromosEventsBusinessLayer();
            IEnumerable<dynamic> promosEvents = businessObject.validPromosEventsByEstablishment(model.establishment);
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

        // POST: api/PromosEvents/modifyPromoEvent
        [Route("PromosEvents/modifyPromoEvent")]
        public HttpResponseMessage modifyPromoEvent(ModifyPromosEventsModel model)
        {
            PromosEventsBusinessLayer businessObject = new PromosEventsBusinessLayer();
            bool result = false;
            int resultCode = 0;
            string message;
            try
            {
                businessObject.modifyPromoEvent(model.name,model.local,model.start_date,model.due_date,model.description,model.imagebase64,model.is_general);
                result = true;
                message = "Se ha actualizar el promo correctamente.";
                resultCode = 1;
            }
            catch (DbUpdateException ex)
            {
                message = (ex.HResult == -2146233087) ? "No se pudo actualizar." : "Ha ocurrido un error al guardar el promo. Error code:" + ex.HResult;
                resultCode = -1;
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                message = "Error desconocido al actualizar el promo.";
                resultCode = -2;
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { message = message, result = result, resultCode = resultCode });
        }

        // POST: api/PromosEvents/removePromoEvent
        [Route("PromosEvents/removePromoEvent")]
        public HttpResponseMessage removePromoEvent(DeletePromosEventsModel model)
        {
            PromosEventsBusinessLayer businessObject = new PromosEventsBusinessLayer();
            bool result = false;
            int resultCode = 0;
            string message;
            try
            {
                businessObject.deletePromoEvent(model.id);
                result = true;
                message = "Se ha eliminado el promo correctamente.";
                resultCode = 1;
            }
            catch (DbUpdateException ex)
            {
                message = (ex.HResult == -2146233087) ? "No se pudo eliminar." : "Ha ocurrido un error al eliminar el promo. Error code:" + ex.HResult;
                resultCode = -1;
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                message = "Error desconocido al eliminar el promo.";
                resultCode = -2;
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { message = message, result = result, resultCode = resultCode });
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