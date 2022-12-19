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
    public partial class CtrlRack : UserControlEqp
    {
        public CtrlRack()
        {
            InitializeComponent();
        }

        #region Properties
        string _RackID = "";
        [DisplayName("Rack ID"), Description("Rack ID"), Category("GroupBox Setting")]
        public string RackID
        {
            get
            {
                return _RackID;
            }
            set
            {
                _RackID = value;
                lbRackID.Text = string.Format(" Rack ID : {0}", _RackID);                
            }
        }
        #endregion

        private void InitGridView()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Level");
            lstTitle.Add("Tray ID");
            lstTitle.Add("Lot ID");
            lstTitle.Add("");
            TrayInfoView.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("");
            lstTitle.Add("");
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(25);
            TrayInfoView.RowsHeight(25);

            TrayInfoView.SetGridViewStyles();
            TrayInfoView.ColumnWidth(0, 60);

            TrayInfoView.SetTitle(2, 0, "Start Time");
            TrayInfoView.SetTitle(2, 1, "Plan Time");
        }

        #region setData
        public override void SetData(DataRow row)
        {
            //int nRow = int.Parse(row["Location"].ToString());
            //TrayInfoView.SetValue(1, nRow, row["tray_id"].ToString());
            //TrayInfoView.SetReworkTray(1, nRow, row["rework_flag"].ToString());
        }

        public void SetEqpStatus(string eqp_status, Color color)
        {
            lbEqpStatus.Text = eqp_status;
            lbEqpStatus.BackColor = color;
        }

        public void SetOperationStatus(string op_status, Color color)
        {
            lbOPStatus.Text = op_status;
            lbOPStatus.BackColor = color;
        }
        #endregion

        private void CtrlEqpControl_Load(object sender, EventArgs e)
        {
            InitGridView();
        }

        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WinManageEqp form = new WinManageEqp();
            form.Show();
        }
    }
}
