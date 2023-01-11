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
        #region Properties
        string _unitD = "";
        [DisplayName("Unit ID"), Description("Unit ID"), Category("GroupBox Setting")]
        public string UnitID
        {
            get
            {
                return _unitD;
            }
            set
            {
                _unitD = value;
            }
        }
        string _textBoxText = "";
        [DisplayName("TextBoxText"), Description("TextBox Text"), Category("GroupBox Setting")]
        public string TextBoxText
        {
            get
            {
                return _textBoxText;
            }
            set
            {
                _textBoxText = value;
                lbRackID.Text = string.Format(" Rack ID : {0}", _textBoxText);
            }
        }
        #endregion

        public CtrlRack()
        {
            InitializeComponent();
        }

        #region CtrlRack Event
        private void CtrlRack_Load(object sender, EventArgs e)
        {
            InitGridView();

            TrayInfoView.MouseCellDoubleClick_Evnet += TrayInfoView_MouseCellDoubleClick;
        }        
        #endregion

        #region InitGridView
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
            TrayInfoView.ColumnWidth(0, 50);
            TrayInfoView.ColumnWidth(1, 120);
            TrayInfoView.ColumnWidth(2, 100);

            TrayInfoView.SetTitle(1, 0, "Tray ID");
            TrayInfoView.SetTitle(2, 0, "Templature");
            TrayInfoView.SetTitle(2, 1, "Start Time");
            TrayInfoView.SetTitle(2, 2, "Plan Time");

            //TrayInfoView.SetTitle(0, 0, "1");
            //TrayInfoView.SetTitle(0, 1, "2");
        }
        #endregion

        #region setData
        public override void SetData(DataRow row)
        {
        }
        public void SetData(string trayid, string trayid2, float temp, DateTime startTime, DateTime planTime)
        {
            TrayInfoView.SetValue(1, 1, trayid);
            TrayInfoView.SetValue(1, 2, trayid2);
            TrayInfoView.SetValue(3, 0, temp.ToString());
            TrayInfoView.SetValue(3, 1, startTime.ToString());
            TrayInfoView.SetValue(3, 2, planTime.ToString());
        }
        #endregion

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

        #region DataGridView Event
        private void TrayInfoView_MouseCellDoubleClick(int col, int row, object value)
        {
            if (col == 1 && row > 0)
            {
                WinTrayInfo form = new WinTrayInfo(EqpID, "", value.ToString());
                form.ShowDialog();
            }
        }
        #endregion

        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WinFormationBox form = new WinFormationBox(EqpID, UnitID);
            form.ShowDialog();
        }
    }
}
