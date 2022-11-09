/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description	    : 
//  Create Date	    : 
//  Author			: LSY
//  Remark			: 
//
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [using]
using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using MonitoringUI.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
#endregion

#region [NameSpace]
namespace MonitoringUI.Controlls.CComboBox
{
    #region [Class]
    public partial class CtrlComboRouteID : CtrlComboRoot
    {
        #region [Variable, Menber]
        public delegate void OnCboItemChangeEvent(string ItemID, string ItemName);
        /// <summary>
        /// CboboBox Seleted Data, Key, Value
        /// </summary>
        public OnCboItemChangeEvent OnCboItemChanged = null;
        bool m_bLoadFlag;
        #endregion

        #region Properties
        [DisplayName("SelectedItem"), Description("Selected Item"), Category("Combo Setting")]
        public object SelectedItem
        {
            get
            {
                return cbItems.SelectedValue;
            }
            set
            {
                cbItems.SelectedValue = value;
            }
        }

        [DisplayName("SelectedItem"), Description("Selected Item"), Category("Combo Setting")]
        public string SelectedKeyString
        {
            get
            {
                //null reference exception 
                if (cbItems.SelectedValue == null) return "";

                return cbItems.SelectedValue.ToString();
            }
            set
            {
                cbItems.SelectedValue = value;
            }
        }

        [DisplayName("SelectedIndex"), Description("Selected Item"), Category("Combo Setting")]
        public int SelectedIndex
        {
            get
            {
                return cbItems.SelectedIndex;
            }
            set
            {
                cbItems.SelectedIndex = value;
            }
        }
        //20190123 KJY
        [DisplayName("ComboObject"), Description("Combo Objectm"), Category("Combo Setting")]
        public System.Windows.Forms.ComboBox ComboObject
        {
            get
            {
                return cbItems;
            }
            set
            {
                cbItems = value;
            }
        }
        #endregion

        #region [Constructor]
        public CtrlComboRouteID()
        {
            InitializeComponent();
        }
        #endregion

        #region [Load]
        private void CtrlCombo_Load(object sender, EventArgs e)
        {
            m_bLoadFlag = true;

            TitleText = LocalLanguage.GetItemString("DEF_CONTROL_093");

            //InitComboBoxList(true).GetAwaiter().GetResult();

            m_bLoadFlag = false;
        }
        #endregion

        #region [Resize]
        private void CtrlCombo_Resize(object sender, EventArgs e)
        {
            cbItems.Top = 1;
            cbItems.Left = Convert.ToInt32(Width * 0.4) + 5;
            cbItems.Width = (Width - Convert.ToInt32(Width * 0.4)) - 10;
            cbItems.Height = Height - 2;
        }
        #endregion

        #region [Init, ComBox]
        /// <summary>
        /// ComBox List Init : ComboBox Init, Data Set, Selected
        /// public : strFilter 
        /// </summary>
        /// <returns></returns>
        public void InitComboBoxList(bool bNull, string strFilter = "", string strOrder = "", string strColumn = "")
        {
            try
            {
                //Init
                //cbItems.Items.Clear();

                if (cbItems.DataSource != null)
                {
                    if (cbItems.DataSource.GetType() == typeof(DataTable))
                    {
                        DataTable dt = cbItems.DataSource as DataTable;
                        dt.Clear();
                    }
                }

                cbItems.DisplayMember = CDefine.DEF_GRIDVIEW_COMBOXNAME;
                cbItems.ValueMember = CDefine.DEF_GRIDVIEW_COMBOXID;

                //Data Set
                cbItems.DataSource = GetListTable(enDBTable.MST_ROUTE_DEF, bNull, strFilter, strOrder, strColumn);

                //Selected
                if (cbItems.Items.Count > 0) cbItems.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Init ComBo, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        public void InitComboBoxListFromProStep(bool bNull, List<string> lsVar)
        {
            TitleText = LocalLanguage.GetItemString("strPastRouteID");

            try
            {
                //Init
                //cbItems.Items.Clear();

                if (cbItems.DataSource != null)
                {
                    if (cbItems.DataSource.GetType() == typeof(DataTable))
                    {
                        DataTable dt = cbItems.DataSource as DataTable;
                        dt.Clear();
                    }
                }

                cbItems.DisplayMember = CDefine.DEF_GRIDVIEW_COMBOXNAME;
                cbItems.ValueMember = CDefine.DEF_GRIDVIEW_COMBOXID;

                //Data Set
                if(lsVar[0] == "Y")
                    cbItems.DataSource = GetListTableGroupBy(enDBTable.MST_ROUTE_FROM_PROSTEP, bNull, lsVar);
                else
                    cbItems.DataSource = GetListTableGroupBy(enDBTable.HIST_DB_ROUTE_FROM_PROSTEP, bNull, lsVar);

                //Selected
                if (cbItems.Items.Count > 0) cbItems.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Init ComBo, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region InitCombo with ALL
        public void InitComboBoxListWithAll(bool bNull, string strFilter = "", string strOrder = "", string strColumn = "")
        {
            try
            {
                //Init
                //cbItems.Items.Clear();

                if (cbItems.DataSource != null)
                {
                    if (cbItems.DataSource.GetType() == typeof(DataTable))
                    {
                        DataTable dt = cbItems.DataSource as DataTable;
                        dt.Clear();
                    }
                }

                cbItems.DisplayMember = CDefine.DEF_GRIDVIEW_COMBOXNAME;
                cbItems.ValueMember = CDefine.DEF_GRIDVIEW_COMBOXID;

                //Data Set
                DataTable dtData = GetListTable(enDBTable.MST_ROUTE_DEF, bNull, strFilter, strOrder, strColumn);
                DataRow row = dtData.NewRow();
                row[CDefine.DEF_GRIDVIEW_COMBOXID] = "ALL";
                row[CDefine.DEF_GRIDVIEW_COMBOXNAME] = "ALL";
                dtData.Rows.InsertAt(row, 0);

                cbItems.DataSource = dtData;

                //Selected
                if (cbItems.Items.Count > 0) cbItems.SelectedItem = 0;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Init ComBo, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        } 
        #endregion

        #region [ComboBox Selected Change Event]
        /// <summary>
        /// UserControl ComboBox Selected Index Change To This. EventHandler ADD(UserForm).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnCboItemChanged == null) return;
            if (m_bLoadFlag) return;
            if (cbItems.SelectedIndex < 0) return;

            string ItemID = null;
            string ItemName = null;

            //tempItem.
            DataRowView rowData = cbItems.Items[cbItems.SelectedIndex] as DataRowView;

            ItemID = rowData.Row.ItemArray[0].ToString();
            ItemName = rowData.Row.ItemArray[1].ToString();

            OnCboItemChanged(ItemID, ItemName);
        }
        #endregion
    }
    #endregion
}
#endregion