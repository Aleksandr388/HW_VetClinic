using System.Collections.Generic;
using System.Data.SqlClient;
using VeterenaryClinic.Data.Interfaces;
using VeterenaryClinic.Data.Models;
using Dapper;
using System.CodeDom;
using System.Data;
using System;

namespace VeterenaryClinic.Data.Repositories
{
    public class VeterenaryClinicDapperRepository : IVeterenaryClinicReposytory
    {
        private readonly string _connectionString;

        public VeterenaryClinicDapperRepository()
        {
            _connectionString = "Data Source=.;Initial Catalog = VetClinicDataBase; Integrated Security = true";
        }

        public VeterenaryClinics Create(VeterenaryClinics model)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO VetClinics(Phone,FullNameOwner,Date,TypeTreatment,Breed) OUTPUT Inserted.Id " +
                    $"VALUES(\'{model.Phone}\',\'{model.FullNameOwner}\',\'{model.Date.ToString("s")}\',\'{model.TypeTreatment}\',\'{model.Breed}\')";

                var insertedId = Convert.ToInt32(command.ExecuteScalar());

                model.Id = insertedId;

                return model;
            }
        }

        public IEnumerable<VeterenaryClinics> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Query<VeterenaryClinics>("SELECT * FROM VetClinics");
            }
            
        }
        public IEnumerable<VeterenaryClinics> GetById()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Query<VeterenaryClinics>("SELECT * FROM VetClinics WHERE VetClinics.id = 1");
            }
        }
    }
}
