
/*
 * 
 * 第4步
 * 
 * 写入mongo，由matlab操作
 * 
 * 
 * 遍历预测为空的，按照日期进行滚动预测？
 * 
 * 
 * 按照日期进行分割。滚动预测。
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoScorePredict.DataMingForMatlab
{
    class DataMingForMatlab
    {

        public void create()
        {
            SimulinkMatchNow smm = new SimulinkMatchNow();
            smm.mongocrud.BulkMongo(matchnowf.ToList(), true);

            SimulinkMatchOver smo = new SimulinkMatchOver();
            smo.mongocrud.BulkMongo(matchover.ToList(), true);

            strBuilder = new StringBuilder();
            for (int j = start_column; j < dataGridView1.Columns.Count; j++)
            {
                strBuilder.Append(dataGridView1.Rows[i].Cells[j].Value.ToString() + ' ');
            }
            strBuilder.Remove(strBuilder.Length - 1, 1);
            sw.WriteLine(strBuilder.ToString());

}
        int simulinkno = 0;
        private void SimulinkGRNN()
        {
            simulinkno++;
            bool lessDimention = false;
            richTextBox3.Text = string.Empty;
            ExportToExcel.DataGridView2Txt(dataGridView2, nn.tempy, 7);
            ExportToExcel.DataGridView2Txt(dataGridView3, nn.tempx, 7);
            StreamReader streamx = new StreamReader(nn.tempx, System.Text.Encoding.Default);
            StreamReader streamy = new StreamReader(nn.tempy, System.Text.Encoding.Default);
            SimulinkRbfLog srlog = new SimulinkRbfLog();
            SimulinkRbf simulinkrbf = new SimulinkRbf();
            try
            {
                //MessageBox.Show("ok");
                //exe文件方式
                //result = ExportToExcel.SimulinkNN(@"D:\My Documents\MATLAB\mygrnn.exe");
                //dll文件方式
                #region MyRegion  //测试程序
                srlog._id = simulinkno;
                srlog.matchtype = label9.Text;
                srlog.matchover = streamy.ReadToEnd();   //y是训练用
                srlog.matchnow = streamx.ReadToEnd();  //x是预测目标
                if (srlog.matchnow.Length < 10 || srlog.matchover.Length < 10) lessDimention = true;
                if (lessDimention)
                {
                    simulinkrbf.mongocrud.MongoCol.Insert(srlog);
                    return;
                }
                srlog.grnn = nn.NewGrnn();
                srlog.pnn = nn.NewPnn();
                simulinkrbf.mongocrud.MongoCol.Insert(srlog);
                var result = mergeGrnnPnn(srlog.grnn, srlog.pnn);
                #endregion

                //dataGridView3.Columns.Add("...", "...");
                dataGridView3.Columns.Add("MyGRNN", "MyGRNN");

                int colx = dataGridView3.Columns.Count - 1;
                int ix = 0;
                //string[] lines = result.Split(new char[] { '\r', '\n' });
                foreach (string line in result)
                //if (line != null)
                //    if (line.Trim().Length > 0)
                //        if (line.IndexOf("=") == -1)
                //        {
                {
                    richTextBox3.Text += line + "\r\n";
                    dataGridView3.Rows[ix].Cells[colx].Value = line;
                    ix++;

                }
                //}


                using (DataClassesMatchDataContext matches = new DataClassesMatchDataContext(Conn.conn))
                {
                    int resultid = 0;
                    int col = dataGridView3.Columns.Count - 1;
                    string grnnfit = null;
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        resultid = Int32.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());
                        grnnfit = dataGridView3.Rows[i].Cells[col].Value.ToString();
                        var mar = matches.Match_analysis_result
                            .Where(e => e.Analysis_result_id == resultid).First();//查找需要更新的数据
                        mar.Grnn_fit = grnnfit.Trim();
                    }
                    matches.SubmitChanges();
                }
                //MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                streamx.Close(); streamx.Dispose();
                streamy.Close(); streamy.Dispose();
            }
        }
    }
}
