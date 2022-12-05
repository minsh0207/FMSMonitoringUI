using OPCUAClientClassLib;
using Org.BouncyCastle.Asn1.Tsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMSMonitoringUI.Monitoring
{
    public partial class WinRackInfo : Form
    {
        private Point point = new Point();

        public WinRackInfo()
        {
            InitializeComponent();

            #region Title Mouse Event
            ctrlTitleBar.MouseDown_Evnet += Title_MouseDownEvnet;
            ctrlTitleBar.MouseMove_Evnet += Title_MouseMoveEvnet;
            #endregion
        }

        public void SetRackInfo(RackTagInfo tagInfo)
        {
            _RackID.TextData = tagInfo.RackID;
            _TrayIdL1.TextData = tagInfo.TrayIdL1;
            _TrayIdL2.TextData = tagInfo.TrayIdL2;
            _ModelID.TextData = tagInfo.ModelID;
            _RouteID.TextData = tagInfo.RouteID;
            _LotID.TextData = tagInfo.LotID;
            _RackStatus.TextData = tagInfo.RackStatus;
            _TrayZone.TextData = tagInfo.TrayZone;
            _CellType.TextData = tagInfo.CellType;
            _StartTime.TextData = tagInfo.StartTime;
            _EndTime.TextData = tagInfo.EndTime;
            _TroubleCode.TextData = tagInfo.TroubleCode;
            _TroubleName.TextData = tagInfo.TroubleName;
        }
        public void SetRackInfo(DataSet ds)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                _RackID.TextData = row["rack_id"].ToString();
                _TrayIdL1.TextData = row["tray_id"].ToString();
                _TrayIdL2.TextData = row["tray_id_2"].ToString();
                _ModelID.TextData = row["in_model_id"].ToString();
                _RouteID.TextData = row["in_route_id"].ToString();
                _LotID.TextData = "";   // row["lot_id"].ToString();
                _RackStatus.TextData = row["status"].ToString();
                _TrayZone.TextData = row["in_tray_zone"].ToString();
                _CellType.TextData = row["in_cell_type"].ToString();
                _StartTime.TextData = row["start_time"].ToString();
                _EndTime.TextData = row["end_time"].ToString();
                _TroubleCode.TextData = row["trouble_code"].ToString();
                _TroubleName.TextData = ""; // row["trouble_name"].ToString();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle clientRectangle = e.ClipRectangle;

            clientRectangle.Y += 0;
            clientRectangle.Height -= 0;

            ControlPaint.DrawBorder(e.Graphics, clientRectangle, Color.White, ButtonBorderStyle.Solid);

            Rectangle textRectangle = e.ClipRectangle;

            textRectangle.X += 0;
            textRectangle.Width = 0;
            textRectangle.Height = 0;

            e.Graphics.FillRectangle(new SolidBrush(BackColor), textRectangle);
            e.Graphics.DrawString("", Font, new SolidBrush(ForeColor), textRectangle);
        }

        private void ctrlButtonExit1_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Tray Tag Value
        private string GetConveyorType(int idx)
        {
            string ret = string.Empty;

            switch (idx)
            {
                case 1:
                    ret = "Conveyor Unit";
                    break;
                case 2:
                    ret = "InStation";
                    break;
                case 4:
                    ret = "OutStation";
                    break;
                case 8:
                    ret = "InOutStation";
                    break;
                case 16:
                    ret = "BufferStation";
                    break;
                case 32:
                    ret = "Diverter";
                    break;
                case 64:
                    ret = "Magazine";
                    break;
                case 128:
                    ret = "Dispenser";
                    break;
                case 256:
                    ret = "MZ / DP";
                    break;
            }

            return ret;
        }

        private string GetStationStatus(int idx)
        {
            string ret = string.Empty;

            switch (idx)
            {
                case 0:
                    ret = "Not Used";
                    break;
                case 1:
                    ret = "Station Down";
                    break;
                case 2:
                    ret = "Station Up";
                    break;
            }

            return ret;
        }

        private string GetTrayType(int idx)
        {
            string ret = string.Empty;

            switch (idx)
            {
                case 1:
                    ret = "BD - Before Degas Long Tray";
                    break;
                case 2:
                    ret = "AD - After Degas Short Tray";
                    break;
            }

            return ret;
        }
        #endregion

        #region Titel Mouse Event
        private void Title_MouseDownEvnet(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void Title_MouseMoveEvnet(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Location = new Point(this.Left - (point.X - e.X), this.Top - (point.Y - e.Y));
            }
        }
        #endregion
    }
}
