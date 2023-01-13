﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Novasoft.Logger;
//using RestSharp;

namespace RestClientLib
{
    public partial class RESTClient
    {
        private JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
        };

        #region ConvertDatCell
        /// <summary>
        /// _jsonDatCellResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonDatCellResponse ConvertDatCell(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonDatCellResponse recvBody = JsonConvert.DeserializeObject<_jsonDatCellResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertDatCellProcess
        /// <summary>
        /// _jsonDatCellProcessResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonDatCellProcessResponse ConvertDatCellProcess(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonDatCellProcessResponse recvBody = JsonConvert.DeserializeObject<_jsonDatCellProcessResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertDatLot
        /// <summary>
        /// _jsonDatLotResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonDatLotResponse ConvertDatLot(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonDatLotResponse recvBody = JsonConvert.DeserializeObject<_jsonDatLotResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertDatProcessData
        /// <summary>
        /// _jsonDatProcessDataResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonDatProcessDataResponse ConvertDatProcessData(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonDatProcessDataResponse recvBody = JsonConvert.DeserializeObject<_jsonDatProcessDataResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertDatStatusEqp
        /// <summary>
        /// _jsonDatStatusEqpResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonDatStatusEqpResponse ConvertDatStatusEqp(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonDatStatusEqpResponse recvBody = JsonConvert.DeserializeObject<_jsonDatStatusEqpResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertDatStatusUnit
        /// <summary>
        /// _jsonDatStatusUnitResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonDatStatusUnitResponse ConvertDatStatusUnit(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonDatStatusUnitResponse recvBody = JsonConvert.DeserializeObject<_jsonDatStatusUnitResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertDatTempHpc
        /// <summary>
        /// _jsonDatTempHpcResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonDatTempHpcResponse ConvertDatTempHpc(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonDatTempHpcResponse recvBody = JsonConvert.DeserializeObject<_jsonDatTempHpcResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertDatTempUnit
        /// <summary>
        /// _jsonDatTempUnitResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonDatTempUnitResponse ConvertDatTempUnit(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonDatTempUnitResponse recvBody = JsonConvert.DeserializeObject<_jsonDatTempUnitResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertDatTray
        /// <summary>
        /// _jsonDatTrayResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonDatTrayResponse ConvertDatTray(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonDatTrayResponse recvBody = JsonConvert.DeserializeObject<_jsonDatTrayResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertDatTrayProc
        /// <summary>
        /// _jsonDatTrayProcResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonDatTrayProcResponse ConvertDatTrayProc(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonDatTrayProcResponse recvBody = JsonConvert.DeserializeObject<_jsonDatTrayProcResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertDatTrayProc
        /// <summary>
        /// _jsonDatTroubleResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonDatTroubleResponse ConvertDatTrouble(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonDatTroubleResponse recvBody = JsonConvert.DeserializeObject<_jsonDatTroubleResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion

        #region ConvertMstAging
        /// <summary>
        /// _jsonMstAgingtResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonMstAgingtResponse ConvertMstAging(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonMstAgingtResponse recvBody = JsonConvert.DeserializeObject<_jsonMstAgingtResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertMstEqp
        /// <summary>
        /// _jsonMstEqpResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonMstEqpResponse ConvertMstEqp(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonMstEqpResponse recvBody = JsonConvert.DeserializeObject<_jsonMstEqpResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertMstEqpType
        /// <summary>
        /// _jsonMstEqpTypeResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonMstEqpTypeResponse ConvertMstEqpType(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonMstEqpTypeResponse recvBody = JsonConvert.DeserializeObject<_jsonMstEqpTypeResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertMstModel
        /// <summary>
        /// _jsonMstModelResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonMstModelResponse ConvertMstModel(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonMstModelResponse recvBody = JsonConvert.DeserializeObject<_jsonMstModelResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertMstProcessType
        /// <summary>
        /// _jsonMstProcessTypeResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonMstProcessTypeResponse ConvertMstProcessType(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonMstProcessTypeResponse recvBody = JsonConvert.DeserializeObject<_jsonMstProcessTypeResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertMstRoute
        /// <summary>
        /// _jsonMstRouteResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonMstRouteResponse ConvertMstRoute(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonMstRouteResponse recvBody = JsonConvert.DeserializeObject<_jsonMstRouteResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertMstRouteHist
        /// <summary>
        /// _jsonMstRouteHistResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonMstRouteHistResponse ConvertMstRouteHist(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonMstRouteHistResponse recvBody = JsonConvert.DeserializeObject<_jsonMstRouteHistResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertMstRouteOrder
        /// <summary>
        /// _jsonMstRouteOrderResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonMstRouteOrderResponse ConvertMstRouteOrder(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonMstRouteOrderResponse recvBody = JsonConvert.DeserializeObject<_jsonMstRouteOrderResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertMstTrouble
        /// <summary>
        /// _jsonMstTroubleResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonMstTroubleResponse ConvertMstTrouble(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonMstTroubleResponse recvBody = JsonConvert.DeserializeObject<_jsonMstTroubleResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertMstUnit
        /// <summary>
        /// _jsonMstUnitResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonMstUnitResponse ConvertMstUnit(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonMstUnitResponse recvBody = JsonConvert.DeserializeObject<_jsonMstUnitResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertMstUser
        /// <summary>
        /// _jsonMstUserResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonMstUserResponse ConvertMstUser(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonMstUserResponse recvBody = JsonConvert.DeserializeObject<_jsonMstUserResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertMstUserClass
        /// <summary>
        /// _jsonMstUserClassResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonMstUserClassResponse ConvertMstUserClass(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonMstUserClassResponse recvBody = JsonConvert.DeserializeObject<_jsonMstUserClassResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertMstWindow
        /// <summary>
        /// _jsonMstWindowResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonMstWindowResponse ConvertMstWindow(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonMstWindowResponse recvBody = JsonConvert.DeserializeObject<_jsonMstWindowResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertMstWindowUser
        /// <summary>
        /// _jsonMstWindowUserResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonMstWindowUserResponse ConvertMstWindowUser(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonMstWindowUserResponse recvBody = JsonConvert.DeserializeObject<_jsonMstWindowUserResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion

