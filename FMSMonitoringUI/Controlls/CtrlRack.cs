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
            TrayInfoView.ColumnHeadersVisible(false);

            lstTitle = new List<string>();
            lstTitle.Add("Level");
            lstTitle.Add("1");
            lstTitle.Add("2");
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(25);
            TrayInfoView.RowsHeight(25);

            TrayInfoView.SetGridViewStyles();
            TrayInfoView.ColumnWidth(0, 60);

            TrayInfoView.SetTitle(1, 0, "Tray ID");
            TrayInfoView.SetTitle(2, 0, "Lot ID");
            TrayInfoView.SetTitle(2, 1, "Start Time");
            TrayInfoView.SetTitle(2, 2, "Plan Time");

            //TrayInfoView.SetTitle(0, 0, "1");
            //TrayInfoView.SetTitle(0, 1, "2");
        }

        #region setData
        public override void SetData(DataRow row)
        {
            //int nRow = int.Parse(row["Location"].ToString());
            TrayInfoView.SetValue(1, 1, row["tray_id"].ToString());
            TrayInfoView.SetValue(1, 2, row["tray_id_2"].ToString());
            TrayInfoView.SetValue(3, 0, row["lot_id"].ToString());
            //TrayInfoView.SetValue(3, 1, row["start_time"].ToString());
            //TrayInfoView.SetValue(3, 2, row["end_time"].ToString());
            TrayInfoView.SetValue(3, 1, "2022-12-28 10:44:01");
            TrayInfoView.SetValue(3, 2, "2022-12-29 10:44:02");
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
            WinFormationBox form = new WinFormationBox();
            form.Show();
        }
    }
}
