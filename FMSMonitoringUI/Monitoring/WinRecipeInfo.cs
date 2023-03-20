using FMSMonitoringUI.Controlls.WindowsForms;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
using Org.BouncyCastle.Ocsp;
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

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinRecipeInfo : WinFormRoot
    {
        private Point point = new Point();

        public WinRecipeInfo(string recipeID)
        {
            InitializeComponent();

            InitControl();
            InitLanguage();
            //InitGridView();

            titBar.TitleText = $"{recipeID} {LocalLanguage.GetItemString("DEF_Recipe_Information")}";
        }

        #region WinRecipeInfo_Load
        private void WinRecipeInfo_Load(object sender, EventArgs e)
        {
            if (CAuthority.CheckAuthority(enAuthority.View, CDefine.m_strLoginID, this.Text) == false)
            {
                Exit_Click(null, null);
                return;
            }

            #region Title Mouse Event
            titBar.MouseDown_Evnet += Title_MouseDownEvnet;
            titBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridRecipeInfo.MouseCellDoubleClick_Evnet += GridCellInfo_MouseCellDoubleClick;
            #endregion

            this.WindowID = CAuthority.GetWindowsText(this.Text);

            CLogger.WriteLog(enLogLevel.Info, this.WindowID, "Window Load");
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
            //titBar.CallLocalLanguage();
            lbParameter.CallLocalLanguage();
            Exit.CallLocalLanguage();
        }
        #endregion

        #region InitGridView
        //private void InitGridView(Dictionary<string, string> rcpItem)
        private void InitGridView(List<_recipe_item> rcpItem)
        {
            List<string> lstTitle = new List<string>
            {
                LocalLanguage.GetItemString("DEF_Recipe_Item"),
                LocalLanguage.GetItemString("DEF_Value")
            };
            gridRecipeInfo.AddColumnHeaderList(lstTitle);

            lstTitle = new List<string>();

            foreach (var item in rcpItem)
            {
                //lstTitle.Add(item.Key);
                lstTitle.Add(item.NAME);
            }
            gridRecipeInfo.AddRowsHeaderList(lstTitle);

            gridRecipeInfo.ColumnHeadersHeight(24);
            gridRecipeInfo.RowsHeight(24);

            gridRecipeInfo.SetGridViewStyles();
            gridRecipeInfo.ColumnHeadersWidth(0, 300);

            for (int i = 0; i < rcpItem.Count; i++)
            {
                //gridRecipeInfo.SetValue(1, i, rcpItem.Values.ToList()[i]);
                string val = $"{rcpItem[i].VALUE} {rcpItem[i].UNIT}";
                gridRecipeInfo.SetValue(1, i, val);
            }
        }
        #endregion

        #region SetData
        public void SetData(_tray_process_flow rcpItem)
        {
            try
            {
                RESTClient rest = new RESTClient();

                string jsonResult = rcpItem.JSON_RECIPE;

                if (jsonResult != null)
                {
                    _jsonRecipeInfoResponse result = rest.ConvertRecipeInfo(jsonResult);

                    if (result != null)
                    {
                        InitGridView(result.RECIPE_ITEM);
                    }
                    else
                    {
                        List<_recipe_item> recipeItem = new List<_recipe_item>();
                        InitGridView(recipeItem);
                    }
                }
                else
                {
                    string log = "JSON_RECIPE : jsonResult is null";
                    CLogger.WriteLog(enLogLevel.Error, this.WindowID, log);
                }
                
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.Print(string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                string log = string.Format("ProcessThreadCallback Exception : {0}\r\n{1}", ex.GetType(), ex.Message);
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
        private void GridCellInfo_MouseCellDoubleClick(int col, int row, object value)
        {
            if (col == 1 && row > -1)
            {
                CLogger.WriteLog(enLogLevel.ButtonClick, this.WindowID, $"Cell Detail Info : Cell ID = {value}");

                WinCellDetailInfo form = new WinCellDetailInfo(value.ToString());
                form.ShowDialog();

                Refresh();
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
