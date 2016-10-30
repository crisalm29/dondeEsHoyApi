﻿using BusinessLayer.BusinessLogic;
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
    public class EstablishmentsAccountsController : ApiController
    {
        // POST: api/EstablishmentsAccounts/login
        [Route("EstablishmentsAccounts/login")]
        public HttpResponseMessage login(LoginEstablishmentAccountModel model)
        {
            EstablishmentsAccountsBusinessLayer businessObject = new EstablishmentsAccountsBusinessLayer();
            establishments_accounts result = businessObject.login(model.email, model.password);
            string message = (result!=null) ? "Se ha iniciado sesion correctamente." : "Usuario o contraseña invalido.";
            if (result != null) {
                EstablishmentsUsersBusinessLayer aux = new EstablishmentsUsersBusinessLayer();
                establishments_users eu = aux.establishmentsUsersInfoByEstablishmentAccount(result.id);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = message, result = new { login = (result != null), establishment = eu.establishment } });
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { message = message, result = new {login= (result!=null)} });
        }


        // POST: api/EstablishmentsAccounts/addEstablishmentAccount
        [Route("EstablishmentsAccounts/addEstablishmentAccount")]
        public HttpResponseMessage AddEstablishmentAccount(RegisterEstablishmentAccountModel model)
        {
            EstablishmentsAccountsBusinessLayer businessObject = new EstablishmentsAccountsBusinessLayer();
            bool result = false;
            int resultCode = 0;
            string message;
            try
            {
                businessObject.registerEstablishmentAccount( model.email, model.password, model.name, model.lastName, model.imagebase64);
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

        // POST: api/EstablishmentsAccounts/infoById
        [Route("EstablishmentsAccounts/infoById")]
        public HttpResponseMessage infoById(InfoByIdEstablishmentAccountModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            EstablishmentsAccountsBusinessLayer businessObject = new EstablishmentsAccountsBusinessLayer();
            establishments_accounts establishment_account = businessObject.establishmentAccountInfoById(model.id);
            var result = new { valido = valido, message = message };
            if (establishment_account != null)
            {
                valido = true;
                message = "Se obtuvo la info.";
                var result2 = new { valido = valido, message = message, result = establishment_account };
                return Request.CreateResponse(HttpStatusCode.OK, result2);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/EstablishmentsAccounts/infoByEmail
        [Route("EstablishmentsAccounts/infoByEmail")]
        public HttpResponseMessage infoByEmail(InfoByEmailEstablishmentAccountModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            EstablishmentsAccountsBusinessLayer businessObject = new EstablishmentsAccountsBusinessLayer();
            establishments_accounts establishment_account = businessObject.establishmentAccountInfoByEmail(model.email);
            var result = new { valido = valido, message = message };
            if (establishment_account != null)
            {
                valido = true;
                message = "Se obtuvo la info.";
                var result2 = new { valido = valido, message = message, result = establishment_account };
                return Request.CreateResponse(HttpStatusCode.OK, result2);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/EstablishmentsAccounts/modifyEstablishmentAccount
        [Route("EstablishmentsAccounts/modifyEstablishmentAccount")]
        public HttpResponseMessage modifyEstablishmentAccount(ModifyEstablishmentAccountModel model)
        {
            EstablishmentsAccountsBusinessLayer businessObject = new EstablishmentsAccountsBusinessLayer();
            bool result = false;
            int resultCode = 0;
            string message;
            try
            {
                businessObject.modifyEstablishmentAccount(model.email, model.password, model.name, model.imagebase64);
                result = true;
                message = "Se ha actualizar el establishment account correctamente.";
                resultCode = 1;
            }
            catch (DbUpdateException ex)
            {
                message = (ex.HResult == -2146233087) ? "No se pudo actualizar." : "Ha ocurrido un error al guardar el establishment account. Error code:" + ex.HResult;
                resultCode = -1;
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                message = "Error desconocido al actualizar el establishment account.";
                resultCode = -2;
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { message = message, result = result, resultCode = resultCode });
        }

        // POST: api/EstablishmentsAccounts/removeEstablishmentAccount
        [Route("EstablishmentsAccounts/removeEstablishmentAccount")]
        public HttpResponseMessage removeEstablishmentAccount(DeleteEstablishmentAccountModel model)
        {
            EstablishmentsAccountsBusinessLayer businessObject = new EstablishmentsAccountsBusinessLayer();
            bool result = false;
            int resultCode = 0;
            string message;
            try
            {
                businessObject.deleteEstablishmentAccount(model.id);
                result = true;
                message = "Se ha eliminado el establishment account correctamente.";
                resultCode = 1;
            }
            catch (DbUpdateException ex)
            {
                message = (ex.HResult == -2146233087) ? "No se pudo eliminar." : "Ha ocurrido un error al eliminar el establishment account. Error code:" + ex.HResult;
                resultCode = -1;
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                message = "Error desconocido al eliminar el establishment account.";
                resultCode = -2;
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { message = message, result = result, resultCode = resultCode });
        }

        // GET: api/EstablishmentsAccounts
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EstablishmentsAccounts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EstablishmentsAccounts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EstablishmentsAccounts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EstablishmentsAccounts/5
        public void Delete(int id)
        {
        }
    }
}