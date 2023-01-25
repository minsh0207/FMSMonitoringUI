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
        string _LanguageID = "";
        [DisplayName("LocalLanguage"), Description("Local Language"), Category("Language Setting")]
        public string LanguageID
        {
            get
            {
                return _LanguageID;
            }
            set
            {
                _LanguageID = value;
            }
        }
        #endregion

        private void InitGridView()
        {
            string[] columnName = { "CH", 
                                    LocalLanguage.GetItemString("DEF_Cell_ID"),
                                    LocalLanguage.GetItemString("DEF_Templature") };

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

        #region CallLocalLanguage
        public void CallLocalLanguage()
        {
            if (_LanguageID != "")
            {
                lbTitle.Text = LocalLanguage.GetItemString(_LanguageID);
            }
        }
        #endregion
    }
}
