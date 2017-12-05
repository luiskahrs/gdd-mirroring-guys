namespace PagoAgilFrba
{
    partial class AbmRendicion
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
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.txtARendir = new System.Windows.Forms.TextBox();
            this.buttonRendir = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.grpBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRendir);
            this.panel1.Size = new System.Drawing.Size(590, 512);
            this.panel1.Controls.SetChildIndex(this.grpBusqueda, 0);
            this.panel1.Controls.SetChildIndex(this.buttonRendir, 0);
            // 
            // grpBusqueda
            // 
            this.grpBusqueda.Controls.Add(this.txtCantidad);
            this.grpBusqueda.Controls.Add(this.label2);
            this.grpBusqueda.Controls.Add(this.txtARendir);
            this.grpBusqueda.Controls.Add(this.txtPorcentaje);
            this.grpBusqueda.Controls.Add(this.label4);
            this.grpBusqueda.Controls.Add(this.label3);
            this.grpBusqueda.Controls.Add(this.txtTotal);
            this.grpBusqueda.Controls.Add(this.label1);
            this.grpBusqueda.Size = new System.Drawing.Size(398, 106);
            this.grpBusqueda.Text = "Detalle";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(52, 19);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(117, 20);
            this.txtTotal.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Porcentaje";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "A rendir";
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Location = new System.Drawing.Point(88, 48);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(81, 20);
            this.txtPorcentaje.TabIndex = 10;
            this.txtPorcentaje.TextChanged += new System.EventHandler(this.txtPorcentaje_TextChanged);
            // 
            // txtARendir
            // 
            this.txtARendir.Location = new System.Drawing.Point(242, 19);
            this.txtARendir.Name = "txtARendir";
            this.txtARendir.ReadOnly = true;
            this.txtARendir.Size = new System.Drawing.Size(117, 20);
            this.txtARendir.TabIndex = 11;
            // 
            // buttonRendir
            // 
            this.buttonRendir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRendir.Location = new System.Drawing.Point(423, 12);
            this.buttonRendir.Name = "buttonRendir";
            this.buttonRendir.Size = new System.Drawing.Size(154, 94);
            this.buttonRendir.TabIndex = 5;
            this.buttonRendir.Text = "Rendir";
            this.buttonRendir.UseVisualStyleBackColor = true;
            this.buttonRendir.Click += new System.EventHandler(this.buttonRendir_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(242, 48);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.ReadOnly = true;
            this.txtCantidad.Size = new System.Drawing.Size(117, 20);
            this.txtCantidad.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Cantidad";
            // 
            // AbmRendicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 512);
            this.Name = "AbmRendicion";
            this.Text = "ABM Rendicion";
            this.panel1.ResumeLayout(false);
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtARendir;
        private System.Windows.Forms.Button buttonRendir;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label2;
    }
}