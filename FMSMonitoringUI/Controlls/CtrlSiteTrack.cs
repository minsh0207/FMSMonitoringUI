using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Windows.Shapes;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaGds;

namespace ControlGallery
{
    public partial class CtrlSiteTrack : BaseControl
    {
        public CtrlSiteTrack()
        {
            InitializeComponent();
            
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            CalcSiteRects();
        }

        private bool _TrayOn = false;

        #region [Class Vars]

        SiteBox[] _siteBoxes;
        public SiteBox[] SiteBoxArray
        {
            get
            {
                return _siteBoxes;
            }
        }

        #endregion

        #region [Properties]

        bool _mainLoop = false;
        [DisplayName("Main Loop Track"), Description("Set If This Track Is Part Of Main Loop"), Category("UBI Property")]
        public bool MainLoop
        {
            get { return _mainLoop; }
            set
            {
                if (_mainLoop != value)
                {
                    _mainLoop = value;
                }
            }
        }

        int _siteCount = 0;
        [DisplayName("Site Count"), Description("Site Count"), Category("UBI Property")]
        public int SiteCount
        {
            get { return _siteCount; }
            set
            {
                if (_siteCount != value)
                {
                    _siteCount = value;
                    _siteBoxes = new SiteBox[_siteCount];
                    CreateSiteBoxes();
                    CalcSiteRects();
                    Refresh();
                }
            }
        }

        int _siteBoxWidth = 16;
        [DisplayName("Site Box Width"), Description("Site Box Width"), Category("UBI Property")]
        public int SiteBoxWidth
        {
            get { return _siteBoxWidth; }
            set
            {
                if (_siteBoxWidth != value)
                {
                    _siteBoxWidth = value;
                    CalcSiteRects();
                    Refresh();
                }
            }
        }

        int _siteBoxHeight = 16;
        [DisplayName("Site Box Height"), Description("Site Box Height"), Category("UBI Property")]
        public int SiteBoxHeight
        {
            get { return _siteBoxHeight; }
            set
            {
                if (value != _siteBoxHeight)
                {
                    _siteBoxHeight = value;
                    CalcSiteRects();
                    Refresh();
                }
            }
        }

        int _interSitePadding = 2;
        [DisplayName("Inter-Site Padding"), Description("Gap Between 2 Site Boxes"), Category("UBI Property")]
        public int InterSitePadding
        {
            get { return _interSitePadding; }
            set
            {
                if (value != _interSitePadding)
                {
                    _interSitePadding = value;
                    CalcSiteRects();
                    Refresh();
                }
            }
        }

        int _marginV = 0;
        [DisplayName("Margin Vertical"), Description("첫번째 Site Box 에 대한 세로방향 마진"), Category("UBI Property")]
        public int MarginVertical
        {
            get { return _marginV; }
            set
            {
                if (value != _marginV)
                {
                    _marginV = value;
                    CalcSiteRects();
                    Refresh();
                }
            }
        }

        int _marginH = 0;
        [DisplayName("Margin Horizontal"), Description("첫번째 Site Box 에 대한 가로방향 마진"), Category("UBI Property")]
        public int MarginHorizontal
        {
            get { return _marginH; }
            set
            {
                if (value != _marginH)
                {
                    _marginH = value;
                    CalcSiteRects();
                    Refresh();
                }
            }
        }

        Color _siteBackColor = Color.Gray;
        [DisplayName("Site BackColor"), Description("Site BackColor"), Category("UBI Property")]
        public Color SiteBoxColor
        {
            get { return _siteBackColor; }
            set
            {
                _siteBackColor = value;
                Refresh();
            }
        }

        Color _siteBorderColor = Color.Black;
        [DisplayName("Site Border Color"), Description("Site Border Color"), Category("UBI Property")]
        public Color SiteBorderColor
        {
            get { return _siteBorderColor; }
            set
            {
                _siteBorderColor = value;
                Refresh();
            }
        }

