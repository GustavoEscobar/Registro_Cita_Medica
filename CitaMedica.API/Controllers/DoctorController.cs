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
    public class DoctorController : ApiController
    {
        GenericApiResponse GenericReponse = new GenericApiResponse();

        [HttpPost]
        [Route("Doctor")]
        public HttpResponseMessage Post(HttpRequestMessage request, [FromBody] DoctorRequest data)
        {
            DoctorBL doctorBl = new DoctorBL();

            DoctorEN doctor = new DoctorEN();
            doctor.Nombre = data.Nombre;
            doctor.Apellido = data.Apellido;
            doctor.EspecialidadID = data.EspecialidadID;
            doctor.Estado = data.Estado;

            var result = doctorBl.InsertDoctor(doctor);

            GenericReponse.HttpCode = 200;
            GenericReponse.Message = "Success";

            return Request.CreateResponse<IResponse>(HttpStatusCode.BadRequest, GenericReponse);
        }

        [HttpPut]
        [Route("Doctor")]
        public HttpResponseMessage Put(HttpRequestMessage request, [FromBody] DoctorRequest data)
        {
            DoctorBL doctorBl = new DoctorBL();

            DoctorEN doctor = new DoctorEN();
            doctor.DoctorID = data.DoctorID;
            doctor.Nombre = data.Nombre;
            doctor.Apellido = data.Apellido;
            doctor.EspecialidadID = data.EspecialidadID;
            doctor.Estado = data.Estado;

            var result = doctorBl.UpdateDoctor(doctor);

            GenericReponse.HttpCode = 200;
            GenericReponse.Message = "Success";

            return Request.CreateResponse<IResponse>(HttpStatusCode.BadRequest, GenericReponse);
        }

        [HttpDelete]
        [Route("Doctor")]
        public HttpResponseMessage Delete(HttpRequestMessage request, [FromBody] DoctorRequest data)
        {
            DoctorBL doctorBl = new DoctorBL();

            var result = doctorBl.DeleteDoctor(data.DoctorID);

            GenericReponse.HttpCode = 200;
            GenericReponse.Message = "Success";

            return Request.CreateResponse<IResponse>(HttpStatusCode.BadRequest, GenericReponse);
        }
    }
}
