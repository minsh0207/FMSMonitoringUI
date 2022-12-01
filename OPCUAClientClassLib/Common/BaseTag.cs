using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCUAClientClassLib
{
    [Serializable]
    public class BaseTag
    {
        public BaseTag()
        {
            //
        }

        public string TypeString { get; set; }

        public string DisplayName { get; set; }

        public string BrowseName { get; set; }

        public string NodeId { get; set; }

        public string NodeClassString { get; set; }

        public object Value { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }

    [Serializable]
    public class BaseNode : BaseTag
    {
        public BaseNode()
        {
            //
        }

        public BaseNode Parent { get; set; }

        public string Path { get; set; }

        public string EqpTagNodeId { get; set; }

        public string EqpTagMapPath { get; set; }

        public BaseTag GetBaseTag()
        {
            return new BaseTag()
            {
                TypeString = this.TypeString,
                DisplayName = this.DisplayName,
                BrowseName = this.BrowseName,
                NodeClassString = this.NodeClassString,
                NodeId = this.NodeId,
                Value = this.Value,
            };
        }
    }
}
