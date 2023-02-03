using FMSMonitoringUI.Controlls.WindowsForms;
using FMSMonitoringUI.Monitoring;
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
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace FMSMonitoringUI.Controlls
{
    public partial class CtrlRackTemp : UserControlEqp
    {
        #region Properties
        //string _TitleName = "";
        //[DisplayName("Title Name"), Description("Title Name"), Category("GroupBox Setting")]
        //public string TitleName
        //{
        //    get
        //    {
        //        return _TitleName;
        //    }
        //    set
        //    {
        //        _TitleName = value;
        //        lbRackID.Text = _TitleName;                
        //    }
        //}
        #endregion

        public CtrlRackTemp()
        {
            InitializeComponent();
        }        

        #region CtrlRackTemp Event
        private void CtrlRackTemp_Load(object sender, EventArgs e)
        {
            InitGridView();

            InitLanguage();
        }
        #endregion

        #region InitLanguage
        private void InitLanguage()
        {
            lbLower.CallLocalLanguage();
            lbUpper.CallLocalLanguage();
        }
        #endregion

        #region InitGridView
        private void InitGridView()
        {
            string[] columnName = { "", "JIG#1", "JIG#2", "JIG#3", "JIG#4", "JIG#5", "JIG#6", "JIG#7", "JIG#8",
                                    "JIG#9", "JIG#10", "JIG#11", "JIG#12", "JIG#13", "JIG#14", "JIG#15", "JIG#16"};

            string[] rowName = { "Rack#1", "Rack#2", "Rack#3", "Rack#4", "Rack#5", 
                                 "Rack#6", "Rack#7", "Rack#8", "Rack#9", "Rack#10", "Rack#11"};
            List<string> lstTitle = new List<string>();

            foreach (var item in columnName)
            {
                lstTitle.Add(item);
            }
            TrayInfoView.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            foreach (var item in rowName)
            {
                lstTitle.Add(item);
            }
            TrayInfoView.AddRowsHeaderList(lstTitle);

            TrayInfoView.ColumnHeadersHeight(28);
            TrayInfoView.RowsHeight(26);

            TrayInfoView.SetGridViewStyles();

            TrayInfoView.ColumnWidth(0, 100);
            //for (int i = 0; i < columnName.Length; i++)
            //{
            //    TrayInfoView.ColumnWidth(i, 50);
            //}
        }
        #endregion

        #region setData
        public void SetData(List<_ctrl_formation_chg> data)
        {
            foreach (var jig in data) 
            {
                // Lower JIG 온도
                int col = 1;
                int row;

                if (int.Parse(jig.UNIT_ID.Substring(jig.UNIT_ID.Length - 3, 1)) > 1)
                {
                    row = int.Parse(jig.UNIT_ID.Substring(jig.UNIT_ID.Length - 3, 1)) * 2 + int.Parse(jig.UNIT_ID.Substring(jig.UNIT_ID.Length - 1, 1));
                    row--;
                }
                else
                {
                    row = int.Parse(jig.UNIT_ID.Substring(jig.UNIT_ID.Length - 1, 1));
                    row--;
                }

                TrayInfoView.SetValue(col, row, jig.JIG_11); col++;
                TrayInfoView.SetValue(col, row, jig.JIG_12); col++;
                TrayInfoView.SetValue(col, row, jig.JIG_13); col++;
                TrayInfoView.SetValue(col, row, jig.JIG_14); col++;
                TrayInfoView.SetValue(col, row, jig.JIG_15); col++;
                TrayInfoView.SetValue(col, row, jig.JIG_16); col++;
                TrayInfoView.SetValue(col, row, jig.JIG_17); col++;
                TrayInfoView.SetValue(col, row, jig.JIG_18); col++;

                // Upper JIG 온도
                TrayInfoView.SetValue(col, row, jig.JIG_21); col++;
                TrayInfoView.SetValue(col, row, jig.JIG_22); col++;
                TrayInfoView.SetValue(col, row, jig.JIG_23); col++;
                TrayInfoView.SetValue(col, row, jig.JIG_24); col++;
                TrayInfoView.SetValue(col, row, jig.JIG_25); col++;
                TrayInfoView.SetValue(col, row, jig.JIG_26); col++;
                TrayInfoView.SetValue(col, row, jig.JIG_27); col++;
                TrayInfoView.SetValue(col, row, jig.JIG_28);
            }
        }
        #endregion
    }
}
