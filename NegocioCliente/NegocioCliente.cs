using DataCliente;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions; 

namespace NegocioCliente
{
    public class NegocioCliente
    {
        // PROPIEDAD
        private DataCliente.DataCliente datos;

        // CONSTRUCTOR
        public NegocioCliente()
        {
            datos = new DataCliente.DataCliente();
        }

        //MÉTODOS 

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
            // === VALIDACIÓN AÑADIDA ===
            // Ahora llamamos al método de validación.
            if (!ValidarID(cliente.CustomerID))
            {
                return false;
            }

            //El nombre de la compañía es obligatorio.
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
            // El ID es obligatorio.
            if (string.IsNullOrWhiteSpace(cliente.CustomerID))
            {
                return false;
            }
            //El nombre de la compañía es obligatorio.
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
        /// *** MÉTODO  DE BÚSQUEDA ***
        /// Caso de Uso: Buscar Clientes.
        /// </summary>
        public List<Cliente> BuscarClientes(string terminoBusqueda)
        {
            //No buscar si el texto es muy corto (ej. menos de 2 letras)
            if (string.IsNullOrWhiteSpace(terminoBusqueda) || terminoBusqueda.Length < 2)
            {
                return new List<Cliente>(); // Devuelve lista vacía
            }
            return datos.BuscarClientes(terminoBusqueda);
        }

        /// <summary>
        /// Valida la regla de negocio para un CustomerID.
        /// Debe ser exactamente 5 letras mayúsculas.
        /// </summary>
        /// <param name="id">El ID a validar</param>
        /// <returns>True si es válido, False si es inválido.</returns>
        public bool ValidarID(string id)
        {
            //El ID es obligatorio y debe tener 5 mayúsculas.
            if (string.IsNullOrWhiteSpace(id) || !Regex.IsMatch(id, @"^[A-Z]{5}$"))
            {
                return false;
            }

            // Si pasa la validación, es verdadero
            return true;
        }
    }
}