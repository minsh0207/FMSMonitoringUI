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
#endregion

#region [NameSpace]
namespace MonitoringUI.Controlls.CComboBox
{
    #region [Class]
    public partial class CtrlComboMachine : CtrlComboRoot
    {
        #region [Variable, Menber]
        public delegate void OnCboItemChangeEvent(string ItemID, string ItemName);
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
        #endregion

        #region [Constructor]
        public CtrlComboMachine()
        {
            InitializeComponent();
        }
        #endregion

        #region [Load]
        private void CtrlCombo_Load(object sender, EventArgs e)
        {
            m_bLoadFlag = true;

            TitleText = LocalLanguage.GetItemString("DEF_CONTROL_152");

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
        public void InitComboBoxListENum(bool bNull, enDBTable enTable, string strFilter = "", string strOrder = "", string strColumn = "")
        {
            try
            {
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
                cbItems.DataSource = GetListTable(enTable, bNull, strFilter, strOrder, strColumn);

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

        public void ComboxClear()
        {
            if (cbItems.DataSource != null)
            {
                if (cbItems.DataSource.GetType() == typeof(DataTable))
                {
                    DataTable dt = cbItems.DataSource as DataTable;
                    dt.Clear();
                }
                cbItems.DataSource = null;
            }
        }

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