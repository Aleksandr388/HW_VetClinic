using System.Collections.Generic;
using VeterenaryClinic.Data.Models;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Data;
using VeterenaryClinic.Data.Interfaces;

namespace VeterenaryClinic.Data.Repositories 
{
    public class VeterenaryClinicRepository : IVeterenaryClinicReposytory
    {
        private readonly string _connectionString;

        private readonly List<VetClinic> VetClinics = new List<VetClinic>();

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

                    VetClinics.Add(veterenaryClinics);
                }
                reader.Close();

            }
            return VetClinics;
        }

        public VetClinic GetById(int id)
        {
            return VetClinics.FirstOrDefault(x => x.Id == id);
        }
    }
}
