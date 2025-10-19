using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;

namespace DataCliente
{
    public class DataCliente
    {
        // Cadena de conexión al servidor SQL Server.
        private string cadena = @"Data Source=MSI\MSSQLSERVER01;Initial Catalog=NorthWind;Integrated Security=True;TrustServerCertificate=True;";

        // Variables para la conexión y las sentencias SQL.
        private SqlConnection conn;
        private string sentencia;

        // establece la conexión con la base de datos.
        private bool Conectar()
        {
            try
            {
                conn = new SqlConnection(cadena);
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                // En caso de error, devuelve false.
                return false;
            }
        }

        // Método que cierra la conexión si está abierta.
        private void Desconectar()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        // Inserta un nuevo registro de cliente en la tabla "Customers".
        public bool Insertar(Cliente cliente)
        {
            sentencia = "INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) " +
                        "VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)";

            if (!Conectar()) return false;

            try
            {
                using (SqlCommand cmd = new SqlCommand(sentencia, conn))
                {
                    // Asignación de parámetros para evitar inyección SQL.
                    cmd.Parameters.AddWithValue("@CustomerID", cliente.CustomerID);
                    cmd.Parameters.AddWithValue("@CompanyName", cliente.CompanyName);
                    cmd.Parameters.AddWithValue("@ContactName", cliente.ContactName);
                    cmd.Parameters.AddWithValue("@ContactTitle", cliente.ContactTitle);
                    cmd.Parameters.AddWithValue("@Address", cliente.Address);
                    cmd.Parameters.AddWithValue("@City", cliente.City);
                    cmd.Parameters.AddWithValue("@Region", (object)cliente.Region ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PostalCode", (object)cliente.PostalCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Country", (object)cliente.Country ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", (object)cliente.Phone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Fax", (object)cliente.Fax ?? DBNull.Value);

                    // Ejecuta el comando SQL.
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Desconectar();
            }
        }

        // Actualiza la información de un cliente existente.
        public bool Actualizar(Cliente cliente)
        {
            sentencia = "UPDATE Customers SET CompanyName = @CompanyName, ContactName = @ContactName, " +
                        "ContactTitle = @ContactTitle, Address = @Address, City = @City, Region = @Region, " +
                        "PostalCode = @PostalCode, Country = @Country, Phone = @Phone, Fax = @Fax " +
                        "WHERE CustomerID = @CustomerID";

            if (!Conectar()) return false;

            try
            {
                using (SqlCommand cmd = new SqlCommand(sentencia, conn))
                {
                    // Parámetros actualizados.
                    cmd.Parameters.AddWithValue("@CompanyName", cliente.CompanyName);
                    cmd.Parameters.AddWithValue("@ContactName", cliente.ContactName);
                    cmd.Parameters.AddWithValue("@ContactTitle", cliente.ContactTitle);
                    cmd.Parameters.AddWithValue("@Address", cliente.Address);
                    cmd.Parameters.AddWithValue("@City", cliente.City);
                    cmd.Parameters.AddWithValue("@Region", (object)cliente.Region ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PostalCode", (object)cliente.PostalCode ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Country", (object)cliente.Country ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", (object)cliente.Phone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Fax", (object)cliente.Fax ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CustomerID", cliente.CustomerID);

                    // Devuelve verrdadero si al menos una fila fue modificada.
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Desconectar();
            }
        }

        // Elimina un cliente según su ID.
        public bool Eliminar(string customerID)
        {
            sentencia = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
            if (!Conectar()) return false;

            try
            {
                using (SqlCommand cmd = new SqlCommand(sentencia, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Desconectar();
            }
        }

        // Carga los datos completos de un cliente específico por su ID.
        public Cliente CargarCliente(string customerID)
        {
            sentencia = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
            if (!Conectar()) return null;

            try
            {
                using (SqlCommand cmd = new SqlCommand(sentencia, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Mapeo de los datos del registro al objeto Cliente.
                            Cliente cliente = new Cliente
                            {
                                CustomerID = reader["CustomerID"].ToString(),
                                CompanyName = reader["CompanyName"].ToString(),
                                ContactName = reader["ContactName"].ToString(),
                                ContactTitle = reader["ContactTitle"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                Region = reader["Region"] != DBNull.Value ? reader["Region"].ToString() : null,
                                PostalCode = reader["PostalCode"] != DBNull.Value ? reader["PostalCode"].ToString() : null,
                                Country = reader["Country"] != DBNull.Value ? reader["Country"].ToString() : null,
                                Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : null,
                                Fax = reader["Fax"] != DBNull.Value ? reader["Fax"].ToString() : null
                            };
                            return cliente;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Desconectar();
            }
        }

        // Busca clientes cuyo ID, nombre de empresa, contacto o ciudad coincidan con el término.
        public List<Cliente> BuscarClientes(string termino)
        {
            List<Cliente> resultados = new List<Cliente>();
            sentencia = "SELECT CustomerID, CompanyName, ContactName, City, Country FROM Customers " +
                        "WHERE CustomerID LIKE @termino " +
                        "OR CompanyName LIKE @termino " +
                        "OR ContactName LIKE @termino " +
                        "OR City LIKE @termino";

            if (!Conectar()) return resultados;

            try
            {
                using (SqlCommand cmd = new SqlCommand(sentencia, conn))
                {
                    cmd.Parameters.AddWithValue("@termino", "%" + termino + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Recorre los resultados y los agrega a la lista.
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                CustomerID = reader["CustomerID"].ToString(),
                                CompanyName = reader["CompanyName"].ToString(),
                                ContactName = reader["ContactName"].ToString(),
                                City = reader["City"].ToString(),
                                Country = reader["Country"].ToString()
                            };
                            resultados.Add(cliente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error, se devuelve una lista vacía.
            }
            finally
            {
                Desconectar();
            }

            return resultados;
        }
    }
}
