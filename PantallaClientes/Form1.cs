using NegocioCliente; 
using DataCliente;    
using System;
using System.Windows.Forms;

namespace PantallaClientes
{
    public partial class Form1 : Form
    {
        //Instancia de la capa de negocio
        private NegocioCliente.NegocioCliente negocio;

        public Form1()
        {
            InitializeComponent();
            //Inicia la capa de negocio en cuanto el formulario se crea
            negocio = new NegocioCliente.NegocioCliente();
        }

        //Implementa el caso de uso "Consultar Informaci�n
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Usamos el 'txtBusqueda' como el campo para introducir el ID a cargar
            string id = txtBusqueda.Text;
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Por favor, ingrese un ID para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Llamamos a la capa de negocio
            Cliente cliente = negocio.CargarCliente(id);

            // Verificamos si se encontr� al cliente
            if (cliente != null)
            {
                PoblarFormConCliente(cliente);
                MessageBox.Show("Cliente cargado exitosamente.", "Consulta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LimpiarCampos();
                MessageBox.Show("Cliente no encontrado. Verifique el ID.", "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Implementa el caso de uso "Dar de Alta un Cliente
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                //Creamos un objeto cliente con los datos del formulario
                Cliente cliente = CargarClienteDesdeForm();

                //Lo mandamos a la capa de negocio para insertar
                bool exito = negocio.Insertar(cliente);

                //Mostramos retroalimentaci�n
                if (exito)
                {
                    MessageBox.Show("Cliente agregado exitosamente.", "Alta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    // Puede ser por ID duplicado o por regla de negocio (ID inv�lido)
                    MessageBox.Show("Error al agregar el cliente.\n\nPosibles causas:\n- El ID ya existe.\n- El ID no cumple el formato (5 letras may�sculas).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurri� un error inesperado: " + ex.Message, "Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Implementa el caso de uso "Modificar Informaci�n
        //
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtenemos los datos (modificados) del formulario
                Cliente cliente = CargarClienteDesdeForm();

                //Lo mandamos a la capa de negocio para actualizar
                bool exito = negocio.Actualizar(cliente);

                //Mostramos retroalimentaci�n
                if (exito)
                {
                    MessageBox.Show("Cliente actualizado exitosamente.", "Cambio Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Error porque el ID no existe
                    MessageBox.Show("Error al actualizar.\nEl cliente con el ID especificado no fue encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurri� un error inesperado: " + ex.Message, "Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Implementa el caso de uso "Dar de Baja un Cliente"
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Usamos el ID que ya est� cargado en el campo txtID
            string id = txtID.Text;
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Por favor, cargue un cliente primero (usando el bot�n Buscar) antes de eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Pedir confirmaci�n es una buena pr�ctica
            var confirmacion = MessageBox.Show($"�Est� seguro de que desea eliminar al cliente {id}?", "Confirmar eliminaci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                //Mandamos el ID a la capa de negocio
                bool exito = negocio.Eliminar(id);

                //Mostramos retroalimentaci�n
                if (exito)
                {
                    MessageBox.Show("Cliente borrado exitosamente.", "Baja Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    // Error porque el ID no existe
                    MessageBox.Show("Error al eliminar.\nEl cliente con ese ID no fue encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Limpia los capos
            LimpiarCampos();
        }

        // --- M�TODOS AUXILIARES---

        /// <summary>
        /// Limpia todos los campos de texto del formulario.
        /// </summary>
        private void LimpiarCampos()
        {
            txtID.Text = "";
            txtCompa��a.Text = "";
            txtContacto.Text = "";
            txtT�tulo.Text = "";
            txtDirecci�n.Text = "";
            txtCiudad.Text = "";
            txtRegi�n.Text = "";
            txtCPostal.Text = "";
            txtPa�s.Text = "";
            txtTel�fono.Text = "";
            txtFax.Text = "";
            txtBusqueda.Text = ""; 
        }

        /// <summary>
        /// Toma los datos de los campos de texto y crea un objeto Cliente.
        /// </summary>
        private Cliente CargarClienteDesdeForm()
        {
            return new Cliente
            {
                CustomerID = txtID.Text.Trim(),
                CompanyName = txtCompa��a.Text.Trim(),
                ContactName = txtContacto.Text.Trim(),
                ContactTitle = txtT�tulo.Text.Trim(),
                Address = txtDirecci�n.Text.Trim(),
                City = txtCiudad.Text.Trim(),
                Region = txtRegi�n.Text.Trim(),
                PostalCode = txtCPostal.Text.Trim(),
                Country = txtPa�s.Text.Trim(),
                Phone = txtTel�fono.Text.Trim(),
                Fax = txtFax.Text.Trim()
            };
        }

        /// <summary>
        /// Toma un objeto Cliente y llena los campos de texto del formulario.
        /// </summary>
        private void PoblarFormConCliente(Cliente cliente)
        {
            txtID.Text = cliente.CustomerID;
            txtCompa��a.Text = cliente.CompanyName;
            txtContacto.Text = cliente.ContactName;
            txtT�tulo.Text = cliente.ContactTitle;
            txtDirecci�n.Text = cliente.Address;
            txtCiudad.Text = cliente.City;
            txtRegi�n.Text = cliente.Region;
            txtCPostal.Text = cliente.PostalCode;
            txtPa�s.Text = cliente.Country;
            txtTel�fono.Text = cliente.Phone;
            txtFax.Text = cliente.Fax;
        }
    }
}