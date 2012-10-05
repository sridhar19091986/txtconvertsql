using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace MongoScorePredict.Extensions
{
    public static class DataTableToTxt
    {
        public static string getDataTableColumnName(DataTable dt1)
        {
            StringBuilder strBuilder = new StringBuilder();

            for (int j = 0; j < dt1.Columns.Count; j++)
            {
                strBuilder.Append(dt1.Columns[j].ColumnName + ' ');
            }
            return strBuilder.ToString();
        }

        public static string DataTable2Txt(DataTable dt1, string filename)
        {
            FileStream sr = File.Open(filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(sr, System.Text.Encoding.Default);
            StringBuilder strBuilder = new StringBuilder();
            StringBuilder sbuilder = new StringBuilder();
            try
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    strBuilder = new StringBuilder();
                    for (int j = 0; j < dt1.Columns.Count; j++)
                    {
                        strBuilder.Append(Convert.ToDouble(dt1.Rows[i][j]).ToString("f3") + ' ');//保留小数点2位置
                    }
                    strBuilder.Remove(strBuilder.Length - 1, 1);
                    sw.WriteLine(strBuilder.ToString());
                    sbuilder.AppendLine(strBuilder.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                sw.Close();
                sr.Close();
            }
            return sbuilder.ToString();
        }

        public static void DataTable2TxtAll(DataTable dt1, string filename)
        {
            FileStream sr = File.Open(filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(sr, System.Text.Encoding.Default);
            StringBuilder strBuilder = new StringBuilder();
            StringBuilder sbuilder = new StringBuilder();
            try
            {
                for (int j = 0; j < dt1.Columns.Count; j++)
                {
                    strBuilder.Append(dt1.Columns[j].ColumnName + ",");
                }
                sw.WriteLine(strBuilder.ToString());
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    strBuilder = new StringBuilder();
                    for (int j = 0; j < dt1.Columns.Count; j++)
                    {
                        strBuilder.Append(dt1.Rows[i][j].ToString() + ",");//保留小数点2位置
                    }
                    strBuilder.Remove(strBuilder.Length - 1, 1);
                    sw.WriteLine(strBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                sw.Close();
                sr.Close();
            }
        }
    }
}
