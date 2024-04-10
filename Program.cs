using System;
using System.Data.SqlClient;

namespace DynamicSqlConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up the connection string
            string connectionString = "Server=localhost;Database=Soccer;Trusted_Connection=True;";

            Console.Write("---------------------------------------");
            Console.Write("Welcome To Acadia Soccer Club ");
            Console.Write("---------------Type 'quit' at anytime to exit------------------------");
            Console.Write("Search for Players by:\n");
            Console.Write("1.Age\n");
            Console.Write("2.Height\n");
            Console.Write("3.Name\n");

            string commandLine = Console.ReadLine().ToLower();

            while (commandLine.ToLower() != "quit")
            {
                if (commandLine == "1")
                {
                    // Search by Age
                    Console.Write("Enter the age parameter value: ");
                    int age = int.Parse(Console.ReadLine());

                    // Create a connection object
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM dbo.PlayersData WHERE Age = @age ";

                        // Open the connection
                        connection.Open();

                        // Create a command object with the SQL query and parameters
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@age", age);

                            // Execute the query and get a data reader
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                // Loop through the results and display them to the console
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        Console.Write(reader.GetValue(i) + " ");
                                    }
                                    Console.WriteLine();
                                }
                            }
                        }
                        // Close the connection
                        connection.Close();
                    }
                }
                else if (commandLine == "2")
                {
                    // Search by Height
                    Console.Write("Enter the height parameter value: ");
                    float height = float.Parse(Console.ReadLine());

                    // Create a connection object
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM dbo.PlayersData WHERE Height = @height ";

                        // Open the connection
                        connection.Open();

                        // Create a command object with the SQL query and parameters
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@height", height);

                            // Execute the query and get a data reader
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                // Loop through the results and display them to the console
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        Console.Write(reader.GetValue(i) + " ");
                                    }
                                    Console.WriteLine();
                                }
                            }
                        }
                        // Close the connection
                        connection.Close();
                    }
                }
                else if (commandLine == "3")
                {
                    // Search by Name
                    Console.Write("Enter the name parameter value: ");
                    string name = Console.ReadLine();

                    // Create a connection object
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM dbo.PlayersData WHERE Name = @name ";

                        // Open the connection
                        connection.Open();

                        // Create a command object with the SQL query and parameters
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@name", name);

                            // Execute the query and get a data reader
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                // Loop through the results and display them to the console
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        Console.Write(reader.GetValue(i) + " ");
                                    }
                                    Console.WriteLine();
                                }
                            }
                        }
                        // Close the connection
                        connection.Close();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command. Please try again.");
                }
            }
        }
    }
}