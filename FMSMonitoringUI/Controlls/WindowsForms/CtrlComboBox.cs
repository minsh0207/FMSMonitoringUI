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
using MonitoringUI.Common;
using System.Drawing;
#endregion

#region [NameSpace]
namespace MonitoringUI.Controlls.CComboBox
{
    #region [Class]
    public partial class CtrlComboBox : CtrlComboRoot
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

        [DisplayName("SelectedValueString"), Description("SelectedValueString"), Category("Combo Setting")]
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

        #region [Constructor]
        public CtrlComboBox()
        {
            InitializeComponent();
        }
        #endregion

        #region [Load]
        private void CtrlComboModel_Load(object sender, EventArgs e)
        {
            m_bLoadFlag = true;

            //TitleText = LocalLanguage.GetItemString("DEF_SPREAD_102");
            
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
        public void InitComboBoxList(bool bNull, string strFilter = "")
        {
            try
            {
                //Init
                cbItems.DataSource = null;
                cbItems.Items.Clear();
                cbItems.DisplayMember = CDefine.DEF_GRIDVIEW_COMBOXNAME;
                cbItems.ValueMember = CDefine.DEF_GRIDVIEW_COMBOXID;

                //20200107 KJY - Order By ProdDefaultFlag DESC

                //Data Set
                //cbItems.DataSource = GetListTable(enDBTable.MST_PROD_MODEL, bNull, strFilter);
                cbItems.DataSource = GetListTable(enDBTable.MST_PROD_MODEL, bNull, strFilter, "ProdDefaultFlag DESC, ProdModel ASC");

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

        #region InitComboWithAll
        public void InitComboBoxListWithAll(bool bNull, string strFilter = "")
        {
            try
            {
                //Init
                cbItems.DataSource = null;
                cbItems.Items.Clear();
                cbItems.DisplayMember = CDefine.DEF_GRIDVIEW_COMBOXNAME;
                cbItems.ValueMember = CDefine.DEF_GRIDVIEW_COMBOXID;

                //Data Set
                DataTable dt = GetListTable(enDBTable.MST_PROD_MODEL, bNull, strFilter);
                DataRow row = dt.NewRow();
                row[CDefine.DEF_GRIDVIEW_COMBOXID] = "ALL";
                row[CDefine.DEF_GRIDVIEW_COMBOXNAME] = "ALL";
                dt.Rows.InsertAt(row, 0);

                cbItems.DataSource = dt;

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

        #region CallLocalLanguage
        public void CallLocalLanguage()
        {
            if (_LanguageID != "")
            {
                TitleText = LocalLanguage.GetItemString(_LanguageID);
            }
        }
        #endregion
    }
    #endregion
}
#endregion