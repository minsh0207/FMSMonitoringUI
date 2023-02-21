//***************************************************************************
//  Description	    : CtrlComboRoot
//  Create Date	    : 
//  Author			: 
//  Remark			: 
//                      UI가 온전히 불러온 후 ComboBox List(DB)를 불러올 수 있게 한다.(김태훈)
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [using]
using System;
using System.Data;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using MonitoringUI.Common;
#endregion

#region [NameSpace] CComboBox
namespace MonitoringUI.Controlls.CComboBox
{
    #region [Classe]
    public partial class CtrlComboRoot : UserControlRoot
    {
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
        #endregion

        #region [Constructor]
        public CtrlComboRoot()
        {
            InitializeComponent();
        }
        #endregion

        #region [Resize]
        private void CtrlComboRoot_Resize(object sender, EventArgs e)
        {
            //this. Resize ..
            lbTitle.Top = 1;
            lbTitle.Left = 1;
            lbTitle.Width = Convert.ToInt32(Width * 0.4);
            lbTitle.Height = Height - 2;
        }
        #endregion
    }
    #endregion
}
#endregion