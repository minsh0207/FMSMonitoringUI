using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ControlGallery
{
    public partial class BCRMarker : BaseControl
    {
        private bool _prevbcruseyn = true;
        private bool _bcruseyn = true;
        public bool BCRUseYN
        {
            get { return _bcruseyn; }
            set
            {
                if(_prevbcruseyn != value)
                {
                    _bcruseyn = value;
                    _prevbcruseyn = _bcruseyn;
                    BackColor = _bcruseyn ? _DefColor : Color.Gray;
                }
                
            }
        }

        public BCRMarker()
        {
            InitializeComponent();

            //
            _DefColor = this.BackColor;
            BCRUseYN = true;
        }

        #region [ToolTip for TrayID Reading]

        BubbleText _BubbleTextControl;
        string _BubbleText = string.Empty;

        public void SetBubbleTextObject(BubbleText c, int bcrLevel, BCRMarkPosition bcrPos)
        {
            _BubbleTextControl = c;
            if (bcrPos == BCRMarkPosition.Top)
            {
                if (bcrLevel == 1)
                {
                    _BubbleTextControl.Location = new Point(this.Location.X + 190, this.Location.Y - 20); // 24 -> 10
                }
                else
                {
                    _BubbleTextControl.Location = new Point(this.Location.X + 190, this.Location.Y - 33);
                }
            }
            else if (bcrPos == BCRMarkPosition.Bottom)
            {
                _BubbleTextControl.Location = new Point(this.Location.X + 200, this.Location.Y + 10); // 24 -> 10
            }
            else if (bcrPos == BCRMarkPosition.Right)
            {
                _BubbleTextControl.Location = new Point(this.Location.X + 220, this.Location.Y + 10); // 24 -> 10
            }
            else if (bcrPos == BCRMarkPosition.Left)
            {
                _BubbleTextControl.Location = new Point(this.Location.X + 140, this.Location.Y + 10); // 24 -> 10
            }

            _BubbleTextControl.Visible = false;
        }

        public void ShowToolTip()
        {
            if (BubbleText != null && BubbleText.Length > 0 && _BubbleTextControl != null)
            {
                _BubbleTextControl.DisplayText(BubbleText, Color.Yellow);
                if (BubbleText[0] == '*')
                {
                    BackColor = Color.Salmon;
                }
                else
                {
                    BackColor = _DefColor;
                }
            }
        }

        private Color _DefColor = Color.LightGray;

        #endregion


        #region [Properties]

        BCRMarkPosition _bcrMarkPosition = BCRMarkPosition.Top;
        [DisplayName("BCR Mark Position"), Description("BCR Mark Position"), Category("UBI Property")]
        public BCRMarkPosition BCRMarkPosition
        {
            get { return _bcrMarkPosition; }
            set
            {
                if(_bcrMarkPosition != value)
                {
                    _bcrMarkPosition = value;
                    CalcBCRMarkerRect();
                    Refresh();
                }
            }
        }

        int _bcrMarkThickness = 4;
        [DisplayName("BCR Mark Thickness"), Description("BCR Mark Thickness"), Category("UBI Property")]
        public int BCRMarkThickness
        {
            get { return _bcrMarkThickness; }
            set
            {
                if (_bcrMarkThickness != value)
                {
                    _bcrMarkThickness = value;
                    CalcBCRMarkerRect();
                    Refresh();
                }
            }
        }

        Color _bcrMarkerColor = Color.Blue;
        [DisplayName("BCR Mark Color"), Description("BCR Mark Color"), Category("UBI Property")]
        public Color BCRMarkColor
        {
            get { return _bcrMarkerColor; }
            set
            {
                if(_bcrMarkerColor != value)
                {
                    _bcrMarkerColor = value;
                    Refresh();
                }
            }
        }

        int _bcrLevel = 1;
        [DisplayName("BCR Level"), Description("BCR Level"), Category("UBI Property")]
        public int BCRLevel
        {
            get { return _bcrLevel; }
            set
            {
                if (_bcrLevel != value)
                {
                    _bcrLevel = value;
                    Refresh();
                }
            }
        }

        public string BubbleText
        {
            get
            {
                return _BubbleText;
            }

            set
            {
                _BubbleText = value;
            }
        }

        #endregion


        #region [Calc BCR Marker Rect]

        Rectangle _rectBCRMarker;

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            CalcBCRMarkerRect();
        }

        private void CalcBCRMarkerRect()
        {
            _rectBCRMarker = DisplayRectangle;
            switch (BCRMarkPosition)
            {
                case BCRMarkPosition.Top:
                    _rectBCRMarker.Height = BCRMarkThickness;
                    break;

                case BCRMarkPosition.Bottom:
                    _rectBCRMarker.Height = BCRMarkThickness;
                    _rectBCRMarker.Y = DisplayRectangle.Height - _rectBCRMarker.Height;
                    break;

                case BCRMarkPosition.Left:
                    _rectBCRMarker.Width = BCRMarkThickness;
                    break;

                case BCRMarkPosition.Right:
                    _rectBCRMarker.Width = BCRMarkThickness;
                    _rectBCRMarker.X = DisplayRectangle.Width - _rectBCRMarker.Width;
                    break;
            }
        }

        #endregion

        private void DrawBCRMarker(Graphics g)
        {
            using (SolidBrush br = new SolidBrush(BCRMarkColor))
            {
                g.FillRectangle(br, _rectBCRMarker);
            }
        }

        protected override void DrawObject(Graphics g)
        {
            base.DrawObject(g);
            DrawBCRMarker(g);
            if (ShowSiteNo)
            {
                //g.DrawString((SiteNo % 100).ToString(), this.Font, Brushes.Black, DisplayRectangle);
                g.DrawString(SiteNo.ToString(), this.Font, Brushes.Black, DisplayRectangle);
            }
        }

    }

    public enum BCRMarkPosition
    {
        Top = 1,
        Bottom,
        Left,
        Right
    }

}
