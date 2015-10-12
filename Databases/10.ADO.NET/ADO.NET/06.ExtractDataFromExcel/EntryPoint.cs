// 06.Create an Excel file with 2 columns: name and score.
// Write a program that reads your MS Excel file through the 
// OLE DB data provider and displays the name and score row by row.

namespace _06.ExtractDataFromExcel
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Text;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            string connectionString = GetConnectionString();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;

                // Get all Sheets in Excel File
                DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                var sheetName = dtSheet.Rows[0]["TABLE_NAME"].ToString();

                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";

                using (var oleDbAdapter = new OleDbDataAdapter(cmd))
                {
                    var dataSet = new DataSet();
                    oleDbAdapter.Fill(dataSet);

                    using (var reader = dataSet.CreateDataReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader["Name"];
                            var score = reader["Score"];
                            Console.WriteLine("{0}: {1}", name, score);
                        }
                    }
                }

                cmd = null;
                conn.Close();
            }
        }

        // http://www.microsoft.com/en-us/download/details.aspx?id=23734 - 2007 Office System Driver
        // http://www.microsoft.com/en-us/download/details.aspx?id=13255 - Microsoft Access Database Engine 2010 Redistributable


        // Reference -> http://www.codeproject.com/Tips/705470/Read-and-Write-Excel-Documents-Using-OLEDB
        private static string GetConnectionString()
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            // XLSX - Excel 2007, 2010, 2012, 2013
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
            props["Extended Properties"] = "Excel 12.0 XML";
            props["Data Source"] = "../../data.xlsx";

            // XLS - Excel 2003 and Older
            //props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            //props["Extended Properties"] = "Excel 8.0";
            //props["Data Source"] = "C:\\MyExcel.xls";

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }

            return sb.ToString();
        }
    }
}
