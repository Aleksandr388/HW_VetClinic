﻿using System.Collections.Generic;
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

        public VeterenaryClinicRepository()
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
            var result = new List<VeterenaryClinics>();
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
                    var veterenaryClinics = new VeterenaryClinics();

                    veterenaryClinics.Id = reader.GetInt32(0);
                    veterenaryClinics.Phone = reader.GetString(1);
                    veterenaryClinics.FullNameOwner = reader.GetString(2);
                    veterenaryClinics.Date = (DateTime)reader["Date"];
                    veterenaryClinics.TypeTreatment = reader.GetString(4);
                    veterenaryClinics.Breed = reader.GetString(5);

                    result.Add(veterenaryClinics);
                }
                reader.Close();

            }
            return result;
        }

        public IEnumerable<VeterenaryClinics> GetById()
        {
            var result = new List<VeterenaryClinics>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM VetClinics WHERE VetClinics.id = 1";

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var veterenaryClinics = new VeterenaryClinics();

                    veterenaryClinics.Id = reader.GetInt32(0);
                    veterenaryClinics.Phone = reader.GetString(1);
                    veterenaryClinics.FullNameOwner = reader.GetString(2);
                    //veterenaryClinics.Date = reader.GetDateTime(3);

                    veterenaryClinics.Date = (DateTime)reader["Date"];
                    veterenaryClinics.TypeTreatment = reader.GetString(4);
                    veterenaryClinics.Breed = reader.GetString(5);

                    result.Add(veterenaryClinics);
                }
                reader.Close();
            }
            return result;
        }
    }
}
