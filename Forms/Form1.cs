using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using ExcelDataReader;
using DataTable = System.Data.DataTable;
using SyscomUtilities;
using System.Data.SqlClient;
using CL_Covolco;

namespace CL_Covolco
{
    public partial class Importarexc : Form
    {
        ActualizacionRem rem = new ActualizacionRem();

        public Importarexc()
        {
            InitializeComponent();
            this.BtnExportar.Visible = false;
        }

        private void BtnImportarArch_Click(object sender, EventArgs e)
        {
            rem = new ActualizacionRem();

            dataGridView1.DataSource = rem.ImportarExcel();

            int i = 0; // Incrementa el índice de fila en lugar de usar una variable externa
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                row.Cells["Item"].Value = (i + 1).ToString();
                i++;
            }
            txtRegistros.Text = "Total de registros: " + (i - 1).ToString();

            dataGridView1.Columns[0].HeaderText = "Item";
            dataGridView1.Columns[1].HeaderText = "Tipo Documento";
            dataGridView1.Columns[2].HeaderText = "Numero Orden";
            dataGridView1.Columns[3].HeaderText = "Compañia";
            dataGridView1.Columns[4].HeaderText = "Documento Cliente";
            

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeColumns();
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11);
        }
       

        private void BtnListado_Click(object sender, EventArgs e)
        {
            using (Form2 ListadoRemesas = new Form2())
            ListadoRemesas.ShowDialog();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            ActualizacionRem rem = new ActualizacionRem();
            Boolean Export;
            Export = rem.ExportarExcel(dataGridView1);

            if (Export)
            {

            }
            else
            {

            }
            
        }

        private void BtnValidar_Click(object sender, EventArgs e)
        {
            bool valida = rem.ValidarRemesas(dataGridView1);
            if (valida)
            {
                MessageBox.Show("Validacion Exitosa");

            }
            this.BtnExportar.Visible = true;






        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            DataTable RemActualizadas = rem.ActulizacionRemeas();
            Form2 form2 = new Form2();
            form2.SetDataTable(RemActualizadas);

        }
    }

}
