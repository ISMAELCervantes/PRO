using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataCliente; // Tu capa de datos
using System.Collections.Generic;

namespace ClienteTests
{
    [TestClass]
    public class DataClienteTests
    {
        private DataCliente.DataCliente data;
        private string _idPrueba = "PRUE1"; // ID que usaremos para crear y borrar

        [TestInitialize]
        public void Setup()
        {
            data = new DataCliente.DataCliente();

            // --- Limpieza ANTES de la prueba ---
            // Nos aseguramos de que el cliente de prueba no exista
            // para que la prueba de Insertar funcione.
            data.Eliminar(_idPrueba);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // --- Limpieza DESPUÉS de la prueba ---
            // Borramos el cliente de prueba si es que se creó
            data.Eliminar(_idPrueba);
        }

        [TestMethod]
        public void Insertar_DebeCrearClienteNuevo_CPD001()
        {
            // 1. Preparar
            Cliente cliente = new Cliente
            {
                CustomerID = _idPrueba,
                CompanyName = "Empresa de Prueba",
                ContactName = "Contacto de Prueba"
                // ... puedes llenar más campos si son obligatorios
            };

            // 2. Actuar
            bool exito = data.Insertar(cliente);

            // 3. Afirmar
            Assert.IsTrue(exito, "La inserción en la BD debió devolver 'true'.");

            // 3b. Afirmar (Verificación)
            Cliente clienteInsertado = data.CargarCliente(_idPrueba);
            Assert.IsNotNull(clienteInsertado, "El cliente no se encontró en la BD después de insertar.");
            Assert.AreEqual("Empresa de Prueba", clienteInsertado.CompanyName);
        }

        [TestMethod]
        public void Insertar_DebeFallarConIDDuplicado_CPD002()
        {
            // 1. Preparar
            Cliente clienteDuplicado = new Cliente { CustomerID = "ALFKI" }; // ID que ya existe

            // 2. Actuar
            bool exito = data.Insertar(clienteDuplicado);

            // 3. Afirmar
            Assert.IsFalse(exito, "La inserción de un ID duplicado debió devolver 'false'.");
        }

        [TestMethod]
        public void CargarCliente_DebeTraerClienteExistente_CPD003()
        {
            // 1. Preparar (ID conocido)
            string id = "ALFKI";

            // 2. Actuar
            Cliente cliente = data.CargarCliente(id);

            // 3. Afirmar
            Assert.IsNotNull(cliente, "CargarCliente() devolvió nulo para un ID existente.");
            Assert.AreEqual(id, cliente.CustomerID);
        }

        [TestMethod]
        public void CargarCliente_DebeDevolverNuloSiNoExiste_CPD004()
        {
            // 1. Preparar
            string id = "XXXXX"; // ID que no existe

            // 2. Actuar
            Cliente cliente = data.CargarCliente(id);

            // 3. Afirmar
            Assert.IsNull(cliente, "CargarCliente() debió devolver nulo para un ID inexistente.");
        }

        // ... Puedes seguir este patrón para Actualizar, Eliminar y Buscar ...
    }
}