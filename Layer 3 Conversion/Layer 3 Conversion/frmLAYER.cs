using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO ;
using System.Xml;
using LayerSQL;
using LayerEXCEL;
using System.Collections;
using System.Runtime.InteropServices;
using System.Globalization;

namespace Layer_3_Conversion
{
    public partial class frmLAYER : Form
    {
        public frmLAYER()
        {
            InitializeComponent();
        }
        public class parameterName
        {
            private string[] _parameterNames = new string[3];
            public string this[int index]
            {
                get
                {
                    if (index >= 0 || index < _parameterNames.Length)
                    {
                        return _parameterNames[index];
                    }
                    return string.Empty;
                }
                set
                {
                    if (index >= 0 || index < _parameterNames.Length)
                    {
                        _parameterNames[index] = value;
                    }
                }
            }
        }
        public class layer3Message
        {
            public int Frame { get; set; }
            public int Addr { get; set; }
            public string TTime { get; set; }
            public string tMessage { get; set; }
            public string lMessage { get; set; }
            public parameterName parameterNames = new parameterName();
        }
        private void ttipLayerbtnOpen_Click(object sender, EventArgs e)
        {
            selectTab("打开文件");
            //打开文件夹子
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mstipLayerlbFilepath.Text = openFileDialog1.FileName;
            }
            else
            {
                return;
            }

            StreamReader sr = new StreamReader(mstipLayerlbFilepath.Text);
            int line = 0;
            while (sr.ReadLine() != null)
            {
                line++;
            }
            toolStripProgressBar1.Maximum = line;
            layer3Message Messages = new layer3Message();
            StreamReader objReader = new StreamReader(mstipLayerlbFilepath.Text);
            string sLine = "";
            int index = -1;
            int addr = -1;
            string strPar = "";
            string strVal = "";
            string strSql = "";
            string strMsg = "";
            while (!objReader.EndOfStream)
            {

                addr++;
                Messages.Addr = addr;
                toolStripProgressBar1.Value = addr;
                sLine = objReader.ReadLine();
                sLine = sLine.Replace("'", "");
                sLine = sLine.Replace("'", "");
                sLine = sLine.Replace("'", "");
                sLine = sLine.Replace("'", "");
                sLine = sLine.Replace("'", "");
                if (sLine != null)
                {
                    //消息帧号、位置、类型
                    if (sLine.IndexOf("***") != -1)
                    {
                        index++;
                        Messages.Frame = index;
                        strMsg = sLine.Replace("*", "");
                        Messages.tMessage = strMsg.Substring(0, strMsg.IndexOf(":"));
                        Messages.lMessage = strMsg.Substring(Messages.tMessage.Length + 1);
                        Messages.tMessage = Messages.tMessage.Trim();
                        Messages.lMessage = Messages.lMessage.Trim();
                    }
                    //消息时间
                    if (sLine.IndexOf("Time:") != -1)
                    {
                        Messages.TTime = sLine.Substring(sLine.Substring(0, sLine.IndexOf(":")).Length + 1).Trim();
                    }
                    //消息参数
                    if (sLine != "" && addr != 1)
                    {
                        if (sLine.IndexOf(":") != -1)
                        {
                            strPar = sLine.Substring(0, sLine.IndexOf(":"));
                            strVal = sLine.Substring(strPar.Length + 1);
                            Messages.parameterNames[0] = strPar;
                            Messages.parameterNames[1] = strVal;
                        }
                        else
                        {
                            Messages.parameterNames[0] = sLine;
                            Messages.parameterNames[1] = "";
                        }
                        strSql = "insert into tbLayer values ('"
                        + Messages.Frame + "','" + Messages.Addr + "','" + Messages.TTime + "','" + Messages.tMessage + "','"
                        + Messages.lMessage + "','" + Messages.parameterNames[0] + "','" + Messages.parameterNames[1] + "')";
                        Acc.RunNoQuery(strSql);
                        //lbLay3Message.Items.Add(strSql);
                    }
                    Application.DoEvents();
                }
            }
        }

