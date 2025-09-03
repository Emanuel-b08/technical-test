using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        private void FormProductList_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos(string filtro = "")
        {
            using (var db = new MiDbContext())
            {
                var productos = db.Product.AsQueryable();

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    productos = productos.Where(p => p.Name.Contains(filtro));
                }

                dgvProductos.DataSource = productos
                    .Select(p => new
                    {
                        p.ProductID,
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
            }
        }

        private void btnBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarProductos(txtBuscar.Text);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            FormProductEditor frm = new FormProductEditor();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarProductos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count != 1)
            {
                MessageBox.Show("Seleccione un único producto para editar.");
                return;
            }

            int id = (int)dgvProductos.SelectedRows[0].Cells["ProductoID"].Value;
            FormProductEditor frm = new FormProductEditor(id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarProductos();
            }
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

            using (var db = new MiDbContext())
            {
                foreach (DataGridViewRow row in dgvProductos.SelectedRows)
                {
                    int id = (int)row.Cells["ProductoID"].Value;
                    var prod = db.Product.Find(id);
                    if (prod != null)
                        db.Product.Remove(prod);
                }
                db.SaveChanges();
            }

            CargarProductos();
        }
    }
}
