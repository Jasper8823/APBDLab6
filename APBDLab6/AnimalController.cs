using System.Data.SqlClient;

namespace APBDLab6;

using System;
using System.Collections.Generic;

public class AnimalController
{
    private readonly string _connectionString;

    public AnimalController(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Animal> GetAllAnimals()
    {
        List<Animal> animals = new List<Animal>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM animal";
            SqlCommand command = new SqlCommand(query, connection);
            Console.Write(3);
            connection.Open();
            Console.Write(5);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Animal animal = new Animal
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    name = reader["name"].ToString(),
                    category = reader["category"].ToString(),
                    weight = Convert.ToInt32(reader["weight"])
                };
                animals.Add(animal);
            }
        }
        return animals;
    }

    public void AddAnimal(Animal animal)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO animal (name, category, weight) VALUES (@name, @category, @weight)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", animal.name);
            command.Parameters.AddWithValue("@category", animal.category);
            command.Parameters.AddWithValue("@weight", animal.weight);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void UpdateAnimal(int id, Animal animal)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE animal SET name = @name, category = @category, weight = @weight WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", animal.name);
            command.Parameters.AddWithValue("@Category", animal.category);
            command.Parameters.AddWithValue("@weight", animal.weight);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void DeleteAnimal(int id)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "DELETE FROM animal WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}