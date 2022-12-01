using Novasoft.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace OPCUAClientClassLib
{
    #region Class WriteValueInfo
    public class WriteValueInfo
    {
        #region Fields
        /// <summary>
        /// The NodeId of the item.
        /// </summary>
        public NodeId NodeId;
        /// <summary>
        /// The DataType of the item.
        /// </summary>
        public BuiltInType DataType;
        /// <summary>
        /// The Value of the item.
        /// </summary>
        public int Value;

        //public bool AttributesRead = false;
        //public bool Error = false;
        #endregion
    }
    #endregion

    public partial class OPCUAClient
    {
        /// <summary>
        /// Extract NodeIds to write from the list_to_write given
        /// Then validate the results
        /// </summary>
        /// <returns>true if all nodeids writes Good, false if any nodeid write failed</returns>
        public uint Write(WriteValueInfo writeInfo)
        {
            List<WriteValue> nodesToWrite = new List<WriteValue>();
            List<StatusCode> results = null;

            if (_session == null)
            {
                _LOG_(LogLevel.Error, "Session not connected!");
                return 1;
            }

            DataValue dataValue = new DataValue();

            dataValue.Value = TypeUtils.Cast(writeInfo.Value, writeInfo.DataType);

            nodesToWrite.Add(new WriteValue()
            {
                NodeId = writeInfo.NodeId,
                Value = dataValue,
                AttributeId = Attributes.Value
            });

            // Call to ClientAPI.
            results = _session.Write(
                nodesToWrite,
                null);
            return results[0].Code;     // Good = 0
        }

        /// <summary>
        /// Extract NodeIds to write from the list_to_write given
        /// Then validate the results
        /// </summary>
        /// <returns>true if all nodeids writes Good, false if any nodeid write failed</returns>
        public List<StatusCode> Write(List<WriteValueInfo> writeInfo)
        {
            List<WriteValue> nodesToWrite = new List<WriteValue>();
            List<StatusCode> results = null;

            if (_session == null)
            {
                _LOG_(LogLevel.OPCUA, "Session not connected!");
                return null;
            }

            foreach (var item in writeInfo)
            {
                DataValue dataValue = new DataValue();

                dataValue.Value = TypeUtils.Cast(item.Value, item.DataType);

                nodesToWrite.Add(new WriteValue()
                {
                    NodeId = item.NodeId,
                    Value = dataValue,
                    AttributeId = Attributes.Value
                });
            }            

            // Call to ClientAPI.
            results = _session.Write(
                nodesToWrite,
                null);
            return results;     // Good = 0
        }
    }
}
