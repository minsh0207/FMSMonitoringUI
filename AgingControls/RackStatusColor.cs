using System.Drawing;

namespace AgingControls
{
    public static class RackStatusBrush
    {
        #region [Brush Properties]
        #region [Bay Brushs]
        // box 여백
        //public static Brush BayBrush_bg = Brushes.DarkGray;
        public static Brush BayBrush_bg = Brushes.WhiteSmoke;
        // box번호가 있는 bay의 여백 / 랙번호 bg
        public static Brush MarkerBayBrush_bg = Brushes.DarkGray;
        //public static Brush MarkerBayBrush_bg = Brushes.WhiteSmoke;
        //public static Brush MarkerBayBrush_bg = new SolidBrush(Color.FromArgb(241,241,241));
        // 랙번호 bg
        public static Brush BayNoLabelBrush_bg = Brushes.DarkBlue;
        // 랙번호 Text 색상
        public static Brush BayNoLabelBrush_fg = Brushes.White;
        #endregion

        #region [Rack Brushs]
        //Juyang - Brush에 RGB Color 적용
        // Empty box
        //public static Brush RackStatusBrush_Empty = Brushes.Gray;
        //public static Brush RackStatusBrush_Empty = new SolidBrush(Color.FromArgb(66, 73, 89));
        //20190409 KJY - Empty 흰색으로
        public static Brush RackStatusBrush_Empty = Brushes.White;
        //20221205 MSH - 바탱색으로 변경
        //public static Brush RackStatusBrush_Empty = new SolidBrush(Color.FromArgb(27, 27, 27));

        //public static Brush RackStatusBrush_Empty_fg = Brushes.White;
        // White 너무 튄다.
        public static Brush RackStatusBrush_Empty_fg = Brushes.Black;

        // 뭐지? 아마도 왼쪽 누르면... 
        public static Brush RackStatusBrush_Full = Brushes.LightGray;
        public static Brush RackDefaultFilter_None = Brushes.Black;             // by YGPark
        public static Brush RackSelectedFilter_Value = Brushes.White;           // by YGPark

         #region - Aging Stages
        public static Brush RackStatusBrush_1stAging_bg = Brushes.LightCyan;
        public static Brush RackStatusBrush_1stAging_fg = Brushes.Black;

        public static Brush RackStatusBrush_2ndAging_bg = Brushes.Cyan;
        public static Brush RackStatusBrush_2ndAging_fg = Brushes.Black;

        public static Brush RackStatusBrush_3rdAging_bg = Brushes.DarkCyan;
        public static Brush RackStatusBrush_3rdAging_fg = Brushes.Black;
        
        public static Brush RackStatusBrush_4thAging_bg = Brushes.Blue;
        public static Brush RackStatusBrush_4thAging_fg = Brushes.White;
        
        public static Brush RackStatusBrush_5thAging_bg = Brushes.DarkBlue;
        public static Brush RackStatusBrush_5thAging_fg = Brushes.White;

        public static Brush RackStatusBrush_6thAging_bg = Brushes.DarkOliveGreen;
        public static Brush RackStatusBrush_6thAging_fg = Brushes.White;

        public static Brush RackStatusBrush_ShipRTAging_bg = Brushes.LightYellow;
        public static Brush RackStatusBrush_ShipRTAging_fg = Brushes.Black;

        //public static Brush RackStatusBrush_HTAging_bg = Brushes.Orange;
        public static Brush RackStatusBrush_HTAging_bg = new SolidBrush(Color.FromArgb(255, 204, 0));
        public static Brush RackStatusBrush_HTAging_fg = Brushes.Black;

        

        #endregion