        SiteTrackDirection _siteNoDirection = SiteTrackDirection.LeftToRight;
        [DisplayName("SiteNo Direction"), Description("Direction of SiteNo Increasing"), Category("UBI Property")]
        public SiteTrackDirection SiteNoDirection
        {
            get { return _siteNoDirection; }
            set
            {
                if (value != _siteNoDirection)
                {
                    _siteNoDirection = value;
                    CalcSiteRects();
                    Refresh();
                }
            }
        }

        TrayMovingDirection _siteTrayDirection = TrayMovingDirection.LeftToRight;
        [DisplayName("Tray Moving Direction"), Description("Direction of Tray Moving"), Category("UBI Property")]
        public TrayMovingDirection SiteTrayDirection
        {
            get { return _siteTrayDirection; }
            set
            {
                _siteTrayDirection = value;
                Refresh();
            }
        }

        int _firstSiteNo = 1;
        [DisplayName("First SiteNo"), Description("First SiteNo Of This Track"), Category("UBI Property")]
        public int FirstSiteNo
        {
            get { return _firstSiteNo; }
            set
            {
                if (value != _firstSiteNo)
                {
                    _firstSiteNo = value;
                    CalcSiteRects();
                    Refresh();
                }
            }
        }

        int _siteNoIncStep = 1;
        [DisplayName("SiteNo Increasing Step"), Description("SiteNo 가 규칙적으로 증가하는 경우 그 증분 값"), Category("UBI Property")]
        public int SiteNoIncStep
        {
            get { return _siteNoIncStep; }
            set
            {
                if (value != _siteNoIncStep)
                {
                    _siteNoIncStep = value;
                    CalcSiteRects();
                    Refresh();
                }
            }
        }


        int[] _siteNoList;
        [DisplayName("SiteNo List"), Description("트랙에 있는 Site 들의 SiteNo가 규칙적이지 않은 경우 사용함"), Category("UBI Property")]
        public int[] SiteNoList
        {
            get { return _siteNoList; }
            set
            {
                if (value != _siteNoList)
                {
                    _siteNoList = value;
                    CalcSiteRects();
                    Refresh();
                }
            }
        }

        string[] _siteTextDisp;
        [DisplayName("SiteText Disp"), Description("SiteNo=SiteText"), Category("UBI Property")]
        public string[] SiteTextDisp
        {
            get { return _siteTextDisp; }
            set
            {
                if (value != _siteTextDisp)
                {
                    _siteTextDisp = value;
                }
            }
        }

        bool _isUpperStage = false;
        [DisplayName("Is Upper Stage"), Description("Upper Stage 로 설정하면 따로 표시를 더 해줌"), Category("UBI Property")]
        public bool IsUpperStage
        {
            get { return _isUpperStage; }
            set
            {
                if (value != _isUpperStage)
                {
                    _isUpperStage = value;
                    Refresh();
                }
            }
        }

        bool _isControled = true;
        [DisplayName("Is Controled Site"), Description("Control 가능한 Site 인지 여부"), Category("UBI Property")]
        public bool IsControled
        {
            get { return _isControled; }
            set
            {
                if (value != _isControled)
                {
                    _isControled = value;
                }
            }
        }

        #endregion

        #region [Calc SiteBoxes Rects]

        private void CreateSiteBoxes()
        {
            if (_siteBoxes == null || _siteBoxes.Length <= 0) return;
            for (int i = 0; i < _siteBoxes.Length; i++)
            {
                _siteBoxes[i] = new SiteBox(_isControled);
            }
        }

