namespace PagoAgilFrba
{
    partial class EditorCliente
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
            this.ckHabilitado = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgFuncionalidades = new System.Windows.Forms.DataGridView();
            this.S = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Privilegio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPrivilegio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFuncionalidades)).BeginInit();
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
            // ckHabilitado
            // 
            this.ckHabilitado.AutoSize = true;
            this.ckHabilitado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckHabilitado.Location = new System.Drawing.Point(19, 45);
            this.ckHabilitado.Name = "ckHabilitado";
            this.ckHabilitado.Size = new System.Drawing.Size(73, 17);
            this.ckHabilitado.TabIndex = 3;
            this.ckHabilitado.Text = "Habilitado";
            this.ckHabilitado.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgFuncionalidades);
            this.groupBox1.Location = new System.Drawing.Point(12, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 286);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funcionalidades";
            // 
            // dgFuncionalidades
            // 
            this.dgFuncionalidades.AllowUserToAddRows = false;
            this.dgFuncionalidades.AllowUserToDeleteRows = false;
            this.dgFuncionalidades.AllowUserToResizeColumns = false;
            this.dgFuncionalidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgFuncionalidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.S,
            this.Privilegio,
            this.IdPrivilegio});
            this.dgFuncionalidades.Location = new System.Drawing.Point(16, 19);
            this.dgFuncionalidades.Name = "dgFuncionalidades";
            this.dgFuncionalidades.Size = new System.Drawing.Size(376, 261);
            this.dgFuncionalidades.TabIndex = 0;
            // 
            // S
            // 
            this.S.FalseValue = "0";
            this.S.HeaderText = "S";
            this.S.Name = "S";
            this.S.TrueValue = "1";
            this.S.Width = 20;
            // 
            // Privilegio
            // 
            this.Privilegio.HeaderText = "Privilegio";
            this.Privilegio.Name = "Privilegio";
            this.Privilegio.ReadOnly = true;
            this.Privilegio.Width = 250;
            // 
            // IdPrivilegio
            // 
            this.IdPrivilegio.HeaderText = "IdPrivilegio";
            this.IdPrivilegio.Name = "IdPrivilegio";
            this.IdPrivilegio.ReadOnly = true;
            this.IdPrivilegio.Visible = false;
            // 
            // EditorRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 394);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ckHabilitado);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Name = "EditorRol";
            this.Text = "EditorRol";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNombre, 0);
            this.Controls.SetChildIndex(this.ckHabilitado, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFuncionalidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.CheckBox ckHabilitado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgFuncionalidades;
        private System.Windows.Forms.DataGridViewCheckBoxColumn S;
        private System.Windows.Forms.DataGridViewTextBoxColumn Privilegio;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPrivilegio;
    }
}