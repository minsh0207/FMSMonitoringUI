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
    public partial class CtrlDateTimeDT2DT : UserControlRoot
    {


        public delegate void OnValueChangeEvent();
        public OnValueChangeEvent OnValueChanged = null;

        #region Properties
        System.DateTime _dateTimeStart = System.DateTime.Now;
        [DisplayName("StartDate"), Description("Start Date"), Category("Date Setting")]
        public System.DateTime StartDate
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
        System.DateTime _dateTimeEnd = System.DateTime.Now;
        [DisplayName("EndDate"), Description("End Date"), Category("Date Setting")]
        public System.DateTime EndDate
        {
            get
            {
                return dtpEnd.Value;
            }
            set
            {
                _dateTimeStart = value;
                dtpEnd.Value = _dateTimeStart;


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

        public CtrlDateTimeDT2DT()
        {
            InitializeComponent();
        }

        public void InitControl(int height)
        {
            lbTitle.Top = (height - lbTitle.Height) / 2;
            dtpFrom.Top = (height - dtpFrom.Height) / 2;
            lbWave.Top = (height - lbWave.Height) / 2;
            dtpEnd.Top = (height - dtpEnd.Height) / 2;

            Invalidate();
        }

        private void CtrlDateTimeDT2DT_Load(object sender, EventArgs e)
        {
            
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (OnValueChanged == null) return;
            OnValueChanged();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
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
