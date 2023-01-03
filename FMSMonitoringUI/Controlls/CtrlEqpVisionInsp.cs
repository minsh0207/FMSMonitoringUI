using FMSMonitoringUI.Monitoring;
using FormationMonCtrl;
using MonitoringUI;
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
    public partial class CtrlEqpVisionInsp : UserControlEqp
    {
        public CtrlEqpVisionInsp()
        {
            InitializeComponent();            
        }

        #region Properties
        string _EqpType = "";
        [DisplayName("EQP TYPE"), Description("EQP TYPE"), Category("GroupBox Setting")]
        public string EqpType
        {
            get
            {
                return _EqpType;
            }
            set
            {
                _EqpType = value;
                lbEqpType.Text = _EqpType;                
            }
        }
        #endregion

        private void InitGridView()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Place TrayID");
            lstTitle.Add("Pick TrayID");
            TrayInfoView.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("");
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(23);
            TrayInfoView.RowsHeight(22);

            TrayInfoView.SetGridViewStyles();
        }

        #region setData
        public override void SetData(DataRow row)
        {
            int nCol = int.Parse(row["Location"].ToString());

            TrayInfoView.SetValue(nCol, 0, row["tray_id"].ToString());
            TrayInfoView.SetReworkTray(nCol, 0, row["rework_flag"].ToString());
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
            WinManageEqp form = new WinManageEqp(EqpID, 2);
            form.ShowDialog();
        }
    }
}
