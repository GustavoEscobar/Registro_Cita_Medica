using CitaMedica.API.Models;
using CitaMedica.BL;
using CitaMedica.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CitaMedica.API.Controllers
{
    public class EspecialidadController : ApiController
    {
        GenericApiResponse GenericReponse = new GenericApiResponse();

        [HttpPost]
        [Route("Especialidad")]
        public HttpResponseMessage Post(HttpRequestMessage request, [FromBody] EspecialidadRequest data)
        {
            EspecialidadBL especialidadBl = new EspecialidadBL();

            EspecialidadEN especialidad = new EspecialidadEN();
            especialidad.Nombre = data.Nombre;

            var result = especialidadBl.InsertEspecialidad(especialidad);

            GenericReponse.HttpCode = 200;
            GenericReponse.Message = "Success";

            return Request.CreateResponse<IResponse>(HttpStatusCode.BadRequest, GenericReponse);
        }

        [HttpPut]
        [Route("Especialidad")]
        public HttpResponseMessage Put(HttpRequestMessage request, [FromBody] EspecialidadRequest data)
        {
            EspecialidadBL especialidadBl = new EspecialidadBL();

            EspecialidadEN especialidad = new EspecialidadEN();
            especialidad.EspecialidadID = data.EspecialidadID;
            especialidad.Nombre = data.Nombre;

            var result = especialidadBl.UpdateEspecialidad(especialidad);

            GenericReponse.HttpCode = 200;
            GenericReponse.Message = "Success";

            return Request.CreateResponse<IResponse>(HttpStatusCode.BadRequest, GenericReponse);
        }

        [HttpDelete]
        [Route("Especialidad")]
        public HttpResponseMessage Delete(HttpRequestMessage request, [FromBody] EspecialidadRequest data)
        {
            EspecialidadBL especialidadBl = new EspecialidadBL();
            var result = especialidadBl.DeleteEspecialidad(data.EspecialidadID);

            GenericReponse.HttpCode = 200;
            GenericReponse.Message = "Success";

            return Request.CreateResponse<IResponse>(HttpStatusCode.BadRequest, GenericReponse);
        }
    }
}
