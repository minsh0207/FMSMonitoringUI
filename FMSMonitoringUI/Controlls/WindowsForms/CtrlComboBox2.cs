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
using System.Windows.Forms;
#endregion

#region [NameSpace]
namespace MonitoringUI.Controlls.CComboBox
{
    #region [Class]
    public partial class CtrlComboBox2 : UserControl
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
        string _labelText = "";
        [DisplayName("TitleText"), Description("Combo Title"), Category("Combo Setting")]
        public string TitleText
        {
            get
            {
                return _labelText;
            }
            set
            {
                _labelText = value;
                lbTitle.Text = _labelText;
            }
        }

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

        Single _TitleWidth = 150F;
        [DisplayName("Column Width"), Description("Column Width"), Category("TablePanel Setting")]
        public Single TitleWidth
        {
            get
            {
                return _TitleWidth;
            }
            set
            {
                _TitleWidth = value;

                Single panelWidth = (Single)(this.Size.Width - (int)_TitleWidth);
                tableLayoutPanel.ColumnStyles.Clear();
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, panelWidth));
                Invalidate();
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
        public CtrlComboBox2()
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

        //#region [Resize]
        private void CtrlCombo_Resize(object sender, EventArgs e)
        {
            //cbItems.Top = 1;
            //cbItems.Left = Convert.ToInt32(Width * 0.4) + 5;
            //cbItems.Width = (Width - Convert.ToInt32(Width * 0.4)) - 10;
            //cbItems.Height = Height - 2;

            //cbItems.Location = new Point(this.Location.X, this.Location.Y + 20);
        }
        //#endregion

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
                //cbItems.DataSource = GetListTable(enDBTable.MST_PROD_MODEL, bNull, strFilter, "ProdDefaultFlag DESC, ProdModel ASC");

                //Selected
                //if (cbItems.Items.Count > 0) cbItems.SelectedItem = 0;
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

        #region DataSource
        public void DataSource(DataTable dtData)
        {
            //Init
            cbItems.DataSource = null;
            cbItems.Items.Clear();
            cbItems.DisplayMember = CDefine.DEF_GRIDVIEW_COMBOXNAME;
            cbItems.ValueMember = CDefine.DEF_GRIDVIEW_COMBOXID;

            //Data Set
            cbItems.DataSource = dtData;

            //Selected
            if (cbItems.Items.Count > 0) cbItems.SelectedItem = 0;
        }
        #endregion

        #region SetComboBoxEnable
        public void SetComboBoxEnable(bool enable)
        {
            cbItems.Enabled = enable;
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