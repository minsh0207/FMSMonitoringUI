//using CraneHandler;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ControlGallery
{
    public partial class CraneCarriageSmall : Label
    {
        public CraneCarriageSmall()
        {
            InitializeComponent();
            Init();
        }

        public CraneCarriageSmall(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            Init();
        }

        private void Init()
        {
            this.AutoSize = false;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Text = "";
            this.BackColor = Color.Black;
        }



        #region [Data I/F]

        public void UpdateUI(bool trayExist, string craneName, int eqpStatus)  //SCHandler h)
        {
            BackColor = GetStatusColor(trayExist, eqpStatus);
            Text = craneName;   // GetStatusText(h).Substring(0, 1);
        }

        #endregion


        #region [Status Text]

        //private string GetStatusText(SCHandler h)
        //{
        //    if (h.SC_IS_FIREOUT || !string.IsNullOrEmpty(h.FireStatus)) return "F"; // 화재 출고 시에는 "F", Host DB 의 장비 화재상태에도 by won
        //    else if (h.CraneUseFlag == EqpUseTypes.BlockBoth) return "X";
        //    else return h.SC_JOB_DIR; // PLC 에 쓰여진 것에서 가져온다.
        //}

        #endregion


        #region [Status Color]

        /*
         * 
         * Decide Status Color of CraneCarriage Box
         * 
         * 1. Power-Off (or None) : DarkGray
         * 2. Offline (Power On) : Gray
         * ---> 회색 계열 : Online 모드가 아님
         * 
         * 3. Online
         *      1) Trouble : Red
         *      2) Running : Lime + Text : I(in), O(out), P(bypass), M(rack move), H(home), F(fire out)
         *      3) Idle : LightBlue : 명령 대기 상태 (idle+지시대기+트레이없음+포크중앙), 아니면 DarkBlue
         * ---> 붉은색 계열 : 트러블
         * ---> 초록색 계열 : 온라인
         * 
         */
        private Color GetStatusColor(bool trayExist, int eqpStatus)
        {
            if (eqpStatus == 4)
            {
                return Color.Red;
            }
            if (trayExist)
            {
                return Color.Lime;
            }

            //if (h.CraneUseFlag == EqpUseTypes.BlockBoth) return Color.DarkGray;

            //if (h.SC_STATUS == MC_STATUS.Trouble) return Color.Red;

            //if (h.SC_MODE == MC_MODE.Online)
            //{
            //    if (h.SC_STATUS == MC_STATUS.Running) return Color.Lime;

            //    if (h.SC_STATUS == MC_STATUS.Idle)
            //    {
            //        if (h.SC_CMD_WAIT == MC_FLAG.On && h.SC_TRAY_ON == MC_FLAG.Off && h.SC_FORK_POSITION == MC_FORK_POSITION.Center)
            //        {
            //            return Color.LightBlue;
            //        }
            //        else
            //        {
            //            return Color.LightGray;
            //        }
            //    }
            //}

            //else
            //{
            //    switch (h.SC_MODE)
            //    {
            //        case MC_MODE.Auto:
            //            return Color.LightGray;

            //        case MC_MODE.Manual:
            //            return Color.LightGray;

            //        default:
            //        case MC_MODE.None:
            //            return Color.DarkGray;
            //    }
            //}

            // 어떤 상태인지 판정 안되면, OFFLINE으로...?
            return Color.DarkGray;
        }

        #endregion
    }
}
