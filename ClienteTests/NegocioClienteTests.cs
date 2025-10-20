using Microsoft.VisualStudio.TestTools.UnitTesting;
using NegocioCliente; // Tu capa de negocio
using DataCliente;    // Para usar la clase Cliente

namespace ClienteTests
{
    [TestClass]
    public class NegocioClienteTests
    {
        private NegocioCliente.NegocioCliente negocio;

        [TestInitialize]
        public void Setup()
        {
            // Creamos una nueva instancia antes de CADA prueba
            negocio = new NegocioCliente.NegocioCliente();
        }

        // --- Pruebas para la regla de negocio VALIDAR ID ---
        // Basadas en CP-N-001 a CP-N-004

        [TestMethod]
        [DataRow("TEST1", true, "CP-N-001: 5 mayúsculas debe ser válido.")]
        [DataRow("test1", false, "CP-N-002: Minúsculas debe ser inválido.")]
        [DataRow("TEST", false, "CP-N-003: 4 caracteres debe ser inválido.")]
        [DataRow("TEST12", false, "CP-N-004: Números debe ser inválido.")]
        [DataRow("TESTING", false, "Longitud > 5 debe ser inválido.")]
        [DataRow("", false, "Vacío debe ser inválido.")]
        [DataRow(null, false, "Nulo debe ser inválido.")]
        public void ValidarID_PruebaVariosEscenarios(string id, bool esperado, string mensajeError)
        {
            // 1. Actuar
            bool resultado = negocio.ValidarID(id);

            // 2. Afirmar (Assert)
            Assert.AreEqual(esperado, resultado, mensajeError);
        }

        // --- Pruebas para INSERTAR (Negocio) ---
        // Basado en CP-N-005

        [TestMethod]
        public void Insertar_DebeRechazarClienteConIDInvalido_CPN005()
        {
            // 1. Preparar (Arrange)
            Cliente clienteInvalido = new Cliente { CustomerID = "12345" }; // ID inválido

            // 2. Actuar (Act)
            // Este método llama internamente a ValidarID()
            bool resultado = negocio.Insertar(clienteInvalido);

            // 3. Afirmar (Assert)
            // Esperamos 'false' PORQUE la regla de negocio debe fallar
            // ANTES de intentar llamar a la capa de datos.
            Assert.IsFalse(resultado, "Insertar() debió devolver 'false' para un ID inválido.");
        }
    }
}