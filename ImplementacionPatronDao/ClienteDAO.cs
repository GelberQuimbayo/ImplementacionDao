using ImplementacionPatronDao;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
 

public class ClienteDAO : IClienteDAO
{
    private string connectionString;

    public ClienteDAO()
    {
        // Obtener la ruta del directorio actual y construir la cadena de conexión
        string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Ejemplo.accdb");
        connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};";
    }

    /// <summary>
    /// Agrega un nuevo cliente a la base de datos.
    /// </summary>
    /// <param name="cliente">El cliente a agregar.</param>
    public void agregarCliente(Cliente cliente)
    {
        using (var connection = new OleDbConnection(connectionString))
        {
            var command = new OleDbCommand("INSERT INTO Clientes (Nombre, Email) VALUES (?, ?)", connection);
            command.Parameters.AddWithValue("?", cliente.Nombre);
            command.Parameters.AddWithValue("?", cliente.Email);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    /// <summary>
    /// consultar cliente en la base de datos
    /// </summary>
    /// <param name="id">id del cliente a agregar.</param>
    public Cliente consultarCliente(int id)
    {
        using (var connection = new OleDbConnection(connectionString))
        {
            var command = new OleDbCommand("SELECT * FROM Clientes WHERE Id = ?", connection);
            command.Parameters.AddWithValue("?", id);

            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Cliente
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
            }
        }
        return null;
    }

    /// <summary>
    /// consultar  todos los cliente en la base de datos y agregarlo a un listado de clientes
    /// </summary>

    public List<Cliente> consultarTodos()
    {
        var clientes = new List<Cliente>();

        using (var connection = new OleDbConnection(connectionString))
        {
            var command = new OleDbCommand("SELECT * FROM Clientes", connection);
            connection.Open();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    clientes.Add(new Cliente
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }
        }
        return clientes;
    }
    /// <summary>
    /// actualizar cliente en la base de datos
    /// </summary>
    /// <param name="cliente">cliente a actualizar.</param>
    public void actualizarCliente(Cliente cliente)
    {
        using (var connection = new OleDbConnection(connectionString))
        {
            var command = new OleDbCommand("UPDATE Clientes SET Nombre = ?, Email = ? WHERE Id = ?", connection);
            command.Parameters.AddWithValue("?", cliente.Nombre);
            command.Parameters.AddWithValue("?", cliente.Email);
            command.Parameters.AddWithValue("?", cliente.Id);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    /// <summary>
    /// eliminar cliente en la base de datos
    /// </summary>
    /// <param name="cliente">cliente a eliminar.</param>
    public void eliminarCliente(int id)
    {
        using (var connection = new OleDbConnection(connectionString))
        {
            var command = new OleDbCommand("DELETE FROM Clientes WHERE Id = ?", connection);
            command.Parameters.AddWithValue("?", id);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
