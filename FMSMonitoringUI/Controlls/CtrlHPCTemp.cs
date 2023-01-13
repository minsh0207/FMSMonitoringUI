using FMSMonitoringUI.Monitoring;
using FormationMonCtrl;
using MonitoringUI;
using MonitoringUI.Common;
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
    public partial class CtrlHPCTemp : UserControlEqp
    {
        /// <summary>
        /// Max Cell Count
        /// </summary>
        int _MaxCellCount = 30;
        public int MaxCellCount
        {
            get => _MaxCellCount;
            set => _MaxCellCount = value;
        }

        public CtrlHPCTemp()
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
        string _TitleName = "";
        [DisplayName("Title Name"), Description("Title Name"), Category("GroupBox Setting")]
        public string TitleName
        {
            get
            {
                return _TitleName;
            }
            set
            {
                _TitleName = value;
                lbTitle.Text = _TitleName;
            }
        }
        #endregion

        private void InitGridView()
        {
            string[] columnName = { "CH", "Cell ID", "Templature" };
            //string[] rowName = { "JIG#1", "JIG#2", "JIG#3", "JIG#4", "JIG#5", "JIG#6", "JIG#7", "JIG#8",
            //                      "JIG#9", "JIG#10", "JIG#11", "JIG#12", "JIG#13", "JIG#14", "JIG#15",
            //                      "JIG#16", "JIG#17", "JIG#18", "JIG#19", "JIG#20", "JIG#21", "JIG#22", "JIG#23",
            //                      "JIG#24", "JIG#25", "JIG#26", "JIG#27", "JIG#28", "JIG#29", "JIG#30"};

            List<string> lstTitle = new List<string>();
            lstTitle = columnName.ToList();
            gridRackTemp.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();            
            for (int i = 0; i < _MaxCellCount; i++)
            {
                lstTitle.Add((i + 1).ToString());                
            }
            gridRackTemp.AddRowsHeaderList(lstTitle);

            //for (int i = 0; i < rowName.Length; i++)
            //{
            //    gridRackTemp.SetValue(2, i, rowName[i].ToString());
            //}

            //List<int> lstColumn = new List<int>();
            //lstColumn.Add(-1);      // DataGridView Header 병합
            //lstTitle = new List<string>();
            //lstTitle.Add("Templature");
            //gridRackTemp.ColumnMergeList(lstColumn, lstTitle);

            gridRackTemp.ColumnHeadersHeight(28);
            gridRackTemp.RowsHeight(27);

            gridRackTemp.SetGridViewStyles();
            gridRackTemp.ColumnHeadersWidth(0, 60);
            gridRackTemp.ColumnHeadersWidth(1, 200);

        }

        #region setData
        public void SetData(List<_ctrl_formation_hpc_temp> data)
        {
            foreach (var hpc in data)
            {
                if (hpc.UNIT_ID != _unitD) continue;

                int row = int.Parse(hpc.CELL_NO) - 1;

                gridRackTemp.SetValue(0, row, hpc.CELL_NO);
                gridRackTemp.SetValue(1, row, hpc.CELL_ID);
                gridRackTemp.SetValue(2, row, hpc.TEMP_JIG);
            }
        }
        #endregion

        private void CtrlHPCTemp_Load(object sender, EventArgs e)
        {
            InitGridView();
        }

        private void lbEqpType_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //WinManageEqp form = new WinManageEqp();
            //form.Show();
        }
    }
}
