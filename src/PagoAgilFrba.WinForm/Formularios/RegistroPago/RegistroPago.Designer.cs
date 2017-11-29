namespace PagoAgilFrba
{
    partial class RegistroPago
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.textNumero = new System.Windows.Forms.TextBox();
            this.Numero = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.textBoxImporte = new System.Windows.Forms.TextBox();
            this.txtImporte = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFormaPago = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.grpBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxFormaPago);
            this.panel1.Size = new System.Drawing.Size(590, 512);
            this.panel1.Controls.SetChildIndex(this.grpBusqueda, 0);
            this.panel1.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.panel1.Controls.SetChildIndex(this.btnBuscar, 0);
            this.panel1.Controls.SetChildIndex(this.comboBoxFormaPago, 0);
            this.panel1.Controls.SetChildIndex(this.btnNuevo, 0);
            // 
            // grpBusqueda
            // 
            this.grpBusqueda.Controls.Add(this.label2);
            this.grpBusqueda.Controls.Add(this.textBoxImporte);
            this.grpBusqueda.Controls.Add(this.txtImporte);
            this.grpBusqueda.Controls.Add(this.label7);
            this.grpBusqueda.Controls.Add(this.dtpVencimiento);
            this.grpBusqueda.Controls.Add(this.label1);
            this.grpBusqueda.Controls.Add(this.comboBoxEmpresa);
            this.grpBusqueda.Controls.Add(this.label6);
            this.grpBusqueda.Controls.Add(this.comboBoxCliente);
            this.grpBusqueda.Controls.Add(this.textNumero);
            this.grpBusqueda.Controls.Add(this.Numero);
            this.grpBusqueda.Text = "Datos Factura";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Empresa";
            // 
            // comboBoxEmpresa
            // 
            this.comboBoxEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxEmpresa.FormattingEnabled = true;
            this.comboBoxEmpresa.Location = new System.Drawing.Point(388, 19);
            this.comboBoxEmpresa.Name = "comboBoxEmpresa";
            this.comboBoxEmpresa.Size = new System.Drawing.Size(367, 21);
            this.comboBoxEmpresa.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(365, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Cliente";
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(406, 46);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(298, 21);
            this.comboBoxCliente.TabIndex = 28;
            // 
            // textNumero
            // 
            this.textNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textNumero.Location = new System.Drawing.Point(66, 19);
            this.textNumero.MaxLength = 50;
            this.textNumero.Name = "textNumero";
            this.textNumero.Size = new System.Drawing.Size(32, 20);
            this.textNumero.TabIndex = 27;
            // 
            // Numero
            // 
            this.Numero.AutoSize = true;
            this.Numero.Location = new System.Drawing.Point(13, 22);
            this.Numero.Name = "Numero";
            this.Numero.Size = new System.Drawing.Size(44, 13);
            this.Numero.TabIndex = 26;
            this.Numero.Text = "Numero";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Vencimiento";
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.CustomFormat = "ddMMyyyy";
            this.dtpVencimiento.Location = new System.Drawing.Point(74, 47);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(200, 20);
            this.dtpVencimiento.TabIndex = 32;
            // 
            // textBoxImporte
            // 
            this.textBoxImporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxImporte.Location = new System.Drawing.Point(66, 73);
            this.textBoxImporte.MaxLength = 50;
            this.textBoxImporte.Name = "textBoxImporte";
            this.textBoxImporte.Size = new System.Drawing.Size(63, 20);
            this.textBoxImporte.TabIndex = 35;
            // 
            // txtImporte
            // 
            this.txtImporte.AutoSize = true;
            this.txtImporte.Location = new System.Drawing.Point(13, 76);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(42, 13);
            this.txtImporte.TabIndex = 34;
            this.txtImporte.Text = "Importe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Forma de Pago";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBoxFormaPago
            // 
            this.comboBoxFormaPago.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxFormaPago.FormattingEnabled = true;
            this.comboBoxFormaPago.Location = new System.Drawing.Point(379, 88);
            this.comboBoxFormaPago.Name = "comboBoxFormaPago";
            this.comboBoxFormaPago.Size = new System.Drawing.Size(298, 21);
            this.comboBoxFormaPago.TabIndex = 36;
            // 
            // RegistroPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 512);
            this.Name = "RegistroPago";
            this.Text = "Registro de Pago";
            this.panel1.ResumeLayout(false);
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.TextBox textNumero;
        private System.Windows.Forms.Label Numero;
        private System.Windows.Forms.TextBox textBoxImporte;
        private System.Windows.Forms.Label txtImporte;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxFormaPago;

    }
}