        private void ttipLayerClearDB_Click(object sender, EventArgs e)
        {
            selectTab("打开文件");
            lbLay3Message.Items.Clear();
            Acc.RunNoQuery("if exists(select * from sysobjects where name='tbLayer' and type='u') drop table tbLayer");
            Acc.RunNoQuery("if exists(select * from sysobjects where name='tbResult' and type='u') drop table tbResult");
            Acc.RunNoQuery("if exists(select * from sysobjects where name='tbFilter' and type='u') drop table tbFilter");
            string strSql= "create table tbLayer(Frame int, Addr int primary key, TTime  nvarchar(50),tMessage nvarchar(50)," +
                           "lMessage nvarchar(50),Strpar nvarchar(255),Strval nvarchar(255))";
            Acc.RunNoQuery(strSql);
            Acc.RunNoQuery( "create table tbFilter(lMessage nvarchar(50) primary key)");
           
        }
        string appPath;
        LayerSQL.IDBAccess Acc = LayerSQL.DBAccessFactory.Create(LayerSQL.DBType.SQL);
        private void frmLAYER_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            appPath = Application.StartupPath.ToString();
            Acc.Init(null, "master", null, null);
            //Acc.Init("", appPath + "\\Db\\Layer.accdb", "", "");
            Acc.Open();

            DataTable sdr = Acc.RunQuery("if exists(select * from sysobjects where name='tbResult' and type='u') select distinct Frame,lMessage from  tbResult order by Frame asc");
            foreach (DataRow row in sdr.Rows)
            {
                lbLay3Message.Items.Add(row[0].ToString() + "-" + row[1].ToString());
            }

            DataTable dt = Acc.RunQuery("select name from master..sysdatabases");
            for (int i = 0; i < dt.Rows.Count; i++)
                toolStripComboBox1.Items.Add(dt.Rows[i][0].ToString());


            //toolStripComboBox1.Text = "master";

            ////加载XML，用xmldocument读取
            //TreeNode newNode4 = tvSql.Nodes.Add("Layer3C");
            //XmlDocument myDoc1 = new XmlDocument();
            //myDoc1.Load(appPath + "\\Db\\Layer.xml");
            ////搜索节点，显示到treeview中
            //System.Xml.XmlNodeList nodes2 = myDoc1.GetElementsByTagName("Layer3C");
            //if (nodes2 != null)
            //{
            //    foreach (System.Xml.XmlNode xn in nodes2)
            //    {
            //        newNode4.Nodes.Add(xn.Attributes.Item(1).Value.ToString());
            //    }
            //}
            //tvSql.ExpandAll();
            //tvSql.SelectedNode = tvSql.Nodes[0];


