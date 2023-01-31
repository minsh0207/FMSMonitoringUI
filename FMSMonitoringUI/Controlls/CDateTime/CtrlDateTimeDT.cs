using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringUI.Controlls.CDateTime
{
    public partial class CtrlDateTimeDT : UserControlRoot
    {
        public delegate void OnValueChangeEvent();
        public OnValueChangeEvent OnValueChanged = null;

        #region Properties
        System.DateTime _dateTimeStart = System.DateTime.Now;
        [DisplayName("StartTime"), Description("Start Time"), Category("StartTime Setting")]
        public System.DateTime StartTime
        {
            get
            {
                return dtpFrom.Value;
            }
            set
            {
                _dateTimeStart = value;
                dtpFrom.Value = _dateTimeStart;

            }
        }
        string _labelText = "";
        [DisplayName("TitleText"), Description("Title"), Category("TextBox Setting")]
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
        Single _TitleWidth = 100F;
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
                tableLayoutPanel.ColumnStyles.Clear();
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, _TitleWidth));
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


        //string strTitleName = string.Empty;

        public CtrlDateTimeDT()
        {
            //strTitleName = "strDateRange";
            InitializeComponent();
        }

        //public void ChangeTitle(string strTitle)
        //{
        //    if (strTitle != null) strTitleName = strTitle;
        //    else strTitleName = "strDateRange";
        //    lbTitle.Text = LocalLanguage.GetItemString(strTitleName);
        //}

        //private void CtrlDateTimeDT_Load(object sender, EventArgs e)
        //{
        //    //lbTitle.Text = LocalLanguage.GetItemString("strDateRange");
        //    lbTitle.Text = LocalLanguage.GetItemString(strTitleName);
        //}

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (OnValueChanged == null) return;
            OnValueChanged();
        }

        public void CallLocalLanguage()
        {
            if (_LanguageID != "")
            {
                lbTitle.Text = LocalLanguage.GetItemString(_LanguageID);
            }
        }
    }
}
