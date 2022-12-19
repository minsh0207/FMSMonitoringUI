using FMSMonitoringUI.Controlls.WindowsForms;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CComboBox;
using MonitoringUI.Controlls.CDateTime;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using static System.Net.Mime.MediaTypeNames;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinAgingRackSetting : Form
    {
        private Point point = new Point();

        public WinAgingRackSetting()
        {
            InitializeComponent();
            InitGridView();
            InitControl();
        }

        private void WinAgingRackSetting_Load(object sender, EventArgs e)
        {
            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion
        }

        private void InitControl()
        {
            foreach (var ctl in splitContainer1.Panel2.Controls)
            {
                if (ctl.GetType() == typeof(CtrlLabel))
                {
                    CtrlLabel label = ctl as CtrlLabel;
                    label.CallLocalLanguage();
                }
                else if (ctl.GetType() == typeof(CtrlComboBox))
                {
                    CtrlComboBox cboBox = ctl as CtrlComboBox;
                    cboBox.CallLocalLanguage();
                }
                else if (ctl.GetType() == typeof(CtrlDateTimeDT))
                {
                    CtrlDateTimeDT dateTime = ctl as CtrlDateTimeDT;
                    dateTime.CallLocalLanguage();
                }
            }
        }

        private void InitGridView()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Rack Information");
            lstTitle.Add("");
            gridRackInfo.AddColumnHeaderList(lstTitle);

            gridRackInfo.ColumnHeadersVisible(false);

            lstTitle = new List<string>();
            lstTitle.Add("Rack ID");
            lstTitle.Add("Tray ID L1");
            lstTitle.Add("Tray ID L2");
            lstTitle.Add("Model ID");
            lstTitle.Add("Route ID");
            lstTitle.Add("Lot ID");
            lstTitle.Add("Rack Status");
            lstTitle.Add("Tray Zone");
            lstTitle.Add("Cell Type");
            lstTitle.Add("Cerrent Process");
            lstTitle.Add("Input Time");
            lstTitle.Add("Output Time");
            lstTitle.Add("Plan Time");
            lstTitle.Add("Use Flag");
            lstTitle.Add("Trouble Code");
            lstTitle.Add("Trouble Name");
            lstTitle.Add("");

            gridRackInfo.AddRowsHeaderList(lstTitle);

            gridRackInfo.ColumnHeadersHeight(30);
            gridRackInfo.RowsHeight(30);

            //List<int> lstColumn = new List<int>();
            //lstColumn.Add(-1);      // DataGridView Header 병합
            //lstTitle = new List<string>();
            //lstTitle.Add("Rack Information");
            //gridRackInfo.ColumnMergeList(lstColumn, lstTitle);

            gridRackInfo.SetGridViewStyles();
            gridRackInfo.ColumnHeadersWidth(0, 140);
        }

        public void SetData()
        {
            for (int i = 0; i < gridRackInfo.RowCount-1; i++)
            {
                gridRackInfo.SetValue(1, i, i.ToString());
            }
            
        }

        public void SetRackInfo(DataSet ds)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                gridRackInfo.SetValue(1, 0, row["rack_id"].ToString());
                gridRackInfo.SetValue(1, 1, row["tray_id"].ToString());
                gridRackInfo.SetValue(1, 2, row["tray_id_2"].ToString());
                gridRackInfo.SetValue(1, 3, row["in_model_id"].ToString());
                gridRackInfo.SetValue(1, 4, row["in_route_id"].ToString());
                gridRackInfo.SetValue(1, 5, "");        // Lot ID
                gridRackInfo.SetValue(1, 6, row["status"].ToString());
                gridRackInfo.SetValue(1, 7, row["in_tray_zone"].ToString());
                gridRackInfo.SetValue(1, 8, row["in_cell_type"].ToString());
                gridRackInfo.SetValue(1, 9, "");        // Cerrent Process
                gridRackInfo.SetValue(1, 10, row["start_time"].ToString());
                gridRackInfo.SetValue(1, 11, row["plan_time"].ToString());
                gridRackInfo.SetValue(1, 12, "");        // Use Flag
                gridRackInfo.SetValue(1, 13, row["trouble_code"].ToString());
                gridRackInfo.SetValue(1, 14, ""); // trouble_name
            }
        }

        #region Tray Tag Value
        private string GetConveyorType(int idx)
        {
            string ret = string.Empty;

            switch (idx)
            {
                case 1:
                    ret = "Conveyor Unit";
                    break;
                case 2:
                    ret = "InStation";
                    break;
                case 4:
                    ret = "OutStation";
                    break;
                case 8:
                    ret = "InOutStation";
                    break;
                case 16:
                    ret = "BufferStation";
                    break;
                case 32:
                    ret = "Diverter";
                    break;
                case 64:
                    ret = "Magazine";
                    break;
                case 128:
                    ret = "Dispenser";
                    break;
                case 256:
                    ret = "MZ / DP";
                    break;
            }

            return ret;
        }

        private string GetStationStatus(int idx)
        {
            string ret = string.Empty;

            switch (idx)
            {
                case 0:
                    ret = "Not Used";
                    break;
                case 1:
                    ret = "Station Down";
                    break;
                case 2:
                    ret = "Station Up";
                    break;
            }

            return ret;
        }

        private string GetTrayType(int idx)
        {
            string ret = string.Empty;

            switch (idx)
            {
                case 1:
                    ret = "BD - Before Degas Long Tray";
                    break;
                case 2:
                    ret = "AD - After Degas Short Tray";
                    break;
            }

            return ret;
        }
        #endregion

        #region Titel Mouse Event
        private void Title_MouseDownEvnet(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void Title_MouseMoveEvnet(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - (point.X - e.X), this.Top - (point.Y - e.Y));
            }
        }
        #endregion

        #region Button Click
        private void ctrlButtonExit1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
