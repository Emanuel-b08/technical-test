using System;
using System.Windows.Forms;

namespace technical__test
{
    public partial class FormProductEditor : Form
    {
        private int? productoId;

        public FormProductEditor(int? id = null)
        {
            InitializeComponent();
            productoId = id;
        }

        private void FormProductEditor_Load(object sender, EventArgs e)
        {
            if (productoId.HasValue)
            {
                lblTitulo.Text = "Editando Producto";

                using (var db = new MiDbContext())
                {
                    var prod = db.Product.Find(productoId.Value);
                    if (prod != null)
                    {
                        txtNombre.Text = prod.Name;
                        txtCodigo.Text = prod.Code.ToString();
                        txtDescripcion.Text = prod.Description;
                        txtPrecio.Text = prod.UnitaryPrice.ToString();
                        txtStock.Text = prod.Stock.ToString();
                        txtCategoria.Text = prod.Category;
                        txtProveedor.Text = prod.Supplier;
                    }
                }
            }
            else
            {
                lblTitulo.Text = "Creando nuevo Producto";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new MiDbContext())
                {
                    Product prod;
                    if (productoId.HasValue)
                    {
                        prod = db.Product.Find(productoId.Value);
                    }
                    else
                    {
                        prod = new Product();
                        db.Product.Add(prod);
                    }

                    prod.Name = txtNombre.Text;
                    prod.Code = int.Parse(txtCodigo.Text);
                    prod.Description = txtDescripcion.Text;
                    prod.UnitaryPrice = decimal.Parse(txtPrecio.Text);
                    prod.Stock = int.Parse(txtStock.Text);
                    prod.Category = txtCategoria.Text;
                    prod.Supplier = txtProveedor.Text;

                    db.SaveChanges();
                }

                MessageBox.Show("Producto guardado correctamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

