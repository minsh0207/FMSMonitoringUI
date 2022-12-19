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
    public partial class CtrlRackTemp : UserControlEqp
    {
        public CtrlRackTemp()
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
            string[] columnName = { "", "JIG#1", "JIG#2", "JIG#3", "JIG#4", "JIG#5", "JIG#6", "JIG#7", "JIG#8",
                                    "JIG#9", "JIG#10", "JIG#11", "JIG#12", "JIG#13", "JIG#14", "JIG#15", "JIG#16"};

            string[] rowName = { "Rack#1", "Rack#2", "Rack#3", "Rack#4", "Rack#5", 
                                 "Rack#6", "Rack#7", "Rack#8", "Rack#9", "Rack#10", "Rack#11"};
            List<string> lstTitle = new List<string>();

            foreach (var item in columnName)
            {
                lstTitle.Add(item);
            }
            TrayInfoView.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            foreach (var item in rowName)
            {
                lstTitle.Add(item);
            }
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(28);
            TrayInfoView.RowsHeight(26);

            TrayInfoView.SetGridViewStyles();

            TrayInfoView.ColumnWidth(0, 100);
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