            ////写树目录
            //TreeNode newNode1 = new TreeNode() ;
            //TreeNode newNode2 =new TreeNode() ; 
            //tvFilterOut.Nodes.Add(ShowAllTree("Layer 3 Message type", newNode1));
            //tvFilterOut.Nodes.Add(ShowAllTree("Mode Report Message type", newNode2));
            //tvFilterOut.ExpandAll();
            //tvFilterOut.SelectedNode = tvFilterOut.Nodes[0];
            ////写筛选目录
            //DataTable sdr1 = Acc.RunQuery("select distinct lMessage from  tbFilter ");
            //foreach (DataRow row in sdr1.Rows)
            //{
            //    lbFilterIn.Items.Add(row[0].ToString());
            //}
            //sdr1.Dispose();

        }
        //根据数据库，动态显示多级树treeview
        private TreeNode ShowAllTree(string strParent, TreeNode node)
        {
            DataTable dt = Acc.RunQuery("select distinct lMessage,tMessage from  tbLayer where tMessage='" + strParent + "'");
            node.Text = strParent;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode newNode = new TreeNode(dt.Rows[i][0].ToString());
                node.Nodes.Add(newNode);
            }
            dt.Dispose();
           return node;
        }  

        private void lbLay3Message_SelectedIndexChanged(object sender, EventArgs e)
        {
            //写筛选目录
            lbMessagePara.Items.Clear();
            string index = lbLay3Message.SelectedItem.ToString();
            index = index.Substring(0, index.IndexOf("-"));
            //DataTable sdr1 = Acc.RunQuery("select * from   tbLayer  where Frame= " + index);
            DataTable sdr1 = Acc.RunQuery("select * from   tbResult  where Frame= " + index);
            foreach (DataRow row in sdr1.Rows)
            {
                lbMessagePara.Items.Add(row[5].ToString() + ":" + row[6].ToString());
            }
            sdr1.Dispose();
        }

        private void ttipLayerFilter_Click(object sender, EventArgs e)
        {
            selectTab("打开文件");
            lbLay3Message.Items.Clear();
            Acc.RunNoQuery("if exists(select * from sysobjects where name='tbResult' and type='u') drop table tbResult");
            //新建过滤数据库
            Acc.RunNoQuery("select * into tbResult  from  tbLayer where lMessage in (select lMessage from tbFilter) ");
            //过滤数据库显示在listbox中
            DataTable sdr = Acc.RunQuery("select distinct Frame,lMessage from tbResult order by Frame");
            foreach (DataRow row in sdr.Rows)
            {
                lbLay3Message.Items.Add(row[0].ToString() + "-" + row[1].ToString());
            }

        }
        //选中根节点，返回函数不处理
        private void tvFilterOut_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvFilterOut.SelectedNode.Text == "Layer 3 Message type")
            {
                return;
            }
            else
            {
                if (lbFilterIn.Items.Count == 0)
                {
                    lbFilterIn.Items.Add(tvFilterOut.SelectedNode.Text);
                }
                else
                {
                    //已经添加过空返回
                    for (int i = 0; i < lbFilterIn.Items.Count; i++)
                    {
                        if (tvFilterOut.SelectedNode.Text == lbFilterIn.Items[i].ToString())
                        {
                            MessageBox.Show("已经添加过了");
                            return;
                        }
                    }
                    //否则继续增加
                    lbFilterIn.Items.Add(tvFilterOut.SelectedNode.Text);
                }
            }
            saveFilter();
        }

        private void ttipLayerExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbFilterIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbFilterIn.Items.Remove(lbFilterIn.SelectedItem);
            saveFilter();
        }
        //保存过滤结果到数据库
        private void saveFilter()
        {
            Acc.RunNoQuery("delete from tbFilter");
            for (int i = 0; i < lbFilterIn.Items.Count; i++)
            {
                Acc.RunNoQuery("insert into tbFilter( lMessage) values('" + lbFilterIn.Items[i].ToString() + "')");
            }
        }
        private void selectTab(string TabName)
        {
            for (int i = 0; i <= 2; i++)
            {
                if (tcLayer.TabPages[i].Name == TabName)
                {
                    tcLayer.SelectedIndex = i;
                }
            }
        }
        //提取xml文件到datagridview
        private void ttipLayerGetXml_Click(object sender, EventArgs e)
        {
            selectTab("信令分析");
            DataSet ds = new DataSet();
            ds.ReadXml(appPath + "\\Db\\Layer.xml");
            this.dgvPara.AutoGenerateColumns = true;
            this.dgvPara.DataSource = new DataView(ds.Tables[0]);
            this.dgvPara.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPara.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvPara.BorderStyle = BorderStyle.Fixed3D;
            this.dgvPara.EditMode = DataGridViewEditMode.EditOnEnter;
            this.dgvPara.GridColor = Color.Blue;
        }
        //把datagridview的内容写入xml
        private void ttipLayerWriteXml_Click(object sender, EventArgs e)
        {
            selectTab("信令分析");
            //Messagebox所属于的类
            DialogResult result;
            result = MessageBox.Show(this, "YesOrNo", "你确定要更新xml数据吗？", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Messagebox返回的值
            if (result == DialogResult.Yes)
            {
                DataView dv = this.dgvPara.DataSource as DataView;   //dataGridview的数据返回到内存
                DataTable dt = dv.Table.Copy();                          //复制数据到  DATATABLE 中
                if (dt == null)
                {
                    return;
                }
                dt.WriteXml(appPath + "\\Db\\Layer.xml"); //写入XML 
            }
        }
        //选中根节点空返回
        private void tvSql_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvSql.SelectedNode.Text == "Layer3C")
            {
                return;
            }
            else
            {
                TreeNode Node1 = this.tvSql.GetNodeAt(this.tvSql.PointToClient(Control.MousePosition));
                XmlDocument myDoc1 = new XmlDocument();
                myDoc1.Load(appPath + "\\Db\\Layer.xml");
                System.Xml.XmlNodeList nodes2 = myDoc1.GetElementsByTagName("Layer3C");
                if (nodes2 != null)
                {
                    foreach (System.Xml.XmlNode xn in nodes2)
                    {
                        //根据treeview节点的内容，从xml读取相应的sql语句，放入richbox中
                        if (Node1.Text == xn.Attributes.Item(1).Value.ToString())
                        {
                            rtxtSql.Text = xn.Attributes.Item(2).Value.ToString();
                            mstipLayerlbStrsql.Text = Node1.Text;
                        }
                    }
                }
                try
                {
                    if (Node1 != null)
                    {  
                        //执行richbox中sql语句的查询
                        DataTable dt = Acc.RunQuery(rtxtSql.Text);
                        {
                            this.dgvPara.AutoGenerateColumns = true;
                            this.dgvPara.DataSource = dt.DefaultView;
                            this.dgvPara.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            this.dgvPara.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                            this.dgvPara.BorderStyle = BorderStyle.Fixed3D;
                            this.dgvPara.EditMode = DataGridViewEditMode.EditOnEnter;
                            this.dgvPara.GridColor = Color.Blue;
                        }
                        dt.Dispose();
                    }
                }
                catch
                {
                }
            }
        }

        private void 信令分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectTab("信令分析");
            tvSql.Nodes.Clear();
            //加载XML，用xmldocument读取
            TreeNode newNode4 = tvSql.Nodes.Add("Layer3C");
            XmlDocument myDoc1 = new XmlDocument();
            myDoc1.Load(appPath + "\\Db\\Layer.xml");
            //搜索节点，显示到treeview中
            System.Xml.XmlNodeList nodes2 = myDoc1.GetElementsByTagName("Layer3C");
            if (nodes2 != null)
            {
                foreach (System.Xml.XmlNode xn in nodes2)
                {
                    newNode4.Nodes.Add(xn.Attributes.Item(1).Value.ToString());
                }
            }
            tvSql.ExpandAll();
            tvSql.SelectedNode = tvSql.Nodes[0];
        }

        private void 信令过滤ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectTab("信令过滤");
            tvFilterOut.Nodes.Clear();
            lbFilterIn.Items.Clear();
            //写树目录
            TreeNode newNode1 = new TreeNode();
            TreeNode newNode2 = new TreeNode();
            tvFilterOut.Nodes.Add(ShowAllTree("Layer 3 Message type", newNode1));
            tvFilterOut.Nodes.Add(ShowAllTree("Mode Report Message type", newNode2));
            tvFilterOut.ExpandAll();
            tvFilterOut.SelectedNode = tvFilterOut.Nodes[0];
            //写筛选目录
            DataTable sdr1 = Acc.RunQuery("select distinct lMessage from  tbFilter ");
            foreach (DataRow row in sdr1.Rows)
            {
                lbFilterIn.Items.Add(row[0].ToString());
            }
            sdr1.Dispose();
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectTab("打开文件");
            DataTable sdr = Acc.RunQuery("if exists(select * from sysobjects where name='tbResult' and type='u') select distinct Frame,lMessage from  tbResult order by Frame asc");
            foreach (DataRow row in sdr.Rows)
            {
                lbLay3Message.Items.Add(row[0].ToString() + "-" + row[1].ToString());
            }
        }

        private void 帮助HToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Layer 3 Conversion v1.0 Update 2009.2.2");
        }

        private void 退出系统EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rtxtSql_TextChanged(object sender, EventArgs e)
        {
            int index = this.rtxtSql.SelectionStart;    //记录修改的位置
            this.rtxtSql.SelectAll();
            this.rtxtSql.SelectionColor = Color.Black;
            string[] keystr = { "select", "Select", "from", "where", ",", "=", "'" ,"(",")"};
            for (int i = 0; i < keystr.Length; i++)
                this.getbunch(keystr[i], this.rtxtSql.Text);
            this.rtxtSql.Select(index, 0);     //返回修改的位置
            this.rtxtSql.SelectionColor = Color.Black;
        }

        public int getbunch(string p, string s) //给关键字上色
        {
            int cnt = 0; int M = p.Length; int N = s.Length;
            char[] ss = s.ToCharArray(), pp = p.ToCharArray();
            if (M > N) return 0;
            for (int i = 0; i < N - M + 1; i++)
            {
                int j;
                for (j = 0; j < M; j++)
                {
                    if (ss[i + j] != pp[j]) break;
                }
                if (j == p.Length)
                {
                    this.rtxtSql.Select(i, p.Length);
                    this.rtxtSql.SelectionColor = Color.Blue;
                    this.rtxtSql.SelectionFont = new Font("Arial", 10, FontStyle.Bold);
                    cnt++;
                }
            }
            return cnt;

        }
        [DllImport("user32")] 
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam); 
        private const int WM_SETREDRAW = 0xB; 
        //停止控件的重绘 
        private void BeginPaint()
        {
            SendMessage(rtxtSql.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
        }

        //允许控件重绘. 
        private void EndPaint()
        {
            SendMessage(rtxtSql.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
            rtxtSql.Refresh();
        }

        //剪切板操作
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(lbMessagePara.SelectedItem.ToString(), true);
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               string str = mstipLayerlbStrsql.Text;
               string sheetname = "";
                //枚举，获取字符的属性，汉字和字母
               foreach (char c in str)
               {
                   if (char.GetUnicodeCategory(c) == UnicodeCategory.OtherLetter
                       || char.GetUnicodeCategory(c) == UnicodeCategory.UppercaseLetter
                       || char.GetUnicodeCategory(c) == UnicodeCategory.LowercaseLetter)
                   {
                       sheetname+=c.ToString();
                   }
               } 
               LayerEXCEL.EXL.ExportForDataGridview(dgvPara, sheetname, true);
            }
            catch { }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            //toolStripComboBox1.Items.Clear();
            //DataTable dt = Acc.RunQuery("select name from master..sysdatabases");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //    toolStripComboBox1.Items.Add(dt.Rows[i][0].ToString());
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string db = toolStripComboBox1.SelectedItem.ToString();
            Acc.RunNoQuery("use [" + db+ "]");
            MessageBox.Show(db);

            //Acc.Close();
            //Acc.Init(null, db, null, null);
            //Acc.Open();
        }

        private void btnRunScript_Click(object sender, EventArgs e)
        {
            // 进度，事件
            try
            {
                DataTable dt = Acc.RunQuery(rtxtSql.Text);
                {
                    this.dgvPara.AutoGenerateColumns = true;
                    this.dgvPara.DataSource = dt.DefaultView;
                    this.dgvPara.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    this.dgvPara.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    this.dgvPara.BorderStyle = BorderStyle.Fixed3D;
                    this.dgvPara.EditMode = DataGridViewEditMode.EditOnEnter;
                    this.dgvPara.GridColor = Color.Blue;
                }
                dt.Dispose();
            }
            catch (Exception ex)
            {
                //throw ex;
                rtxtEvent.Text = ex.ToString();
            }
        }
   

    }
}
