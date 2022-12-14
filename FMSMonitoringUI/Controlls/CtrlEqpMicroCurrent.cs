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
    public partial class CtrlEqpMicroCurrent : UserControlEqp
    {
        public CtrlEqpMicroCurrent()
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
            lstTitle.Add("Tray ID");
            TrayInfoView.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            lstTitle.Add("");
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(22);
            TrayInfoView.RowsHeight(21);

            TrayInfoView.SetGridViewStyles();
        }

        #region setData
        public override void SetData(DataRow row)
        {
            int nRow = int.Parse(row["Location"].ToString());

            if (nRow == 0)
            {
                TrayInfoView.SetValue(0, nRow, row["tray_id"].ToString());
                TrayInfoView.SetReworkTray(0, nRow, row["rework_flag"].ToString());
            }
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
            MessageBox.Show($"EqpType DoubleClick {EqpType}");
        }
    }
}
