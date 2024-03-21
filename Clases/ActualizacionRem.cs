using System;
using System.Collections.Generic;
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
using System.IO;
using CL_Covolco.Clases;
using System.Data;
using CL_Covolco.Models;

namespace CL_Covolco
{
    public class ActualizacionRem
    {
        DataTable hojaExcel = new DataTable();
        DataTable FilasValidas = new DataTable();
        

        public DataTable ImportarExcel ()
        {
            DataTable TablaExcel = new DataTable();
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivos de Excel|*.xlsx|Archivos de Excel 97-2003|*.xls" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });

                            DataTable dataset = EliminarColumnas(dataSet.Tables[0], "Documento Cliente");
                            dataset.Columns.Add("Observacion");
                            TablaExcel = dataset;
                            this.hojaExcel = TablaExcel;

                        }

                    }


                }

            }
            return TablaExcel;
        }

        public Boolean ExportarExcel(DataGridView dataGridView1)
        {
            bool Export = false;
            try
            {
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


                Export = true;
            }
            catch (Exception e)

            {

            }

            return Export;
        }

        public Boolean ValidarRemesas(DataGridView dataGridView)
        {
            try
            {

                DataTable actualizacionRem = new DataTable();
                actualizacionRem = this.hojaExcel;
                clsConnSqlite sqlite = new clsConnSqlite("");
                SqlConnectionStringBuilder dbsyscom = sqlite.obtenerConexionSQLServer("dbSyscom");
                ConexionBD con = new ConexionBD();
                con.setConnection(dbsyscom);


                List<Remesa> rem = new List<Remesa>();
                List<SqlParameter> Parametros = new List<SqlParameter>();
                string Doccliente = "";

                DataTable tablaRem = new DataTable();
                List<DataTable> listaTablesRemesas = new List<DataTable>();
                int i = 0;

                foreach (DataRow row in actualizacionRem.Rows)
                {
                    Parametros.Add(new SqlParameter("TipDoc", row["TipoDocumento"].ToString()));
                    Parametros.Add(new SqlParameter("NumOrden", row["Numero Orden"]));
                    Parametros.Add(new SqlParameter("IdCia", row["Compañia"]));
                    con.addParametersProc(Parametros);
                    con.ejecutarProcedimiento("SpConsultarRemesaTrn_TraMcias");
                    con.resetQuery();
                    Parametros.Clear();

                    DataSet  TablaConRemesas = con.getDataSet();

                    listaTablesRemesas.Add(TablaConRemesas.Tables[0]);

                }
                foreach (DataTable ValidacionesTables in listaTablesRemesas)
                {
                        

                    if (ValidacionesTables.Rows.Count > 0)
                    {
                        foreach (DataRow rows in ValidacionesTables.Rows)
                        {
                            Doccliente = rows["DocCliente"].ToString();
                        }

                        if (Doccliente == "0")
                        {
                            dataGridView.Rows[i].Cells["Observacion"].Value = "ok";
                            listaTablesRemesas[i] = FilasValidas;

                            
                        }
                        else
                        {
                            dataGridView.Rows[i].Cells["Observacion"].Value = "¡¡Ya existe dato Cliente!!";
                        }
                    }
                    else
                    {
                        dataGridView.Rows[i].Cells["Observacion"].Value = "No existe remesa";
                    }

                    i++;
                }


                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        //public DataTable ActulizacionRemeas()
        //{
        //    DataTable actualizacionRem = new DataTable();
        //    DataTable RemsasAct = new DataTable();
        //    ConexionBD con = new ConexionBD();
        //    List<Remesa> ListaRemesa = new List<Remesa>();
        //    actualizacionRem = hojaExcel;
        //    bool validacion = ValidarRemesas();

        //    if (validacion)
        //    {
        //        try
        //        {
        //            clsConnSqlite sqlite = new clsConnSqlite();
        //            SqlConnectionStringBuilder dbsyscom = sqlite.obtenerConexionSQLServer("dbSyscom");
        //            con.setConnection(dbsyscom);
        //            List<SqlParameter> Parametros = new List<SqlParameter>();

        //            var remesasOrdenadas = actualizacionRem.AsEnumerable()
        //            .OrderBy(row => row.Field<int>("NumeroRemesa"))
        //            .ThenBy(row => row.Field<string>("Compania"))
        //            .ToList();

        //            foreach (var RemOrdenadas in remesasOrdenadas)
        //            {

        //                foreach (DataRow row in actualizacionRem.Rows)
        //                {

        //                    Remesa rem = new Remesa();
        //                    {
        //                        rem.DocCliente = row.Field<String>("DocumentoCliente");
        //                    }


        //                }
        //                //ListaRemesa.Add(rem)
        //            }

        //            Parametros.Add(new SqlParameter("DocCliente", ListaRemesa));
        //            con.addParametersProc(Parametros);
        //            con.ejecutarProcedimiento("spActualizarRemesa");
        //            con.resetQuery();

        //            Parametros.Clear();
        //            con.setConnection(dbsyscom);
        //            con.addParametersProc(Parametros);
        //            con.ejecutarProcedimiento("SpValidarActualizacionRem");
        //            RemsasAct = con.getDataTable();
        //            if (RemsasAct.Rows.Count > 0)
        //            {
        //                actualizacionRem = RemsasAct;
        //            }
        //            else
        //            {

        //            }

        //        }
        //        catch (Exception e)
        //        {

        //        }


        //    }

        //    return actualizacionRem;

        //}

        


        private DataTable EliminarColumnas(DataTable dt, string columnaEspecifica)
        {
            int indiceColumna = dt.Columns.IndexOf(columnaEspecifica);

            if (indiceColumna != -1)
            {
                for (int i = dt.Columns.Count - 1; i > indiceColumna; i--)
                {
                    dt.Columns.RemoveAt(i);
                }
            }
            return dt;
        }
    }
}
