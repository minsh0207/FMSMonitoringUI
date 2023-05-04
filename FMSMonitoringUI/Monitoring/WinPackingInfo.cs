using ExcelDataReader.Log;
using FMSMonitoringUI.Controlls.WindowsForms;
using Google.Protobuf.WellKnownTypes;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Ocsp;
using RestClientLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Windows.Forms;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinPackingInfo : WinFormRoot
    {
        private Point point = new Point();
        private string _PalletId = string.Empty;

        private List<_dat_cell> _CellInfo;
        private List<_cell_process_flow> _CellProcessFlow;

        #region Working Thread
        private Thread _ProcessThread;
        private bool _TheadVisiable;
        #endregion

        public WinPackingInfo(string palletId)
        {
            InitializeComponent();

            InitControl();
            InitGridViewPalletInfo();
            InitGridViewTrayPosition();
            InitGridViewCellList();
            
            InitLanguage();

            _PalletId = palletId;
        }

        #region WinPackingInfo Event
        private void WinPackingInfo_Load(object sender, EventArgs e)
        {
            if (CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, this.Name) == false)
            {
                Exit_Click(null, null);
                return;
            }

            #region Title Mouse Event
            titBar.MouseDown_Evnet += Title_MouseDownEvnet;
            titBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridCellIDLIst.MouseCellDoubleClick_Evnet += GridCellIDLIst_MouseCellDoubleClick;
            gridTrayPosition.MouseCellDoubleClick_Evnet += GridTrayPosition_MouseCellDoubleClick;
            #endregion

            //GetCellIDList(_TrayId);

            _TheadVisiable = true;            

            this.BeginInvoke(new MethodInvoker(delegate ()
            {
                _ProcessThread = new Thread(() => ProcessThreadCallback());
                _ProcessThread.IsBackground = true; _ProcessThread.Start();
            }));

            this.WindowID = CAuthority.GetWindowsText(this.Text);

            CLogger.WriteLog(enLogLevel.Info, this.WindowID, "Window Load");
        }
        private void WinPackingInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._ProcessThread.IsAlive)
                this._TheadVisiable = false;

            this._ProcessThread.Abort();
        }
        #endregion

        //화면 깜빡임 방지
        #region CreateParams
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        #region InitControl
        private void InitControl()
        {
            Exit.Left = (this.panel2.Width - Exit.Width) / 2;             
            Exit.Top = (this.panel2.Height - Exit.Height) / 2;
        }
        #endregion

        #region InitLanguage
        private void InitLanguage()
        {
            titBar.CallLocalLanguage();

            lbPalletInfo.CallLocalLanguage();
            lbTrayPosition.CallLocalLanguage();
            lbCellIDList.CallLocalLanguage();

            Exit.CallLocalLanguage();
        }
        #endregion

        #region InitGridView
        private void InitGridViewPalletInfo()
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Pallet Info");      // -1
            lstTitle.Add("");
            gridPalletInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Pallet_ID"),
                LocalLanguage.GetItemString("DEF_Model_ID"),
                LocalLanguage.GetItemString("DEF_Grade")
            };
            gridPalletInfo.AddRowsHeaderList(lstTitle);

            gridPalletInfo.RowsHeight(22);

            List<int> lstColumn = new List<int>();
            lstColumn.Add(-1);      // DataGridView Header 병합
            lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Pallet_Info")
            };
            gridPalletInfo.ColumnMergeList(lstColumn, lstTitle);

            gridPalletInfo.SetGridViewStyles();
            gridPalletInfo.ColumnHeadersWidth(0, 140);
        }

        private void InitGridViewTrayPosition()
        {
            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Tray_Position")
            };

            gridTrayPosition.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            for (int i = 0; i < CDefine.DEF_MAX_PALLET_CELL_COUNT; i++)
            {
                lstTitle.Add((i + 1).ToString());
            }
            gridTrayPosition.AddRowsHeaderList(lstTitle);

            gridTrayPosition.RowsHeight(22);

            gridTrayPosition.SetGridViewStyles();
            //gridTrayPosition.ColumnHeadersWidth(0, 60);
        }

        private void InitGridViewCellList()
        {
            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Cell_ID")
            };

            gridCellIDLIst.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();
            for (int i = 1; i <= CDefine.DEF_MAX_PALLET_CELL_COUNT; i++)
            {
                lstTitle.Add("");
            }
            //lstTitle.Add("");
            gridCellIDLIst.AddRowsHeaderList(lstTitle);

            gridCellIDLIst.RowsHeight(22);

            gridCellIDLIst.SetGridViewStyles();
            gridCellIDLIst.ColumnHeadersWidth(0, 60);

        }
        #endregion

        #region ProcessThreadCallback
        private void ProcessThreadCallback()
        {
            try
            {
                //while (this._TheadVisiable == true)
                {
                    GC.Collect();

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        LoadPalletData(_PalletId).GetAwaiter().GetResult();
                    }));

                    //Thread.Sleep(3000);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }
        }
        #endregion

        #region LoadCellData
        private async Task LoadPalletData(string palletId)
        {
            try
            {
                RESTClient rest = new RESTClient();
                //// Set Query
                StringBuilder strSQL = new StringBuilder();

                strSQL.Append(" SELECT *");
                strSQL.Append(" FROM fms_v.tb_dat_packing");
                //필수값
                strSQL.Append($" WHERE pallet_id = '{palletId}'");

                var jsonResult = await rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonDatPackingResponse result = rest.ConvertDatPacking(jsonResult);

                    if (result != null)
                    {
                        SetPalletInfo(result.DATA);
                    }
                    else
                    {
                        string log = "ConvertDatCell : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                    }
                }
                else
                {
                    string log = "ConvertDatCell : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("LoadCellData Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("LoadCellData Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }
        }
        #endregion

        #region SetData
        private void SetCellList(List<_dat_packing> data)
        {
            if (data == null || data.Count == 0) return;

            for (int i = 0; i < data.Count(); i++)
            {
                gridCellIDLIst.SetValue(0, i, data[i].CELL_ID);
            }
        }
        private void SetPalletInfo(List<_dat_packing> data)
        {
            if (data == null || data.Count == 0) return;

            int row = 0;
            gridPalletInfo.SetValue(1, row, data[0].PALLET_ID); row++;
            gridPalletInfo.SetValue(1, row, data[0].MODEL_ID); row++;
            gridPalletInfo.SetValue(1, row, data[0].GRADE);
        }
        #endregion

        #region GetCellIDList
        private void GetCellIDList(string palletid, int trayPosition)
        {
            try
            {
                RESTClient rest = new RESTClient();
                //// Set Query
                StringBuilder strSQL = new StringBuilder();
                // Tray Information
                strSQL.Append(" SELECT *");
                strSQL.Append(" FROM fms_v.tb_dat_packing");
                //필수값
                strSQL.Append($" WHERE pallet_id = '{palletid}' AND tray_position = '{trayPosition}'");

                var jsonResult = rest.GetJson(enActionType.SQL_SELECT, strSQL.ToString());

                if (jsonResult != null)
                {
                    _jsonDatPackingResponse result = rest.ConvertDatPacking(jsonResult.Result);

                    if (result != null)
                    {
                        this.BeginInvoke(new Action(() => SetCellList(result.DATA)));
                    }
                    else
                    {
                        string log = "ConvertDatPacking : result is null";
                        CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                    }
                }
                else
                {
                    string log = "ConvertDatPacking : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("GetCellIDList Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("GetCellIDList Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
                CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
            }
            
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

        #region DataGridView Event
        private void GridCellIDLIst_MouseCellDoubleClick(int col, int row, object value)
        {
            for (int i = 0; i < CDefine.DEF_MAX_PALLET_CELL_COUNT; i++)
            {
                gridCellIDLIst.SetStyleBackColor(col, i, Color.FromArgb(27,27,27));
                gridCellIDLIst.SetStyleForeColor(col, i, Color.White);
            }

            if (col == 0 && row > -1)
            {
                gridCellIDLIst.SetStyleBackColor(col, row, Color.LightBlue);
                gridCellIDLIst.SetStyleForeColor(col, row, Color.Black);

                Point parentPoint = this.Location;

                WinCellDetailInfo form = new WinCellDetailInfo("", value.ToString());
                form.StartPosition = FormStartPosition.Manual;  // 폼의 위치가 Location 의 속성에 의해서 결정
                form.Location = new Point(parentPoint.X - parentPoint.X/2, parentPoint.Y);
                form.ShowDialog();
            }
        }        
        private void GridTrayPosition_MouseCellDoubleClick(int col, int row, object value)
        {
            for (int i = 0; i < CDefine.DEF_MAX_PALLET_CELL_COUNT; i++)
            {
                gridTrayPosition.SetStyleBackColor(col, i, Color.FromArgb(27, 27, 27));
                gridTrayPosition.SetStyleForeColor(col, i, Color.White);
            }

            if (row > -1)
            {
                gridTrayPosition.SetStyleBackColor(col, row, Color.LightBlue);
                gridTrayPosition.SetStyleForeColor(col, row, Color.Black);

                int trayPosition = Convert.ToInt16(value);
                GetCellIDList(_PalletId, trayPosition);
            }
        }
        #endregion

        #region Button Event
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        


    }
}
