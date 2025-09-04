using System;
using System.Windows.Forms;

namespace technical__test
{
    public partial class FormProductEditor : Form
    {
        private int? productId;

        public FormProductEditor(int? id = null)
        {
            InitializeComponent();
            productId = id;
        }

        private void FormProductEditor_Load(object sender, EventArgs e)
        {
            var controller = new ProductController();

            if (productId.HasValue)
            {
                lblTitulo.Text = "Editando Producto";
                var prod = controller.GetById(productId.Value);

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
            else
            {
                lblTitulo.Text = "Creando nuevo Producto";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var controller = new ProductController();
            Product prod;

            // Si estamos editando un producto existente
            if (productId.HasValue)
            {
                prod = controller.GetById(productId.Value);
                if (prod == null)
                {
                    MessageBox.Show("No se encontró el producto.");
                    return;
                }
            }
            else
            {
                // Creando un nuevo producto
                prod = new Product();
                prod.GuidCode = Guid.NewGuid();   // Asignado solo al crear
                prod.CreationDate = DateTime.Now; // Fecha de creación
            }

            try
            {
                // Actualizamos los campos desde los TextBox
                prod.Name = txtNombre.Text;
                prod.Code = int.Parse(txtCodigo.Text);
                prod.Description = txtDescripcion.Text;
                prod.UnitaryPrice = decimal.Parse(txtPrecio.Text);
                prod.Stock = int.Parse(txtStock.Text);
                prod.Category = txtCategoria.Text;
                prod.Supplier = txtProveedor.Text;
                prod.ModificationDate = DateTime.Now; // Fecha de modificación

                // Guardamos usando el controlador
                controller.Save(prod);

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
