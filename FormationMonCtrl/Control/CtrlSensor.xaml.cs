/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description		: CtrlStackerCrane
//  Create Data		: 
//  Author			: 
//  Remark			:
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////


/////////////////////////////////////////////////////////////////////
//	Using
//=================================================================== 
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;


/////////////////////////////////////////////////////////////////////
//	Namespace:  FormationMonCtrl
//===================================================================
namespace FormationMonCtrl
{
	#region [Class CtrlStackerCrane]
	/////////////////////////////////////////////////////////////////////
	//	Class:  CtrlCommonDevice
	//===================================================================
	public partial class CtrlSensor : UserControl
	{
		#region [Variable]
		string m_strObjectId = "";
		#endregion

		#region [Constructor]
		/////////////////////////////////////////////////////////////////////
		//	Constructor
		//===================================================================
		public CtrlSensor()
		{
			// InitializeComponent
			InitializeComponent();
		}
		#endregion

		#region [Property]
		#region [Object ID Setting]
		/////////////////////////////////////////////////////////////////////
		//	Object ID Setting
		//===================================================================
		[Description("Set Object ID"), Category("Appearance")]
		public string ObjectID
		{
			get
			{
				return m_strObjectId;
			}
			set
			{
				m_strObjectId = string.Copy(value);
			}
		}
		#endregion

		#region [Object ID Setting]
		/////////////////////////////////////////////////////////////////////
		//	Object ID Setting
		//===================================================================
		[Description("Set Device Name"), Category("Appearance")]
		public string DeviceName
		{
			get
			{
				return this.lblSensor.Content.ToString();
			}
			set
			{
				this.lblSensor.Content = value;

				// 이후에 UpdateLayout이 강제로 지정하는 경우가 아니면 업데이트는 비동기적으로 수행됩니다. 
				InvalidateVisual();
			}
		}
		#endregion
		#endregion

		#region [Method]
		#region [Set Data]
		/////////////////////////////////////////////////////////////////////
		//	Set Datqa
		//===================================================================
		public void SetData(string strObjectId, char chrUnitStatus = ' ', char chrProcessStatus =' ')
		{
			try
			{
				switch (chrUnitStatus)
				{
					// Run
					case 'R':
						lblSensor.Background = Brushes.Green;
						break;
					// Trouble
					case 'T':
						//lblSensor.Background = Brushes.Red;
						break;
					// Idle
					case 'I':
						lblSensor.Background = Brushes.Yellow;

						// 고온 입고 센서
						if (m_strObjectId == CDefine.DEF_SENSORID_HT_AGING_1_IN)
						{
							if (chrProcessStatus != 'I' || chrProcessStatus != 'U')
							{
								lblSensor.Background = Brushes.DeepPink;
							}
						}

						// 출고 센서
						if (m_strObjectId == CDefine.DEF_SENSORID_HT_AGING_1_OUT || m_strObjectId == CDefine.DEF_SENSORID_RT_AGING_1_OUT ||
							m_strObjectId == CDefine.DEF_SENSORID_RT_AGING_2_OUT || m_strObjectId == CDefine.DEF_SENSORID_RT_AGING_3_OUT ||
							m_strObjectId == CDefine.DEF_SENSORID_RT_AGING_4_OUT ||
							m_strObjectId == CDefine.DEF_SENSORID_FORM_1_OUT_F1 || m_strObjectId == CDefine.DEF_SENSORID_FORM_1_OUT_F2 ||
							m_strObjectId == CDefine.DEF_SENSORID_FORM_2_OUT_F1 || m_strObjectId == CDefine.DEF_SENSORID_FORM_2_OUT_F2 ||
							m_strObjectId == CDefine.DEF_SENSORID_FORM_3_OUT_F1 || m_strObjectId == CDefine.DEF_SENSORID_FORM_3_OUT_F2)
						{
							//if (chrProcessStatus != 'I' || chrProcessStatus != 'L')
							//{
							//    lblSensor.Background = Brushes.DeepPink;
							//}
						}
						break;
					default:
						this.lblSensor.Background = Brushes.Yellow;
						break;
				}		

				// 요소의 정렬 상태(레이아웃)을 무효화합니다. 
				// 무효화 이후 해당 요소의 레이아웃은 업데이트되며, 
				// 이후에 UpdateLayout이 강제로 지정하는 경우가 아니면 업데이트는 비동기적으로 수행됩니다. 
				InvalidateVisual();
			}
			catch (Exception ex)
			{
				// System Debug
				System.Diagnostics.Debug.Print(string.Format("### Insert Tray Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
			}
		}
		#endregion

		#region [Reset Data]
		/////////////////////////////////////////////////////////////////////
		//	Reset Data
		//===================================================================
		public void ResetData()
		{
			SetData("");
		}
		#endregion
		#endregion
	}
	#endregion
}
