namespace PagoAgilFrba
{
    partial class EditorFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Numero = new System.Windows.Forms.Label();
            this.textNumero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dvgItemsFactura = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.textBoxCantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMonto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgItemsFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // Numero
            // 
            this.Numero.AutoSize = true;
            this.Numero.Location = new System.Drawing.Point(25, 69);
            this.Numero.Name = "Numero";
            this.Numero.Size = new System.Drawing.Size(44, 13);
            this.Numero.TabIndex = 6;
            this.Numero.Text = "Numero";
            this.Numero.Click += new System.EventHandler(this.label2_Click);
            // 
            // textNumero
            // 
            this.textNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textNumero.Location = new System.Drawing.Point(78, 66);
            this.textNumero.MaxLength = 50;
            this.textNumero.Name = "textNumero";
            this.textNumero.Size = new System.Drawing.Size(332, 20);
            this.textNumero.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Cliente";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(78, 12);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(332, 21);
            this.comboBoxCliente.TabIndex = 21;
            this.comboBoxCliente.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Empresa";
            // 
            // comboBoxEmpresa
            // 
            this.comboBoxEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxEmpresa.FormattingEnabled = true;
            this.comboBoxEmpresa.Location = new System.Drawing.Point(78, 39);
            this.comboBoxEmpresa.Name = "comboBoxEmpresa";
            this.comboBoxEmpresa.Size = new System.Drawing.Size(332, 21);
            this.comboBoxEmpresa.TabIndex = 23;
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.CustomFormat = "ddMMyyyy";
            this.dtpVencimiento.Location = new System.Drawing.Point(100, 92);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(200, 20);
            this.dtpVencimiento.TabIndex = 25;
            this.dtpVencimiento.ValueChanged += new System.EventHandler(this.dtpVencimiento_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Vencimiento";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // dvgItemsFactura
            // 
            this.dvgItemsFactura.AllowUserToAddRows = false;
            this.dvgItemsFactura.AllowUserToDeleteRows = false;
            this.dvgItemsFactura.AllowUserToResizeRows = false;
            this.dvgItemsFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvgItemsFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dvgItemsFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgItemsFactura.Location = new System.Drawing.Point(12, 190);
            this.dvgItemsFactura.MultiSelect = false;
            this.dvgItemsFactura.Name = "dvgItemsFactura";
            this.dvgItemsFactura.ReadOnly = true;
            this.dvgItemsFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgItemsFactura.Size = new System.Drawing.Size(398, 148);
            this.dvgItemsFactura.TabIndex = 27;
            this.dvgItemsFactura.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgItemsFactura_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Items";
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarItem.Location = new System.Drawing.Point(328, 136);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarItem.TabIndex = 30;
            this.btnAgregarItem.Text = "Agregar Item";
            this.btnAgregarItem.UseVisualStyleBackColor = true;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // textBoxCantidad
            // 
            this.textBoxCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCantidad.Location = new System.Drawing.Point(78, 138);
            this.textBoxCantidad.MaxLength = 50;
            this.textBoxCantidad.Name = "textBoxCantidad";
            this.textBoxCantidad.Size = new System.Drawing.Size(82, 20);
            this.textBoxCantidad.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Monto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Cantidad";
            // 
            // textBoxMonto
            // 
            this.textBoxMonto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMonto.Location = new System.Drawing.Point(218, 138);
            this.textBoxMonto.MaxLength = 50;
            this.textBoxMonto.Name = "textBoxMonto";
            this.textBoxMonto.Size = new System.Drawing.Size(82, 20);
            this.textBoxMonto.TabIndex = 35;
            // 
            // EditorFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 378);
            this.Controls.Add(this.textBoxMonto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCantidad);
            this.Controls.Add(this.btnAgregarItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dvgItemsFactura);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpVencimiento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxEmpresa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxCliente);
            this.Controls.Add(this.textNumero);
            this.Controls.Add(this.Numero);
            this.Name = "EditorFactura";
            this.Text = "EditorEmpresa";
            this.Controls.SetChildIndex(this.Numero, 0);
            this.Controls.SetChildIndex(this.textNumero, 0);
            this.Controls.SetChildIndex(this.comboBoxCliente, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.comboBoxEmpresa, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtpVencimiento, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.dvgItemsFactura, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnAgregarItem, 0);
            this.Controls.SetChildIndex(this.textBoxCantidad, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.textBoxMonto, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dvgItemsFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Numero;
        private System.Windows.Forms.TextBox textNumero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.Label label7;
        protected System.Windows.Forms.DataGridView dvgItemsFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.TextBox textBoxCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMonto;
    }
}