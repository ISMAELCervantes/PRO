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

        // === 1. BOT�N BUSCAR ===
        // Busca en la tabla (DataGridView)
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBusqueda.Text;

            // Esta es la l�nea clave:
            // Llama a "BuscarClientes" (plural) y ASIGNA el resultado.
            // Esto evita duplicados y solo trae las columnas de la consulta.
            dataGridView1.DataSource = negocio.BuscarClientes(busqueda);
        }

        // === 2. CLIC EN LA TABLA (EL M�TODO BUENO) ===
        // Carga los campos de texto al hacer clic en una fila
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegurarse de que el clic no fue en el encabezado (e.RowIndex < 0)
            if (e.RowIndex >= 0)
            {
                try
                {
                    // 1. Obtener el ID de la fila seleccionada.
                    string id = dataGridView1.Rows[e.RowIndex].Cells["CustomerID"].Value.ToString();

                    // 2. Cargar el cliente COMPLETO usando el ID
                    Cliente cliente = negocio.CargarCliente(id);

                    // 3. Llenar los campos de texto con ese cliente
                    if (cliente != null)
                    {
                        PoblarFormConCliente(cliente);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar el cliente de la tabla: " + ex.Message);
                }
            }
        }


        //Implementa el caso de uso "Dar de Alta un Cliente"
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = CargarClienteDesdeForm();
                bool exito = negocio.Insertar(cliente);

                if (exito)
                {
                    MessageBox.Show("Cliente agregado exitosamente.", "Alta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    // Actualizamos la tabla
                    btnBuscar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error al agregar el cliente.\n\nPosibles causas:\n- El ID ya existe.\n- El ID no cumple el formato (5 letras may�sculas).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurri� un error inesperado: " + ex.Message, "Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Implementa el caso de uso "Modificar Informaci�n"
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = CargarClienteDesdeForm();
                bool exito = negocio.Actualizar(cliente);

                if (exito)
                {
                    MessageBox.Show("Cliente actualizado exitosamente.", "Cambio Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBuscar_Click(sender, e);
                }
                else
                {
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
            string id = txtID.Text;
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Por favor, seleccione un cliente de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmacion = MessageBox.Show($"�Est� seguro de que desea eliminar al cliente {id}?", "Confirmar eliminaci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                bool exito = negocio.Eliminar(id);
                if (exito)
                {
                    MessageBox.Show("Cliente borrado exitosamente.", "Baja Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    btnBuscar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error al eliminar.\nEl cliente con ese ID no fue encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            dataGridView1.DataSource = null;
        }

        // --- M�TODOS AUXILIARES (Helpers) ---

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

        // Este es el evento que ten�as conectado por error.
        // Lo dejamos aqu� para que no falle, pero lo hacemos
        // llamar al m�todo correcto ("dataGridView1_CellClick").
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
        }
    }
}