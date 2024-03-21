using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using ExcelDataReader;
using System.Windows.Forms;
using CL_Covolco;

namespace CL_Covolco
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            ActualizacionRem rem = new ActualizacionRem();

            bool Exportar = rem.ExportarExcel(dataGridView1);
            if (Exportar)
            {

            }
            else
            {

            }

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            Workbook workbook = excelApp.Workbooks.Add();

            Worksheet worksheet = (Worksheet)workbook.Sheets[1];

            int columnCount = dataGridView1.ColumnCount;
            for (int i = 0; i < columnCount; i++)
            {
                worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }

            int rowCount = dataGridView1.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }

            string tempFile = System.IO.Path.GetTempFileName() + ".xls";
            workbook.SaveAs(tempFile);
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {

        }
    }
}
