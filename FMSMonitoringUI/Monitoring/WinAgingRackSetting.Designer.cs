namespace MonitoringUI.Monitoring
{
    partial class WinAgingRackSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbJobKind = new System.Windows.Forms.GroupBox();
            this.rbDelayAlarmOff = new System.Windows.Forms.RadioButton();
            this.rbManualOutputOkTray = new System.Windows.Forms.RadioButton();
            this.rbManualInputOkTray = new System.Windows.Forms.RadioButton();
            this.rdInitTrouble = new System.Windows.Forms.RadioButton();
            this.rbFireInit = new System.Windows.Forms.RadioButton();
            this.rbYesOut = new System.Windows.Forms.RadioButton();
            this.rbYesIn = new System.Windows.Forms.RadioButton();
            this.rbNoOut = new System.Windows.Forms.RadioButton();
            this.rbDeleteRackInfo = new System.Windows.Forms.RadioButton();
            this.rbNoIn = new System.Windows.Forms.RadioButton();
            this.btExit = new MonitoringUI.Controlls.CButton.CtrlButtonExit();
            this.ctrlTitleBar1 = new MonitoringUI.Controlls.CtrlTitleBar();
            this.tbRackID = new MonitoringUI.Controlls.TextBox.CtrlTextBoxRackID();
            this.tbProcessName = new MonitoringUI.Controlls.TextBox.CtrlTextBoxProcessName();
            this.tbTrayID = new MonitoringUI.Controlls.TextBox.CtrlTextBoxTrayID();
            this.tbCurrentProcessName = new MonitoringUI.Controlls.TextBox.CtrlTextBoxCurrProcess();
            this.dtPlanTime = new MonitoringUI.Controlls.CDateTime.CtrlDateTimePlanTime();
            this.tbNextProcessName = new MonitoringUI.Controlls.TextBox.CtrlTextBoxNextProcess();
            this.btConfirm = new MonitoringUI.Controlls.CButton.CtrlButtonConfirm();
            this.cbChangePlantime = new System.Windows.Forms.CheckBox();
            this.btOutNow = new System.Windows.Forms.Button();
            this.dtStartTime = new MonitoringUI.Controlls.CDateTime.CtrlDateTimeDT();
            this.ctrlLine1 = new MonitoringUI.Controlls.CtrlLine();
            this.gbChangeRouteID = new System.Windows.Forms.GroupBox();
            this.btCancelReserve = new System.Windows.Forms.Button();
            this.btReserve = new System.Windows.Forms.Button();
            this.tbReservedProc = new MonitoringUI.Controlls.TextBox.CtrlTextBoxNextProcess();
            this.tbReservedRouteID = new MonitoringUI.Controlls.TextBox.CtrlTextBoxInputRouteID();
            this.btManageOut = new System.Windows.Forms.Button();
            this.gbJobKind.SuspendLayout();
            this.gbChangeRouteID.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbJobKind
            // 
            this.gbJobKind.Controls.Add(this.rbDelayAlarmOff);
            this.gbJobKind.Controls.Add(this.rbManualOutputOkTray);
            this.gbJobKind.Controls.Add(this.rbManualInputOkTray);
            this.gbJobKind.Controls.Add(this.rdInitTrouble);
            this.gbJobKind.Controls.Add(this.rbFireInit);
            this.gbJobKind.Controls.Add(this.rbYesOut);
            this.gbJobKind.Controls.Add(this.rbYesIn);
            this.gbJobKind.Controls.Add(this.rbNoOut);
            this.gbJobKind.Controls.Add(this.rbDeleteRackInfo);
            this.gbJobKind.Controls.Add(this.rbNoIn);
            this.gbJobKind.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gbJobKind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.gbJobKind.Location = new System.Drawing.Point(22, 329);
            this.gbJobKind.Name = "gbJobKind";
            this.gbJobKind.Size = new System.Drawing.Size(531, 122);
            this.gbJobKind.TabIndex = 5;
            this.gbJobKind.TabStop = false;
            this.gbJobKind.Text = "작업종류";
            // 
            // rbDelayAlarmOff
            // 
            this.rbDelayAlarmOff.AutoSize = true;
            this.rbDelayAlarmOff.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbDelayAlarmOff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.rbDelayAlarmOff.Location = new System.Drawing.Point(390, 27);
            this.rbDelayAlarmOff.Name = "rbDelayAlarmOff";
            this.rbDelayAlarmOff.Size = new System.Drawing.Size(129, 17);
            this.rbDelayAlarmOff.TabIndex = 9;
            this.rbDelayAlarmOff.TabStop = true;
            this.rbDelayAlarmOff.Text = "출고지연알람해제";
            this.rbDelayAlarmOff.UseVisualStyleBackColor = true;
            this.rbDelayAlarmOff.Visible = false;
            // 
            // rbManualOutputOkTray
            // 
            this.rbManualOutputOkTray.AutoSize = true;
            this.rbManualOutputOkTray.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbManualOutputOkTray.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.rbManualOutputOkTray.Location = new System.Drawing.Point(390, 88);
            this.rbManualOutputOkTray.Name = "rbManualOutputOkTray";
            this.rbManualOutputOkTray.Size = new System.Drawing.Size(107, 17);
            this.rbManualOutputOkTray.TabIndex = 8;
            this.rbManualOutputOkTray.TabStop = true;
            this.rbManualOutputOkTray.Text = "수동 출고완료";
            this.rbManualOutputOkTray.UseVisualStyleBackColor = true;
            this.rbManualOutputOkTray.Visible = false;
            // 
            // rbManualInputOkTray
            // 
            this.rbManualInputOkTray.AutoSize = true;
            this.rbManualInputOkTray.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbManualInputOkTray.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.rbManualInputOkTray.Location = new System.Drawing.Point(390, 56);
            this.rbManualInputOkTray.Name = "rbManualInputOkTray";
            this.rbManualInputOkTray.Size = new System.Drawing.Size(107, 17);
            this.rbManualInputOkTray.TabIndex = 8;
            this.rbManualInputOkTray.TabStop = true;
            this.rbManualInputOkTray.Text = "수동 입고완료";
            this.rbManualInputOkTray.UseVisualStyleBackColor = true;
            this.rbManualInputOkTray.Visible = false;
            // 
            // rdInitTrouble
            // 
            this.rdInitTrouble.AutoSize = true;
            this.rdInitTrouble.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdInitTrouble.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.rdInitTrouble.Location = new System.Drawing.Point(260, 27);
            this.rdInitTrouble.Name = "rdInitTrouble";
            this.rdInitTrouble.Size = new System.Drawing.Size(110, 17);
            this.rdInitTrouble.TabIndex = 6;
            this.rdInitTrouble.TabStop = true;
            this.rdInitTrouble.Text = "Trouble 초기화";
            this.rdInitTrouble.UseVisualStyleBackColor = true;
            // 
            // rbFireInit
            // 
            this.rbFireInit.AutoSize = true;
            this.rbFireInit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbFireInit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.rbFireInit.Location = new System.Drawing.Point(143, 27);
            this.rbFireInit.Name = "rbFireInit";
            this.rbFireInit.Size = new System.Drawing.Size(111, 17);
            this.rbFireInit.TabIndex = 7;
            this.rbFireInit.TabStop = true;
            this.rbFireInit.Text = "화재 정보 해제";
            this.rbFireInit.UseVisualStyleBackColor = true;
            // 
            // rbYesOut
            // 
            this.rbYesOut.AutoSize = true;
            this.rbYesOut.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbYesOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.rbYesOut.Location = new System.Drawing.Point(143, 56);
            this.rbYesOut.Name = "rbYesOut";
            this.rbYesOut.Size = new System.Drawing.Size(81, 17);
            this.rbYesOut.TabIndex = 4;
            this.rbYesOut.TabStop = true;
            this.rbYesOut.Text = "출고 가능";
            this.rbYesOut.UseVisualStyleBackColor = true;
            // 
            // rbYesIn
            // 
            this.rbYesIn.AutoSize = true;
            this.rbYesIn.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbYesIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.rbYesIn.Location = new System.Drawing.Point(143, 88);
            this.rbYesIn.Name = "rbYesIn";
            this.rbYesIn.Size = new System.Drawing.Size(81, 17);
            this.rbYesIn.TabIndex = 2;
            this.rbYesIn.TabStop = true;
            this.rbYesIn.Text = "입고 가능";
            this.rbYesIn.UseVisualStyleBackColor = true;
            // 
            // rbNoOut
            // 
            this.rbNoOut.AutoSize = true;
            this.rbNoOut.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbNoOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.rbNoOut.Location = new System.Drawing.Point(24, 56);
            this.rbNoOut.Name = "rbNoOut";
            this.rbNoOut.Size = new System.Drawing.Size(81, 17);
            this.rbNoOut.TabIndex = 3;
            this.rbNoOut.TabStop = true;
            this.rbNoOut.Text = "출고 금지";
            this.rbNoOut.UseVisualStyleBackColor = true;
            // 
            // rbDeleteRackInfo
            // 
            this.rbDeleteRackInfo.AutoSize = true;
            this.rbDeleteRackInfo.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbDeleteRackInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.rbDeleteRackInfo.Location = new System.Drawing.Point(24, 27);
            this.rbDeleteRackInfo.Name = "rbDeleteRackInfo";
            this.rbDeleteRackInfo.Size = new System.Drawing.Size(113, 17);
            this.rbDeleteRackInfo.TabIndex = 5;
            this.rbDeleteRackInfo.TabStop = true;
            this.rbDeleteRackInfo.Text = "Rack 정보 삭제";
            this.rbDeleteRackInfo.UseVisualStyleBackColor = true;
            // 
            // rbNoIn
            // 
            this.rbNoIn.AutoSize = true;
            this.rbNoIn.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbNoIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.rbNoIn.Location = new System.Drawing.Point(24, 88);
            this.rbNoIn.Name = "rbNoIn";
            this.rbNoIn.Size = new System.Drawing.Size(81, 17);
            this.rbNoIn.TabIndex = 1;
            this.rbNoIn.TabStop = true;
            this.rbNoIn.Text = "입고 금지";
            this.rbNoIn.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.btExit.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btExit.LabelText = "Exit";
            this.btExit.Location = new System.Drawing.Point(280, 457);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(100, 38);
            this.btExit.TabIndex = 9;
            // 
            // ctrlTitleBar1
            // 
            this.ctrlTitleBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(90)))), ((int)(((byte)(107)))));
            this.ctrlTitleBar1.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ctrlTitleBar1.ForeColor = System.Drawing.Color.White;
            this.ctrlTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.ctrlTitleBar1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlTitleBar1.Name = "ctrlTitleBar1";
            this.ctrlTitleBar1.Size = new System.Drawing.Size(603, 50);
            this.ctrlTitleBar1.TabIndex = 10;
            this.ctrlTitleBar1.TitleText = "Aging Rack 설정";
            // 
            // tbRackID
            // 
            this.tbRackID.BackColor = System.Drawing.Color.LightGray;
            this.tbRackID.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbRackID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbRackID.Location = new System.Drawing.Point(13, 63);
            this.tbRackID.MaxLength = 32767;
            this.tbRackID.Name = "tbRackID";
            this.tbRackID.PasswordChar = '\0';
            this.tbRackID.Size = new System.Drawing.Size(260, 27);
            this.tbRackID.TabIndex = 11;
            this.tbRackID.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbRackID.TextBoxText = "";
            this.tbRackID.TextData = "";
            this.tbRackID.TitleText = "strRackID";
            // 
            // tbProcessName
            // 
            this.tbProcessName.BackColor = System.Drawing.Color.LightGray;
            this.tbProcessName.Enabled = false;
            this.tbProcessName.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbProcessName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbProcessName.Location = new System.Drawing.Point(280, 63);
            this.tbProcessName.MaxLength = 32767;
            this.tbProcessName.Name = "tbProcessName";
            this.tbProcessName.PasswordChar = '\0';
            this.tbProcessName.Size = new System.Drawing.Size(260, 27);
            this.tbProcessName.TabIndex = 12;
            this.tbProcessName.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbProcessName.TextBoxText = "";
            this.tbProcessName.TextData = "";
            this.tbProcessName.TitleText = "strProcessName";
            // 
            // tbTrayID
            // 
            this.tbTrayID.BackColor = System.Drawing.Color.LightGray;
            this.tbTrayID.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbTrayID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbTrayID.Location = new System.Drawing.Point(13, 133);
            this.tbTrayID.MaxLength = 32767;
            this.tbTrayID.Name = "tbTrayID";
            this.tbTrayID.PasswordChar = '\0';
            this.tbTrayID.Size = new System.Drawing.Size(260, 27);
            this.tbTrayID.TabIndex = 13;
            this.tbTrayID.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbTrayID.TextBoxText = "";
            this.tbTrayID.TextData = "";
            this.tbTrayID.TitleText = "strTrayID";
            // 
            // tbCurrentProcessName
            // 
            this.tbCurrentProcessName.BackColor = System.Drawing.Color.LightGray;
            this.tbCurrentProcessName.Enabled = false;
            this.tbCurrentProcessName.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCurrentProcessName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbCurrentProcessName.Location = new System.Drawing.Point(13, 167);
            this.tbCurrentProcessName.MaxLength = 32767;
            this.tbCurrentProcessName.Name = "tbCurrentProcessName";
            this.tbCurrentProcessName.PasswordChar = '\0';
            this.tbCurrentProcessName.Size = new System.Drawing.Size(260, 27);
            this.tbCurrentProcessName.TabIndex = 15;
            this.tbCurrentProcessName.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbCurrentProcessName.TextBoxText = "";
            this.tbCurrentProcessName.TextData = "";
            this.tbCurrentProcessName.TitleText = "strCurrProcessName";
            // 
            // dtPlanTime
            // 
            this.dtPlanTime.BackColor = System.Drawing.Color.LightGray;
            this.dtPlanTime.Enabled = false;
            this.dtPlanTime.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtPlanTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.dtPlanTime.Location = new System.Drawing.Point(280, 96);
            this.dtPlanTime.Name = "dtPlanTime";
            this.dtPlanTime.PlanTime = new System.DateTime(2019, 3, 18, 18, 13, 28, 458);
            this.dtPlanTime.Size = new System.Drawing.Size(251, 27);
            this.dtPlanTime.TabIndex = 16;
            // 
            // tbNextProcessName
            // 
            this.tbNextProcessName.BackColor = System.Drawing.Color.LightGray;
            this.tbNextProcessName.Enabled = false;
            this.tbNextProcessName.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbNextProcessName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbNextProcessName.Location = new System.Drawing.Point(280, 167);
            this.tbNextProcessName.MaxLength = 32767;
            this.tbNextProcessName.Name = "tbNextProcessName";
            this.tbNextProcessName.PasswordChar = '\0';
            this.tbNextProcessName.Size = new System.Drawing.Size(260, 27);
            this.tbNextProcessName.TabIndex = 17;
            this.tbNextProcessName.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbNextProcessName.TextBoxText = "";
            this.tbNextProcessName.TextData = "";
            this.tbNextProcessName.TitleText = "strNextProcessName";
            // 
            // btConfirm
            // 
            this.btConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(69)))), ((int)(((byte)(88)))));
            this.btConfirm.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btConfirm.LabelText = "Confirm";
            this.btConfirm.Location = new System.Drawing.Point(159, 457);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(100, 38);
            this.btConfirm.TabIndex = 18;
            // 
            // cbChangePlantime
            // 
            this.cbChangePlantime.AutoSize = true;
            this.cbChangePlantime.Location = new System.Drawing.Point(539, 12);
            this.cbChangePlantime.Name = "cbChangePlantime";
            this.cbChangePlantime.Size = new System.Drawing.Size(52, 17);
            this.cbChangePlantime.TabIndex = 19;
            this.cbChangePlantime.Text = "변경";
            this.cbChangePlantime.UseVisualStyleBackColor = true;
            this.cbChangePlantime.Visible = false;
            this.cbChangePlantime.CheckedChanged += new System.EventHandler(this.cbChangePlantime_CheckedChanged);
            // 
            // btOutNow
            // 
            this.btOutNow.BackColor = System.Drawing.Color.Black;
            this.btOutNow.ForeColor = System.Drawing.Color.White;
            this.btOutNow.Location = new System.Drawing.Point(307, 129);
            this.btOutNow.Name = "btOutNow";
            this.btOutNow.Size = new System.Drawing.Size(139, 23);
            this.btOutNow.TabIndex = 21;
            this.btOutNow.Text = "지금 출고";
            this.btOutNow.UseVisualStyleBackColor = false;
            this.btOutNow.Click += new System.EventHandler(this.btOutNow_Click);
            // 
            // dtStartTime
            // 
            this.dtStartTime.BackColor = System.Drawing.Color.LightGray;
            this.dtStartTime.Enabled = false;
            this.dtStartTime.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtStartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.dtStartTime.Location = new System.Drawing.Point(13, 96);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(251, 27);
            this.dtStartTime.StartTime = new System.DateTime(2019, 10, 30, 12, 29, 34, 592);
            this.dtStartTime.TabIndex = 22;
            // 
            // ctrlLine1
            // 
            this.ctrlLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.ctrlLine1.Location = new System.Drawing.Point(13, 205);
            this.ctrlLine1.Name = "ctrlLine1";
            this.ctrlLine1.Size = new System.Drawing.Size(567, 2);
            this.ctrlLine1.TabIndex = 23;
            // 
            // gbChangeRouteID
            // 
            this.gbChangeRouteID.Controls.Add(this.btCancelReserve);
            this.gbChangeRouteID.Controls.Add(this.btReserve);
            this.gbChangeRouteID.Controls.Add(this.tbReservedProc);
            this.gbChangeRouteID.Controls.Add(this.tbReservedRouteID);
            this.gbChangeRouteID.Location = new System.Drawing.Point(22, 214);
            this.gbChangeRouteID.Name = "gbChangeRouteID";
            this.gbChangeRouteID.Size = new System.Drawing.Size(531, 97);
            this.gbChangeRouteID.TabIndex = 24;
            this.gbChangeRouteID.TabStop = false;
            this.gbChangeRouteID.Text = "RouteID 변경 예약 정보";
            // 
            // btCancelReserve
            // 
            this.btCancelReserve.BackColor = System.Drawing.Color.Red;
            this.btCancelReserve.ForeColor = System.Drawing.Color.White;
            this.btCancelReserve.Location = new System.Drawing.Point(342, 59);
            this.btCancelReserve.Name = "btCancelReserve";
            this.btCancelReserve.Size = new System.Drawing.Size(151, 23);
            this.btCancelReserve.TabIndex = 3;
            this.btCancelReserve.Text = "예약취소";
            this.btCancelReserve.UseVisualStyleBackColor = false;
            this.btCancelReserve.Click += new System.EventHandler(this.btCancelReserve_Click);
            // 
            // btReserve
            // 
            this.btReserve.BackColor = System.Drawing.Color.Blue;
            this.btReserve.ForeColor = System.Drawing.Color.White;
            this.btReserve.Location = new System.Drawing.Point(342, 30);
            this.btReserve.Name = "btReserve";
            this.btReserve.Size = new System.Drawing.Size(151, 23);
            this.btReserve.TabIndex = 2;
            this.btReserve.Text = "변경예약";
            this.btReserve.UseVisualStyleBackColor = false;
            this.btReserve.Click += new System.EventHandler(this.btReserve_Click);
            // 
            // tbReservedProc
            // 
            this.tbReservedProc.BackColor = System.Drawing.Color.LightGray;
            this.tbReservedProc.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbReservedProc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbReservedProc.Location = new System.Drawing.Point(48, 55);
            this.tbReservedProc.MaxLength = 32767;
            this.tbReservedProc.Name = "tbReservedProc";
            this.tbReservedProc.PasswordChar = '\0';
            this.tbReservedProc.Size = new System.Drawing.Size(260, 27);
            this.tbReservedProc.TabIndex = 1;
            this.tbReservedProc.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbReservedProc.TextBoxText = "";
            this.tbReservedProc.TextData = "";
            this.tbReservedProc.TitleText = "strNextProcessName";
            // 
            // tbReservedRouteID
            // 
            this.tbReservedRouteID.BackColor = System.Drawing.Color.LightGray;
            this.tbReservedRouteID.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbReservedRouteID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.tbReservedRouteID.Location = new System.Drawing.Point(48, 22);
            this.tbReservedRouteID.MaxLength = 32767;
            this.tbReservedRouteID.Name = "tbReservedRouteID";
            this.tbReservedRouteID.PasswordChar = '\0';
            this.tbReservedRouteID.Size = new System.Drawing.Size(260, 27);
            this.tbReservedRouteID.TabIndex = 0;
            this.tbReservedRouteID.TextBoxAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbReservedRouteID.TextBoxText = "";
            this.tbReservedRouteID.TextData = "";
            this.tbReservedRouteID.TitleText = "DEF_CONTROL_093";
            // 
            // btManageOut
            // 
            this.btManageOut.Location = new System.Drawing.Point(459, 129);
            this.btManageOut.Name = "btManageOut";
            this.btManageOut.Size = new System.Drawing.Size(139, 23);
            this.btManageOut.TabIndex = 25;
            this.btManageOut.Text = "출고시간 변경";
            this.btManageOut.UseVisualStyleBackColor = true;
            this.btManageOut.Click += new System.EventHandler(this.btManageOut_Click);
            // 
            // WinAgingRackSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 550);
            this.Controls.Add(this.btManageOut);
            this.Controls.Add(this.gbChangeRouteID);
            this.Controls.Add(this.ctrlLine1);
            this.Controls.Add(this.dtStartTime);
            this.Controls.Add(this.btOutNow);
            this.Controls.Add(this.cbChangePlantime);
            this.Controls.Add(this.btConfirm);
            this.Controls.Add(this.tbNextProcessName);
            this.Controls.Add(this.dtPlanTime);
            this.Controls.Add(this.tbCurrentProcessName);
            this.Controls.Add(this.tbTrayID);
            this.Controls.Add(this.tbProcessName);
            this.Controls.Add(this.tbRackID);
            this.Controls.Add(this.ctrlTitleBar1);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.gbJobKind);
            this.Name = "WinAgingRackSetting";
            this.Text = "WinAgingRackSetting";
            this.Load += new System.EventHandler(this.WinAgingRackSetting_Load);
            this.Controls.SetChildIndex(this.gbJobKind, 0);
            this.Controls.SetChildIndex(this.btExit, 0);
            this.Controls.SetChildIndex(this.ctrlTitleBar1, 0);
            this.Controls.SetChildIndex(this.tbRackID, 0);
            this.Controls.SetChildIndex(this.tbProcessName, 0);
            this.Controls.SetChildIndex(this.tbTrayID, 0);
            this.Controls.SetChildIndex(this.tbCurrentProcessName, 0);
            this.Controls.SetChildIndex(this.dtPlanTime, 0);
            this.Controls.SetChildIndex(this.tbNextProcessName, 0);
            this.Controls.SetChildIndex(this.btConfirm, 0);
            this.Controls.SetChildIndex(this.cbChangePlantime, 0);
            this.Controls.SetChildIndex(this.btOutNow, 0);
            this.Controls.SetChildIndex(this.dtStartTime, 0);
            this.Controls.SetChildIndex(this.ctrlLine1, 0);
            this.Controls.SetChildIndex(this.gbChangeRouteID, 0);
            this.Controls.SetChildIndex(this.btManageOut, 0);
            this.gbJobKind.ResumeLayout(false);
            this.gbJobKind.PerformLayout();
            this.gbChangeRouteID.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbNoIn;
        private System.Windows.Forms.RadioButton rbDeleteRackInfo;
        private System.Windows.Forms.GroupBox gbJobKind;
        private Controlls.CButton.CtrlButtonExit btExit;
        private Controlls.CtrlTitleBar ctrlTitleBar1;
        private Controlls.TextBox.CtrlTextBoxRackID tbRackID;
        private Controlls.TextBox.CtrlTextBoxProcessName tbProcessName;
        private Controlls.TextBox.CtrlTextBoxTrayID tbTrayID;
        private Controlls.TextBox.CtrlTextBoxCurrProcess tbCurrentProcessName;
        private Controlls.CDateTime.CtrlDateTimePlanTime dtPlanTime;
        private Controlls.TextBox.CtrlTextBoxNextProcess tbNextProcessName;
        private Controlls.CButton.CtrlButtonConfirm btConfirm;
        private System.Windows.Forms.RadioButton rbNoOut;
        private System.Windows.Forms.RadioButton rbYesOut;
        private System.Windows.Forms.RadioButton rbYesIn;
        private System.Windows.Forms.CheckBox cbChangePlantime;
        private System.Windows.Forms.RadioButton rbFireInit;
        private System.Windows.Forms.RadioButton rdInitTrouble;
        private System.Windows.Forms.RadioButton rbManualInputOkTray;
        private System.Windows.Forms.RadioButton rbManualOutputOkTray;
        //private Controlls.CDateTime.CtrlDateTimeDT dtStartTime;
        private System.Windows.Forms.Button btOutNow;
        private Controlls.CDateTime.CtrlDateTimeDT dtStartTime;
        private System.Windows.Forms.RadioButton rbDelayAlarmOff;
        private Controlls.CtrlLine ctrlLine1;
        private System.Windows.Forms.GroupBox gbChangeRouteID;
        private Controlls.TextBox.CtrlTextBoxNextProcess tbReservedProc;
        private Controlls.TextBox.CtrlTextBoxInputRouteID tbReservedRouteID;
        private System.Windows.Forms.Button btCancelReserve;
        private System.Windows.Forms.Button btReserve;
        private System.Windows.Forms.Button btManageOut;
    }
}