        private void CalcSiteRects()
        {
            if (_siteBoxes == null || _siteBoxes.Length <= 0) return;
                        
            for (int i = 0; i < _siteBoxes.Length; i++)
            {

                switch (SiteNoDirection)
                {
                    case SiteTrackDirection.LeftToRight:
                        _siteBoxes[i].Rect = new Rectangle(
                            MarginHorizontal + i * (SiteBoxWidth + InterSitePadding)
                            , MarginVertical
                            , SiteBoxWidth
                            , SiteBoxHeight);
                        break;

                    case SiteTrackDirection.RightToLeft:
                        _siteBoxes[i].Rect = new Rectangle(
                            DisplayRectangle.Width - (MarginHorizontal + (i + 1) * (SiteBoxWidth + InterSitePadding))
                            , MarginVertical
                            , SiteBoxWidth
                            , SiteBoxHeight);
                        break;

                    case SiteTrackDirection.TopToBottom:
                        _siteBoxes[i].Rect = new Rectangle(
                            MarginHorizontal
                            , MarginVertical + i * (SiteBoxHeight + InterSitePadding)
                            , SiteBoxWidth
                            , SiteBoxHeight);
                        break;

                    case SiteTrackDirection.BottomToTop:
                        _siteBoxes[i].Rect = new Rectangle(
                            MarginHorizontal
                            , DisplayRectangle.Height - (MarginVertical + (i + 1) * (SiteBoxHeight + InterSitePadding))
                            , SiteBoxWidth
                            , SiteBoxHeight);
                        break;
                }

                if (SiteNoList != null && SiteNoList.Length > 0 && i < SiteNoList.Length)
                {
                    _siteBoxes[i].SiteNo = SiteNoList[i];
                }
                else
                {
                    _siteBoxes[i].SiteNo = FirstSiteNo + i * SiteNoIncStep;
                }

                _siteBoxes[i].DeviceInfo.SetData(PLCNo, CVPLCListDeviceID, _siteBoxes[i].SiteNo);

            }
        }

        #endregion

        #region [PLC Data I/F]

        public void DataFromPLC(short[] plc_data_words, int plc_start_site_no, int site_words_length, int offset_mc_status_word, int offset_host_status_word)
        {
            int my_data_start = this.FirstSiteNo - plc_start_site_no;
            if (my_data_start < 0)
            {
                // 설정이 잘못된 것 (config csv, UI 에서 control 속성 등을 확인해 볼것)
                throw new System.Exception($"DataFromPLC - Error At PLC:{this.PLCNo} / FirstSiteNo:{this.FirstSiteNo}");
            }

            int my_data_end = my_data_start + (this.SiteCount * this.SiteNoIncStep) * site_words_length;
            if (my_data_end > plc_data_words.Length)
            {
                // 설정이 잘못된 것 (config csv, UI 에서 control 속성 등을 확인해 볼것)
                throw new System.Exception($"DataFromPLC - Error At PLC:{this.PLCNo} / LastSiteNo:{this.FirstSiteNo + SiteCount * SiteNoIncStep}");
            }

            foreach (SiteBox box in _siteBoxes)
            {
                short mc_status = plc_data_words[(box.SiteNo - plc_start_site_no) * site_words_length + offset_mc_status_word];
                short host_status = plc_data_words[(box.SiteNo - plc_start_site_no) * site_words_length + offset_host_status_word];
                box.DeviceInfo.DeviceStatus = GetDeviceStatus(mc_status, host_status);
            }

        }

        public void UpdateTrackStatus(int siteNo, bool trayOn, bool trayRework, int eqpStatus)
        {
            _TrayOn = trayOn;

            foreach (SiteBox box in _siteBoxes)
            {
                if (box.SiteNo == siteNo)
                {
                    box.DeviceInfo.DeviceStatus = GetDeviceStatus(trayOn, trayRework, eqpStatus);
                }
            }
        }

        #endregion

