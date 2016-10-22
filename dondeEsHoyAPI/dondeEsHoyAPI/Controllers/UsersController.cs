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
    public class UsersController : ApiController
    {
        // POST: api/Users/login
        [Route("Users/login")]
        public HttpResponseMessage login(LoginUserModel model)
        {
            UsersBusinessLayer businessObject = new UsersBusinessLayer();
            bool result = businessObject.login(model.email,model.password);
            string message = (result) ? "Se ha iniciado sesion correctamente." : "Usuario o contraseña invalido.";

            return Request.CreateResponse(HttpStatusCode.OK, new { message = message, result = result } );
        }


        // POST: api/Users/addUser
        [Route("Users/addUser")]
        public HttpResponseMessage AddUser(RegisterUserModel model)
        {
            UsersBusinessLayer businessObject = new UsersBusinessLayer();
            bool result = false;
            int resultCode = 0;
            string message;
            try {
                businessObject.registerUser(model.email, model.password, model.name, model.lastName, model.imagebase64);
                result = true;
                message = "Se ha registrado el usuario correctamente.";
                resultCode = 1;
            } catch (DbUpdateException ex)
            {
                message = (ex.HResult == -2146233087) ? "Ya existe un usario con ese correo electronico." : "Ha ocurrido un error al guardar el usuario. Error code:" + ex.HResult;
                resultCode = -1;
                Console.WriteLine(ex);
            } catch (Exception)
            {
                message = "Error desconocido al crear el usuario.";
                resultCode = -2;
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { message = message, result = result , resultCode = resultCode });
        }

        // POST: api/Users/infoById
        [Route("Users/infoById")]
        public HttpResponseMessage infoById(InfoByIdUserModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            UsersBusinessLayer businessObject = new UsersBusinessLayer();
            users user = businessObject.userInfoById(model.id);
            var result = new { valido= valido,message= message};
            if (user != null)
            {
                valido = true;
                message = "Se obtuvo la info.";
                var result2 = new { valido=valido, message=message, result= user};
                return Request.CreateResponse(HttpStatusCode.OK, result2);
            }
            
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Users/infoByEmail
        [Route("Users/infoByEmail")]
        public HttpResponseMessage infoByEmail(InfoByEmailUserModel model)
        {
            bool valido = false;
            string message = "No se obtuvo la info.";
            UsersBusinessLayer businessObject = new UsersBusinessLayer();
            users user = businessObject.userInfoByEmail(model.email);
            var result = new { valido = valido, message = message };
            if (user != null)
            {
                valido = true;
                message = "Se obtuvo la info.";
                var result2 = new { valido = valido, message = message, result = user };
                return Request.CreateResponse(HttpStatusCode.OK, result2);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Users/modifyUser
        [Route("Users/modifyUser")]
        public HttpResponseMessage modifyUser(ModifyUserModel model)
        {
            UsersBusinessLayer businessObject = new UsersBusinessLayer();
            bool result = false;
            int resultCode = 0;
            string message;
            try
            {
                businessObject.modifyUser(model.id, model.email, model.password, model.name, model.lastName, model.imagebase64);
                result = true;
                message = "Se ha actualizar el usuario correctamente.";
                resultCode = 1;
            }
            catch (DbUpdateException ex)
            {
                message = (ex.HResult == -2146233087) ? "No se pudo actualizar." : "Ha ocurrido un error al guardar el usuario. Error code:" + ex.HResult;
                resultCode = -1;
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                message = "Error desconocido al actualizar el usuario.";
                resultCode = -2;
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { message = message, result = result, resultCode = resultCode });
        }

        // POST: api/Users/ddeleteUser
        [Route("Users/ddeleteUser")]
        public HttpResponseMessage ddeleteUser(DeleteUserModel model)
        {
            UsersBusinessLayer businessObject = new UsersBusinessLayer();
            bool result = false;
            int resultCode = 0;
            string message;
            try
            {
                businessObject.deleteUser(model.id);
                result = true;
                message = "Se ha eliminado el usuario correctamente.";
                resultCode = 1;
            }
            catch (DbUpdateException ex)
            {
                message = (ex.HResult == -2146233087) ? "No se pudo eliminar." : "Ha ocurrido un error al elimianr el usuario. Error code:" + ex.HResult;
                resultCode = -1;
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
                message = "Error desconocido al eliminar el usuario.";
                resultCode = -2;
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { message = message, result = result, resultCode = resultCode });
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
        [HttpDelete]
        public void Delete(int id)
        {
            UsersBusinessLayer businessObject = new UsersBusinessLayer();
            try
            {
                businessObject.deleteUser(id);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception)
            {
            }
        }
    }
}
