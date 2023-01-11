using FMSMonitoringUI.Monitoring;
using FormationMonCtrl;
using MonitoringUI;
using MySqlX.XDevAPI.Relational;
using OPCUAClientClassLib;
using RestClientLib;
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
                lbRackID.Text = string.Format(" {0}", _textBoxText);
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
            lstTitle.Add("Tray ID");
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
        }
        public void SetData(_ctrl_formation_hpc data)
        {
            int nRow = 0;
            TrayInfoView.SetValue(1, nRow, data.TRAY_ID); nRow++;
            TrayInfoView.SetValue(1, nRow, data.EQP_MODE); nRow++;
            TrayInfoView.SetValue(1, nRow, data.EQP_STATUS); nRow++;
            TrayInfoView.SetValue(1, nRow, data.OPERATION_MODE); nRow++;
            TrayInfoView.SetValue(1, nRow, data.PROCESS_NAME); nRow++;
            TrayInfoView.SetValue(1, nRow, data.START_TIME.ToString()); nRow++;
            TrayInfoView.SetValue(1, nRow, data.PLAN_TIME.ToString()); nRow++;
            TrayInfoView.SetValue(1, nRow, data.TEMP_AVG); nRow++;
            TrayInfoView.SetValue(1, nRow, data.PRESSURE); nRow++;
            TrayInfoView.SetValue(1, nRow, data.TROUBLE_CODE); nRow++;
            TrayInfoView.SetValue(1, nRow, data.TROUBLE_NAME);
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
        

        private void CtrlEqpControl_Load(object sender, EventArgs e)
        {
            InitGridView();
        }

        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WinFormationHPC form = new WinFormationHPC(lbRackID.Text);            
            form.Show();
        }
    }
}
