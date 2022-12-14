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
    public partial class CtrlEqpHTAging : UserControlEqp
    {
        public CtrlEqpHTAging()
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
                lbTitle.Text = _EqpType;
            }
        }
        #endregion

        #region setData
        public void setData(DataRow row)
        {
            //string[] trayID = { $"{row["tray_id"]}", $"{row["tray_id_2"]}" };
            //string startTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");    //row["start_time"].ToString();
            //string templature = string.Format($"{40}℃");            //row["jig_avg"].ToString();
            //string lotID = string.Format($"LotID001");              //row["lot_id"].ToString();
            //string eqpStatus = "N";             //row["eqp_status"].ToString();
            //string opStatus = "Discharge";             //row["eqp_status"].ToString();

            //SetEqpStatus(eqpStatus);
            //SetOperationStatus(opStatus);

            //CtrlFormationBoxCHG chg = (CtrlFormationBoxCHG)formationCHG.Child;
            //chg.setBox(trayID, startTime, templature, lotID);
        }

        public void SetEqpStatus(string eqp_status)
        {
            //eqpStatus.Text = eqp_status;
            //eqpStatus.BackColor = Color.Red;
        }

        public void SetOperationStatus(string op_status)
        {
            //opStatus.Text = op_status;
            //opStatus.BackColor = Color.Yellow;
        }
        #endregion
    }
}