        #region - Load/Unload
        // 입고 금지
        //public static Brush RackStatusBrush_NoInput_bg = Brushes.Magenta;
        public static Brush RackStatusBrush_NoInput_bg = new SolidBrush(Color.FromArgb(96, 62, 138));
        public static Brush RackStatusBrush_NoInput_fg = Brushes.White;
        // 출고 금지
        //public static Brush RackStatusBrush_NoOutput_bg = Brushes.Magenta;
        //public static Brush RackStatusBrush_NoOutput_bg = new SolidBrush(Color.FromArgb(96, 62, 138));
        //public static Brush RackStatusBrush_NoOutput_fg = Brushes.White;
        public static Brush RackStatusBrush_NoOutput_bg = Brushes.Gray;
        public static Brush RackStatusBrush_NoOutput_fg = Brushes.White;
        // Load
        //public static Brush RackStatusBrush_LoadRequest_bg = Brushes.DarkGreen;
        public static Brush RackStatusBrush_LoadRequest_bg = new SolidBrush(Color.FromArgb(0, 128, 1));
        public static Brush RackStatusBrush_LoadRequest_fg = Brushes.White;
        // Loading
        //public static Brush RackStatusBrush_Loading_bg = Brushes.LightSalmon;
        public static Brush RackStatusBrush_Loading_bg = new SolidBrush(Color.FromArgb(220, 101, 58));
        public static Brush RackStatusBrush_Loading_fg = Brushes.Black;
        // Unload
        //public static Brush RackStatusBrush_UnloadRequest_bg = Brushes.Green;
        public static Brush RackStatusBrush_UnloadRequest_bg = new SolidBrush(Color.FromArgb(127, 165, 128));
        public static Brush RackStatusBrush_UnloadRequest_fg = Brushes.Black;
        // Unloading
        //public static Brush RackStatusBrush_Unloading_bg = Brushes.Brown;
        public static Brush RackStatusBrush_Unloading_bg = new SolidBrush(Color.FromArgb(197, 136, 21));
        public static Brush RackStatusBrush_Unloading_fg = Brushes.White;
        // Plan Unloading
        //public static Brush RackStatusBrush_UnloadPlanned_bg = Brushes.LightGreen;
        public static Brush RackStatusBrush_UnloadPlanned_bg = new SolidBrush(Color.FromArgb(0, 251, 0));
        public static Brush RackStatusBrush_UnloadPlanned_fg = Brushes.Black;


        //강제 입고
        public static Brush RackStatusBrush_GLoading_bg = Brushes.Yellow;
        public static Brush RackStatusBrush_GLoading_fg = Brushes.Black;

        //20210430 KJY - 강제입고 305
        public static Brush RackStatusBrush_G305Loading_bg = Brushes.Pink;
        public static Brush RackStatusBrush_G305Loading_fg = Brushes.Black;
        //20210430 KJY - 강제입고 322
        public static Brush RackStatusBrush_G322Loading_bg = Brushes.LightBlue;
        public static Brush RackStatusBrush_G322Loading_fg = Brushes.Black;

        #endregion

        #region - Abnormal Statuses
        //public static Brush RackStatusBrush_Abnormal_Bad_bg = Brushes.Red;
        public static Brush RackStatusBrush_Abnormal_Bad_bg = new SolidBrush(Color.FromArgb(244, 30, 30));
        public static Brush RackStatusBrush_Abnormal_Bad_fg = Brushes.White;

        //public static Brush RackStatusBrush_Abnormal_Trouble_bg = Brushes.Red;
        public static Brush RackStatusBrush_Abnormal_Trouble_bg = new SolidBrush(Color.FromArgb(244, 30, 30));
        public static Brush RackStatusBrush_Abnormal_Trouble_fg = Brushes.White;

        //public static Brush RackStatusBrush_Abnormal_Fire_bg = Brushes.Red;
        public static Brush RackStatusBrush_Abnormal_Fire_bg = new SolidBrush(Color.FromArgb(244, 30, 30));
        public static Brush RackStatusBrush_Abnormal_Fire_fg = Brushes.White;

        //public static Brush RackStatusBrush_Abnormal_Water_bg = Brushes.Red;
        public static Brush RackStatusBrush_Abnormal_Water_bg = new SolidBrush(Color.FromArgb(244, 30, 30));
        public static Brush RackStatusBrush_Abnormal_Water_fg = Brushes.White;

        //public static Brush RackStatusBrush_Abnormal_Duplicated_bg = Brushes.Red;
        public static Brush RackStatusBrush_Abnormal_Duplicated_bg = new SolidBrush(Color.FromArgb(244, 30, 30));
        public static Brush RackStatusBrush_Abnormal_Duplicated_fg = Brushes.White;

        //public static Brush RackStatusBrush_Abnormal_Emptied_bg = Brushes.Red;
        public static Brush RackStatusBrush_Abnormal_Emptied_bg = new SolidBrush(Color.FromArgb(244, 30, 30));
        public static Brush RackStatusBrush_Abnormal_Emptied_fg = Brushes.White;

        // 20211118 KJY - Marked Lock Tray By MES API
        public static Brush RackStatusBrush_Lock_bg = Brushes.DarkOrchid;
        public static Brush RackStatusBrush_Lock_fg = Brushes.White;
        #endregion
        #endregion

        #endregion

    }
}
