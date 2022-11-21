using ControlGallery;
using DBHandler;
using FMSMonitoringUI.Controlls;
using FormationMonCtrl;
using MonitoringUI;
using MySqlX.XDevAPI;
using OPCUAClientClassLib;
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
    public partial class CtrlFormation1 : UserControlRoot
    {
        private MySqlManager _mysql;

        public CtrlFormation1()
        {
            InitializeComponent();

            InitFormationBox();

            _mysql = new MySqlManager(ConfigurationManager.ConnectionStrings["DB_CONNECTION_STRING"].ConnectionString);

            // Timer
            //m_timer.Tick += new EventHandler(OnTimer);
            //m_timer.Start();
        }
        
        private void CtrlFormationBox1_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }

        private void InitFormationBox()
        {
            ctrlFormationBoxCHG1_01.Name = "F101";
            ctrlFormationBoxCHG1_02.Name = "F102";
            ctrlFormationBoxCHG1_03.Name = "F103";
            ctrlFormationBoxCHG1_04.Name = "F104";
            ctrlFormationBoxCHG2_01.Name = "F201";
            ctrlFormationBoxCHG2_02.Name = "F202";
            ctrlFormationBoxCHG2_03.Name = "F203";
            ctrlFormationBoxCHG2_04.Name = "F204";
            ctrlFormationBoxCHG3_01.Name = "F301";
            ctrlFormationBoxCHG3_02.Name = "F302";
            ctrlFormationBoxCHG3_03.Name = "F303";
            ctrlFormationBoxCHG3_04.Name = "F304";

            ctrlFormationBoxCHG1_01.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBoxCHG1_02.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBoxCHG1_03.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBoxCHG1_04.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBoxCHG2_01.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBoxCHG2_02.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBoxCHG2_03.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBoxCHG2_04.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBoxCHG3_01.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBoxCHG3_02.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBoxCHG3_03.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;
            ctrlFormationBoxCHG3_04.MouseDoubleClick += CtrlFormationBox1_MouseDoubleClick;

            this.HandleDestroyed += CtrlFormation_HandleDestroyed;

        }

        private void InitControls()
        {
            string trayID1 = string.Format($"TrayID0001");
            string startTime1 = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string templature1 = string.Format($"{40}℃");
            string pressure1 = string.Format($"{40}kgf");
            string lotID1 = string.Format($"LotID0001");

            CtrlFormationBoxJIG jig = null; // (CtrlFormationBoxHPC)HPC1.Child;
            //hpc.setBox(trayID1, lotID1, templature1, pressure1, startTime1);

            foreach (var ctl in splitterHPC.Controls)
            {
                if (ctl is CtrlFormationBoxJIG)
                {
                    jig = (CtrlFormationBoxJIG)JIG2.Child;
                    jig.setBox(templature1);
                }
                if (ctl.GetType() == typeof(CtrlFormationBoxJIG))
                {
                    jig = (CtrlFormationBoxJIG)JIG2.Child;
                    jig.setBox(templature1);
                }

            }
        }

        public static CtrlFormationBoxCHG FindByName(Control root, string strName)
        {
            for (int i = 0; i < root.Controls.Count; i++)
            {
                if (root.Controls[i] is ElementHost)
                {
                    if (((ElementHost)root.Controls[i]).Child is CtrlFormationBoxCHG)
                    {
                        CtrlFormationBoxCHG eh = (CtrlFormationBoxCHG)((ElementHost)root.Controls[i]).Child;
                        if (eh.Name == strName)
                            return eh;
                    }
                }
            }

            return null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //InitControls();

            //for (int i = 1; i <= 3; i++)
            //{
            //    for (int j = 1; j <= 4; j++)
            //    {
            //        string rackid = string.Format($"F{i}0{j}");
            //        CtrlFormationBoxCHG formationCell = FindByName(panelCHG, rackid);

            //        string[] trayID = { $"TrayIDTT{i}00{j}", $"TrayIDBB{i}00{j}" };
            //        string startTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            //        string templature = string.Format($"{i+40}℃");
            //        string lotID = string.Format($"LotID{i}00{j}");

            //        formationCell.setBox(trayID, startTime, templature, lotID);
            //    }
            //}

            //string trayID1 = string.Format($"TrayID0001");
            //string startTime1 = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            //string templature1 = string.Format($"{40}℃");
            //string pressure1 = string.Format($"{40}kgf");
            //string lotID1 = string.Format($"LotID0001");

            //CtrlFormationBoxHPC hpc = (CtrlFormationBoxHPC)HPC1.Child;
            //hpc.setBox(trayID1, lotID1, templature1, pressure1, startTime1);

            //hpc = (CtrlFormationBoxHPC)HPC2.Child;
            //hpc.setBox(trayID1, lotID1, templature1, pressure1, startTime1);

            //CtrlFormationBoxJIG jig = (CtrlFormationBoxJIG)JIG1.Child;
            //jig.setBox(templature1);

            //jig = (CtrlFormationBoxJIG)JIG2.Child;
            //jig.setBox(templature1);




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
            //DataSet ds = _mysql.SelectChargerInfo();

            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    string unit_name = row["unit_name"].ToString();

            //    CtrlFormationBox formationCell = FindByName(panelCHG, "unit_name");

            //    //formationCell.setBox();
            //}
        }
    }
}
