using MongoDB.Driver;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientData.Controllers
{
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
    }
}
