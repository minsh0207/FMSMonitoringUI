﻿/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: WinTroubleAlarm
//  Create Data		: 
//  Author			: 
//  Remark			:
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [USing]
using System.Windows.Forms;
using System.Windows.Threading;         // 참조 WinDowsBase 추가
using MonitoringUI.Common;
using System;
#endregion

#region [Name Space]
namespace MonitoringUI.Popup
{
    #region [Class]
    public partial class WinTroubleAlarm : Form
    {
        #region [Variable]

        // Timer
        DispatcherTimer m_timer;

        // Board Color Change Toggle
        bool m_bToggleOn;

        #endregion

        #region [USing]
        public WinTroubleAlarm()
        {
            InitializeComponent();

            Initialize();

            InitControl();
        }
        #endregion

        #region [Init]
        #region [Initialize]
        /////////////////////////////////////////////////////////////////////
        //	Initialize
        //===================================================================
        private void Initialize()
        {
            // Timer
            m_timer = new DispatcherTimer();
            //CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "Initialize : m_timer Init");

            //BackGround Color
            m_bToggleOn = true;
        }
        #endregion

        #region [InitControl]
        /////////////////////////////////////////////////////////////////////
        //	Init Control
        //===================================================================
        private void InitControl()
        {
            try
            {
                // Init Timer
                m_timer.Interval = TimeSpan.FromSeconds(2);
                m_timer.Tick += new EventHandler(OnTimer);
                m_timer.Start();
                CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "InitControl : m_timer Start");
            }

            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Window Init Control Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                CLogger.WriteLog(enLogLevel.ERROR, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "InitControl Error Exception : " + ex.Message);
            }
        }
        #endregion
        #endregion

        #region [Timer Event]
        /////////////////////////////////////////////////////////////////////
        //	Timer Event
        //===================================================================
        private void OnTimer(object sender, EventArgs e)
        {
            try
            {
                ////DB 연결이 안되면 타이머 돌 필요가 없다?
                //if (CDataBase.m_dbCon.State.ToString() == "Closed")
                //    return;

                //timer Stop And Start
                m_timer.Stop();

                //Set This Focus
                this.Focus();

                //Togle Change
                if (m_bToggleOn == true)
                {
                    panBack.BackColor = System.Drawing.Color.Red;
                    panText.BackColor = System.Drawing.Color.Yellow;
                    lblTroubleName.BackColor = System.Drawing.Color.Yellow;
                    lblTroubleUnitName.BackColor = System.Drawing.Color.Yellow;
                    lblTroubleName.ForeColor = System.Drawing.Color.Red;
                    lblTroubleUnitName.ForeColor = System.Drawing.Color.Red;
                    m_bToggleOn = false;
                }
                else
                {
                    panBack.BackColor = System.Drawing.Color.Black;
                    panText.BackColor = System.Drawing.Color.Red;
                    lblTroubleName.BackColor = System.Drawing.Color.Red;
                    lblTroubleUnitName.BackColor = System.Drawing.Color.Red;
                    lblTroubleName.ForeColor = System.Drawing.Color.Yellow;
                    lblTroubleUnitName.ForeColor = System.Drawing.Color.Yellow;
                    m_bToggleOn = true;
                }

                //Set Time interval
                if (m_timer.Interval.Seconds.ToString() != "2")
                    m_timer.Interval = TimeSpan.FromSeconds(2);

                //timer Stop And Start
                m_timer.Start();
                //CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "OnTimer : Start");

            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### DB Load Data Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                CLogger.WriteLog(enLogLevel.ERROR, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "OnTimer Error Exception : " + ex.Message);

                //if (CDataBase.m_dbCon.State.ToString() != "Closed")
                //{
                //    //timer Start
                //    m_timer.Start();
                //    //CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "OnTimer : Start");
                //}
            }
        }
        #endregion

        #region [Exit]
        /////////////////////////////////////////////////////////////////////
        //	Exit
        //===================================================================
        public void Exit()
        {
            m_timer.Stop();
            CLogger.WriteLog(enLogLevel.LOG, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "Exit  : Timer Stop");
            this.Close();
        }
        #endregion

        #region [Label Mouse Key Down]
        private void lblTrouble_MouseDown(object sender, EventArgs e)
        {
            Exit();
        }
        #endregion

        #region [Label Mouse Key Down]
        private void lblTrouble_MouseDown(object sender, MouseEventArgs e)
        {
            Exit();
        }
        #endregion

    }
    #endregion
}
#endregion
