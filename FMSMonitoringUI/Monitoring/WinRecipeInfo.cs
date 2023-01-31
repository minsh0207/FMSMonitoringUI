using FMSMonitoringUI.Controlls.WindowsForms;
using MonitoringUI;
using MonitoringUI.Common;
using MonitoringUI.Controlls;
using MonitoringUI.Controlls.CButton;
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

        public WinRecipeInfo()
        {
            InitializeComponent();

            InitControl();
            InitLanguage();
            //InitGridView();
        }

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
        }

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
            lbParameter.CallLocalLanguage();
            Exit.CallLocalLanguage();
        }
        #endregion

        #region InitGridView
        private void InitGridView(Dictionary<string, object> rcpItem)
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
                lstTitle.Add(item.Key);
            }
            gridRecipeInfo.AddRowsHeaderList(lstTitle);

            gridRecipeInfo.ColumnHeadersHeight(24);
            gridRecipeInfo.RowsHeight(24);

            gridRecipeInfo.SetGridViewStyles();
            //gridRecipeInfo.ColumnHeadersWidth(0, 140);

            for (int i = 0; i < rcpItem.Count; i++)
            {
                gridRecipeInfo.SetValue(1, i, rcpItem.Values.ToList()[i]);
            }
        }
        #endregion

        #region SetData
        public void SetData(_tray_process_flow rcpItem, string recipeId)
        {
            RESTClient rest = new RESTClient();

            string jsonResult = rcpItem.JSON_RECIPE;
            _jsonRecipeInfoResponse result = rest.ConvertRecipeInfo(jsonResult);

            if (result != null)
            {
                InitGridView(result.RECIPE_ITEM);
            }
            else
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                InitGridView(data);
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
                //MessageBox.Show($"TrayInfoView DoubleClick CellID = {value}");

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
