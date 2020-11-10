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
        public IEnumerable<VetClinic> VetClinics { get; set; }

        public VeterenaryClinicDapperRepository()
        {
            _connectionString = "Data Source=.;Initial Catalog = VetClinicDataBase; Integrated Security = true";
        }

        public VetClinic Create(VetClinic model)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO VetClinics(FullNameOwner,Date,TypeTreatment) OUTPUT Inserted.Id " +
                    $"VALUES(\'{model.FullNameOwner}\',\'{model.Date.ToString("s")}\',\'{model.TypeTreatment}\')";

                var insertedId = Convert.ToInt32(command.ExecuteScalar());

                model.Id = insertedId;

                return model;
            }
        }

        public IEnumerable<VetClinic> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                VetClinics = connection.Query<VetClinic>("SELECT * FROM VetClinics");

                return VetClinics;
            }
        }

        public VetClinic GetByDateTime(DateTime date)
        {
            return VetClinics.FirstOrDefault(x => x.Date.CompareTo(date) == 0);
        }


        public VetClinic GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Query<VetClinic>("SELECT * FROM VetClinics WHERE Id=@Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}
