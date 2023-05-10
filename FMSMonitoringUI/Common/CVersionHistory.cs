using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMSMonitoringUI.Common
{
    public static class CVersionHistory
    {
        private static List<string> _List = new List<string>
        {
            { "2023/05/09, v2023.05.09.001, Add ConveyorCommand, msh" },
            { "2023/05/08, v2023.05.08.001, Add Conveyor Bug Fix, msh" },
            { "2023/05/04, v2023.05.04.001, Add TrackPause on/off, msh" }
        };

        public static string GetVersion()
        {
            string[] version = _List[0].Split(',');

            return version[1].TrimStart();
        }

        public static List<ListViewItem> GetLitViewItem()
        {
            List < ListViewItem > list = new List<ListViewItem>();
            for (int i = 0; i < 22; i++)
            {
                if (_List.Count > i)
                {
                    string[] item = _List[i].Split(',');

                    ListViewItem lv = new ListViewItem();

                    lv.SubItems.Add(item[0]);
                    lv.SubItems.Add(item[1].TrimStart());
                    lv.SubItems.Add(item[2].TrimStart());

                    list.Add(lv);
                }
            }

            return list;
        }
    }


}
