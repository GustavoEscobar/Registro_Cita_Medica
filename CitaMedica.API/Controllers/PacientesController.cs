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
    public class PacientesController : ApiController
    {
        GenericApiResponse GenericReponse = new GenericApiResponse();

        [HttpPost]
        [Route("Paciente")]
        public HttpResponseMessage Post(HttpRequestMessage request, [FromBody] PacienteRequest data)
        {
            PacienteBL pacienteBl = new PacienteBL();

            PacienteEN paciente = new PacienteEN();
            paciente.Nombre = data.Nombre;
            paciente.Apellido = data.Apellido;
            paciente.Correo = data.Correo;
            paciente.Edad = data.Edad;
            paciente.FechaRegistro = DateTime.Now;

            var result = pacienteBl.InsertPaciente(paciente);

            GenericReponse.HttpCode = 200;
            GenericReponse.Message = "Success";

            return Request.CreateResponse<IResponse>(HttpStatusCode.BadRequest, GenericReponse);
        }

        [HttpPut]
        [Route("Paciente")]
        public HttpResponseMessage Put(HttpRequestMessage request, [FromBody] PacienteRequest data)
        {
            PacienteBL pacienteBl = new PacienteBL();

            PacienteEN paciente = new PacienteEN();
            paciente.PacienteID = data.PacienteID;
            paciente.Nombre = data.Nombre;
            paciente.Apellido = data.Apellido;
            paciente.Correo = data.Correo;
            paciente.Edad = data.Edad;
            paciente.FechaRegistro = DateTime.Now;
            paciente.DUI = data.DUI;

            var result = pacienteBl.UpdatePaciente(paciente);

            GenericReponse.HttpCode = 200;
            GenericReponse.Message = "Success";

            return Request.CreateResponse<IResponse>(HttpStatusCode.BadRequest, GenericReponse);
        }

        [HttpDelete]
        [Route("Paciente")]
        public HttpResponseMessage Delete(HttpRequestMessage request, [FromBody] PacienteRequest data)
        {
            PacienteBL pacienteBl = new PacienteBL();

            var result = pacienteBl.DeletePaciente(data.PacienteID);

            GenericReponse.HttpCode = 200;
            GenericReponse.Message = "Success";

            return Request.CreateResponse<IResponse>(HttpStatusCode.BadRequest, GenericReponse);
        }
    }
}
