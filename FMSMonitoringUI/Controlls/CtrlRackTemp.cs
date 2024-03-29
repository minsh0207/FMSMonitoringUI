﻿using FMSMonitoringUI.Controlls.WindowsForms;
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
            for (int i = 0; i < data.Count; i++)
            {
                int col = 1;                

                TrayInfoView.SetValue(col, i, data[i].JIG_11); 
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_11, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;
                TrayInfoView.SetValue(col, i, data[i].JIG_12);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_12, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;
                TrayInfoView.SetValue(col, i, data[i].JIG_13);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_13, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;
                TrayInfoView.SetValue(col, i, data[i].JIG_14);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_14, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;
                TrayInfoView.SetValue(col, i, data[i].JIG_15);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_15, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;
                TrayInfoView.SetValue(col, i, data[i].JIG_16);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_16, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;
                TrayInfoView.SetValue(col, i, data[i].JIG_17);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_17, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;
                TrayInfoView.SetValue(col, i, data[i].JIG_18);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_18, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;

                // Upper JIG 온도
                TrayInfoView.SetValue(col, i, data[i].JIG_21);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_21, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;
                TrayInfoView.SetValue(col, i, data[i].JIG_22);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_22, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;
                TrayInfoView.SetValue(col, i, data[i].JIG_23);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_23, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;
                TrayInfoView.SetValue(col, i, data[i].JIG_24);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_24, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;
                TrayInfoView.SetValue(col, i, data[i].JIG_25);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_25, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;
                TrayInfoView.SetValue(col, i, data[i].JIG_26);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_26, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;
                TrayInfoView.SetValue(col, i, data[i].JIG_27);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_27, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL)); col++;
                TrayInfoView.SetValue(col, i, data[i].JIG_28);
                TrayInfoView.SetStyleForeColor(col, i, CheckTempLimit(data[i].JIG_28, data[i].EQP_TEMP_LSL, data[i].EQP_TEMP_USL));
            }
        }
        #endregion

        #region CheckTempLimit
        private Color CheckTempLimit(float temp, float spacTemplsl, float spacTempusl)
        {
            Color tempColor = Color.White;

            if (temp <= spacTemplsl)
            {
                tempColor = Color.Blue;
            }
            if (temp >= spacTempusl)
            {
                tempColor = Color.Red;
            }

            return tempColor;
        }
        #endregion
    }
}
