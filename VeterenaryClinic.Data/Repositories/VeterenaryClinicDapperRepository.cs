using System.Collections.Generic;
using System.Data.SqlClient;
using VeterenaryClinic.Data.Interfaces;
using VeterenaryClinic.Data.Models;
using Dapper;
using System.CodeDom;
using System.Data;
using System;
using System.Linq;

namespace VeterenaryClinic.Data.Repositories
{
    public class VeterenaryClinicDapperRepository : IVeterenaryClinicReposytory
    {
        private readonly string _connectionString;
        public IEnumerable<VetClinics> VetClinics { get; set; }

        public VeterenaryClinicDapperRepository()
        {
            _connectionString = "Data Source=.;Initial Catalog = VetClinicDataBase; Integrated Security = true";
        }

        public VetClinics Create(VetClinics model)
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

        public IEnumerable<VetClinics> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                VetClinics = connection.Query<VetClinics>("SELECT * FROM VetClinics");

                return VetClinics;
            }
            
        }
        public VetClinics GetById(int id)
        {
            return VetClinics.FirstOrDefault(x => x.Id == id);
        }
    }
}
