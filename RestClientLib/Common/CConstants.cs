using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    #region Action Type
    public enum enActionType
    {
        SQL_SELECT = 0,
        SQL_UPDATE,
        SQL_INSERT,
        SEND_MANUAL_COMMAND
    }
    #endregion

    #region REST Equipment Type
    public enum enRestEqpType
    {
        IMS = 30011,
        OCV = 30301,
        DCR = 30401,
        MIC = 30501,
        LKC = 30601,
        VSI = 30701,
        DGS = 30801,
        NGS = 30901,
        HPC = 0,
        CHG = 1,
        PAC = 31101
    }
    #endregion

    #region REST Unit ID
    public enum enRestUnitID
    {
        NULL = 0,
        HPC0110101 = 30201,
        HPC0110102 = 30202,
        CHG0110101 = 30101,
        CHG0110102 = 30102,
        CHG0110103 = 30103,
        CHG0110104 = 30104,
        CHG0110201 = 30105,
        CHG0110202 = 30106,
        CHG0110203 = 30107,
        CHG0110204 = 30108,
        CHG0110301 = 30109,
        CHG0110302 = 30110,
        CHG0110303 = 30111

    }
    #endregion
}
