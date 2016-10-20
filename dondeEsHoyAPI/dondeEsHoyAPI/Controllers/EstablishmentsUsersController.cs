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
    public class EstablishmentsUsersController : ApiController
    {
        // POST: api/EstablishmentsUsers/addEstablishmentUser
        [Route("EstablishmentsUsers/addEstablishmentUser")]
        public HttpResponseMessage addEstablishmentUser(RegisterEstablishmentsUsersModel model)
        {
            EstablishmentsUsersBusinessLayer businessObject = new EstablishmentsUsersBusinessLayer();
            bool result = false;
            int resultCode = 0;
            string message;
            try
            {
                businessObject.registerEstablishmentsUsers(model.establishment, model.establishment_account);
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

        // POST: api/EstablishmentsUsers/infoById
        [Route("EstablishmentsUsers/infoById")]
        public HttpResponseMessage infoById(InfoByIdEstablishmentsUsersModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            EstablishmentsUsersBusinessLayer businessObject = new EstablishmentsUsersBusinessLayer();
            establishments_users establishment_user = businessObject.establishmentsUsersInfoById(model.id);
            var result = new { valido = valido, message = message };
            if (establishment_user != null)
            {
                valido = true;
                message = "Se obtuvo la info.";
                var result2 = new { valido = valido, message = message, result = establishment_user };
                return Request.CreateResponse(HttpStatusCode.OK, result2);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/EstablishmentsUsers/infoByEstablishmentAccount
        [Route("EstablishmentsUsers/infoByEstablishmentAccount")]
        public HttpResponseMessage infoByEstablishmentAccount(InfoByEstablishmentAccountEstablishmentsUsersModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            EstablishmentsUsersBusinessLayer businessObject = new EstablishmentsUsersBusinessLayer();
            establishments_users establishment_user = businessObject.establishmentsUsersInfoByEstablishmentAccount(model.establishment_account);
            var result = new { valido = valido, message = message };
            if (establishment_user != null)
            {
                valido = true;
                message = "Se obtuvo la info.";
                var result2 = new { valido = valido, message = message, result = establishment_user };
                return Request.CreateResponse(HttpStatusCode.OK, result2);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }



        // POST: api/EstablishmentsUsers/allEstablishmentsUsersInfoByEstablishment
        [Route("EstablishmentsUsers/allEstablishmentsUsersInfoByEstablishment")]
        public HttpResponseMessage allEstablishmentsUsersInfoByEstablishment(allEstablishmentsUsersInfoByEstablishmentModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            EstablishmentsUsersBusinessLayer businessObject = new EstablishmentsUsersBusinessLayer();
            List<establishments_users> establishments = businessObject.allEstablishmentsUsersInfoByEstablishment(model.establishment);
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

        // GET: api/EstablishmentsUsers
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EstablishmentsUsers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EstablishmentsUsers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EstablishmentsUsers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EstablishmentsUsers/5
        public void Delete(int id)
        {
        }
    }
}