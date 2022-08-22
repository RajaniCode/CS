using MongoDB.Driver;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PatientData.Controllers
{
    // Another way is to enable CORS on WebApiConfig
    [EnableCors("*", "*", "GET")]
    [Authorize]
    public class PatientsController : ApiController
    {
        // Obsolete
        // MongoCollection<Patient> _patients;
        IMongoCollection<Patient> _patients;

        public PatientsController()
        {
            _patients = PatientDb.Open();
        }

        public IEnumerable<Patient> Get()
        {
            // Obsolete
            // return _patients.FindAll();
            return _patients.Find(_ => true).ToList();
        }

        /*
        public HttpResponseMessage Get(string id)
        {
            // Obsolete
            // var patient = _patients.FindOneById(ObjectId.Parse(id)); // using MongoDB.Bson;
            var patient = _patients.Find(_ => _.Id == id).FirstOrDefault();

            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found!");
            }

            return Request.CreateResponse(patient);
        }

        [Route("api/patients/{id}/medications")]
        public HttpResponseMessage GetMedications(string id)
        {
            // Obsolete
            // var patient = _patients.FindOneById(ObjectId.Parse(id)); // using MongoDB.Bson;
            var patient = _patients.Find(_ => _.Id == id).FirstOrDefault();

            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found!");
            }

            return Request.CreateResponse(patient.Medications);
        }
        */

        public IHttpActionResult Get(string id)
        {
            // Obsolete
            // var patient = _patients.FindOneById(ObjectId.Parse(id)); // using MongoDB.Bson;
            var patient = _patients.Find(_ => _.Id == id).FirstOrDefault();

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [Route("api/patients/{id}/medications")]
        public IHttpActionResult GetMedications(string id)
        {
            // Obsolete
            // var patient = _patients.FindOneById(ObjectId.Parse(id)); // using MongoDB.Bson;
            var patient = _patients.Find(_ => _.Id == id).FirstOrDefault();

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient.Medications);
        }

    }
}
