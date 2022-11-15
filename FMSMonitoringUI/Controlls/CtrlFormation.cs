using ControlGallery;
using DBHandler;
using FormationMonCtrl;
using MonitoringUI;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace FMSMonitoringUI
{
    public partial class CtrlFormation : UserControlRoot
    {
        private MySqlManager _mysql;

        public CtrlFormation()
        {
            InitializeComponent();

            InitFormationBox();

            _mysql = new MySqlManager(ConfigurationManager.ConnectionStrings["DB_CONNECTION_STRING"].ConnectionString);

            // Timer
            m_timer.Tick += new EventHandler(OnTimer);
            m_timer.Start();
        }
        
        private void CtrlFormationBox1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }

        private void InitFormationBox()
        {
            ctrlFormationBox1_01.Name = "F101";
            ctrlFormationBox1_02.Name = "F102";
            ctrlFormationBox1_03.Name = "F103";
            ctrlFormationBox1_04.Name = "F104";
            ctrlFormationBox2_01.Name = "F201";
            ctrlFormationBox2_02.Name = "F202";
            ctrlFormationBox2_03.Name = "F203";
            ctrlFormationBox2_04.Name = "F204";
            ctrlFormationBox3_01.Name = "F301";
            ctrlFormationBox3_02.Name = "F302";
            ctrlFormationBox3_03.Name = "F303";
            ctrlFormationBox3_04.Name = "F304";


            ctrlFormationBox1_01.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBox1_02.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBox1_03.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBox1_04.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBox2_01.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBox2_02.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBox2_03.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBox2_04.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBox3_01.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBox3_02.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBox3_03.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBox3_04.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;

            this.HandleDestroyed += CtrlFormation_HandleDestroyed;

        }

        public static CtrlFormationBox FindByName(Control root, string strName)
        {
            for (int i = 0; i < root.Controls.Count ; i++)
            {
                if (root.Controls[i] is ElementHost)
                {
                    if (((ElementHost)root.Controls[i]).Child is CtrlFormationBox)
                    {
                        CtrlFormationBox eh = (CtrlFormationBox)((ElementHost)root.Controls[i]).Child;
                        if ((string)eh.Name == strName)
                            return eh;
                    }
                }
            }

            return null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //CtrlFormationBox formationCell = null;

            //formationCell = FindByName(panelCHG, "F101");

            //string[] trayID = {"trayid0001", "trayid0002" };
            //string[] startTime = { DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") };
            //string[] templature = { "45.C", "50.C" };
            //string[] lotID = { "lotid0001", "lotid0002" };

            //formationCell.setBox(0, trayID, startTime, templature, lotID);

            DataSet ds = _mysql.SelectChargerInfo();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string[] trayids = new string[2];
                trayids[0] = row["unit_id"].ToString();
                trayids[1] = row["unit_name"].ToString();
            }


        }

        private void OnTimer(object sender, EventArgs e)
        {
            try
            {
                m_timer.Stop();

                Task task = LoadChargerRackData();

                if (m_timer.Interval != 5000)
                    m_timer.Interval = 5000;
                m_timer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:OnTimer] {0}", ex.ToString()));
            }
        }

        private void CtrlFormation_HandleDestroyed(object sender, EventArgs e)
        {
            m_timer.Stop();
        }

        private async Task LoadChargerRackData()
        {
            try
            {
                Task task = ChargerDataView();
                await task;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("[Exception:LoadChargerRackData] {0}", ex.ToString()));
            }
        }

        private async Task<bool> ChargerDataView()
        {
            try
            {
                //if (this.InvokeRequired)
                {
                    await Task.Run(() =>
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            
                        }));
                    });
                }
            }
            catch (Exception ex)        // 예외처리
            {
                Console.WriteLine(string.Format("[Exception:ChargerDataView] {0}", ex.ToString()));
                // Return
                return false;
            }

            // Return
            return true;
        }

        private void UpdateCharger()
        {
            DataSet ds = _mysql.SelectChargerInfo();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string unit_name = row["unit_name"].ToString();

                CtrlFormationBox formationCell = FindByName(panelCHG, "unit_name");

                //formationCell.setBox();
            }
        }
    }
}
