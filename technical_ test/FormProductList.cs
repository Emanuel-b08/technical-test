using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace technical__test
{
    public partial class FormProductList : Form
    {
        public FormProductList()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Agregar columna de selección si no existe
            if (!dgvProductos.Columns.Contains("Seleccionar"))
            {
                var chk = new DataGridViewCheckBoxColumn();
                chk.HeaderText = "Seleccionar";
                chk.Name = "Seleccionar";
                dgvProductos.Columns.Insert(0, chk); // Insertar al inicio
            }
            CargarProductos();
        }

        private void CargarProductos(string filtro = "")
        {
            var controller = new ProductController();
            var productos = controller.GetAll(filtro);

            dgvProductos.DataSource = productos
                .Select(p => new
                {
                    p.ProductID,
                    p.GuidCode,
                    p.Name,
                    p.Code,
                    p.Description,
                    p.UnitaryPrice,
                    p.Stock,
                    p.Category,
                    p.Supplier,
                    p.CreationDate,
                    p.ModificationDate
                })
                .ToList();

            dgvProductos.Columns["ProductID"].Visible = false;
            dgvProductos.Columns["GuidCode"].ReadOnly = true;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarProductos(txtBuscar.Text);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            var frm = new FormProductEditor();
            if (frm.ShowDialog() == DialogResult.OK)
                CargarProductos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Obtener filas marcadas
            var filasSeleccionadas = dgvProductos.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["Seleccionar"].Value) == true)
                .ToList();

            if (filasSeleccionadas.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un producto para editar.");
                return;
            }

            if (filasSeleccionadas.Count > 1)
            {
                MessageBox.Show("Seleccione solo un producto para editar.");
                return;
            }

            // Solo una fila marcada
            int id = (int)filasSeleccionadas[0].Cells["ProductID"].Value;
            var frm = new FormProductEditor(id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarProductos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var controller = new ProductController();

            // Filtrar filas seleccionadas
            var filasSeleccionadas = dgvProductos.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["Seleccionar"].Value) == true)
                .ToList();

            if (filasSeleccionadas.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un producto para eliminar.");
                return;
            }

            var confirm = MessageBox.Show($"¿Está seguro de eliminar los {filasSeleccionadas.Count} productos seleccionados?",
                                          "Confirmar eliminación",
                                          MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No) return;

            // Eliminamos los productos seleccionados
            foreach (var row in filasSeleccionadas)
            {
                int id = (int)row.Cells["ProductID"].Value;
                controller.Delete(id);
            }

            // Recargamos la lista
            CargarProductos();
        }
        

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}