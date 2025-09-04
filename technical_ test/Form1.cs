using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace technical__test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
            if (dgvProductos.SelectedRows.Count != 1)
            {
                MessageBox.Show("Seleccione un único producto para editar.");
                return;
            }

            int id = (int)dgvProductos.SelectedRows[0].Cells["ProductID"].Value;
            var frm = new FormProductEditor(id);
            if (frm.ShowDialog() == DialogResult.OK)
                CargarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un producto para eliminar.");
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro de eliminar los productos seleccionados?",
                                          "Confirmar eliminación",
                                          MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No) return;

            var controller = new ProductController();

            foreach (DataGridViewRow row in dgvProductos.SelectedRows)
            {
                int id = (int)row.Cells["ProductID"].Value;
                controller.Delete(id);
            }

            CargarProductos();
        }
    }
}