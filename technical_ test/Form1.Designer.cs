namespace technical__test
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(12, 50);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(760, 350);
            this.dgvProductos.TabIndex = 0;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(12, 15);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(300, 23);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // btnAñadir
            // 
            this.btnAñadir.Location = new System.Drawing.Point(330, 12);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(80, 25);
            this.btnAñadir.TabIndex = 2;
            this.btnAñadir.Text = "Añadir";
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(420, 12);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(80, 25);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(510, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 25);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAñadir);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dgvProductos);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Productos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
