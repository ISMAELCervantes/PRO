using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic; // <-- Asegúrate de tener este

namespace DataCliente
{
    public class DataCliente
    {
        // !!! IMPORTANTE: Cambia "TU_SERVIDOR" por el nombre de tu SQL Server
        // Nombres comunes: (localdb)\MSSQLLocalDB ,   .\SQLEXPRESS   , o   localhost
        private string cadena = @"Data Source=TU_SERVIDOR;Initial Catalog=NorthWind;Integrated Security=True;TrustServerCertificate=True;";

        private SqlConnection conn;
        private string sentencia;

        private bool Conectar()
        {
            try
            {
                conn = new SqlConnection(cadena);
                conn.Open();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        private void Desconectar()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public bool Insertar(Cliente cliente)
        {
            sentencia = "INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) " +
                        "VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)";
            if (!Conectar()) return false;
            try
            {
                using (SqlCommand cmd = new SqlCommand(sentencia, conn))
                {
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
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex) { return false; }
            finally { Desconectar(); }
        }

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
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex) { return false; }
            finally { Desconectar(); }
        }

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
            catch (Exception ex) { return false; }
            finally { Desconectar(); }
        }

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
                            Cliente cliente = new Cliente();
                            cliente.CustomerID = reader["CustomerID"].ToString();
                            cliente.CompanyName = reader["CompanyName"].ToString();
                            cliente.ContactName = reader["ContactName"].ToString();
                            cliente.ContactTitle = reader["ContactTitle"].ToString();
                            cliente.Address = reader["Address"].ToString();
                            cliente.City = reader["City"].ToString();
                            cliente.Region = reader["Region"] != DBNull.Value ? reader["Region"].ToString() : null;
                            cliente.PostalCode = reader["PostalCode"] != DBNull.Value ? reader["PostalCode"].ToString() : null;
                            cliente.Country = reader["Country"] != DBNull.Value ? reader["Country"].ToString() : null;
                            cliente.Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : null;
                            cliente.Fax = reader["Fax"] != DBNull.Value ? reader["Fax"].ToString() : null;
                            return cliente;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex) { return null; }
            finally { Desconectar(); }
        }

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
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente();
                            cliente.CustomerID = reader["CustomerID"].ToString();
                            cliente.CompanyName = reader["CompanyName"].ToString();
                            cliente.ContactName = reader["ContactName"].ToString();
                            cliente.City = reader["City"].ToString();
                            cliente.Country = reader["Country"].ToString();
                            resultados.Add(cliente);
                        }
                    }
                }
            }
            catch (Exception ex) { /* Devuelve lista vacía */ }
            finally { Desconectar(); }
            return resultados;
        }
    }
}