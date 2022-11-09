using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ControlGallery
{
    public partial class BaseControl : Label
    {
        public BaseControl()
        {
            InitializeComponent();

            _DeviceInfo = new StatusAndData();

            //
            this.AutoSize = false;
            this.Text = string.Empty;
            this.Size = new Size(16, 16);

            //
            this.MouseDoubleClick += OnMouseDoubleClick;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            InitDeviceInfo();
        }

        public virtual void InitDeviceInfo()
        {
            _DeviceInfo.CVPLCListDeviceID = this.CVPLCListDeviceID;
            _DeviceInfo.SiteNo = this.SiteNo;
            _DeviceInfo.PLCNo = this.PLCNo;
        }

        #region [Custom DblClick Event]

        protected virtual void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                OnObjectDoubleClick(new ObjectDoubleClickEventArgs(this.DeviceInfo));
            }
        }


        public EventHandler<ObjectDoubleClickEventArgs> ObjectDoubleClick;
        protected void OnObjectDoubleClick(ObjectDoubleClickEventArgs arg)
        {
            ObjectDoubleClick?.Invoke(this, arg);
        }

        #endregion



        #region [Override Base Properties]

        [Browsable(false)]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = false; }
        }

        [Browsable(false)]
        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        [Browsable(false)]
        protected StatusAndData _DeviceInfo = null;
        public StatusAndData DeviceInfo
        {
            get
            {
                return _DeviceInfo;
            }
        }

        #endregion



        #region [Properties]

        int _plcNo;
        [DisplayName("PLC No"), Description("PLCNo This Is Connected"), Category("UBI Property")]
        public int PLCNo
        {
            get { return _plcNo; }
            set
            {
                if (value != _plcNo)
                {
                    _plcNo = value;
                }
            }
        }

        int _CVPLCListDeviceID;
        [DisplayName("CVPLCListDeviceID"), Description("PLC Reader ID"), Category("UBI Property")]
        public int CVPLCListDeviceID
        {
            get { return _CVPLCListDeviceID; }
            set
            {
                if (value != _CVPLCListDeviceID)
                {
                    _CVPLCListDeviceID = value;
                }
            }
        }

        int _siteNo;
        [DisplayName("SiteNo"), Description("SiteNo Of This"), Category("UBI Property")]
        public int SiteNo
        {
            get { return _siteNo; }
            set
            {
                if (value != _siteNo)
                {
                    _siteNo = value;
                    Refresh();
                }
            }
        }

        bool _showSiteNo = false;
        [DisplayName("Show SiteNo"), Description("Show SiteNo"), Category("UBI Property")]
        public bool ShowSiteNo
        {
            get { return _showSiteNo; }
            set
            {
                if (_showSiteNo != value)
                {
                    _showSiteNo = value;
                    Refresh();
                }
            }
        }

        bool _showTroubleFirst = false;
        [DisplayName("Show Trouble Always"), Description("Show Trouble State Regardless Of Online"), Category("UBI Property")]
        public bool ShowTroubleState
        {
            get { return _showTroubleFirst; }
            set
            {
                if (_showTroubleFirst != value)
                {
                    _showTroubleFirst = value;
                    Refresh();
                }
            }
        }

        string _displayText = string.Empty;
        [DisplayName("Display Text"), Description("String To Display Inside This Control"), Category("UBI Property")]
        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                if (_displayText != value)
                {
                    _displayText = value;
                    Refresh();
                }
            }
        }

        int _textRotateAngle = 0;
        [DisplayName("Text Rotate Angle"), Description("Angle To Rotate Text"), Category("UBI Property")]
        public int TextRotateAngle
        {
            get { return _textRotateAngle; }
            set
            {
                if (_textRotateAngle != value)
                {
                    _textRotateAngle = value;
                    Refresh();
                }
            }
        }

        #endregion





        // Base Paint
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            DrawObject(pe.Graphics);
        }



        #region [Draw Function]

        protected virtual void DrawObject(Graphics g)
        {

            if(DeviceInfo != null && DeviceInfo.DeviceStatus != EnumDeviceStatus.None)
            {
                using (SolidBrush bg = new SolidBrush(GetStatusColor(DeviceInfo.DeviceStatus, BackColor)))
                {
                    Rectangle rc = DisplayRectangle;
                    rc.Inflate(-1, -1);
                    g.FillRectangle(bg, rc);
                }
            }

            if (DisplayText?.Length > 0 && !ShowSiteNo)
            {
                SolidBrush textBrush = new SolidBrush(ForeColor);

                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                if (TextRotateAngle % 360 == 0)
                {
                    // Text 방향을 바꾸기 위한 Transform 이 비용이 많이 드는 일이라서...
                    // 필요 없을 땐 하지 않기 위해서 if-else 로 구분한다.
                    Rectangle rcArea = this.DisplayRectangle;
                    rcArea.Inflate(-1, -1);
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    g.DrawString(DisplayText, Font, textBrush, rcArea, sf);
                }
                else
                {
                    // Transform 했으면...
                    g.TranslateTransform(this.Width / 2, this.Height / 2);
                    g.RotateTransform(this.TextRotateAngle);
                    PointF pf = new PointF(0f, 0f);
                    g.DrawString(DisplayText, Font, textBrush, pf, sf);

                    // 원상복구 시켜줘야...
                    g.ResetTransform();
                }
            }
        }

        #endregion

        #region [Get Color By Status]
        public static Color SiteDefaultColor = Color.FromArgb(95, 95, 95);
        public static Color SiteNoneColor = Color.FromArgb(27, 27, 27);
        public static Color SiteEmptyColor = Color.FromArgb(190, 190, 190);

        public Color GetStatusColor(EnumDeviceStatus status, Color def_color, int siteNo = -1)
        {
            //
            switch (siteNo)
            {
                case -1:
                    def_color = Color.Gray;
                    break;
                case -2:
                    def_color = SiteNoneColor;
                    break;
                default:
                    def_color = SiteDefaultColor;
                    break;
            }

            //
            if (status == EnumDeviceStatus.None) return def_color;

            //
            if(ShowTroubleState) // Online, Offline 무조건 표시
            {
                if (status >= EnumDeviceStatus.TroubleStateBegin) return Color.Red;
            }

            //
            if (status.HasFlag(EnumDeviceStatus.PLCOffline))
            {
                if (status.HasFlag(EnumDeviceStatus.TrayOn)) return Color.DarkGoldenrod;
                else return Color.DarkGray;
            }

            //
            if (status >= EnumDeviceStatus.TroubleStateBegin) return Color.Red;

            //
            if (status.HasFlag(EnumDeviceStatus.NotMyTray)) return Color.Magenta;

            //
            if (status.HasFlag(EnumDeviceStatus.StationReady))
            {
                if (status.HasFlag(EnumDeviceStatus.TrayOn)) return Color.Green;
                else return Color.Yellow;
            }

            //
            if (status.HasFlag(EnumDeviceStatus.TrayOn)) return Color.Lime; //.Yellow;

            if (status.HasFlag(EnumDeviceStatus.ReqBCR)) return Color.LightGreen;
            if (status.HasFlag(EnumDeviceStatus.BCRReading)) return Color.RoyalBlue;

            if (status.HasFlag(EnumDeviceStatus.GettingCommand)) return Color.Blue;
            if (status.HasFlag(EnumDeviceStatus.CommandWritten)) return Color.DarkBlue;

            // station-ready 가 아닌데 Up 이라면, 트레이 없이 입고대가 Up되어 있거나, 트레이 있는데 출고대가 Up 되어 있는 것!
            if (status.HasFlag(EnumDeviceStatus.StationUp)) return Color.Orange;

            return def_color;
        }

        public EnumDeviceStatus GetDeviceStatus(bool trayOn)
        {
            EnumDeviceStatus ret = EnumDeviceStatus.None;

            if (trayOn == true)
            {
                ret |= EnumDeviceStatus.TrayOn;
            }
            return ret;
        }


        public EnumDeviceStatus GetDeviceStatus(short mc_status, short host_status)
        {
            EnumDeviceStatus ret = EnumDeviceStatus.None;

            //ret = EnumDeviceStatus.Online;

            if (mc_status == 0)
            {
                ret |= EnumDeviceStatus.TrayOn;
            }
            else
            {
                ret = EnumDeviceStatus.Online;
            }

            //ret |= EnumDeviceStatus.StationReady;

            return ret;

            //if (IsBitOn(mc_status, (int)MC_STATUS_BIT.ONLINE))
            //{
            //    ret = EnumDeviceStatus.Online;
            //}
            //else
            //{
            //    ret = EnumDeviceStatus.PLCOffline;
            //}

            //if (IsBitOn(mc_status, (int)MC_STATUS_BIT.TROUBLE)) ret |= EnumDeviceStatus.TroubleStateBegin;

            //if (IsBitOn(mc_status, (int)MC_STATUS_BIT.TRAY_ON)) ret |= EnumDeviceStatus.TrayOn;
            //if (IsBitOn(mc_status, (int)MC_STATUS_BIT.READ_BCR)) ret |= EnumDeviceStatus.ReqBCR;

            //if (IsBitOn(mc_status, (int)MC_STATUS_BIT.NOT_MY_TRAY)) ret |= EnumDeviceStatus.NotMyTray;

            //// 입고대 준비가 되었다는것은 트레이 있고 상승했을 때임
            //if (IsBitOn(mc_status, (int)MC_STATUS_BIT.IN_READY))
            //{
            //    if (IsBitOn(mc_status, (int)MC_STATUS_BIT.TRAY_ON))
            //    {
            //        ret |= EnumDeviceStatus.StationReady;
            //    }
            //    else
            //    {
            //        ret |= EnumDeviceStatus.StationUp;
            //    }
            //}
            //else
            //{
            //    ret |= EnumDeviceStatus.StationDown;
            //}


            //// 출고대 준비가 되었다는 것은 트레이 없고 상승했을 때임
            //if (IsBitOn(mc_status, (int)MC_STATUS_BIT.OUT_READY))
            //{
            //    if (IsBitOn(mc_status, (int)MC_STATUS_BIT.TRAY_ON))
            //    {
            //        ret |= EnumDeviceStatus.StationUp;
            //    }
            //    else
            //    {
            //        ret |= EnumDeviceStatus.StationReady;
            //    }
            //}
            //else
            //{
            //    ret |= EnumDeviceStatus.StationDown;
            //}

            //return ret;
        }

        public bool IsBitOn(short word, int bitno)
        {
            return (word & ((short)(0x01 << bitno))) != 0;
        }

        #endregion

        public enum MC_STATUS_BIT
        {
            ONLINE = 0
            , TROUBLE = 1
            , TRAY_ON = 2
            , READ_BCR = 3



            // 다른 라인에서 넘어온 트레이, ECS 에서 명령 주지 않음 (READ_BCR 비트도 켜지 않기로 협의함)
            , NOT_MY_TRAY = 4



            , IN_READY = 6      // 입고대인 경우 : 입고 가능
            , OUT_READY = 7     // 출고대인 경우 : 출고 가능



            // 다른 라인으로 보낼 트레이
            , NOT_MY_TRAY_SEND_TO_ASSEMBLY = 8  // 조립 라인으로 보낼 것, ECS 에서 명령 주지 않음
            , NOT_MY_TRAY_SEND_TO_PKG = 9       // 포장 라인으로 보낼 것, ECS 에서 명령 주지 않음
        }

        public enum HOST_STATUS_BIT
        {
            CMD_CONFIRM = 3                     // 목적지 쓰고 난 후, 이 비트 켜주면 움직인다
            , MOVE_BY_FORCE = 4                 // 강제 배출 (목적지 모르거나, BCR 못 읽으면...)


            // 입고대 동작해도 됨, 출고대 동작해도 됨
            // 입/출고대 센서 연결 하므로 ECS 에서 중계 안해도 됨!
            , IN_MAY_MOVE = 6
            , OUT_MAY_MOVE = 7
        }
    }

    public class ObjectDoubleClickEventArgs : EventArgs
    {
        StatusAndData _device_info;
        public StatusAndData DeviceInfo
        {
            get { return _device_info; }
        }

        public ObjectDoubleClickEventArgs(StatusAndData info)
        {
            _device_info = info;
        }
    }

}
