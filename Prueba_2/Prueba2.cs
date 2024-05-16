using System;
using System.Data.SqlClient;
using System.IO;

class Program
{
    static string connectionString = "Data Source=DESKTOP-6CPEHOH,Initial Catalog=prueba;Integrated Security=True";

    static void Main()
    {
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1. Listar top 10 usuarios");
        Console.WriteLine("2. Agregar un nuevo usuario");
        Console.WriteLine("3. Actualizar el salario de un usuario existente");
        Console.WriteLine("4. Salir");

        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
        {
            Console.WriteLine("Por favor, seleccione una opción válida (1, 2, 3 o 4):");
        }

        switch (opcion)
        {
            case 1:
                ListarTop10Usuarios();
                break;
            case 2:
                AgregarNuevoUsuario();
                break;
            case 3:
                ActualizarSalarioUsuario();
                break;
            case 4:
                DepurarIDsYListarTop10Usuarios();
                break;
            case 5:
                Console.WriteLine("Saliendo del programa...");
                break;

        }
    }

    static void ListarTop10Usuarios()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string Top10 = "SELECT TOP 10 username, nombre, apellido_paterno, apellido_materno FROM usuarios ORDER BY puntuacion DESC";

            SqlCommand command = new SqlCommand(Top10, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Top 10 usuarios:");

                while (reader.Read())
                {
                    string username = reader["username"].ToString();
                    string nombre = reader["nombre"].ToString();
                    string apellidoPaterno = reader["apellido_paterno"].ToString();
                    string apellidoMaterno = reader["apellido_materno"].ToString();

                    Console.WriteLine($"Username: {username}, Nombre: {nombre} {apellidoPaterno} {apellidoMaterno}");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static void AgregarNuevoUsuario()
    {
        Console.WriteLine("Ingrese el nombre de usuario:");
        string username = Console.ReadLine();

        Console.WriteLine("Ingrese el nombre:");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese el apellido paterno:");
        string apellidoPaterno = Console.ReadLine();

        Console.WriteLine("Ingrese el apellido materno:");
        string apellidoMaterno = Console.ReadLine();

        Console.WriteLine("Ingrese el salario:");
        decimal sueldo;
        while (!decimal.TryParse(Console.ReadLine(), out sueldo))
        {
            Console.WriteLine("Por favor, ingrese un valor numérico válido para el salario:");
        }

        DateTime fechaIngreso = DateTime.Today;

        string sqlQuery = "INSERT INTO usuarios (username, nombre, apellido_paterno, apellido_materno, sueldo, fecha_ingreso) " +
                          "VALUES (@Username, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Sueldo, @FechaIngreso)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Nombre", nombre);
            command.Parameters.AddWithValue("@ApellidoPaterno", apellidoPaterno);
            command.Parameters.AddWithValue("@ApellidoMaterno", apellidoMaterno);
            command.Parameters.AddWithValue("@Sueldo", sueldo);
            command.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("¡El nuevo usuario se ha agregado correctamente!");
                }
                else
                {
                    Console.WriteLine("Error al agregar el nuevo usuario.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el nuevo usuario: {ex.Message}");
            }
        }
    }

    static void ActualizarSalarioUsuario()
    {
        Console.WriteLine("Ingrese el nombre de usuario del empleado cuyo salario desea actualizar:");
        string username = Console.ReadLine();

        Console.WriteLine("Ingrese el nuevo salario:");
        decimal nuevoSueldo;
        while (!decimal.TryParse(Console.ReadLine(), out nuevoSueldo))
        {
            Console.WriteLine("Por favor, ingrese un valor numérico válido para el salario:");
        }

        string sqlQuery = "UPDATE usuarios SET sueldo = @NuevoSueldo WHERE username = @Username";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@NuevoSueldo", nuevoSueldo);
            command.Parameters.AddWithValue("@Username", username);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {                Console.WriteLine("¡El salario se ha actualizado correctamente!");
                }
                else
                {
                    Console.WriteLine("No se encontró ningún empleado con el nombre de usuario proporcionado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el salario: {ex.Message}");
            }
        }
    }
    static void DepurarIDsYListarTop10Usuarios()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT TOP 10 username, nombre, apellido_paterno, apellido_materno FROM usuarios " +
                           "WHERE id NOT IN (6, 7, 9, 10) ORDER BY puntuacion DESC";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Top 10 usuarios después de depurar IDs 6, 7, 9 y 10:");

                while (reader.Read())
                {
                    string username = reader["username"].ToString();
                    string nombre = reader["nombre"].ToString();
                    string apellidoPaterno = reader["apellido_paterno"].ToString();
                    string apellidoMaterno = reader["apellido_materno"].ToString();

                    Console.WriteLine($"Username: {username}, Nombre: {nombre} {apellidoPaterno} {apellidoMaterno}");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}