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
    public partial class CtrlEqpDegas : UserControlEqp
    {
        public CtrlEqpDegas()
        {
            InitializeComponent();

            TrayInfoView.MouseCellDoubleClick_Evnet += TrayInfoView_MouseCellDoubleClick;
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
            lstTitle.Add("Location");
            lstTitle.Add("Tray ID");
            TrayInfoView.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("Place");
            lstTitle.Add("Pick");
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(21);
            TrayInfoView.RowsHeight(21);

            TrayInfoView.SetGridViewStyles();
            TrayInfoView.ColumnWidth(0, 70);
        }

        #region setData
        public override void SetData(DataRow row)
        {
            int nRow = int.Parse(row["Location"].ToString());
            TrayInfoView.SetValue(1, nRow, row["tray_id"].ToString());
            TrayInfoView.SetReworkTray(1, nRow, row["rework_flag"].ToString());
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

        #region DataGridView Event
        private void TrayInfoView_MouseCellDoubleClick(int col, int row, object value)
        {
            WinTrayInfo form = new WinTrayInfo();
            form.SetData(value.ToString());
            form.ShowDialog();
        }
        #endregion

        private void CtrlEqpControl_Load(object sender, EventArgs e)
        {
            InitGridView();
        }

        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WinManageEqp form = new WinManageEqp(EqpID, EqpType, 2);
            form.ShowDialog();
        }
    }
}
