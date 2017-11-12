namespace PagoAgilFrba
{
    partial class FormSelSuc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelSuc));
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.lblSuc = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbSucursales
            // 
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(79, 12);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(163, 21);
            this.cbSucursales.TabIndex = 0;
            // 
            // lblSuc
            // 
            this.lblSuc.AutoSize = true;
            this.lblSuc.Location = new System.Drawing.Point(22, 15);
            this.lblSuc.Name = "lblSuc";
            this.lblSuc.Size = new System.Drawing.Size(51, 13);
            this.lblSuc.TabIndex = 1;
            this.lblSuc.Text = "Sucursal:";
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(79, 39);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // FormSelSuc
            // 
            this.AcceptButton = this.btAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 75);
            this.ControlBox = false;
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.lblSuc);
            this.Controls.Add(this.cbSucursales);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSelSuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selección de Sucursal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.Label lblSuc;
        private System.Windows.Forms.Button btAceptar;
    }
}