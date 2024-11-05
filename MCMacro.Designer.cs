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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MCMacro));
			gbProcess = new System.Windows.Forms.GroupBox();
			btnProcessReload = new System.Windows.Forms.Button();
			cbProcessList = new System.Windows.Forms.ComboBox();
			btnBotStart = new System.Windows.Forms.Button();
			btnBotStop = new System.Windows.Forms.Button();
			gbMacroSetting = new System.Windows.Forms.GroupBox();
			btnSettingReset = new System.Windows.Forms.Button();
			lbCurrectRate = new System.Windows.Forms.Label();
			numCurrectRate = new System.Windows.Forms.NumericUpDown();
			btnImageDownload = new System.Windows.Forms.Button();
			btnImageUpload = new System.Windows.Forms.Button();
			numCollectDelay = new System.Windows.Forms.NumericUpDown();
			numThrowDelay = new System.Windows.Forms.NumericUpDown();
			lbCollectDelay = new System.Windows.Forms.Label();
			lbThrowDelay = new System.Windows.Forms.Label();
			numBotStartDelay = new System.Windows.Forms.NumericUpDown();
			lbBotStartDelay = new System.Windows.Forms.Label();
			lbMacroTimes = new System.Windows.Forms.Label();
			numMacroTimes = new System.Windows.Forms.NumericUpDown();
			ssProcessStatus = new System.Windows.Forms.StatusStrip();
			ssProcessStatuslb1 = new System.Windows.Forms.ToolStripStatusLabel();
			ssMacroStatus = new System.Windows.Forms.ToolStripStatusLabel();
			gbMacro = new System.Windows.Forms.GroupBox();
			btnFishingTimesReset = new System.Windows.Forms.Button();
			lbFishingTimes = new System.Windows.Forms.Label();
			lbFishing = new System.Windows.Forms.Label();
			gbLog = new System.Windows.Forms.GroupBox();
			lbLog = new System.Windows.Forms.ListBox();
			cbDefaultImg = new System.Windows.Forms.CheckBox();
			gbProcess.SuspendLayout();
			gbMacroSetting.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numCurrectRate).BeginInit();
			((System.ComponentModel.ISupportInitialize)numCollectDelay).BeginInit();
			((System.ComponentModel.ISupportInitialize)numThrowDelay).BeginInit();
			((System.ComponentModel.ISupportInitialize)numBotStartDelay).BeginInit();
			((System.ComponentModel.ISupportInitialize)numMacroTimes).BeginInit();
			ssProcessStatus.SuspendLayout();
			gbMacro.SuspendLayout();
			gbLog.SuspendLayout();
			SuspendLayout();
			// 
			// gbProcess
			// 
			gbProcess.Controls.Add(btnProcessReload);
			gbProcess.Controls.Add(cbProcessList);
			gbProcess.Location = new System.Drawing.Point(12, 15);
			gbProcess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			gbProcess.Name = "gbProcess";
			gbProcess.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			gbProcess.Size = new System.Drawing.Size(480, 68);
			gbProcess.TabIndex = 1;
			gbProcess.TabStop = false;
			gbProcess.Text = "프로세스 제어";
			// 
			// btnProcessReload
			// 
			btnProcessReload.Location = new System.Drawing.Point(395, 25);
			btnProcessReload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnProcessReload.Name = "btnProcessReload";
			btnProcessReload.Size = new System.Drawing.Size(79, 25);
			btnProcessReload.TabIndex = 1;
			btnProcessReload.Text = "새로고침";
			btnProcessReload.UseVisualStyleBackColor = true;
			btnProcessReload.Click += btnProcessReload_Click;
			// 
			// cbProcessList
			// 
			cbProcessList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbProcessList.FormattingEnabled = true;
			cbProcessList.Location = new System.Drawing.Point(6, 25);
			cbProcessList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			cbProcessList.Name = "cbProcessList";
			cbProcessList.Size = new System.Drawing.Size(383, 23);
			cbProcessList.TabIndex = 0;
			cbProcessList.SelectedIndexChanged += cbProcessList_SelectedIndexChanged;
			// 
			// btnBotStart
			// 
			btnBotStart.Location = new System.Drawing.Point(6, 25);
			btnBotStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnBotStart.Name = "btnBotStart";
			btnBotStart.Size = new System.Drawing.Size(468, 64);
			btnBotStart.TabIndex = 2;
			btnBotStart.Text = "매크로 실행";
			btnBotStart.UseVisualStyleBackColor = true;
			btnBotStart.Click += btnBotStart_Click;
			// 
			// btnBotStop
			// 
			btnBotStop.Enabled = false;
			btnBotStop.Location = new System.Drawing.Point(6, 96);
			btnBotStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnBotStop.Name = "btnBotStop";
			btnBotStop.Size = new System.Drawing.Size(468, 64);
			btnBotStop.TabIndex = 3;
			btnBotStop.Text = "매크로 중단";
			btnBotStop.UseVisualStyleBackColor = true;
			btnBotStop.Click += btnBotStop_Click;
			// 
			// gbMacroSetting
			// 
			gbMacroSetting.Controls.Add(btnSettingReset);
			gbMacroSetting.Controls.Add(lbCurrectRate);
			gbMacroSetting.Controls.Add(numCurrectRate);
			gbMacroSetting.Controls.Add(btnImageDownload);
			gbMacroSetting.Controls.Add(btnImageUpload);
			gbMacroSetting.Controls.Add(numCollectDelay);
			gbMacroSetting.Controls.Add(numThrowDelay);
			gbMacroSetting.Controls.Add(lbCollectDelay);
			gbMacroSetting.Controls.Add(lbThrowDelay);
			gbMacroSetting.Controls.Add(numBotStartDelay);
			gbMacroSetting.Controls.Add(lbBotStartDelay);
			gbMacroSetting.Controls.Add(lbMacroTimes);
			gbMacroSetting.Controls.Add(numMacroTimes);
			gbMacroSetting.Location = new System.Drawing.Point(12, 90);
			gbMacroSetting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			gbMacroSetting.Name = "gbMacroSetting";
			gbMacroSetting.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			gbMacroSetting.Size = new System.Drawing.Size(480, 232);
			gbMacroSetting.TabIndex = 4;
			gbMacroSetting.TabStop = false;
			gbMacroSetting.Text = "매크로 설정";
			// 
			// btnSettingReset
			// 
			btnSettingReset.Location = new System.Drawing.Point(395, 162);
			btnSettingReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnSettingReset.Name = "btnSettingReset";
			btnSettingReset.Size = new System.Drawing.Size(79, 62);
			btnSettingReset.TabIndex = 16;
			btnSettingReset.Text = "설정\r\n초기화";
			btnSettingReset.UseVisualStyleBackColor = true;
			btnSettingReset.Click += btnSettingReset_Click;
			// 
			// lbCurrectRate
			// 
			lbCurrectRate.AutoSize = true;
			lbCurrectRate.Location = new System.Drawing.Point(6, 192);
			lbCurrectRate.Name = "lbCurrectRate";
			lbCurrectRate.Size = new System.Drawing.Size(160, 15);
			lbCurrectRate.TabIndex = 15;
			lbCurrectRate.Text = "정확도(1~10 높을수록 정확)";
			// 
			// numCurrectRate
			// 
			numCurrectRate.Location = new System.Drawing.Point(237, 190);
			numCurrectRate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numCurrectRate.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
			numCurrectRate.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			numCurrectRate.Name = "numCurrectRate";
			numCurrectRate.Size = new System.Drawing.Size(146, 23);
			numCurrectRate.TabIndex = 14;
			numCurrectRate.Value = new decimal(new int[] { 9, 0, 0, 0 });
			numCurrectRate.ValueChanged += numCurrectRate_ValueChanged;
			// 
			// btnImageDownload
			// 
			btnImageDownload.Location = new System.Drawing.Point(395, 22);
			btnImageDownload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnImageDownload.Name = "btnImageDownload";
			btnImageDownload.Size = new System.Drawing.Size(79, 62);
			btnImageDownload.TabIndex = 13;
			btnImageDownload.Text = "창이미지\r\n캡처";
			btnImageDownload.UseVisualStyleBackColor = true;
			btnImageDownload.Click += btnImageDownload_Click;
			// 
			// btnImageUpload
			// 
			btnImageUpload.Location = new System.Drawing.Point(395, 92);
			btnImageUpload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnImageUpload.Name = "btnImageUpload";
			btnImageUpload.Size = new System.Drawing.Size(79, 62);
			btnImageUpload.TabIndex = 12;
			btnImageUpload.Text = "이미지패턴\r\n업로드";
			btnImageUpload.UseVisualStyleBackColor = true;
			btnImageUpload.Click += btnImageUpload_Click;
			// 
			// numCollectDelay
			// 
			numCollectDelay.Location = new System.Drawing.Point(237, 149);
			numCollectDelay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numCollectDelay.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
			numCollectDelay.Name = "numCollectDelay";
			numCollectDelay.Size = new System.Drawing.Size(146, 23);
			numCollectDelay.TabIndex = 11;
			numCollectDelay.ValueChanged += numCollectDelay_ValueChanged;
			// 
			// numThrowDelay
			// 
			numThrowDelay.Location = new System.Drawing.Point(237, 105);
			numThrowDelay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numThrowDelay.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
			numThrowDelay.Name = "numThrowDelay";
			numThrowDelay.Size = new System.Drawing.Size(146, 23);
			numThrowDelay.TabIndex = 10;
			numThrowDelay.Value = new decimal(new int[] { 1000, 0, 0, 0 });
			numThrowDelay.ValueChanged += numThrowDelay_ValueChanged;
			// 
			// lbCollectDelay
			// 
			lbCollectDelay.AutoSize = true;
			lbCollectDelay.Location = new System.Drawing.Point(6, 151);
			lbCollectDelay.Name = "lbCollectDelay";
			lbCollectDelay.Size = new System.Drawing.Size(182, 15);
			lbCollectDelay.TabIndex = 9;
			lbCollectDelay.Text = "낚시줄 회수 딜레이(1000 = 1초)";
			// 
			// lbThrowDelay
			// 
			lbThrowDelay.AutoSize = true;
			lbThrowDelay.Location = new System.Drawing.Point(6, 108);
			lbThrowDelay.Name = "lbThrowDelay";
			lbThrowDelay.Size = new System.Drawing.Size(194, 15);
			lbThrowDelay.TabIndex = 8;
			lbThrowDelay.Text = "낚시줄 던지기 딜레이(1000 = 1초)";
			// 
			// numBotStartDelay
			// 
			numBotStartDelay.Location = new System.Drawing.Point(237, 62);
			numBotStartDelay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numBotStartDelay.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
			numBotStartDelay.Name = "numBotStartDelay";
			numBotStartDelay.Size = new System.Drawing.Size(146, 23);
			numBotStartDelay.TabIndex = 7;
			numBotStartDelay.Value = new decimal(new int[] { 2000, 0, 0, 0 });
			numBotStartDelay.ValueChanged += numBotStartDelay_ValueChanged;
			// 
			// lbBotStartDelay
			// 
			lbBotStartDelay.AutoSize = true;
			lbBotStartDelay.Location = new System.Drawing.Point(6, 65);
			lbBotStartDelay.Name = "lbBotStartDelay";
			lbBotStartDelay.Size = new System.Drawing.Size(182, 15);
			lbBotStartDelay.TabIndex = 6;
			lbBotStartDelay.Text = "매크로 시작 딜레이(1000 = 1초)";
			// 
			// lbMacroTimes
			// 
			lbMacroTimes.AutoSize = true;
			lbMacroTimes.Location = new System.Drawing.Point(6, 28);
			lbMacroTimes.Name = "lbMacroTimes";
			lbMacroTimes.Size = new System.Drawing.Size(166, 15);
			lbMacroTimes.TabIndex = 5;
			lbMacroTimes.Text = "매크로 실행할 횟수(0 = 무한)";
			// 
			// numMacroTimes
			// 
			numMacroTimes.Location = new System.Drawing.Point(237, 25);
			numMacroTimes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			numMacroTimes.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
			numMacroTimes.Name = "numMacroTimes";
			numMacroTimes.Size = new System.Drawing.Size(146, 23);
			numMacroTimes.TabIndex = 4;
			numMacroTimes.ValueChanged += numMacroTimes_ValueChanged;
			// 
			// ssProcessStatus
			// 
			ssProcessStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ssProcessStatuslb1, ssMacroStatus });
			ssProcessStatus.Location = new System.Drawing.Point(0, 670);
			ssProcessStatus.Name = "ssProcessStatus";
			ssProcessStatus.Size = new System.Drawing.Size(500, 22);
			ssProcessStatus.TabIndex = 5;
			ssProcessStatus.Text = "statusStrip1";
			// 
			// ssProcessStatuslb1
			// 
			ssProcessStatuslb1.Name = "ssProcessStatuslb1";
			ssProcessStatuslb1.Size = new System.Drawing.Size(78, 17);
			ssProcessStatuslb1.Text = "매크로 상태 :";
			// 
			// ssMacroStatus
			// 
			ssMacroStatus.ForeColor = System.Drawing.Color.Red;
			ssMacroStatus.Name = "ssMacroStatus";
			ssMacroStatus.Size = new System.Drawing.Size(43, 17);
			ssMacroStatus.Text = "정지중";
			// 
			// gbMacro
			// 
			gbMacro.Controls.Add(btnFishingTimesReset);
			gbMacro.Controls.Add(lbFishingTimes);
			gbMacro.Controls.Add(lbFishing);
			gbMacro.Controls.Add(btnBotStop);
			gbMacro.Controls.Add(btnBotStart);
			gbMacro.Location = new System.Drawing.Point(12, 448);
			gbMacro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			gbMacro.Name = "gbMacro";
			gbMacro.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			gbMacro.Size = new System.Drawing.Size(480, 214);
			gbMacro.TabIndex = 4;
			gbMacro.TabStop = false;
			gbMacro.Text = "매크로 관리";
			// 
			// btnFishingTimesReset
			// 
			btnFishingTimesReset.Location = new System.Drawing.Point(399, 170);
			btnFishingTimesReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			btnFishingTimesReset.Name = "btnFishingTimesReset";
			btnFishingTimesReset.Size = new System.Drawing.Size(75, 29);
			btnFishingTimesReset.TabIndex = 6;
			btnFishingTimesReset.Text = "횟수 리셋";
			btnFishingTimesReset.UseVisualStyleBackColor = true;
			btnFishingTimesReset.Click += btnFishingTimesReset_Click;
			// 
			// lbFishingTimes
			// 
			lbFishingTimes.AutoSize = true;
			lbFishingTimes.Location = new System.Drawing.Point(89, 176);
			lbFishingTimes.Name = "lbFishingTimes";
			lbFishingTimes.Size = new System.Drawing.Size(14, 15);
			lbFishingTimes.TabIndex = 5;
			lbFishingTimes.Text = "0";
			// 
			// lbFishing
			// 
			lbFishing.AutoSize = true;
			lbFishing.Location = new System.Drawing.Point(6, 176);
			lbFishing.Name = "lbFishing";
			lbFishing.Size = new System.Drawing.Size(78, 15);
			lbFishing.TabIndex = 4;
			lbFishing.Text = "낚시한 횟수 :";
			// 
			// gbLog
			// 
			gbLog.Controls.Add(lbLog);
			gbLog.Location = new System.Drawing.Point(12, 330);
			gbLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			gbLog.Name = "gbLog";
			gbLog.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			gbLog.Size = new System.Drawing.Size(480, 110);
			gbLog.TabIndex = 6;
			gbLog.TabStop = false;
			gbLog.Text = "로그";
			// 
			// lbLog
			// 
			lbLog.FormattingEnabled = true;
			lbLog.ItemHeight = 15;
			lbLog.Location = new System.Drawing.Point(6, 22);
			lbLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			lbLog.Name = "lbLog";
			lbLog.Size = new System.Drawing.Size(468, 79);
			lbLog.TabIndex = 0;
			// 
			// cbDefaultImg
			// 
			cbDefaultImg.AutoSize = true;
			cbDefaultImg.Location = new System.Drawing.Point(357, 671);
			cbDefaultImg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			cbDefaultImg.Name = "cbDefaultImg";
			cbDefaultImg.Size = new System.Drawing.Size(146, 19);
			cbDefaultImg.TabIndex = 7;
			cbDefaultImg.Text = "기본 패턴 이미지 사용";
			cbDefaultImg.UseVisualStyleBackColor = true;
			cbDefaultImg.CheckedChanged += cbDefaultImg_CheckedChanged;
			// 
			// MCMacro
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(500, 692);
			Controls.Add(cbDefaultImg);
			Controls.Add(gbLog);
			Controls.Add(gbMacro);
			Controls.Add(ssProcessStatus);
			Controls.Add(gbMacroSetting);
			Controls.Add(gbProcess);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			MaximizeBox = false;
			Name = "MCMacro";
			Text = "MCFishingBot";
			Load += MCMacro_Load;
			gbProcess.ResumeLayout(false);
			gbMacroSetting.ResumeLayout(false);
			gbMacroSetting.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numCurrectRate).EndInit();
			((System.ComponentModel.ISupportInitialize)numCollectDelay).EndInit();
			((System.ComponentModel.ISupportInitialize)numThrowDelay).EndInit();
			((System.ComponentModel.ISupportInitialize)numBotStartDelay).EndInit();
			((System.ComponentModel.ISupportInitialize)numMacroTimes).EndInit();
			ssProcessStatus.ResumeLayout(false);
			ssProcessStatus.PerformLayout();
			gbMacro.ResumeLayout(false);
			gbMacro.PerformLayout();
			gbLog.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
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

