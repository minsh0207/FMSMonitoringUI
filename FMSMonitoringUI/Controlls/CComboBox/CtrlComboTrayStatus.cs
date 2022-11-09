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
#endregion

namespace MonitoringUI.Controlls.CComboBox
{
    public partial class CtrlComboTrayStatus : CtrlComboRoot
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
        #endregion

        #region [Constructor]
        public CtrlComboTrayStatus()
        {
            InitializeComponent();
        }
        #endregion

        #region [Load]
        private void CtrlComboModel_Load(object sender, EventArgs e)
        {
            m_bLoadFlag = true;

            TitleText = LocalLanguage.GetItemString("DEF_CONTROL_304");
            InitComboBoxList();
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
        /// </summary>
        /// <returns></returns>
        private void InitComboBoxList()
        {
            try
            {
                //Init
                cbItems.DataSource = null;
                cbItems.Items.Clear();
                cbItems.DisplayMember = CDefine.DEF_GRIDVIEW_COMBOXNAME;
                cbItems.ValueMember = CDefine.DEF_GRIDVIEW_COMBOXID;

                //Data Set
                cbItems.DataSource = CDataTable.TableTrayStatus();

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
        {;
            if (m_bLoadFlag) return;

            string ItemID = null;
            string ItemName = null;

            if (OnCboItemChanged == null) return;

            ComboBox cbo = sender as ComboBox;

            //tempItem.
            DataRowView rowData = cbo.Items[cbo.SelectedIndex] as DataRowView;

            ItemID = rowData.Row.ItemArray[0].ToString();
            ItemName = rowData.Row.ItemArray[1].ToString();

            OnCboItemChanged(ItemID, ItemName);
        }
        #endregion

    }
}
