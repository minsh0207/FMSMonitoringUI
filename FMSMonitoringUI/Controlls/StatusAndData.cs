using System;

namespace ControlGallery
{
    public class StatusAndData
    {
        public int PLCNo;
        public int CVPLCListDeviceID;
        public int SiteNo;
        public EnumDeviceStatus DeviceStatus = EnumDeviceStatus.None;
        public short WordStatus;
        public short WordTroubleCode;
        public short[] DataWordArray;

        public bool IsControled = true;
        public void SetData(int plcno, int plc_reader_id, int siteno, EnumDeviceStatus status = EnumDeviceStatus.None, short wst = 0, short wtr = 0, short[] data_arr = null)
        {
            PLCNo = plcno;
            CVPLCListDeviceID = plc_reader_id;
            SiteNo = siteno;
            DeviceStatus = status;
            WordStatus = wst;
            WordTroubleCode = wtr;
            DataWordArray = data_arr;
        }

        public override string ToString()
        {
            return $"GROUPNo:{CVPLCListDeviceID},PLCNo:{PLCNo}, SiteNo:{SiteNo}, DeviceStatus:{DeviceStatus}";
        }
    }

    [Flags]
    public enum EnumDeviceStatus
    {
        None = 0

        ,NormalStateBegin = 1

        ,Online = 1
        ,TrayOn = 2
        ,ReqBCR = 4
        ,BCRReading = 8
        ,GettingCommand = 16
        ,CommandWritten = 32
        ,StationUp = 64
        ,StationDown = 128
        ,StationReady = 256

        ,NotMyTray = 512

        ,NormalStateEnd = 1024


        ,PLCOffline = 2048
        ,TroubleStateBegin = 4096

        ,BCRReadingError = 4096
        ,PLCWriteFailed = 8192
        ,UnKnownTrayID = 16384
        ,RouteNotFound = 32768
        ,PLCTrouble = 65536

        ,MAXVALUE
    }

}
