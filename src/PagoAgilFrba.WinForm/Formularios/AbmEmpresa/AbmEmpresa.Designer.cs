namespace PagoAgilFrba
{
    partial class AbmEmpresa
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textCuit = new System.Windows.Forms.TextBox();
            this.comboBoxRubro = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.grpBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(590, 512);
            // 
            // grpBusqueda
            // 
            this.grpBusqueda.Controls.Add(this.comboBoxRubro);
            this.grpBusqueda.Controls.Add(this.textCuit);
            this.grpBusqueda.Controls.Add(this.label4);
            this.grpBusqueda.Controls.Add(this.label3);
            this.grpBusqueda.Controls.Add(this.txtNombre);
            this.grpBusqueda.Controls.Add(this.label1);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(69, 19);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(291, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cuit";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rubro";
            // 
            // textCuit
            // 
            this.textCuit.Location = new System.Drawing.Point(69, 48);
            this.textCuit.Name = "textCuit";
            this.textCuit.Size = new System.Drawing.Size(291, 20);
            this.textCuit.TabIndex = 10;
            // 
            // comboBoxRubro
            // 
            this.comboBoxRubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxRubro.FormattingEnabled = true;
            this.comboBoxRubro.Location = new System.Drawing.Point(69, 78);
            this.comboBoxRubro.Name = "comboBoxRubro";
            this.comboBoxRubro.Size = new System.Drawing.Size(291, 21);
            this.comboBoxRubro.TabIndex = 13;
            this.comboBoxRubro.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // AbmEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 512);
            this.Name = "AbmEmpresa";
            this.Text = "ABM Empresas";
            this.panel1.ResumeLayout(false);
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCuit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxRubro;
    }
}