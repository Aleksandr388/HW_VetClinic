using System.Collections.Generic;
using VeterenaryClinic.Data.Models;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Data;
using VeterenaryClinic.Data.Interfaces;
using System.Security.Cryptography.X509Certificates;
using System.Data.Entity.Infrastructure;

namespace VeterenaryClinic.Data.Repositories 
{
    public class VeterenaryClinicRepository : IVeterenaryClinicReposytory
    {
        private readonly string _connectionString;

        List<VetClinic> result = new List<VetClinic>();

        public VeterenaryClinicRepository()
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
                command.CommandText = "INSERT INTO VetClinics(Phone,FullNameOwner,Date,TypeTreatment,Breed) OUTPUT Inserted.Id " +
                    $"VALUES(\'{model.FullNameOwner}\',\'{model.Date.ToString("s")}\',\'{model.TypeTreatment}\')";

                var insertedId = Convert.ToInt32(command.ExecuteScalar());

                model.Id = insertedId;

                return model;
            }
        }

        public IEnumerable<VetClinic> GetAll()
        {
            List<VetClinic> result = new List<VetClinic>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM VetClinics";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var veterenaryClinics = new VetClinic();

                    veterenaryClinics.Id = reader.GetInt32(0);
                    veterenaryClinics.FullNameOwner = reader.GetString(2);
                    veterenaryClinics.Date = (DateTime)reader["Date"];
                    veterenaryClinics.TypeTreatment = reader.GetString(4);

                    result.Add(veterenaryClinics);
                }
                reader.Close();

            }
            return result;
        }

        public VetClinic GetByDateTime(DateTime date)
        {
            throw new NotImplementedException();
        }

        public VetClinic GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM VetClinics WHERE VetClinics.Id == id";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var veterenaryClinics = new VetClinic();

                    veterenaryClinics.Id = reader.GetInt32(0);
                    veterenaryClinics.FullNameOwner = reader.GetString(2);
                    veterenaryClinics.Date = (DateTime)reader["Date"];
                    veterenaryClinics.TypeTreatment = reader.GetString(4);

                    result.Add(veterenaryClinics);
                }
                reader.Close();

            }
            return result.FirstOrDefault(x => x.Id == id);
        }

        public VetClinic GetByName(string fullName)
        {
            throw new NotImplementedException();
        }
    }
}
