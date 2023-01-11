using MonitoringUI.Common;
using MonitoringUI.Controlls;
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

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinRecipeInfo : Form
    {
        private Point point = new Point();

        public WinRecipeInfo()
        {
            InitializeComponent();

            //InitGridView();
        }

        private void WinRecipeInfo_Load(object sender, EventArgs e)
        {
            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion

            #region DataGridView Event
            gridRecipeInfo.MouseCellDoubleClick_Evnet += GridCellInfo_MouseCellDoubleClick;
            #endregion
        }

        private void InitGridView(Dictionary<string, object> rcpItem)
        {
            List<string> lstTitle = new List<string>();
            lstTitle.Add("Recipe Item");
            lstTitle.Add("Value");
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