        protected override void DrawObject(Graphics g)
        {
            if (_siteBoxes == null || _siteBoxes.Length <= 0) return;

            if (ShowSiteNo)
            {
                using (Pen p = new Pen(SiteBorderColor))
                {
                    if(!_isControled) p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot; // 내꺼 아님
                    foreach (SiteBox sitebox in _siteBoxes)
                    {
                        using (SolidBrush b = new SolidBrush(GetStatusColor(sitebox.DeviceInfo.DeviceStatus, SiteBoxColor, sitebox.SiteNo)))
                        {
                            g.FillRectangle(b, sitebox.Rect);
                            g.DrawRectangle(p, sitebox.Rect);
                            //g.DrawString((sitebox.SiteNo % 100).ToString(), this.Font, Brushes.Black, sitebox.Rect);
                            if (sitebox.SiteNo > 0)
                            {
                                g.DrawString((sitebox.SiteNo).ToString(), this.Font, Brushes.Black, sitebox.Rect);

                            }
                        }
                    }
                }
            }
            else
            {
                using (Pen p = new Pen(SiteBorderColor))
                {
                    if (!_isControled) p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot; // 내꺼 아님

                    Dictionary<int, string> siteTitle = new Dictionary<int, string>();

                    if (SiteTextDisp != null)
                    {
                        foreach (var item in SiteTextDisp)
                        {
                            string[] title = item.Split('=');
                            siteTitle.Add(int.Parse(title[0].ToString()), title[1].ToString());
                        }
                    }                    

                    foreach (SiteBox sitebox in _siteBoxes)
                    {
                        using (SolidBrush b = new SolidBrush(GetStatusColor(sitebox.DeviceInfo.DeviceStatus, SiteBoxColor, sitebox.SiteNo)))
                        {
                            g.FillRectangle(b, sitebox.Rect);
                            g.DrawRectangle(p, sitebox.Rect);

                            if (IsUpperStage)
                            {
                                Rectangle r = sitebox.Rect;
                                g.DrawRectangle(p, r);
                            }

                            if (siteTitle.ContainsKey(sitebox.SiteNo))
                            {
                                Rectangle rectangle = new Rectangle();

                                switch (SiteNoDirection)
                                {
                                    case SiteTrackDirection.LeftToRight:
                                        rectangle = new Rectangle(sitebox.Rect.X + 6, sitebox.Rect.Y + 10, 0, 0);
                                        break;

                                    case SiteTrackDirection.RightToLeft:
                                        break;

                                    case SiteTrackDirection.TopToBottom:
                                        rectangle = new Rectangle(6, sitebox.Rect.Y + 10, 0, 0);
                                        break;

                                    case SiteTrackDirection.BottomToTop:
                                        break;
                                }

                                g.DrawString(siteTitle[sitebox.SiteNo], this.Font, (_TrayOn ? Brushes.Black : Brushes.White), rectangle);
                            }
                        }
                    }
                }
            }
        }

        #region [Click Event]

        protected override void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                StatusAndData info = GetClickedSite(e.Location);
                if(info != null)
                {
                    OnObjectDoubleClick(new ObjectDoubleClickEventArgs(info));
                }
            }
        }

        private StatusAndData GetClickedSite(Point pt)
        {
            if (_siteBoxes != null && _siteBoxes.Length > 0)
            {
                foreach(SiteBox box in _siteBoxes)
                {
                    if (box.Rect.Contains(pt)) return box.DeviceInfo;
                }
            }

            return null;
        }

        #endregion

        #region [Status Color Test]
#if DEBUG
        private int _demo_index = 1;
        public void DemoSiteStatus()
        {
            _siteBoxes[0].DeviceInfo.DeviceStatus = (EnumDeviceStatus)_demo_index;
            Refresh();

            _demo_index <<= 1;
            if (_demo_index >= (int)EnumDeviceStatus.MAXVALUE) _demo_index = 1;
        }
#endif
        #endregion

    }

    public class SiteBox
    {
        public int SiteNo;
        public Rectangle Rect;
        public StatusAndData DeviceInfo;

        public SiteBox(bool isControl=true)
        {
            DeviceInfo = new StatusAndData();
            DeviceInfo.IsControled = isControl;
        }
    }

    public enum SiteTrackDirection
    {
        LeftToRight = 1,
        RightToLeft = 2,
        TopToBottom = 3,
        BottomToTop = 4,
    }

    public enum TrayMovingDirection
    {
        LeftToRight = 1,
        RightToLeft = 2,
        TopToBottom = 3,
        BottomToTop = 4,
        BiDirectionH = 5,
        BiDirectionV = 6
    }

}
