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
    public partial class CtrlHPC : UserControlEqp
    {
        public CtrlHPC()
        {
            InitializeComponent();
        }

        #region Properties
        string _HpcID = "";
        [DisplayName("HPC ID"), Description("HPC ID"), Category("GroupBox Setting")]
        public string HpcID
        {
            get
            {
                return _HpcID;
            }
            set
            {
                _HpcID = value;
                lbRackID.Text = _HpcID;
            }
        }
        #endregion

        private void InitGridView()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("");
            lstTitle.Add("");
            TrayInfoView.AddColumnHeaderList(lstTitle);
            TrayInfoView.ColumnHeadersVisible(false);

            lstTitle = new List<string>();
            lstTitle.Add("Control Mode");
            lstTitle.Add("Status");
            lstTitle.Add("Operation Mode");
            lstTitle.Add("Current Process");
            lstTitle.Add("Start Time");
            lstTitle.Add("Plan Time");
            lstTitle.Add("Avg Temp");
            lstTitle.Add("Pressure");
            lstTitle.Add("Trouble Code");
            lstTitle.Add("Trouble Name");
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(30);
            TrayInfoView.RowsHeight(30);

            TrayInfoView.SetGridViewStyles();
            TrayInfoView.ColumnWidth(0, 140);
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
            WinFormationHPC form = new WinFormationHPC();
            form.Show();
        }
    }
}
