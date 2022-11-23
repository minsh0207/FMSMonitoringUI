using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCUAClientClassLib
{
    public enum enEqpType
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// Conveyor
        /// </summary>
        CNV,

        /// <summary>
        /// StackerCrane
        /// </summary>
        STC,

        /// <summary>
        /// RTV
        /// </summary>
        RTV,
    }

    public enum enSiteTagList
    {
        Alive = 0,
        Power,
        Mode,
        Status,
        EqpErrorNo,
        EqpErrorLevel,
        TimeSync,
        FMSErrorNo,
        FMSErrorLevel,
        ConveyorNo,
        ConveyorType,
        StationStatus,
        TrayExist,
        TrayType,
        TrayCount,
        TrayIdL1,
        TrayIdL2,
        CarriagePos,
        CommandReady,
        Destination,
        MagazineCommand
    }

    public enum enCraneTagList
    {
        TrayExist = 0,
        JobType,
        TrayIdL1,
        TrayIdL2,
        TrayCount
    }
}
