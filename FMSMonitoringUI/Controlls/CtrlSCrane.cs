using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
//using CraneHandler;

namespace ControlGallery
{
    public partial class CtrlSCrane : UserControl
    {
        public CtrlSCrane()
        {
            InitializeComponent();

            //
            cranebox.MouseDoubleClick += CraneObject_MouseDoubleClick;
            lbRail.MouseDoubleClick += CraneObject_MouseDoubleClick;
        }

        #region [Properties]

        string _DeviceID;
        [DisplayName("DeviceID"), Description("Crane Device ID"), Category("UBI Property")]
        public string DeviceID
        {
            get { return _DeviceID; }
            set
            {
                if (value != _DeviceID)
                {
                    _DeviceID = value;
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

        EnumCraneDirection _craneDirection = EnumCraneDirection.Up;
        [DisplayName("Crane Direction"), Description("Direction Of Bay Number"), Category("UBI Property")]
        public EnumCraneDirection CraneDirection
        {
            get { return _craneDirection; }
            set
            {
                if (_craneDirection != value)
                {
                    _craneDirection = value;
                    CalcPixelsPerBay();
                    Refresh();
                }
            }
        }


        int _maxBayCount = 10;
        [DisplayName("Bay Count"), Description("Set Bay Count"), Category("UBI Property")]
        public int MaxBayCount
        {
            get { return _maxBayCount; }
            set
            {
                if (_maxBayCount != value)
                {
                    _maxBayCount = value;
                    CalcPixelsPerBay();
                    Refresh();
                }
            }
        }

        int _currBay = 0;
        [DisplayName("Current Bay"), Description("Set Current Bay"), Category("UBI Property")]
        public int CurrentBay
        {
            get { return _currBay; }
            set
            {
                if (_currBay != value)
                {
                    _currBay = value;
                    CalcCarriagePosition();
                    Refresh();
                }
            }
        }

        #endregion

        #region [SCHandler I/F]

        //SCHandler _SCHandler = null;

        //public SCHandler GetSCHandler()
        //{
        //    return _SCHandler;
        //}

        //public void SetSCHandler(SCHandler h)
        //{
        //    if (h != null)
        //    {
        //        _SCHandler = h;
        //        this.DisplayText = h.DeviceName;
        //    }
        //}

        public void UpdateUI(bool trayExist, string craneName)
        {
            cranebox.UpdateUI(trayExist, craneName);
            //if (_SCHandler != null)
            //{
            //    //CurrentBay = _SCHandler.SC_POSITION_BAY;
            //    cranebox.UpdateUI(_SCHandler);
            //    Refresh();
            //}
        }

        private void CraneObject_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }

        #endregion

        double _pixelsPerBay = 1.0;
        private void CalcPixelsPerBay()
        {
            switch (CraneDirection)
            {
                case EnumCraneDirection.Left:
                case EnumCraneDirection.Right:
                    _pixelsPerBay = (lbRail.Width - cranebox.Width) / (double)_maxBayCount;
                    break;

                case EnumCraneDirection.Up:
                case EnumCraneDirection.Down:
                    _pixelsPerBay = (lbRail.Height - cranebox.Height) / (double)_maxBayCount;
                    break;
            }

            CalcCarriagePosition();
        }

        private void CalcCarriagePosition()
        {

            // CurrentBay 는 크레인 PLC 에서 읽어 오는데... 혹시 이상한 값 날아 오면...
            //
            int safe_current_bay = CurrentBay;
            if (safe_current_bay < 0) safe_current_bay = 0;
            else if (safe_current_bay > MaxBayCount) safe_current_bay = MaxBayCount;

            //
            switch (CraneDirection)
            {
                case EnumCraneDirection.Left: // bay-9 <--- bay-1
                    cranebox.Location = new Point(lbRail.Location.X + (int)((MaxBayCount - safe_current_bay) * _pixelsPerBay), cranebox.Location.Y);
                    break;

                case EnumCraneDirection.Right: // bay-1 ---> bay-9
                    cranebox.Location = new Point(lbRail.Location.X + (int)(safe_current_bay * _pixelsPerBay), cranebox.Location.Y);
                    break;

                case EnumCraneDirection.Up: // bay-1 ^ bay-9
                    cranebox.Location = new Point(cranebox.Location.X, lbRail.Location.Y + (int)((MaxBayCount - safe_current_bay) * _pixelsPerBay));
                    break;

                case EnumCraneDirection.Down: // bay-9 v bay-1
                    cranebox.Location = new Point(cranebox.Location.X, lbRail.Location.Y + (int)(safe_current_bay * _pixelsPerBay));
                    break;
            }
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            //
            switch (CraneDirection)
            {
                case EnumCraneDirection.Left:
                case EnumCraneDirection.Right:
                    lbRail.Width = DisplayRectangle.Width - lbRail.Location.X - 16;
                    break;

                case EnumCraneDirection.Up:
                case EnumCraneDirection.Down:
                    lbRail.Height = DisplayRectangle.Height - lbRail.Location.Y - 16;
                    break;
            }

            CalcPixelsPerBay();
        }

    }


    public enum EnumCraneDirection
    {
        None = 0,
        Left = 1,
        Right = 2,
        Up = 3,
        Down = 4
    }

}
