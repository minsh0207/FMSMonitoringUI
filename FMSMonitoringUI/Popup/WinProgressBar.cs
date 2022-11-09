/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description	    : 
//  Create Date	    : 
//  Author			: 
//  Remark			: 
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [using]
using System;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
#endregion

#region [NameSpace]
namespace MonitoringUI.Popup
{
    #region [Calss]
    public partial class WinProgressBar : Form
    {

        System.Threading.Timer _timer;

        #region [Constructor]
        public WinProgressBar(int nMinValue, int nMaxValue, bool useThreadTimer = false)
        {
            InitializeComponent();

            // Init
            ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            ProgressBar.ForeColor = System.Drawing.Color.FromArgb(220, 29, 217, 29);
            ProgressBar.Minimum = nMinValue;
            ProgressBar.Maximum = nMaxValue;
            ProgressBar.Value = 0;

            if(useThreadTimer)
            {
                StartTimer();
            }


        }
        #endregion
        private void StartTimer()
        {
            //_timer = new System.Threading.Timer(TimerEvent);

            TimerCallback tc = new TimerCallback(TimerEvent);

            _timer = new System.Threading.Timer(tc, null, 0, 100);


        }

        private void TimerEvent(object state)
        {
            if (this.InvokeRequired)
                ProgressBar.BeginInvoke(new Action(() => Progress(ProgressBar.Value++)));
            else
            {
                if (ProgressBar.Value == 100) return;
                Progress(ProgressBar.Value++);
            }
        }






        #region [Progress]
        /////////////////////////////////////////////////////////////////////
        //	Progress
        //===================================================================
        public void Progress(int nValue)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => this.Focus()));

                if(nValue % 10 == 0)
                {
                    // nValue가 Min, Max를 벗어나는경우가 있음? 이유는 확인 못함. 2019.07.01 KTH
                    if (ProgressBar.Minimum > nValue) ProgressBar.BeginInvoke(new Action(() => ProgressBar.Value = ProgressBar.Minimum));
                    else if (ProgressBar.Maximum < nValue) ProgressBar.BeginInvoke(new Action(() => ProgressBar.Value = ProgressBar.Maximum));
                    else ProgressBar.BeginInvoke(new Action(() => ProgressBar.Value = nValue));

                    ProgressBar.BeginInvoke(new Action(() => ProgressBar.PerformStep()));
                }
                // Exit
                if (ProgressBar.Maximum == nValue)
                {
                    this.BeginInvoke(new Action(() => this.Close()));
                }
            }
            else
            {

                // Set Focus
                this.Focus();

                if (nValue % 10 == 0)
                {
                    // nValue가 Min, Max를 벗어나는경우가 있음? 이유는 확인 못함. 2019.07.01 KTH
                    if (ProgressBar.Minimum > nValue) ProgressBar.Value = ProgressBar.Minimum;
                    else if (ProgressBar.Maximum < nValue) ProgressBar.Value = ProgressBar.Maximum;
                    else ProgressBar.Value = nValue;

                    ProgressBar.PerformStep();
                }


                // Exit
                if (ProgressBar.Maximum == nValue)
                {
                    this.Close();
                }
            }
        }
        #endregion

        #region [Exit]
        /////////////////////////////////////////////////////////////////////
        //	Exit
        //===================================================================
        public void Exit()
        {
            _timer?.Dispose();
            this.Close();
        }
        #endregion
    }

    #endregion
}
#endregion