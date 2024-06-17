namespace MCFishingBot
{
	partial class MCMacro
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MCMacro));
			this.gbProcess = new System.Windows.Forms.GroupBox();
			this.btnProcessReload = new System.Windows.Forms.Button();
			this.cbProcessList = new System.Windows.Forms.ComboBox();
			this.btnBotStart = new System.Windows.Forms.Button();
			this.btnBotStop = new System.Windows.Forms.Button();
			this.gbMacroSetting = new System.Windows.Forms.GroupBox();
			this.btnSettingReset = new System.Windows.Forms.Button();
			this.lbCurrectRate = new System.Windows.Forms.Label();
			this.numCurrectRate = new System.Windows.Forms.NumericUpDown();
			this.btnImageDownload = new System.Windows.Forms.Button();
			this.btnImageUpload = new System.Windows.Forms.Button();
			this.numCollectDelay = new System.Windows.Forms.NumericUpDown();
			this.numThrowDelay = new System.Windows.Forms.NumericUpDown();
			this.lbCollectDelay = new System.Windows.Forms.Label();
			this.lbThrowDelay = new System.Windows.Forms.Label();
			this.numBotStartDelay = new System.Windows.Forms.NumericUpDown();
			this.lbBotStartDelay = new System.Windows.Forms.Label();
			this.lbMacroTimes = new System.Windows.Forms.Label();
			this.numMacroTimes = new System.Windows.Forms.NumericUpDown();
			this.ssProcessStatus = new System.Windows.Forms.StatusStrip();
			this.ssProcessStatuslb1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.ssMacroStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.gbMacro = new System.Windows.Forms.GroupBox();
			this.btnFishingTimesReset = new System.Windows.Forms.Button();
			this.lbFishingTimes = new System.Windows.Forms.Label();
			this.lbFishing = new System.Windows.Forms.Label();
			this.MacroTimer = new System.Windows.Forms.Timer(this.components);
			this.gbLog = new System.Windows.Forms.GroupBox();
			this.lbLog = new System.Windows.Forms.ListBox();
			this.cbDefaultImg = new System.Windows.Forms.CheckBox();
			this.gbProcess.SuspendLayout();
			this.gbMacroSetting.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numCurrectRate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCollectDelay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numThrowDelay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBotStartDelay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMacroTimes)).BeginInit();
			this.ssProcessStatus.SuspendLayout();
			this.gbMacro.SuspendLayout();
			this.gbLog.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbProcess
			// 
			this.gbProcess.Controls.Add(this.btnProcessReload);
			this.gbProcess.Controls.Add(this.cbProcessList);
			this.gbProcess.Location = new System.Drawing.Point(12, 12);
			this.gbProcess.Name = "gbProcess";
			this.gbProcess.Size = new System.Drawing.Size(480, 54);
			this.gbProcess.TabIndex = 1;
			this.gbProcess.TabStop = false;
			this.gbProcess.Text = "프로세스 제어";
			// 
			// btnProcessReload
			// 
			this.btnProcessReload.Location = new System.Drawing.Point(395, 20);
			this.btnProcessReload.Name = "btnProcessReload";
			this.btnProcessReload.Size = new System.Drawing.Size(79, 20);
			this.btnProcessReload.TabIndex = 1;
			this.btnProcessReload.Text = "새로고침";
			this.btnProcessReload.UseVisualStyleBackColor = true;
			this.btnProcessReload.Click += new System.EventHandler(this.btnProcessReload_Click);
			// 
			// cbProcessList
			// 
			this.cbProcessList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProcessList.FormattingEnabled = true;
			this.cbProcessList.Location = new System.Drawing.Point(6, 20);
			this.cbProcessList.Name = "cbProcessList";
			this.cbProcessList.Size = new System.Drawing.Size(383, 20);
			this.cbProcessList.TabIndex = 0;
			this.cbProcessList.SelectedIndexChanged += new System.EventHandler(this.cbProcessList_SelectedIndexChanged);
			// 
			// btnBotStart
			// 
			this.btnBotStart.Location = new System.Drawing.Point(6, 20);
			this.btnBotStart.Name = "btnBotStart";
			this.btnBotStart.Size = new System.Drawing.Size(468, 51);
			this.btnBotStart.TabIndex = 2;
			this.btnBotStart.Text = "매크로 실행";
			this.btnBotStart.UseVisualStyleBackColor = true;
			this.btnBotStart.Click += new System.EventHandler(this.btnBotStart_Click);
			// 
			// btnBotStop
			// 
			this.btnBotStop.Enabled = false;
			this.btnBotStop.Location = new System.Drawing.Point(6, 77);
			this.btnBotStop.Name = "btnBotStop";
			this.btnBotStop.Size = new System.Drawing.Size(468, 51);
			this.btnBotStop.TabIndex = 3;
			this.btnBotStop.Text = "매크로 중단";
			this.btnBotStop.UseVisualStyleBackColor = true;
			this.btnBotStop.Click += new System.EventHandler(this.btnBotStop_Click);
			// 
			// gbMacroSetting
			// 
			this.gbMacroSetting.Controls.Add(this.btnSettingReset);
			this.gbMacroSetting.Controls.Add(this.lbCurrectRate);
			this.gbMacroSetting.Controls.Add(this.numCurrectRate);
			this.gbMacroSetting.Controls.Add(this.btnImageDownload);
			this.gbMacroSetting.Controls.Add(this.btnImageUpload);
			this.gbMacroSetting.Controls.Add(this.numCollectDelay);
			this.gbMacroSetting.Controls.Add(this.numThrowDelay);
			this.gbMacroSetting.Controls.Add(this.lbCollectDelay);
			this.gbMacroSetting.Controls.Add(this.lbThrowDelay);
			this.gbMacroSetting.Controls.Add(this.numBotStartDelay);
			this.gbMacroSetting.Controls.Add(this.lbBotStartDelay);
			this.gbMacroSetting.Controls.Add(this.lbMacroTimes);
			this.gbMacroSetting.Controls.Add(this.numMacroTimes);
			this.gbMacroSetting.Location = new System.Drawing.Point(12, 72);
			this.gbMacroSetting.Name = "gbMacroSetting";
			this.gbMacroSetting.Size = new System.Drawing.Size(474, 186);
			this.gbMacroSetting.TabIndex = 4;
			this.gbMacroSetting.TabStop = false;
			this.gbMacroSetting.Text = "매크로 설정";
			// 
			// btnSettingReset
			// 
			this.btnSettingReset.Location = new System.Drawing.Point(393, 130);
			this.btnSettingReset.Name = "btnSettingReset";
			this.btnSettingReset.Size = new System.Drawing.Size(73, 50);
			this.btnSettingReset.TabIndex = 16;
			this.btnSettingReset.Text = "설정\r\n초기화";
			this.btnSettingReset.UseVisualStyleBackColor = true;
			this.btnSettingReset.Click += new System.EventHandler(this.btnSettingReset_Click);
			// 
			// lbCurrectRate
			// 
			this.lbCurrectRate.AutoSize = true;
			this.lbCurrectRate.Location = new System.Drawing.Point(6, 157);
			this.lbCurrectRate.Name = "lbCurrectRate";
			this.lbCurrectRate.Size = new System.Drawing.Size(158, 12);
			this.lbCurrectRate.TabIndex = 15;
			this.lbCurrectRate.Text = "정확도(1~10 높을수록 정확)";
			// 
			// numCurrectRate
			// 
			this.numCurrectRate.Location = new System.Drawing.Point(237, 148);
			this.numCurrectRate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numCurrectRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numCurrectRate.Name = "numCurrectRate";
			this.numCurrectRate.Size = new System.Drawing.Size(146, 21);
			this.numCurrectRate.TabIndex = 14;
			this.numCurrectRate.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.numCurrectRate.ValueChanged += new System.EventHandler(this.numCurrectRate_ValueChanged);
			// 
			// btnImageDownload
			// 
			this.btnImageDownload.Location = new System.Drawing.Point(393, 18);
			this.btnImageDownload.Name = "btnImageDownload";
			this.btnImageDownload.Size = new System.Drawing.Size(73, 50);
			this.btnImageDownload.TabIndex = 13;
			this.btnImageDownload.Text = "창이미지\r\n캡처";
			this.btnImageDownload.UseVisualStyleBackColor = true;
			this.btnImageDownload.Click += new System.EventHandler(this.btnImageDownload_Click);
			// 
			// btnImageUpload
			// 
			this.btnImageUpload.Location = new System.Drawing.Point(393, 74);
			this.btnImageUpload.Name = "btnImageUpload";
			this.btnImageUpload.Size = new System.Drawing.Size(73, 50);
			this.btnImageUpload.TabIndex = 12;
			this.btnImageUpload.Text = "이미지패턴\r\n업로드";
			this.btnImageUpload.UseVisualStyleBackColor = true;
			this.btnImageUpload.Click += new System.EventHandler(this.btnImageUpload_Click);
			// 
			// numCollectDelay
			// 
			this.numCollectDelay.Location = new System.Drawing.Point(237, 119);
			this.numCollectDelay.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.numCollectDelay.Name = "numCollectDelay";
			this.numCollectDelay.Size = new System.Drawing.Size(146, 21);
			this.numCollectDelay.TabIndex = 11;
			this.numCollectDelay.ValueChanged += new System.EventHandler(this.numCollectDelay_ValueChanged);
			// 
			// numThrowDelay
			// 
			this.numThrowDelay.Location = new System.Drawing.Point(237, 84);
			this.numThrowDelay.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.numThrowDelay.Name = "numThrowDelay";
			this.numThrowDelay.Size = new System.Drawing.Size(146, 21);
			this.numThrowDelay.TabIndex = 10;
			this.numThrowDelay.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numThrowDelay.ValueChanged += new System.EventHandler(this.numThrowDelay_ValueChanged);
			// 
			// lbCollectDelay
			// 
			this.lbCollectDelay.AutoSize = true;
			this.lbCollectDelay.Location = new System.Drawing.Point(6, 119);
			this.lbCollectDelay.Name = "lbCollectDelay";
			this.lbCollectDelay.Size = new System.Drawing.Size(175, 12);
			this.lbCollectDelay.TabIndex = 9;
			this.lbCollectDelay.Text = "낚시줄 회수 딜레이(1000 = 1초)";
			// 
			// lbThrowDelay
			// 
			this.lbThrowDelay.AutoSize = true;
			this.lbThrowDelay.Location = new System.Drawing.Point(4, 84);
			this.lbThrowDelay.Name = "lbThrowDelay";
			this.lbThrowDelay.Size = new System.Drawing.Size(187, 12);
			this.lbThrowDelay.TabIndex = 8;
			this.lbThrowDelay.Text = "낚시줄 던지기 딜레이(1000 = 1초)";
			// 
			// numBotStartDelay
			// 
			this.numBotStartDelay.Location = new System.Drawing.Point(237, 50);
			this.numBotStartDelay.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.numBotStartDelay.Name = "numBotStartDelay";
			this.numBotStartDelay.Size = new System.Drawing.Size(146, 21);
			this.numBotStartDelay.TabIndex = 7;
			this.numBotStartDelay.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.numBotStartDelay.ValueChanged += new System.EventHandler(this.numBotStartDelay_ValueChanged);
			// 
			// lbBotStartDelay
			// 
			this.lbBotStartDelay.AutoSize = true;
			this.lbBotStartDelay.Location = new System.Drawing.Point(4, 52);
			this.lbBotStartDelay.Name = "lbBotStartDelay";
			this.lbBotStartDelay.Size = new System.Drawing.Size(175, 12);
			this.lbBotStartDelay.TabIndex = 6;
			this.lbBotStartDelay.Text = "매크로 시작 딜레이(1000 = 1초)";
			// 
			// lbMacroTimes
			// 
			this.lbMacroTimes.AutoSize = true;
			this.lbMacroTimes.Location = new System.Drawing.Point(6, 22);
			this.lbMacroTimes.Name = "lbMacroTimes";
			this.lbMacroTimes.Size = new System.Drawing.Size(167, 12);
			this.lbMacroTimes.TabIndex = 5;
			this.lbMacroTimes.Text = "매크로 실행할 회수 (0 = 무한)";
			// 
			// numMacroTimes
			// 
			this.numMacroTimes.Location = new System.Drawing.Point(237, 20);
			this.numMacroTimes.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.numMacroTimes.Name = "numMacroTimes";
			this.numMacroTimes.Size = new System.Drawing.Size(146, 21);
			this.numMacroTimes.TabIndex = 4;
			this.numMacroTimes.ValueChanged += new System.EventHandler(this.numMacroTimes_ValueChanged);
			// 
			// ssProcessStatus
			// 
			this.ssProcessStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssProcessStatuslb1,
            this.ssMacroStatus});
			this.ssProcessStatus.Location = new System.Drawing.Point(0, 532);
			this.ssProcessStatus.Name = "ssProcessStatus";
			this.ssProcessStatus.Size = new System.Drawing.Size(504, 22);
			this.ssProcessStatus.TabIndex = 5;
			this.ssProcessStatus.Text = "statusStrip1";
			// 
			// ssProcessStatuslb1
			// 
			this.ssProcessStatuslb1.Name = "ssProcessStatuslb1";
			this.ssProcessStatuslb1.Size = new System.Drawing.Size(78, 17);
			this.ssProcessStatuslb1.Text = "매크로 상태 :";
			// 
			// ssMacroStatus
			// 
			this.ssMacroStatus.ForeColor = System.Drawing.Color.Red;
			this.ssMacroStatus.Name = "ssMacroStatus";
			this.ssMacroStatus.Size = new System.Drawing.Size(43, 17);
			this.ssMacroStatus.Text = "정지중";
			// 
			// gbMacro
			// 
			this.gbMacro.Controls.Add(this.btnFishingTimesReset);
			this.gbMacro.Controls.Add(this.lbFishingTimes);
			this.gbMacro.Controls.Add(this.lbFishing);
			this.gbMacro.Controls.Add(this.btnBotStop);
			this.gbMacro.Controls.Add(this.btnBotStart);
			this.gbMacro.Location = new System.Drawing.Point(12, 358);
			this.gbMacro.Name = "gbMacro";
			this.gbMacro.Size = new System.Drawing.Size(480, 171);
			this.gbMacro.TabIndex = 4;
			this.gbMacro.TabStop = false;
			this.gbMacro.Text = "매크로 관리";
			// 
			// btnFishingTimesReset
			// 
			this.btnFishingTimesReset.Location = new System.Drawing.Point(399, 136);
			this.btnFishingTimesReset.Name = "btnFishingTimesReset";
			this.btnFishingTimesReset.Size = new System.Drawing.Size(75, 23);
			this.btnFishingTimesReset.TabIndex = 6;
			this.btnFishingTimesReset.Text = "횟수 리셋";
			this.btnFishingTimesReset.UseVisualStyleBackColor = true;
			this.btnFishingTimesReset.Click += new System.EventHandler(this.btnFishingTimesReset_Click);
			// 
			// lbFishingTimes
			// 
			this.lbFishingTimes.AutoSize = true;
			this.lbFishingTimes.Location = new System.Drawing.Point(89, 141);
			this.lbFishingTimes.Name = "lbFishingTimes";
			this.lbFishingTimes.Size = new System.Drawing.Size(11, 12);
			this.lbFishingTimes.TabIndex = 5;
			this.lbFishingTimes.Text = "0";
			// 
			// lbFishing
			// 
			this.lbFishing.AutoSize = true;
			this.lbFishing.Location = new System.Drawing.Point(6, 141);
			this.lbFishing.Name = "lbFishing";
			this.lbFishing.Size = new System.Drawing.Size(77, 12);
			this.lbFishing.TabIndex = 4;
			this.lbFishing.Text = "낚시한 횟수 :";
			// 
			// MacroTimer
			// 
			this.MacroTimer.Interval = 500;
			this.MacroTimer.Tick += new System.EventHandler(this.MacroTimer_Tick);
			// 
			// gbLog
			// 
			this.gbLog.Controls.Add(this.lbLog);
			this.gbLog.Location = new System.Drawing.Point(12, 264);
			this.gbLog.Name = "gbLog";
			this.gbLog.Size = new System.Drawing.Size(474, 88);
			this.gbLog.TabIndex = 6;
			this.gbLog.TabStop = false;
			this.gbLog.Text = "로그";
			// 
			// lbLog
			// 
			this.lbLog.FormattingEnabled = true;
			this.lbLog.ItemHeight = 12;
			this.lbLog.Location = new System.Drawing.Point(6, 18);
			this.lbLog.Name = "lbLog";
			this.lbLog.Size = new System.Drawing.Size(460, 64);
			this.lbLog.TabIndex = 0;
			// 
			// cbDefaultImg
			// 
			this.cbDefaultImg.AutoSize = true;
			this.cbDefaultImg.Location = new System.Drawing.Point(357, 537);
			this.cbDefaultImg.Name = "cbDefaultImg";
			this.cbDefaultImg.Size = new System.Drawing.Size(144, 16);
			this.cbDefaultImg.TabIndex = 7;
			this.cbDefaultImg.Text = "기본 패턴 이미지 사용";
			this.cbDefaultImg.UseVisualStyleBackColor = true;
			this.cbDefaultImg.CheckedChanged += new System.EventHandler(this.cbDefaultImg_CheckedChanged);
			// 
			// MCMacro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 554);
			this.Controls.Add(this.cbDefaultImg);
			this.Controls.Add(this.gbLog);
			this.Controls.Add(this.gbMacro);
			this.Controls.Add(this.ssProcessStatus);
			this.Controls.Add(this.gbMacroSetting);
			this.Controls.Add(this.gbProcess);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MCMacro";
			this.Text = "MCFishingBot";
			this.Load += new System.EventHandler(this.MCMacro_Load);
			this.gbProcess.ResumeLayout(false);
			this.gbMacroSetting.ResumeLayout(false);
			this.gbMacroSetting.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numCurrectRate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCollectDelay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numThrowDelay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBotStartDelay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMacroTimes)).EndInit();
			this.ssProcessStatus.ResumeLayout(false);
			this.ssProcessStatus.PerformLayout();
			this.gbMacro.ResumeLayout(false);
			this.gbMacro.PerformLayout();
			this.gbLog.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gbProcess;
		private System.Windows.Forms.Button btnProcessReload;
		private System.Windows.Forms.ComboBox cbProcessList;
		private System.Windows.Forms.Button btnBotStart;
		private System.Windows.Forms.Button btnBotStop;
		private System.Windows.Forms.GroupBox gbMacroSetting;
		private System.Windows.Forms.StatusStrip ssProcessStatus;
		private System.Windows.Forms.GroupBox gbMacro;
		private System.Windows.Forms.NumericUpDown numMacroTimes;
		private System.Windows.Forms.Label lbFishing;
		private System.Windows.Forms.NumericUpDown numBotStartDelay;
		private System.Windows.Forms.Label lbBotStartDelay;
		private System.Windows.Forms.Label lbMacroTimes;
		private System.Windows.Forms.Label lbFishingTimes;
		private System.Windows.Forms.ToolStripStatusLabel ssProcessStatuslb1;
		private System.Windows.Forms.NumericUpDown numCollectDelay;
		private System.Windows.Forms.NumericUpDown numThrowDelay;
		private System.Windows.Forms.Label lbCollectDelay;
		private System.Windows.Forms.Label lbThrowDelay;
		private System.Windows.Forms.Button btnImageUpload;
		private System.Windows.Forms.Button btnImageDownload;
		private System.Windows.Forms.Timer MacroTimer;
		private System.Windows.Forms.GroupBox gbLog;
		private System.Windows.Forms.ListBox lbLog;
		private System.Windows.Forms.NumericUpDown numCurrectRate;
		private System.Windows.Forms.Label lbCurrectRate;
		private System.Windows.Forms.Button btnSettingReset;
		private System.Windows.Forms.Button btnFishingTimesReset;
		private System.Windows.Forms.ToolStripStatusLabel ssMacroStatus;
		private System.Windows.Forms.CheckBox cbDefaultImg;
	}
}

