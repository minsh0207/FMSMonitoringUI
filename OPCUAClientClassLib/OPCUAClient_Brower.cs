using Novasoft.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace OPCUAClientClassLib
{
    public partial class OPCUAClient
    {
        List<BaseNode> _nodelist_browsed = new List<BaseNode>();
        public List<BaseNode> BrowsedNodeList
        {
            get
            {
                return _nodelist_browsed;
            }
        }

        private BrowsePath GetBrowsePath(NodeId startingNodeId, IList<QualifiedName> qnames, string fullBrowseName="")
        {
            BrowsePath browsePath = new BrowsePath();
            browsePath.StartingNode = startingNodeId;
            browsePath.UserData = fullBrowseName;

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

        public Dictionary<int, List<BrowsePath>> AddBrowsePath(string startNodeID, string eqpType, List<CBrowerInfo> taglist)
        {
            int idx = 0;
            int nsIdx = 0;
            // parse the node id.
            NodeId startingNodeId = NodeId.Parse(startNodeID);

            List<BrowsePath> browsePath = new List<BrowsePath>();
            Dictionary<int, List<BrowsePath>> dictBrowsePath = new Dictionary<int, List<BrowsePath>>();

            foreach (var item in taglist)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();

                string[] taglevel = item.BrowerPath.Split('.');

                //for (int i = 0; i < taglevel.Count() - 1; i++)
                //{
                //    sb.Append($"/2:{taglevel[i]}");
                //}
                //browsePath.Add(GetBrowsePath(startingNodeId, AbsoluteName.ToQualifiedNames($"{sb}/2:Address Space.{eqpType}.{item.BrowerPath}")));

                // 프랑스가서 경로 확인 후 맞춰 줄것
                for (int i = 0; i < taglevel.Count(); i++)
                {
                    if (_BrowseNSIndex.ContainsKey(taglevel[i]))
                    {
                        nsIdx = _BrowseNSIndex[taglevel[i]];
                        sb.Append($"/{nsIdx}:{taglevel[i]}");
                    }
                    else
                    {
                        // _BrowseNSIndex에 BrowerName이 없는것은 이전 NamespaceIndex와 동일한것으로 간주한다.
                        sb.Append($"/{nsIdx}:{taglevel[i]}");
                    }

                    if (i == taglevel.Count() - 1)
                    {
                        sb2.Append($"{taglevel[i]}");
                    }
                    else
                    {
                        sb2.Append($"{taglevel[i]}.");
                    }
                }
                browsePath.Add(GetBrowsePath(startingNodeId, AbsoluteName.ToQualifiedNames($"{sb}"), sb2.ToString()));

                if (browsePath.Count > BROWSEPATH_MAXCOUNT)
                {
                    dictBrowsePath.Add(idx, browsePath);
                    browsePath = new List<BrowsePath>();
                    idx++;
                }
            }

            dictBrowsePath.Add(idx, browsePath);

            return dictBrowsePath;
        }

        public Dictionary<int, List<BrowsePath>> AddSubscibeBrowsePath(string startNodeID, string eqpType, List<CBrowerInfo> taglist)
        {
            int idx = 0;
            int nsIdx = 0;
            // parse the node id.
            NodeId startingNodeId = NodeId.Parse(startNodeID);

            List<BrowsePath> browsePath = new List<BrowsePath>();
            Dictionary<int, List<BrowsePath>> dictBrowsePath = new Dictionary<int, List<BrowsePath>>();

            foreach (var item in taglist)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();

                string[] taglevel = item.BrowerPath.Split('.');

                if (item.SubScribe)
                {
                    //for (int i = 0; i < taglevel.Count() - 1; i++)
                    //{
                    //    sb.Append($"/2:{taglevel[i]}");
                    //}
                    //browsePath.Add(GetBrowsePath(startingNodeId, AbsoluteName.ToQualifiedNames($"{sb}/2:Address Space.{eqpType}.{item.BrowerPath}")));

                    for (int i = 0; i < taglevel.Count(); i++)
                    {
                        //sb.Append($"/2:{taglevel[i]}");

                        if (_BrowseNSIndex.ContainsKey(taglevel[i]))
                        {
                            nsIdx = _BrowseNSIndex[taglevel[i]];
                            sb.Append($"/{nsIdx}:{taglevel[i]}");
                        }
                        else
                        {
                            // _BrowseNSIndex에 BrowerName이 없는것은 이전 NamespaceIndex와 동일한것으로 간주한다.
                            sb.Append($"/{nsIdx}:{taglevel[i]}");
                        }

                        if (i == taglevel.Count() - 1)
                        {
                            sb2.Append($"{taglevel[i]}");
                        }
                        else
                        {
                            sb2.Append($"{taglevel[i]}.");
                        }
                    }
                    browsePath.Add(GetBrowsePath(startingNodeId, AbsoluteName.ToQualifiedNames($"{sb}"), sb2.ToString()));

                    if (browsePath.Count > BROWSEPATH_MAXCOUNT)
                    {
                        dictBrowsePath.Add(idx, browsePath);
                        browsePath = new List<BrowsePath>();
                        idx++;
                    }
                }
            }

            dictBrowsePath.Add(idx, browsePath);

            return dictBrowsePath;
        }

        public void AddConveyorNodeID(Dictionary<int, List<BrowsePathResult>> dictResultPath, 
                                      Dictionary<int, List<BrowsePath>> dictBrowsePath)
        {
            // build a list of values to read.
            List<ReadValueId> nodesToRead = new List<ReadValueId>();
            _ConveyorNodeID = new Dictionary<int, List<ReadValueId>>();

            try
            {
                for (int i = 0; i < dictResultPath.Count(); i++)
                {
                    List<BrowsePathResult> browerResult = dictResultPath[i];
                    List<BrowsePath> browsePath = dictBrowsePath[i];

                    for (int j = 0; j < browerResult.Count; j++)
                    {
                        //string[] taglevel = browsePath[j].ToString().Replace("/2:", ".").Split('.');

                        string[] taglevel = browsePath[j].UserData.ToString().Split('.');

                        string sNodeId = browerResult[j].Targets[0].TargetId.ToString();
//#if DEBUG
                        //string[] temp_no = taglevel[2].ToString().Split('_');
                        //int cv_no = int.Parse(temp_no[1]);
//#else
                        int cv_no = int.Parse(taglevel[1].Substring(taglevel[1].Length - 4));
                        
//#endif
                        nodesToRead.Add(new ReadValueId() 
                        {
                            NodeId = NodeId.Parse(sNodeId), 
                            AttributeId = Attributes.Value,
                            UserData = string.Format($"{taglevel[taglevel.Length - 2]}.{taglevel[taglevel.Length - 1]}")
                        });

                        if (taglevel[taglevel.Count() - 1] == "MagazineCommand")
                        {
                            if (_ConveyorNodeID.ContainsKey(cv_no) == false)
                            {
                                _ConveyorNodeID.Add(cv_no, nodesToRead);
                                nodesToRead = new List<ReadValueId>();
                            }                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _EX_LOG_(ex);
            }
        }

        public void AddCraneNodeID(Dictionary<int, List<BrowsePathResult>> dictResultPath, 
                                   Dictionary<int, List<BrowsePath>> dictBrowsePath,
                                   Dictionary<string, ItemInfo> controlInfo)
        {
            // build a list of values to read.
            List<ReadValueId> nodesToRead = new List<ReadValueId>();
            _CraneNodeID = new Dictionary<int, List<ReadValueId>>();

            for (int i = 0; i < dictResultPath.Count(); i++)
            {
                List<BrowsePathResult> browerResult = dictResultPath[i];
                List<BrowsePath> browsePath = dictBrowsePath[i];

                for (int j = 0; j < browerResult.Count; j++)
                {
                    string sNodeId = browerResult[j].Targets[0].TargetId.ToString();
                    //string[] taglevel = browsePath[j].ToString().Replace("/2:", ".").Split('.');
                    string[] taglevel = browsePath[j].UserData.ToString().Split('.');

                    //string tagLevel1 = taglevel[taglevel.Count() - 2];
                    //string tagLevel2 = taglevel[taglevel.Count() - 1];

                    //if ( (tagLevel1 == "CraneCommand") &&
                    //    ((tagLevel2 == "JobType") || (tagLevel2 == "TrayIdL1") ||
                    //     (tagLevel2 == "TrayIdL2") || (tagLevel2 == "TrayExist") || 
                    //     (tagLevel2 == "TrayCount")) )
                    //{
                    //    nodesToRead.Add(new ReadValueId() 
                    //    {
                    //        NodeId = NodeId.Parse(sNodeId), 
                    //        AttributeId = Attributes.Value
                    //    });
                    //}

                    string tagName = string.Empty;

                    if (taglevel[taglevel.Length - 2] == "PrevLocation")
                    {
                        tagName = string.Format($"{taglevel[taglevel.Length - 3]}.{taglevel[taglevel.Length - 2]}.{taglevel[taglevel.Length - 1]}");
                    }
                    else
                    {
                        tagName = string.Format($"{taglevel[taglevel.Length - 2]}.{taglevel[taglevel.Length - 1]}");
                    }

                    nodesToRead.Add(new ReadValueId()
                    {
                        NodeId = NodeId.Parse(sNodeId),
                        AttributeId = Attributes.Value,
                        UserData = tagName
                    });

                    if ((taglevel[taglevel.Count() - 2] == "WaterTank02") &&
                        (taglevel[taglevel.Count() - 1] == "RestockButtonPressed"))
                    {
                        ItemInfo crane = controlInfo[taglevel[0].ToString()];
                        _CraneNodeID.Add(crane.CraneNo, nodesToRead);

                        nodesToRead = new List<ReadValueId>();
                    }
                }
            }
        }
    }
}
