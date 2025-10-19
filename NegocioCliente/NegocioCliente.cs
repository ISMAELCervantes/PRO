// Este es el archivo: NegocioCliente.cs
// Ubicación: Proyecto NegocioCliente

using DataCliente; // Para poder usar las clases "Cliente" y "DataCliente"
using System;
using System.Collections.Generic; // Necesario para List<>
using System.Text.RegularExpressions; // Para validaciones

namespace NegocioCliente
{
    // Esta es la clase de la Capa de Negocio (BLL)
    public class NegocioCliente
    {
        // 1. PROPIEDAD
        private DataCliente.DataCliente datos;

        // 2. CONSTRUCTOR
        public NegocioCliente()
        {
            datos = new DataCliente.DataCliente();
        }

        // 3. MÉTODOS (Casos de Uso)

        /// <summary>
        /// Caso de Uso: Consultar un Cliente por ID.
        /// </summary>
        public Cliente CargarCliente(string id)
        {
            return datos.CargarCliente(id);
        }

        /// <summary>
        /// Caso de Uso: Dar de Alta un Cliente.
        /// </summary>
        public bool Insertar(Cliente cliente)
        {
            // Regla 1: El ID es obligatorio y debe tener 5 mayúsculas.
            if (string.IsNullOrWhiteSpace(cliente.CustomerID) || !Regex.IsMatch(cliente.CustomerID, @"^[A-Z]{5}$"))
            {
                return false;
            }
            // Regla 2: El nombre de la compañía es obligatorio.
            if (string.IsNullOrWhiteSpace(cliente.CompanyName))
            {
                return false;
            }
            return datos.Insertar(cliente);
        }

        /// <summary>
        /// Caso de Uso: Modificar Información de un Cliente.
        /// </summary>
        public bool Actualizar(Cliente cliente)
        {
            // Regla 1: El ID es obligatorio.
            if (string.IsNullOrWhiteSpace(cliente.CustomerID))
            {
                return false;
            }
            // Regla 2: El nombre de la compañía es obligatorio.
            if (string.IsNullOrWhiteSpace(cliente.CompanyName))
            {
                return false;
            }
            return datos.Actualizar(cliente);
        }

        /// <summary>
        /// Caso de Uso: Dar de Baja un Cliente.
        /// </summary>
        public bool Eliminar(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }
            return datos.Eliminar(id);
        }

        /// <summary>
        /// *** MÉTODO NUEVO PARA BÚSQUEDA ***
        /// Caso de Uso: Buscar Clientes.
        /// </summary>
        public List<Cliente> BuscarClientes(string terminoBusqueda)
        {
            // Regla 1: No buscar si el texto es muy corto (ej. menos de 2 letras)
            if (string.IsNullOrWhiteSpace(terminoBusqueda) || terminoBusqueda.Length < 2)
            {
                return new List<Cliente>(); // Devuelve lista vacía
            }
            return datos.BuscarClientes(terminoBusqueda);
        }
    }
}