using Novasoft.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace OPCUAClientClassLib
{
    public partial class OPCUAClient
    {
        /// <summary>
        /// Tarck별 Tag NodeID를 가져온다.
        /// </summary>
        /// <param name="pathsToTranslate"></param>
        /// <returns></returns>
        public Dictionary<int, List<BrowsePathResult>> ReadBrowse(Dictionary<int, List<BrowsePath>> pathsToTranslate)
        {
            if (Connected == false)
            {
                _LOG_(LogLevel.OPCUA, "Session not connected!");
                return null;
            }
            Dictionary<int, List<BrowsePathResult>> dicResult = new Dictionary<int, List<BrowsePathResult>>();

            for (int i = 0; i < pathsToTranslate.Count; i++)
            {
                if (pathsToTranslate[i] == null || pathsToTranslate[i].Count == 0)
                {
                    _LOG_(LogLevel.OPCUA, "List Of Tags To Read Is Empty.");
                    return null;
                }

                List<BrowsePathResult> results = _session.TranslateBrowsePath(
                pathsToTranslate[i],
                new RequestSettings() { OperationTimeout = 10000 });

                dicResult.Add(i, results);
            }

            return dicResult;
        }

        public List<BrowsePathResult> ReadBrowse(List<BrowsePath> pathsToTranslate)
        {
            if (Connected == false)
            {
                _LOG_(LogLevel.Error, "Session not connected!");
                return null;
            }

            if (pathsToTranslate == null || pathsToTranslate.Count == 0)
            {
                _LOG_(LogLevel.Error, "List Of Tags To Read Is Empty.");
                return null;
            }

            List<BrowsePathResult> results = _session.TranslateBrowsePath(
            pathsToTranslate,
            new RequestSettings() { OperationTimeout = 10000 });

            return results;
        }

        /// <summary>
        /// Subscribe에 등록된 Tag NodeID를 가져온다.
        /// </summary>
        /// <param name="pathsToTranslate"></param>
        /// <returns></returns>
        //public Dictionary<int, List<BrowsePathResult>> ReadSubscribe(Dictionary<int, List<BrowsePath>> pathsToTranslate)
        //{
        //    if (Connected == false)
        //    {
        //        _LOG_("Session not connected!");
        //        return null;
        //    }

        //    if (pathsToTranslate == null || pathsToTranslate.Count == 0)
        //    {
        //        _LOG_("List Of Tags To Read Is Empty.");
        //        return null;
        //    }

        //    List<BrowsePathResult> results = _session.TranslateBrowsePath(
        //    pathsToTranslate,
        //    new RequestSettings() { OperationTimeout = 10000 });

        //    return results;
        //}

        /// <summary>
        /// Tag NodeID를 가져온다.
        /// </summary>
        /// <param name="nodesToRead"></param>
        /// <returns></returns>
        public List<DataValue> ReadNodeID(List<ReadValueId> nodesToRead)
        {
            if (nodesToRead == null || nodesToRead.Count == 0)
            {
                _LOG_(LogLevel.Error, "List Of Tags To Read Is Empty..");
                return null;
            }

            if (Connected == false)
            {
                _LOG_(LogLevel.Error, "Session not connected!!");
                return null;
            }

            // read the value (setting a 10 second timeout).
            List<DataValue> results = _session.Read(
                nodesToRead,
                0,
                TimestampsToReturn.Both,
                new RequestSettings() { OperationTimeout = 10000 });

            return results;
        }
    }
}
