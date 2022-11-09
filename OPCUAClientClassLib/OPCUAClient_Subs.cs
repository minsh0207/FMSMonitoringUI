﻿using System;
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
        public void SubscribeNodes(NodeId nodeId)
        {
            // Create the subscription if it does not already exist.
            if (_Subscription == null)
            {
                _Subscription = new Subscription(_session)
                {
                    PublishingEnabled = _PublishingEnabled,
                    PublishingInterval = _PublishingInterval
                    //DataChanged += new DataChangedEventHandler(Subscription_DataChanged);
                    //StatusChanged += new SubscriptionStatusChangedEventHandler(Subscription_StatusChanged); 
                };               

                _Subscription.Create();
            }

            List<MonitoredItem> monitoredItems = new List<MonitoredItem>();
            List<StatusCode> results = new List<StatusCode>();

            monitoredItems.Add(new DataMonitoredItem(nodeId)
            {
                DiscardOldest = true,
                QueueSize = 1,
                SamplingInterval = 250,
                // UserData = item,                            // ConveyorNo
                // DataChangeTrigger.Status                 : Status 가 변경되었을 때에만 감지 (PLC와의 연결 상태에 대한 것만을 감지한다고 보면 됨)
                // DataChangeTrigger.StatusValue            : Status 또는 Value 가 변경되었을 때에만 감지(위의 것 + 값이 변경되었을 때만 감지함.True->True 로 새로 write 하더라도 감지 안됨)
                // DataChangeTrigger.StatusValueTimestamp   : Status, Value, 또는 Timestamp 가 변경되었을 때에만 감지(연결상태, 값, write 모두에 대해 감지함)
                DataChangeTrigger = DataChangeTrigger.StatusValue,
            });

            try
            {
                // Add the item and apply any changes to it.
                results = _Subscription.CreateMonitoredItems(monitoredItems);

                // Update status label.
                //OnUpdateStatusLabel("Adding monitored item succeeded for NodeId:" +
                //    nodeId.ToString(), true);
            }
            catch (Exception ex)
            {
                //item.SubItems[6].Text = results[0].ToString();

                // Update status label.
                //OnUpdateStatusLabel("An exception occured while adding an item: " +
                //    exception.Message, false);
                _EX_LOG_(ex);
            }
        }

        /// <summary>
        /// Subscribe Event를 등록한다.
        /// </summary>
        /// <param name="results"></param>
        public void SubscribeNodes(Dictionary<int, List<BrowsePathResult>> results, 
                                   Dictionary<int, List<BrowsePath>> dictBrowsePath,
                                   Dictionary<int, ItemInfo> siteInfo,
                                   ItemInfo groupInfo)
        {
            // Create the subscription if it does not already exist.
            if (_Subscription == null)
            {
                _Subscription = new Subscription(_session)
                {
                    PublishingEnabled = _PublishingEnabled,
                    PublishingInterval = _PublishingInterval
                    //DataChanged += new DataChangedEventHandler(Subscription_DataChanged);
                    //StatusChanged += new SubscriptionStatusChangedEventHandler(Subscription_StatusChanged); 
                };

                _Subscription.Create();
            }

            List<MonitoredItem> monitoredItems = new List<MonitoredItem>();

            for (int i = 0; i < results.Count; i++)
            {
                List<BrowsePathResult> browerResult = results[i];
                List<BrowsePath> browsePath = dictBrowsePath[i];

                for (int j = 0; j < browerResult.Count; j++)
                {
                    string sNodeId = browerResult[j].Targets[0].TargetId.ToString();

                    string[] taglevel = browsePath[j].ToString().Replace("/2:", ".").Split('.');

                    ItemInfo item = new ItemInfo();
                    
                    if (groupInfo.ControlType == EnumCtrlType.STC)
                    {
                        item.SiteNo = groupInfo.CraneNo;
                        item.GroupNo = groupInfo.GroupNo;
                        item.BrowseName = taglevel[taglevel.Count() - 1];
                        item.ControlType = groupInfo.ControlType;
                    }
                    else
                    {
                        int siteno = int.Parse(taglevel[1].Substring(3));

                        item.SiteNo = siteno;
                        item.GroupNo = groupInfo.GroupNo;
                        item.BrowseName = taglevel[taglevel.Count() - 1];
                        item.ControlType = siteInfo[siteno].ControlType;
                        item.BrowseName = taglevel[taglevel.Count() - 1];

                        if (siteno != siteInfo[siteno].SiteNo)
                        {
                            ;
                        }
                    }

                    monitoredItems.Add(new DataMonitoredItem(NodeId.Parse(sNodeId))
                    {
                        DiscardOldest = true,
                        QueueSize = 1,
                        SamplingInterval = 100,                     //250 -> 100
                        UserData = item,
                        // DataChangeTrigger.Status                 : Status 가 변경되었을 때에만 감지 (PLC와의 연결 상태에 대한 것만을 감지한다고 보면 됨)
                        // DataChangeTrigger.StatusValue            : Status 또는 Value 가 변경되었을 때에만 감지(위의 것 + 값이 변경되었을 때만 감지함.True->True 로 새로 write 하더라도 감지 안됨)
                        // DataChangeTrigger.StatusValueTimestamp   : Status, Value, 또는 Timestamp 가 변경되었을 때에만 감지(연결상태, 값, write 모두에 대해 감지함)
                        DataChangeTrigger = DataChangeTrigger.StatusValue,
                    });
                }
            }

            try
            {
                // Add the item and apply any changes to it.
                List<StatusCode> statusCode = _Subscription.CreateMonitoredItems(monitoredItems);

                // Update status label.
                //OnUpdateStatusLabel("Adding monitored item succeeded for NodeId:" +
                //    nodeId.ToString(), true);
            }
            catch (Exception ex)
            {
                //item.SubItems[6].Text = results[0].ToString();

                // Update status label.
                //OnUpdateStatusLabel("An exception occured while adding an item: " +
                //    exception.Message, false);
                _EX_LOG_(ex);
            }
        }

        /// <summary>
        /// Callback to receive data changes from an UA server.
        /// </summary>
        /// <param name="clientHandle">The source of the event.</param>
        /// <param name="value">The instance containing the changed data.</param>
        //private void Subscription_DataChanged(Subscription subscription, DataChangedEventArgs e)
        //{
        //    if (e.DataChanges.Count > 1)        // 프로그램 기동시 모든 구독목록이 들어온다. 처음연결시 들어오는 event는 무시한다.
        //    {
        //        return;
        //    }

        //    // Update the value
        //    foreach (DataChange change in e.DataChanges)
        //    {
        //        Subscription_Event(change.Value.ToString());
        //    }
        //}

        /// <summary>
        /// Callback to receive subscription status change events.
        /// </summary>
        /// <param name="subscription">The source of the event.</param>
        /// <param name="e">The new status of the subscription.</param>
        private void Subscription_StatusChanged(Subscription subscription, SubscriptionStatusChangedEventArgs e)
        {
            try
            {
                // XXX ToDo - show in the GUI e.g. disable monitoring view
                // Deleted,
                // Created,
                // Transferred,
                // Error
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show("Error in Subscription_StatusChanged callback", exception);
            }
        }
    }
}
