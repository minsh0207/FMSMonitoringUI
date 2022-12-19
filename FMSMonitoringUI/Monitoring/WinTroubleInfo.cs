using MonitoringUI.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringUI.Monitoring
{
    public partial class WinTroubleInfo : WinFormRoot
    {
        #region Variables
        string m_strEqpTypeID;
        string m_strUnitID;
        #endregion

        #region Constructor
        public WinTroubleInfo()
        {
            InitializeComponent();
        }
        public WinTroubleInfo(string strEqpTypeID, string strUnitID)
        {
            InitializeComponent();

            InitControl();

            // Get Data
            m_strEqpTypeID = strEqpTypeID;
            m_strUnitID = strUnitID;
        }
        #endregion

        #region InitControl
        private void InitControl()
        {
            ctrlDateTimeDT2DT1.StartDate = DateTime.Now.AddDays(-5);
            ctrlDateTimeDT2DT1.EndDate = DateTime.Now.AddDays(1);


            /// 
            /// 화면권한 관련
            /// 
            bool bView = false;
            bool bSave = false;
            // 화면ID 설정
            Tag = CAuthority.WindowsNameToWindowID(this.GetType().FullName.ToString());
            //Get Authority
            CAuthority.GetAuthority(CDefine.m_strLoginID, Tag.ToString(), ref bView, ref bSave);
            this.WindowID = Tag.ToString();
            ///
            ///
            ///


        }

        #endregion
        #region WinTroubleInfo_Load
        private void WinTroubleInfo_Load(object sender, EventArgs e)
        {
            titBar.TitleText = LocalLanguage.GetItemString("titleTroubleInfo");

            //ctrlButtonSearch_MouseClick(sender, e);
            ctrlButtonSearch1_Click(sender, e);


        } 
        #endregion

        #region ctrlButtonSearch_MouseClick
        //private void ctrlButtonSearch_MouseClick(object sender, MouseEventArgs e)
        private void ctrlButtonSearch_MouseClick(object sender, EventArgs e)
        {
            InitGridView();

            //Set UnitName
            string strUnitName = GetUnitName().GetAwaiter().GetResult();
            ctrlTextBoxEqpName1.TextBoxText = strUnitName;

            //Set GridView
            GetTroubleData().GetAwaiter().GetResult();

            //Grid채우기

        }
        #endregion

        #region InitGridView
        private void InitGridView()
        {
            gridView.Init(ScrollBars.Both, DataGridViewSelectionMode.CellSelect, true);

            gridView.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 100, LocalLanguage.GetItemString("DEF_CONTROL_152"), true, true, 10); //설비명
            gridView.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 200, LocalLanguage.GetItemString("DEF_CONTROL_045"), true, true, 10); // Unit
            gridView.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 100, LocalLanguage.GetItemString("strTroubleCode"), true, true, 10); // Trouble Code
            gridView.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 300, LocalLanguage.GetItemString("strTroubleName"), true, true, 10);
            gridView.ColumnType(enSpreadColumnType.Text, DataGridViewContentAlignment.MiddleCenter, 150, LocalLanguage.GetItemString("DEF_SPREAD_110"), true, true, 10); //발생일시


        }
        #endregion

        #region GetEQPData
        //private async Task<DataTable> GetTroubleData()
        private async Task GetTroubleData()
        {
            string[] strData = new string[5];
            try
            {
                RESTClient_old restClinet = new RESTClient_old();
                JObject loadEQPQuery = new JObject();
                string strSql = "";
                strSql += " SELECT C.EqpTypeName,D.UnitName,         E.UnitName BcrUnitName"
                       + "       , (CASE ISNULL(A.EventTime, '') WHEN '' THEN A.EventTime ELSE CONVERT(VARCHAR(19), CONVERT(DATETIME,stuff(stuff(stuff(A.EventTime, 9, 0, ' '), 12, 0, ':'), 15, 0, ':')), 120) END) AS EventTime"
                       + "       , A.UserAction,A.TroubleCode,C.EqpTypeID"
                       + "       , B.TroubleName_kr,B.TroubleName_cn,B.TroubleName_en"
                       + "       , SUBSTRING(F.RackID, 1, 1) + CONVERT(VARCHAR, CONVERT(int, SUBSTRING(F.RackID, 2, 2))) + '-' + SUBSTRING(F.RackID, 4, 1) + 'Line-' + SUBSTRING(F.RackID, 5, 2) + 'Bay-' + SUBSTRING(F.RackID, 7, 2) + 'Rack' AS AgingUnitName"
                       + "   FROM tTroubleEventTm A WITH (NOLOCK)"
                       + "        LEFT OUTER JOIN tMstTrouble B WITH (NOLOCK)"
                       + "          ON B.EqpTypeID= A.EqpTypeID"
                       + "         AND B.TroubleCode= A.TroubleCode"
                       + "        LEFT OUTER JOIN tMstEqpGroup C WITH (NOLOCK)"
                       + "          ON C.EqpTypeID= A.EqpTypeID"
                       + "        LEFT OUTER JOIN tMstEquipment D WITH (NOLOCK)"
                       + "          ON D.EqpTypeID= A.EqpTypeID"
                       + "         AND D.UnitID   = A.UnitID"
                       + "        LEFT OUTER JOIN tMstEquipmentBcr E WITH (NOLOCK)"
                       + "          ON E.EqpTypeID= A.EqpTypeID"
                       + "         AND E.UnitID   = A.UnitID"
                       + "        LEFT OUTER JOIN tMstAgingRack F WITH (NOLOCK)"
                       + "          ON F.RackID= A.UnitID"
                       + " WHERE A.EqpTypeID= '" + m_strEqpTypeID + "'"
                       + "   AND A.UnitID= '" + m_strUnitID + "'"
                       + "   AND A.EventTime     BETWEEN '" + ctrlDateTimeDT2DT1.StartDate.ToString("yyyyMMdd") + ctrlDateTimeDT2DT1.StartDate.ToString("HHmmss") + "'"
                       + "                           AND '" + ctrlDateTimeDT2DT1.EndDate.ToString("yyyyMMdd") + ctrlDateTimeDT2DT1.EndDate.ToString("HHmmss") + "'"
                       + "   ORDER BY A.EventTime DESC ";


                loadEQPQuery["query"] = strSql;
                var JsonResult = await restClinet.GetJson(JsonApiType.Table, JsonCRUD.SELECT, "query.php", loadEQPQuery);

                JsonTroubleEventTm Troubles = JsonConvert.DeserializeObject<JsonTroubleEventTm>(JsonResult);

                if(Troubles.count>0)
                {
                    for(int i =0; i< Troubles.count; i++)
                    {
                        strData[0] = Troubles.troubleEventTmList[i].EqpTypeName;
                        strData[1] = Troubles.troubleEventTmList[i].UnitName;
                        strData[2] = Troubles.troubleEventTmList[i].TroubleCode;
                        // language에 따라 간다.
                        if (CDefine.m_enLanguage == enLoginLanguage.Korean)
                            strData[3] = Troubles.troubleEventTmList[i].TroubleName_kr;
                        else if (CDefine.m_enLanguage == enLoginLanguage.France)
                            strData[3] = Troubles.troubleEventTmList[i].TroubleName_fr;
                        else if (CDefine.m_enLanguage == enLoginLanguage.English)
                            strData[3] = Troubles.troubleEventTmList[i].TroubleName_en;
                        else
                            strData[3] = "Check Language Setting";

                        strData[4] = Troubles.troubleEventTmList[i].EventTime;

                        gridView.CustRowADDHeaderNumber(strData);
                    }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:LoadAgingRackData] {0}", ex.ToString()));
                //return null;
            }
        }
        #endregion
        #region GetUnitName
        private async Task<string> GetUnitName()
        {
            try
            {
                RESTClient_old restClinet = new RESTClient_old();
                JObject loadEQPQuery = new JObject();
                string strSql = "";
                if (m_strEqpTypeID == "3")
                {
                    //strSql += " SELECT A.RackID UnitID"
                    strSql += " SELECT A.RackID RetString1"
                       //+ "      , SUBSTRING(A.RackID, 1, 1) + CONVERT(VARCHAR, CONVERT(int, SUBSTRING(A.RackID, 2, 2))) + '-' + SUBSTRING(A.RackID, 4, 1) + 'Line-' + SUBSTRING(A.RackID, 5, 2) + 'Bay-' + SUBSTRING(A.RackID, 7, 2) + 'Rack' AS UnitName"
                       + "      , SUBSTRING(A.RackID, 1, 1) + CONVERT(VARCHAR, CONVERT(int, SUBSTRING(A.RackID, 2, 2))) + '-' + SUBSTRING(A.RackID, 4, 1) + 'Line-' + SUBSTRING(A.RackID, 5, 2) + 'Bay-' + SUBSTRING(A.RackID, 7, 2) + 'Rack' AS RetString2"
                       + "   FROM tMstAgingRack  A WITH (NOLOCK)"
                       + "  WHERE A.RackID= '" + m_strUnitID.ToString() + "'"
                       + "  ORDER BY A.RackID";
                }
                else
                {
                    //strSql += " SELECT A.UnitName"
                    strSql += " SELECT A.UnitName as RetString1 "
                       + "    FROM tMstEquipment     A WITH (NOLOCK)"
                       + "   WHERE A.EqpTypeID= '" + m_strEqpTypeID + "'"
                       + "     AND A.UnitID= '" + m_strUnitID + "'"
                       + "   ORDER BY EqpTypeID ASC";
                }


                loadEQPQuery["query"] = strSql;
                var JsonResult = await restClinet.GetJson(JsonApiType.Table, JsonCRUD.SELECT, "query.php", loadEQPQuery);
                JsonNReturnString GetUniNameJson = JsonConvert.DeserializeObject<JsonNReturnString>(JsonResult);

                if (GetUniNameJson.code == 0)
                {
                    if (m_strEqpTypeID == "3")
                    {
                        return GetUniNameJson.returnStringList[0].RetString2;
                    }
                    else
                    {
                        return GetUniNameJson.returnStringList[0].RetString1;
                    }
                }

                return null;


            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:LoadAgingRackData] {0}", ex.ToString()));
                return null;
            }
        }
        #endregion

        private void ctrlButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            gridView.GridViewToExportExcel(titBar.TitleText);
        }

        private void ctrlButtonSearch1_Click(object sender, EventArgs e)
        {
            InitGridView();

            //Set UnitName
            string strUnitName = GetUnitName().GetAwaiter().GetResult();
            ctrlTextBoxEqpName1.TextBoxText = strUnitName;

            //Set GridView
            GetTroubleData().GetAwaiter().GetResult();
        }
    }
}

