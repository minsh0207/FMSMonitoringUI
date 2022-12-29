using FMSMonitoringUI.Monitoring;
using FormationMonCtrl;
using MonitoringUI;
using MySqlX.XDevAPI.Relational;
using OPCUAClientClassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMSMonitoringUI.Controlls
{
    public partial class CtrlHPCTemp_old : UserControlEqp
    {
        public CtrlHPCTemp_old()
        {
            InitializeComponent();
        }

        #region Properties
        //string _TitleName = "";
        //[DisplayName("Title Name"), Description("Title Name"), Category("GroupBox Setting")]
        //public string TitleName
        //{
        //    get
        //    {
        //        return _TitleName;
        //    }
        //    set
        //    {
        //        _TitleName = value;
        //        lbRackID.Text = _TitleName;                
        //    }
        //}
        #endregion

        private void InitGridView()
        {
            string[] columnName1 = { "JIG#1", "JIG#2", "JIG#3", "JIG#4", "JIG#5", "JIG#6", "JIG#7", "JIG#8",
                                    "JIG#9", "JIG#10", "JIG#11", "JIG#12", "JIG#13", "JIG#14", "JIG#15"};

            string[] columnName2 = { "JIG#16", "JIG#17", "JIG#18", "JIG#19", "JIG#20", "JIG#21", "JIG#22", "JIG#23",
                                    "JIG#24", "JIG#25", "JIG#26", "JIG#27", "JIG#28", "JIG#29", "JIG#30"};

            List<string> lstTitle = new List<string>();

            foreach (var item in columnName1)
            {
                lstTitle.Add(item);
            }
            TrayInfoView.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("");
            lstTitle.Add("");
            lstTitle.Add("");
            TrayInfoView.AddRowsHeaderList(lstTitle);

            for (int i = 0; i < columnName2.Length; i++)
            {
                TrayInfoView.SetTitle(i, 1, columnName2[i]);
            }
            

            TrayInfoView.ColumnHeadersHeight(30);
            TrayInfoView.RowsHeight(30);

            TrayInfoView.SetGridViewStyles();

            //TrayInfoView.ColumnWidth(0, 100);
            //for (int i = 0; i < columnName.Length; i++)
            //{
            //    TrayInfoView.ColumnWidth(i, 50);
            //}
        }

        #region setData
        public override void SetData(DataRow row)
        {
            //int nRow = int.Parse(row["Location"].ToString());
            //TrayInfoView.SetValue(1, nRow, row["tray_id"].ToString());
            //TrayInfoView.SetReworkTray(1, nRow, row["rework_flag"].ToString());
        }
        #endregion

        private void CtrlEqpControl_Load(object sender, EventArgs e)
        {
            InitGridView();
        }

        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //WinManageEqp form = new WinManageEqp();
            //form.Show();
        }
    }
}
