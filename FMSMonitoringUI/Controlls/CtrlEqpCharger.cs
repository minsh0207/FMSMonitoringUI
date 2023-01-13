using FMSMonitoringUI.Controlls.WindowsForms;
using FMSMonitoringUI.Monitoring;
using FormationMonCtrl;
using MonitoringUI;
using MySqlX.XDevAPI.Relational;
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
    public partial class CtrlEqpCharger : UserControlEqp
    {
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
                lbTitle.Text = string.Format($" {_EqpType}");
            }
        }
        #endregion

        private List<string> _UnitID { get; set; }

        private Label[,] _chgEqpStatus;
        private Label[,] _chgEqpMode;

        public CtrlEqpCharger()
        {
            InitializeComponent();
        }

        #region CtrlEqpControl_Load
        private void CtrlEqpControl_Load(object sender, EventArgs e)
        {
            InitControl();
        }
        #endregion

        #region InitControl
        private void InitControl()
        {
            _chgEqpStatus = new Label[uiTlbEqpStatus.ColumnCount, uiTlbEqpStatus.RowCount];
            _chgEqpMode = new Label[uiTlbEqpStatus.ColumnCount, uiTlbEqpStatus.RowCount];

            _UnitID = new List<string>();

            for (int col = 0; col < uiTlbEqpStatus.ColumnCount; col++)
            {
                for (int row = 0; row < uiTlbEqpStatus.RowCount; row++)
                {
                    if (col == 2 && row == 0)
                    {
                        _chgEqpStatus[col, row] = new Label
                        {
                            Text = "  X",
                            TextAlign = ContentAlignment.MiddleCenter,
                            BackColor = Color.LightGray
                        };
                        _chgEqpMode[col, row] = new Label
                        {
                            BackColor = Color.LightGray
                        };
                    }
                    else
                    {
                        _chgEqpStatus[col, row] = new Label
                        {
                            Text = "I",
                            TextAlign = ContentAlignment.MiddleCenter,
                            BackColor = Color.FromArgb(255, 255, 128)
                        };

                        _chgEqpMode[col, row] = new Label
                        {
                            BackColor = Color.FromArgb(197, 135, 21)
                        };
                        
                    }

                    uiTlbEqpStatus.Controls.Add(_chgEqpStatus[col, row], col, row);

                    string chgUnitID = string.Format($"CHG0110{col+1}0{row+1}");
                    _UnitID.Add(chgUnitID);
                }
            }

            for (int row = 0; row < uiTlbEqpStatus.RowCount; row++)
            {
                uiTlbEqpMode1.Controls.Add(_chgEqpMode[0, row], 0, row);
                uiTlbEqpMode2.Controls.Add(_chgEqpMode[1, row], 0, row);
                uiTlbEqpMode3.Controls.Add(_chgEqpMode[2, row], 0, row);
            }
        }
        #endregion

        #region setData
        public override void SetData(List<_entire_eqp_list> data, Dictionary<string, Color> eqpStatus)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].UNIT_ID == null) continue;

                int col = int.Parse(data[i].UNIT_ID.Substring(data[i].UNIT_ID.Length - 3, 1)) -1;
                int row = uiTlbEqpStatus.RowCount - int.Parse(data[i].UNIT_ID.Substring(data[i].UNIT_ID.Length - 1, 1));

                _chgEqpStatus[col, row].Text = string.Format($"  {data[i].EQP_STATUS}");
                _chgEqpStatus[col, row].BackColor = eqpStatus[data[i].EQP_STATUS];

                _chgEqpMode[col, row].Text = string.Format($"  {data[i].EQP_MODE}");
                _chgEqpMode[col, row].BackColor = eqpStatus[data[i].EQP_MODE];
            }
        }
        #endregion

        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WinManageEqp form = new WinManageEqp(EqpID, "", EqpType, 1);
            form.ShowDialog();
        }

        
    }
}
