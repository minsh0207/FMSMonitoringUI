using System;
using System.Collections.Generic;
using System.Linq;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaGds;

namespace OPCUAClientClassLib
{
    [Serializable]
    public class SiteTagInfo
    {
        public SiteTagInfo()
        {
            //
        }
        //public bool Alive { get; set; }

        //public bool Power { get; set; }

        //public int Mode { get; set; }

        //public int Status { get; set; }

        //public int EqpErrorNo { get; set; }

        //public int EqpErrorLevel { get; set; }

        //public string TimeSync { get; set; }

        //public int FMSErrorNo { get; set; }

        //public int FMSErrorLevel { get; set; }

        public int ConveyorNo { get; set; }

        public int ConveyorType { get; set; }

        public int StationStatus { get; set; }

        public bool TrayExist { get; set; }

        public int TrayType { get; set; }

        public int TrayCount { get; set; }

        public string TrayIdL1 { get; set; }

        public string TrayIdL2 { get; set; }

        public int CarriagePos { get; set; }

        public int Destination { get; set; }

        //public bool CommandReady { get; set; }

        //public int Destination { get; set; }

        //public int MagazineCommand { get; set; }
    }

    public class CraneTagInfo
    {
        public CraneTagInfo()
        {
            //
        }

        public int JobType { get; set; }

        public bool TrayExist { get; set; }

        public int TrayCount { get; set; }

        public string TrayIdL1 { get; set; }

        public string TrayIdL2 { get; set; }
    }

    public class RackTagInfo
    {
        public RackTagInfo()
        {
            //
        }

        public string RackID { get; set; }

        public string TrayIdL1 { get; set; }

        public string TrayIdL2 { get; set; }

        public string ModelID { get; set; }

        public string RouteID { get; set; }

        public string LotID { get; set; }

        public string RackStatus { get; set; }

        public string TrayZone { get; set; }

        public string CellType { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string TroubleCode { get; set; }

        public string TroubleName { get; set; }
    }

    public class ItemInfo
    {
        public ItemInfo()
        {
            SiteNo = 0;
            CraneNo = 0;
            ConveyorNo = 0;
            GroupNo = 0;
            BrowseName = string.Empty;
            EqpID = string.Empty;
            ServerNo = 0;
            //ControlType = enEqpType.CNV;
        }
        /// <summary>
        /// Track No
        /// </summary>
        public int SiteNo { get; set; }
        /// <summary>
        /// Crane No
        /// </summary>
        public int CraneNo { get; set; }
        /// <summary>
        /// Conveyor No (CtrlSiteTrack Control 하나를 가리킨다. Control속성중 PLC No를 사용함)
        /// </summary>
        public int ConveyorNo { get; set; }
        /// <summary>
        /// Track를 Group별로 구분한다.(OPCServer 구분인자)
        /// </summary>
        public int GroupNo { get; set; }
        /// <summary>
        /// Browse Name
        /// </summary>
        public string BrowseName { get; set; }
        /// <summary>
        /// Equipment ID
        /// </summary>
        public string EqpID { get; set; }
        /// <summary>
        /// Control의 Type을 구분한다.(Conveyor=CNV, StackerCrane=STC)
        /// </summary>
        /// /// <summary>
        /// FMS Server No
        /// </summary>
        public int ServerNo { get; set; }
        public enEqpType ControlType { get; set; }

    }

    public class CBrowerInfo
    {
        public string BrowerPath { get; set; }
        public bool SubScribe { get; set; }
    }

    public class CDeviceInfo
    {
        public CDeviceInfo()
        {
            Item = new Dictionary<int, List<ItemInfo>>();
        }

        public int GroupNo { get; set; }

        public Dictionary<int, List<ItemInfo>> Item { get; }

        public void AddItem(int deviceID, ItemInfo itemInfo)
        {
            if (Item.ContainsKey(deviceID))
            {
                Item[deviceID].Add(itemInfo);
            }
            else
            {
                Item[deviceID] = new List<ItemInfo> { itemInfo };
            }
        }

    }

    public class COPCGroupCtrl
    {
        public COPCGroupCtrl()
        {
            GroupList = new Dictionary<int, List<CDeviceInfo>>();
        }

        public Dictionary<int, List<CDeviceInfo>> GroupList { get; }

        public void AddList(int deviceID, CDeviceInfo deviceInfo)
        {
            if (GroupList.ContainsKey(deviceID))
            {
                GroupList[deviceID].Add(deviceInfo);
            }
            else
            {
                GroupList[deviceID] = new List<CDeviceInfo> { deviceInfo };
            }
        }
    }
}