        #region ConvertRecipelInfo
        /// <summary>
        /// _jsonRecipeInfoResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonRecipeInfoResponse ConvertRecipeInfo(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonRecipeInfoResponse recvBody = JsonConvert.DeserializeObject<_jsonRecipeInfoResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertProcessData
        /// <summary>
        /// _jsonRecipeInfoResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonProcessDataResponse ConvertProcessData(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonProcessDataResponse recvBody = JsonConvert.DeserializeObject<_jsonProcessDataResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertWinManageEqp
        /// <summary>
        /// _jsonWinManageEqpResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonWinManageEqpResponse ConvertWinManageEqp(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonWinManageEqpResponse recvBody = JsonConvert.DeserializeObject<_jsonWinManageEqpResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertWinTrayInfo
        /// <summary>
        /// _jsonWinManageEqpResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonWinTrayInfoResponse ConvertWinTrayInfo(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonWinTrayInfoResponse recvBody = JsonConvert.DeserializeObject<_jsonWinTrayInfoResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertWinTrayInfo
        /// <summary>
        /// _jsonWinManageEqpResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonTrayProcessFlowResponse ConvertTrayPorcessFlow(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonTrayProcessFlowResponse recvBody = JsonConvert.DeserializeObject<_jsonTrayProcessFlowResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertWinCellDetailInfo
        /// <summary>
        /// _jsonWinManageEqpResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonCellProcessFlowResponse ConvertCellPorcessFlow(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonCellProcessFlowResponse recvBody = JsonConvert.DeserializeObject<_jsonCellProcessFlowResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertWinLeadTime
        /// <summary>
        /// _jsonWinLeadTimeResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonWinLeadTimeResponse ConvertWinLeadTime(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonWinLeadTimeResponse recvBody = JsonConvert.DeserializeObject<_jsonWinLeadTimeResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertWinAgingRackSetting
        /// <summary>
        /// _jsonWinAgingRackSettingResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonWinAgingRackSettingResponse ConvertWinAgingRackSetting(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonWinAgingRackSettingResponse recvBody = JsonConvert.DeserializeObject<_jsonWinAgingRackSettingResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertAgingRackCount
        /// <summary>
        /// _jsonAgingRackCountResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonAgingRackCountResponse ConvertAgingRackCount(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonAgingRackCountResponse recvBody = JsonConvert.DeserializeObject<_jsonAgingRackCountResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertWinFormationBox
        /// <summary>
        /// _jsonWinFormationBoxResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonWinFormationBoxResponse ConvertWinFormationBox(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonWinFormationBoxResponse recvBody = JsonConvert.DeserializeObject<_jsonWinFormationBoxResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertWinFormationHPC
        /// <summary>
        /// _jsonWinFormationHPCResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonWinFormationHPCResponse ConvertWinFormationHPC(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonWinFormationHPCResponse recvBody = JsonConvert.DeserializeObject<_jsonWinFormationHPCResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertCtrlFormationCHG
        /// <summary>
        /// _jsonCtrlFormationCHGResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonCtrlFormationCHGResponse ConvertCtrlFormationCHG(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonCtrlFormationCHGResponse recvBody = JsonConvert.DeserializeObject<_jsonCtrlFormationCHGResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertCtrlFormationHPC
        /// <summary>
        /// _jsonCtrlFormationHPCResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonCtrlFormationHPCResponse ConvertCtrlFormationHPC(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonCtrlFormationHPCResponse recvBody = JsonConvert.DeserializeObject<_jsonCtrlFormationHPCResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertCtrlFormationHPCTemp
        /// <summary>
        /// _jsonCtrlFormationHPCTempResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonCtrlFormationHPCTempResponse ConvertCtrlFormationHPCTemp(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonCtrlFormationHPCTempResponse recvBody = JsonConvert.DeserializeObject<_jsonCtrlFormationHPCTempResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion
        #region ConvertEntireEqpList
        /// <summary>
        /// _jsonEntireEqpListResponse 형태의 Class로 변환한다.
        /// </summary>
        public _jsonEntireEqpListResponse ConvertEntireEqpList(string jsonResult)
        {
            try
            {
                // Recv Body의 JSON string을 class 변수에 할당
                _jsonEntireEqpListResponse recvBody = JsonConvert.DeserializeObject<_jsonEntireEqpListResponse>(jsonResult, _jsonSettings);
                return recvBody;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }
        #endregion


    }


}
