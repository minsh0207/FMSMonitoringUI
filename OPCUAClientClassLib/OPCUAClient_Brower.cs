using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace OPCUAClientClassLib
{
    public partial class OPCUAClient
    {
        private BrowsePath GetBrowsePath(NodeId startingNodeId, IList<QualifiedName> qnames)
        {
            BrowsePath browsePath = new BrowsePath();
            browsePath.StartingNode = startingNodeId;

            foreach (QualifiedName qname in qnames)
            {
                browsePath.RelativePath.Elements.Add(new RelativePathElement()
                {
                    ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences,
                    IncludeSubtypes = true,
                    IsInverse = false,
                    TargetName = qname
                });
            }

            return browsePath;
        }

        public Dictionary<int, List<BrowsePath>> AddBrowsePath(List<string> taglist, int group)
        {
            int idx = 0;
            // parse the node id.
            NodeId startingNodeId = NodeId.Parse(StartNodeID);

            List<BrowsePath> browsePath = new List<BrowsePath>();
            Dictionary<int, List<BrowsePath>> dictBrowsePath = new Dictionary<int, List<BrowsePath>>();

            foreach (var item in taglist)
            {
                StringBuilder sb = new StringBuilder();

                string[] taglevel = item.Split('.');

                for (int i = 0; i < taglevel.Count() - 1; i++)
                {
                    sb.Append($"/2:{taglevel[i]}");
                }

                browsePath.Add(GetBrowsePath(startingNodeId, AbsoluteName.ToQualifiedNames($"{sb}/2:Address Space.{_EqpID}.{item}")));

                if (browsePath.Count > BROWSEPATH_MAXCOUNT)
                {
                    dictBrowsePath.Add(idx, browsePath);
                    browsePath = new List<BrowsePath>();
                    idx++;
                }
                //paths.Add(GetBrowsePath(startingNodeId, AbsoluteName.ToQualifiedNames($"{EQP_ID}.{item}")));
            }

            dictBrowsePath.Add(idx, browsePath);

            return dictBrowsePath;
        }

        public void AddConveyorNodeID(Dictionary<int, List<BrowsePathResult>> dictResultPath, Dictionary<int, List<BrowsePath>> dictBrowsePath)
        {
            // build a list of values to read.
            List<ReadValueId> nodesToRead = new List<ReadValueId>();
            _ConveyorNodeID = new Dictionary<int, List<ReadValueId>>();

            for (int i = 0; i < dictResultPath.Count(); i++)
            {
                List<BrowsePathResult> browerResult = dictResultPath[i];
                List<BrowsePath> browsePath = dictBrowsePath[i];

                for (int j = 0; j < browerResult.Count; j++)
                {
                    string sNodeId = browerResult[j].Targets[0].TargetId.ToString();
                    string[] taglevel = browsePath[j].ToString().Replace("/2:", ".").Split('.');

                    int cv_no = int.Parse(taglevel[1].Substring(3));

                    nodesToRead.Add(new ReadValueId() { NodeId = NodeId.Parse(sNodeId), AttributeId = Attributes.Value });

                    if (taglevel[taglevel.Count() - 1] == "MagazineCommand")
                    {
                        _ConveyorNodeID.Add(cv_no, nodesToRead);
                        nodesToRead = new List<ReadValueId>();
                    }
                }
            }
        }
    }
}
