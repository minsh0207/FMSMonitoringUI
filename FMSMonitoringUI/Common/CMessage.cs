/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: CMessage
//  Create Data		: 2015.08.18
//  Author			: 석보원
//  Remark			:
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////
//	Using
//===================================================================
using System.Windows.Forms;


/////////////////////////////////////////////////////////////////////
//	Namespace:  FormationSystem
//===================================================================
namespace MonitoringUI.Common
{
    #region [Class CMessage]
    /////////////////////////////////////////////////////////////////////
    //	Class:  CMessage
    //===================================================================
    public static class CMessage
    {
        #region [Msg Question]
        /////////////////////////////////////////////////////////////////////////////
        //  Question Msg
        //===========================================================================
        public static DialogResult MsgQuestionYN(string strMsg)
        {
            //  Questing Msg
            DialogResult Result = MessageBox.Show(strMsg, "Question !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                  MessageBoxDefaultButton.Button1);
            return Result;
        }
        #endregion

        #region [Msg Error Y/N]
        /////////////////////////////////////////////////////////////////////////////
        //  Error Msg Y/N
        //===========================================================================
        public static DialogResult MsgErrorYN(string strMsg)
        {
            //  Questing Msg
            DialogResult Result = MessageBox.Show(strMsg, "Error !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Error,
                                  MessageBoxDefaultButton.Button1);
            return Result;
        }
        #endregion

        #region [Msg Information]
        /////////////////////////////////////////////////////////////////////////////
        //  Information Msg
        //===========================================================================
        public static void MsgInformation(string strMsg)
        {
            // Msg
            MessageBox.Show(strMsg, "Confirm !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region [Msg Warning]
        /////////////////////////////////////////////////////////////////////////////
        //  Warning Msg
        //===========================================================================
        public static void MsgWarning(string strMsg)
        {
            // Msg
            MessageBox.Show(strMsg, "Warning !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region [Msg Error]
        /////////////////////////////////////////////////////////////////////////////
        //  Error Msg 
        //===========================================================================
        public static void MsgError(string strMsg)
        {
            // Msg
            MessageBox.Show(strMsg, "Error Msg", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region [Msg Data Load]
        /////////////////////////////////////////////////////////////////////////////
        //  Data Load Msg 
        //===========================================================================
        public static void MsgDataLoad()
        {
            // Msg
            //MsgInformation("정상적으로 데이터를 불러오기에 성공하였습니다.");
            CMessage.MsgInformation(LocalLanguage.GetItemString("msgLoad"));
        }
        #endregion

        #region [Msg Data Save]
        /////////////////////////////////////////////////////////////////////////////
        //  Data Save Msg 
        //===========================================================================
        public static void MsgDataSave()
        {
            // Msg
            //MsgInformation("정상적으로 데이터를 저장하였습니다.");
            CMessage.MsgInformation(LocalLanguage.GetItemString("msgSave"));
        }
        #endregion

        #region [Msg Data Delete]
        /////////////////////////////////////////////////////////////////////////////
        //  Data Delete Msg 
        //===========================================================================
        public static void MsgDataDelete()
        {
            // Msg
            //MsgInformation("정상적으로 데이터를 삭제하였습니다.");
            CMessage.MsgInformation(LocalLanguage.GetItemString("msgDelte"));
        }
        #endregion

        #region [Msg Data Change Error]
        /////////////////////////////////////////////////////////////////////////////
        //  Data Change Error Msg
        //===========================================================================
        public static void MsgDataChangeError()
        {
            //MsgError("데이터를 변경하는중 오류가 발생하였습니다.");
            CMessage.MsgError(LocalLanguage.GetItemString("msgChgErr"));
        }
        #endregion

        #region [Msg Data Select Error]
        /////////////////////////////////////////////////////////////////////////////
        //  Data Select Error Msg
        //===========================================================================
        public static void MsgDataSelectError()
        {
            //MsgError("데이터를 선택하는중 오류가 발생하였습니다.");
            CMessage.MsgError(LocalLanguage.GetItemString("msgSeleteErr"));
        }
        #endregion

        #region [Msg Excel Export Error]
        /////////////////////////////////////////////////////////////////////////////
        //  Excel Export Error Msg
        //===========================================================================
        public static void MsgExcelExportError()
        {
            //MsgError("데이터를 엑셀로 저장하는중 오류가 발생하였습니다.");
            CMessage.MsgError(LocalLanguage.GetItemString("msgExcelSaveErr"));
        }
        #endregion

        #region [Msg Data Load Error]
        /////////////////////////////////////////////////////////////////////////////
        //  Data Load Error Msg 
        //===========================================================================
        public static void MsgDataLoadError()
        {
            // Msg
            //MsgError("DB측에서 데이터를 불러오는중 오류가 발생하였습니다.");
            CMessage.MsgError(LocalLanguage.GetItemString("msgLoadErr"));
        }
        #endregion

        #region [Msg Data Save Error]
        /////////////////////////////////////////////////////////////////////////////
        //  Data Save Error Msg
        //===========================================================================
        public static bool MsgSaveError(string sReturn, string sDataName)
        {
            bool bReturn = false;
            // Return Msg
            switch (sReturn.ToUpper())
            {
                case "TRUE":
                    bReturn = true;
                    break;
                case "CANCEL":
                    bReturn = true;
                    break;
                case "ERROR_INSERT":
                    //MsgError("DB측에 " + sDataName + " 데이터를 저장하는중 INSERT 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("msgTheDB") + sDataName + LocalLanguage.GetItemString("msgSaveInsertErr"));
                    bReturn = false;
                    break;
                case "ERROR_DELETE":
                    //MsgError("DB측에 " + sDataName + " 데이터를 저장하는중 DELETE 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("msgTheDB") + sDataName + LocalLanguage.GetItemString("msgSaveDeleteErr"));
                    bReturn = false;
                    break;
                case "ERROR_UPDATE":
                    //MsgError("DB측에 " + sDataName + " 데이터를 저장하는중 UPDATE 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("msgTheDB") + sDataName + LocalLanguage.GetItemString("msgSaveUpdata"));
                    bReturn = false;
                    break;
                case "ERROR":
                    //MsgError("DB측에 " + sDataName + " 데이터를 저장하는중 PROCESS 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("msgTheDB") + sDataName + LocalLanguage.GetItemString("msgSaveProcErr"));
                    bReturn = false;
                    break;
                default:
                    bReturn = false;
                    break;
            }

            // Return
            return bReturn;
        }
        #endregion

        #region [Msg Data Save Error]
        /////////////////////////////////////////////////////////////////////////////
        //  Data Save Error Msg
        //===========================================================================
        public static bool MsgSaveError(enDBMsgState enReturn, string sDataName)
        {
            bool bReturn = false;
            // Return Msg
            switch (enReturn)
            {
                case enDBMsgState.TRUE:
                    bReturn = true;
                    break;
                case enDBMsgState.CANCEL:
                    bReturn = true;
                    break;
                case enDBMsgState.INSERT_ERROR:
                    //MsgError("DB측에 " + sDataName + " 데이터를 저장하는중 INSERT 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_08") + sDataName + LocalLanguage.GetItemString("DEF_MSG_09"));
                    bReturn = false;
                    break;
                case enDBMsgState.DELETE_ERROR:
                    //MsgError("DB측에 " + sDataName + " 데이터를 저장하는중 DELETE 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_08") + sDataName + LocalLanguage.GetItemString("DEF_MSG_10"));
                    bReturn = false;
                    break;
                case enDBMsgState.UPDATE_ERROR:
                    //MsgError("DB측에 " + sDataName + " 데이터를 저장하는중 UPDATE 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_08") + sDataName + LocalLanguage.GetItemString("DEF_MSG_11"));
                    bReturn = false;
                    break;
                case enDBMsgState.ERROR:
                    //MsgError("DB측에 " + sDataName + " 데이터를 저장하는중 PROCESS 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_08") + sDataName + LocalLanguage.GetItemString("DEF_MSG_12"));
                    bReturn = false;
                    break;
                default:
                    bReturn = false;
                    break;
            }

            // Return
            return bReturn;
        }
        #endregion

        #region [Msg Data Save Error]
        /////////////////////////////////////////////////////////////////////////////
        //  Data Save Error Msg
        //===========================================================================
        public static void MsgSaveErrorT(enDBMsgState enReturn, string sDataName)
        {
            // Return Msg
            switch (enReturn)
            {
                case enDBMsgState.TRUE:
                    break;
                case enDBMsgState.CANCEL:
                    break;
                case enDBMsgState.INSERT_ERROR:
                    //MsgError("DB측에 " + sDataName + " 데이터를 저장하는중 INSERT 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_08") + sDataName + LocalLanguage.GetItemString("DEF_MSG_09"));
                    break;
                case enDBMsgState.DELETE_ERROR:
                    //MsgError("DB측에 " + sDataName + " 데이터를 저장하는중 DELETE 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_08") + sDataName + LocalLanguage.GetItemString("DEF_MSG_10"));
                    break;
                case enDBMsgState.UPDATE_ERROR:
                    //MsgError("DB측에 " + sDataName + " 데이터를 저장하는중 UPDATE 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_08") + sDataName + LocalLanguage.GetItemString("DEF_MSG_11"));
                    break;
                case enDBMsgState.ERROR:
                    //MsgError("DB측에 " + sDataName + " 데이터를 저장하는중 PROCESS 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_08") + sDataName + LocalLanguage.GetItemString("DEF_MSG_12"));
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [Msg Data Delete Error]
        /////////////////////////////////////////////////////////////////////////////
        //  Data Delete Error Msg
        //===========================================================================
        public static bool MsgDeleteError(string sReturn, string sDataName)
        {
            bool bReturn = false;
            // Return Msg
            switch (sReturn.ToUpper())
            {
                case "TRUE":
                    bReturn = true;
                    break;
                case "CANCEL":
                    bReturn = true;
                    break;
                case "ERROR_DELETE":
                    //MsgError("DB측에 " + sDataName + " 데이터를 삭제하는중 DELETE 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("msgTheDB") + sDataName + LocalLanguage.GetItemString("msgDelDeleteErr"));
                    bReturn = false;
                    break;
                case "ERROR_UPDATE":
                    //MsgError("DB측에 " + sDataName + " 데이터를 삭제하는중 UPDATE 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("msgTheDB") + sDataName + LocalLanguage.GetItemString("msgDelUpdateErr"));
                    bReturn = false;
                    break;
                case "ERROR":
                    //MsgError("DB측에 " + sDataName + " 데이터를 삭제하는중 PROCESS 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("msgTheDB") + sDataName + LocalLanguage.GetItemString("msgDelProcErr"));
                    bReturn = false;
                    break;
                default:
                    bReturn = false;
                    break;
            }

            // Return
            return bReturn;
        }
        #endregion

        #region [Msg Data Delete Error]
        /////////////////////////////////////////////////////////////////////////////
        //  Data Delete Error Msg
        //===========================================================================
        public static bool MsgDeleteError(enDBMsgState enReturn, string sDataName)
        {
            bool bReturn = false;
            // Return Msg
            switch (enReturn)
            {
                case enDBMsgState.TRUE:
                    bReturn = true;
                    break;
                case enDBMsgState.CANCEL:
                    bReturn = true;
                    break;
                case enDBMsgState.DELETE_ERROR:
                    //MsgError("DB측에 " + sDataName + " 데이터를 삭제하는중 DELETE 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_08") + sDataName + LocalLanguage.GetItemString("DEF_MSG_13"));
                    bReturn = false;
                    break;
                case enDBMsgState.UPDATE_ERROR:
                    //MsgError("DB측에 " + sDataName + " 데이터를 삭제하는중 UPDATE 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_08") + sDataName + LocalLanguage.GetItemString("DEF_MSG_14"));
                    bReturn = false;
                    break;
                case enDBMsgState.ERROR:
                    //MsgError("DB측에 " + sDataName + " 데이터를 삭제하는중 PROCESS 오류가 발생하여, 작업을 취소하였습니다.");
                    CMessage.MsgError(LocalLanguage.GetItemString("DEF_MSG_08") + sDataName + LocalLanguage.GetItemString("DEF_MSG_15"));
                    bReturn = false;
                    break;
                default:
                    bReturn = false;
                    break;
            }

            // Return
            return bReturn;
        }
        #endregion
    }
    #endregion
}