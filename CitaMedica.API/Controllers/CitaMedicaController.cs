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
    public class CitaMedicaController : ApiController
    {
        GenericApiResponse GenericReponse = new GenericApiResponse();

        [HttpPost]
        [Route("CitaMedica")]
        public HttpResponseMessage Post(HttpRequestMessage request, [FromBody] CitaMedicaRequest data)
        {
            CitaMedicaBL CitaMedicaBl = new CitaMedicaBL();

            CitaMedicaEN citaMedica = new CitaMedicaEN();
            citaMedica.DoctorID = data.DoctorID;
            citaMedica.PacienteID = data.PacienteID;
            citaMedica.EstadoCitaMedicaID = data.EstadoCitaMedicaID;
            citaMedica.FechaCita = data.FechaCita;
            citaMedica.FechaRegistro = DateTime.Now;
            citaMedica.Referencia = data.Referencia;

            var result = CitaMedicaBl.InsertCitaMedica(citaMedica);

            GenericReponse.HttpCode = 200;
            GenericReponse.Message = "Success";

            return Request.CreateResponse<IResponse>(HttpStatusCode.BadRequest, GenericReponse);
        }
    }
}
