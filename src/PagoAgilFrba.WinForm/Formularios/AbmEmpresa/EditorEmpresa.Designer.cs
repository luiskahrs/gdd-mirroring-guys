namespace PagoAgilFrba
{
    partial class EditorEmpresa
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cuit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textCuit = new System.Windows.Forms.TextBox();
            this.textDireccion = new System.Windows.Forms.TextBox();
            this.comboBoxRubro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCodigoPostal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ckActiva = new System.Windows.Forms.CheckBox();
            this.textDiaRedencion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(78, 19);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(332, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // cuit
            // 
            this.cuit.AutoSize = true;
            this.cuit.Location = new System.Drawing.Point(25, 59);
            this.cuit.Name = "cuit";
            this.cuit.Size = new System.Drawing.Size(28, 13);
            this.cuit.TabIndex = 6;
            this.cuit.Text = "Cuit:";
            this.cuit.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Direccion:";
            // 
            // textCuit
            // 
            this.textCuit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textCuit.Location = new System.Drawing.Point(78, 56);
            this.textCuit.MaxLength = 50;
            this.textCuit.Name = "textCuit";
            this.textCuit.Size = new System.Drawing.Size(332, 20);
            this.textCuit.TabIndex = 8;
            // 
            // textDireccion
            // 
            this.textDireccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDireccion.Location = new System.Drawing.Point(86, 96);
            this.textDireccion.MaxLength = 50;
            this.textDireccion.Name = "textDireccion";
            this.textDireccion.Size = new System.Drawing.Size(324, 20);
            this.textDireccion.TabIndex = 9;
            // 
            // comboBoxRubro
            // 
            this.comboBoxRubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxRubro.FormattingEnabled = true;
            this.comboBoxRubro.Location = new System.Drawing.Point(78, 170);
            this.comboBoxRubro.Name = "comboBoxRubro";
            this.comboBoxRubro.Size = new System.Drawing.Size(332, 21);
            this.comboBoxRubro.TabIndex = 14;
            this.comboBoxRubro.SelectedIndexChanged += new System.EventHandler(this.comboBoxRubro_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Rubro:";
            // 
            // tbCodigoPostal
            // 
            this.tbCodigoPostal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCodigoPostal.Location = new System.Drawing.Point(106, 134);
            this.tbCodigoPostal.MaxLength = 50;
            this.tbCodigoPostal.Name = "tbCodigoPostal";
            this.tbCodigoPostal.Size = new System.Drawing.Size(126, 20);
            this.tbCodigoPostal.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Codigo Postal:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // ckActiva
            // 
            this.ckActiva.AutoSize = true;
            this.ckActiva.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckActiva.Location = new System.Drawing.Point(298, 136);
            this.ckActiva.Name = "ckActiva";
            this.ckActiva.Size = new System.Drawing.Size(56, 17);
            this.ckActiva.TabIndex = 18;
            this.ckActiva.Text = "Activa";
            this.ckActiva.UseVisualStyleBackColor = true;
            // 
            // textDiaRedencion
            // 
            this.textDiaRedencion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDiaRedencion.Location = new System.Drawing.Point(124, 206);
            this.textDiaRedencion.MaxLength = 50;
            this.textDiaRedencion.Name = "textDiaRedencion";
            this.textDiaRedencion.Size = new System.Drawing.Size(286, 20);
            this.textDiaRedencion.TabIndex = 20;
            this.textDiaRedencion.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Dia Redencion:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // EditorEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 275);
            this.Controls.Add(this.textDiaRedencion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ckActiva);
            this.Controls.Add(this.tbCodigoPostal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxRubro);
            this.Controls.Add(this.textDireccion);
            this.Controls.Add(this.textCuit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cuit);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Name = "EditorEmpresa";
            this.Text = "EditorEmpresa";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            this.Controls.SetChildIndex(this.cuit, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.textCuit, 0);
            this.Controls.SetChildIndex(this.textDireccion, 0);
            this.Controls.SetChildIndex(this.comboBoxRubro, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tbCodigoPostal, 0);
            this.Controls.SetChildIndex(this.ckActiva, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.textDiaRedencion, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label cuit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textCuit;
        private System.Windows.Forms.TextBox textDireccion;
        private System.Windows.Forms.ComboBox comboBoxRubro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCodigoPostal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckActiva;
        private System.Windows.Forms.TextBox textDiaRedencion;
        private System.Windows.Forms.Label label5;
    }
}