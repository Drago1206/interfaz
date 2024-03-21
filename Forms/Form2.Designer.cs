namespace CL_Covolco
{
    partial class Form2
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.NumeroProceso = new System.Windows.Forms.TextBox();
            this.FechaProceso = new System.Windows.Forms.TextBox();
            this.Remesa = new System.Windows.Forms.TextBox();
            this.DocumentoCliente = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.BtnGenerar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Aquamarine;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 65);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Listado de remesas";
            // 
            // NumeroProceso
            // 
            this.NumeroProceso.Location = new System.Drawing.Point(26, 137);
            this.NumeroProceso.Name = "NumeroProceso";
            this.NumeroProceso.Size = new System.Drawing.Size(154, 22);
            this.NumeroProceso.TabIndex = 1;
            this.NumeroProceso.Text = "Numero Proceso";
            // 
            // FechaProceso
            // 
            this.FechaProceso.Location = new System.Drawing.Point(226, 137);
            this.FechaProceso.Name = "FechaProceso";
            this.FechaProceso.Size = new System.Drawing.Size(158, 22);
            this.FechaProceso.TabIndex = 2;
            this.FechaProceso.Text = "Fecha Proceso";
            // 
            // Remesa
            // 
            this.Remesa.Location = new System.Drawing.Point(418, 137);
            this.Remesa.Name = "Remesa";
            this.Remesa.Size = new System.Drawing.Size(174, 22);
            this.Remesa.TabIndex = 3;
            this.Remesa.Text = "Remesa";
            // 
            // DocumentoCliente
            // 
            this.DocumentoCliente.Location = new System.Drawing.Point(631, 137);
            this.DocumentoCliente.Name = "DocumentoCliente";
            this.DocumentoCliente.Size = new System.Drawing.Size(166, 22);
            this.DocumentoCliente.TabIndex = 4;
            this.DocumentoCliente.Text = "Documento Cliente";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vScrollBar1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(26, 263);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(771, 434);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(744, 12);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 416);
            this.vScrollBar1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(765, 416);
            this.dataGridView1.TabIndex = 0;
            // 
            // BtnExportar
            // 
            this.BtnExportar.Location = new System.Drawing.Point(444, 222);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(108, 35);
            this.BtnExportar.TabIndex = 6;
            this.BtnExportar.Text = "Exportar";
            this.BtnExportar.UseVisualStyleBackColor = true;
            this.BtnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.Location = new System.Drawing.Point(249, 222);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(106, 35);
            this.BtnGenerar.TabIndex = 7;
            this.BtnGenerar.Text = "Generar";
            this.BtnGenerar.UseVisualStyleBackColor = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 732);
            this.Controls.Add(this.BtnGenerar);
            this.Controls.Add(this.BtnExportar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DocumentoCliente);
            this.Controls.Add(this.Remesa);
            this.Controls.Add(this.FechaProceso);
            this.Controls.Add(this.NumeroProceso);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Listado de remesas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox NumeroProceso;
        private System.Windows.Forms.TextBox FechaProceso;
        private System.Windows.Forms.TextBox Remesa;
        private System.Windows.Forms.TextBox DocumentoCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnExportar;
        private System.Windows.Forms.Button BtnGenerar;
        private System.Windows.Forms.Label label1;
    }
}

