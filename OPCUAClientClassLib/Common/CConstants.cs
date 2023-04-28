﻿using System;
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
        //None = 0,

        /// <summary>
        /// Conveyor
        /// </summary>
        CNV = 0,
        /// <summary>
        /// StackerCrane
        /// </summary>
        STC,
        /// <summary>
        /// StackerCrane(LT)
        /// </summary>
        //STL,
        /// <summary>
        /// StackerCrane(HT)
        /// </summary>
        //STH,
        /// <summary>
        /// StackerCrane(FORMATION)
        /// </summary>
        //STF,
        /// <summary>
        /// RTV
        /// </summary>
        RTV01 = 999,
    }

    //public enum enCVTagList
    //{
    //    Mode = 0,
    //    Status,
    //    EqpErrorNo,
    //    EqpErrorLevel,
    //    FMSStatus,
    //    FMSErrorNo,
    //    TrackNo,
    //    ConveyorType,
    //    StationStatus,
    //    TrayExist,
    //    TrayType,
    //    TrayCount,
    //    TrayIdL1,
    //    TrayIdL2,
    //    CarriagePos,
    //    CommandReady,
    //    Destination,
    //    MagazineCommand
    //}

    //public enum enCraneTagList
    //{
    //    TrayExist = 0,
    //    JobType,
    //    TrayIdL1,
    //    TrayIdL2,
    //    TrayCount
    //}
}
