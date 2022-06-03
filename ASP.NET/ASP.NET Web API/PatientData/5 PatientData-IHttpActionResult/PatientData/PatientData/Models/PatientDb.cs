using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientData.Models
{
    public static class PatientDb
    {
        public static IMongoCollection<Patient> Open()
        {
            var client = new MongoClient(); // "mongodb://localhost:27017"
            var database = client.GetDatabase("PatientDb");
            return database.GetCollection<Patient>("Patients");
        }

        /*
        [Obsolete]
        public static MongoCollection<Patient> Open()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var server = client.GetServer();
            var database = server.GetDatabase("PatientDb");
            return database.GetCollection<Patient>("Patients");
        }
        */
    }
}