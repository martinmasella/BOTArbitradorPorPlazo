namespace BOTArbitradorPorPlazo
{
    partial class frmBOT
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			grbLogin = new GroupBox();
			txtClaveVETA = new TextBox();
			label5 = new Label();
			txtUsuarioVETA = new TextBox();
			label6 = new Label();
			label7 = new Label();
			btnLogin = new Button();
			txtClaveIOL = new TextBox();
			label3 = new Label();
			txtUsuarioIOL = new TextBox();
			label2 = new Label();
			label1 = new Label();
			cboUmbral = new ComboBox();
			txtPresupuesto = new TextBox();
			label8 = new Label();
			label4 = new Label();
			grdPanel = new DataGridView();
			lbLog = new ListBox();
			tmr = new System.Windows.Forms.Timer(components);
			chkAuto = new CheckBox();
			chkBeep = new CheckBox();
			chkFollow = new CheckBox();
			grbLogin.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)grdPanel).BeginInit();
			SuspendLayout();
			// 
			// grbLogin
			// 
			grbLogin.Controls.Add(txtClaveVETA);
			grbLogin.Controls.Add(label5);
			grbLogin.Controls.Add(txtUsuarioVETA);
			grbLogin.Controls.Add(label6);
			grbLogin.Controls.Add(label7);
			grbLogin.Controls.Add(btnLogin);
			grbLogin.Controls.Add(txtClaveIOL);
			grbLogin.Controls.Add(label3);
			grbLogin.Controls.Add(txtUsuarioIOL);
			grbLogin.Controls.Add(label2);
			grbLogin.Controls.Add(label1);
			grbLogin.Location = new Point(17, 20);
			grbLogin.Margin = new Padding(4, 5, 4, 5);
			grbLogin.Name = "grbLogin";
			grbLogin.Padding = new Padding(4, 5, 4, 5);
			grbLogin.Size = new Size(773, 128);
			grbLogin.TabIndex = 1;
			grbLogin.TabStop = false;
			grbLogin.Text = "Logins";
			grbLogin.Enter += grbLogin_Enter;
			// 
			// txtClaveVETA
			// 
			txtClaveVETA.Location = new Point(333, 78);
			txtClaveVETA.Margin = new Padding(4, 5, 4, 5);
			txtClaveVETA.Name = "txtClaveVETA";
			txtClaveVETA.Size = new Size(107, 31);
			txtClaveVETA.TabIndex = 12;
			txtClaveVETA.UseSystemPasswordChar = true;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(273, 83);
			label5.Margin = new Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new Size(54, 25);
			label5.TabIndex = 11;
			label5.Text = "Clave";
			// 
			// txtUsuarioVETA
			// 
			txtUsuarioVETA.Location = new Point(151, 78);
			txtUsuarioVETA.Margin = new Padding(4, 5, 4, 5);
			txtUsuarioVETA.Name = "txtUsuarioVETA";
			txtUsuarioVETA.Size = new Size(107, 31);
			txtUsuarioVETA.TabIndex = 10;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(73, 83);
			label6.Margin = new Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new Size(72, 25);
			label6.TabIndex = 9;
			label6.Text = "Usuario";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(17, 83);
			label7.Margin = new Padding(4, 0, 4, 0);
			label7.Name = "label7";
			label7.Size = new Size(52, 25);
			label7.TabIndex = 8;
			label7.Text = "VETA";
			// 
			// btnLogin
			// 
			btnLogin.Location = new Point(459, 30);
			btnLogin.Margin = new Padding(4, 5, 4, 5);
			btnLogin.Name = "btnLogin";
			btnLogin.Size = new Size(100, 87);
			btnLogin.TabIndex = 5;
			btnLogin.Text = "Login";
			btnLogin.UseVisualStyleBackColor = true;
			btnLogin.Click += btnLogin_Click;
			// 
			// txtClaveIOL
			// 
			txtClaveIOL.Location = new Point(333, 30);
			txtClaveIOL.Margin = new Padding(4, 5, 4, 5);
			txtClaveIOL.Name = "txtClaveIOL";
			txtClaveIOL.Size = new Size(107, 31);
			txtClaveIOL.TabIndex = 4;
			txtClaveIOL.UseSystemPasswordChar = true;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(273, 35);
			label3.Margin = new Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new Size(54, 25);
			label3.TabIndex = 3;
			label3.Text = "Clave";
			// 
			// txtUsuarioIOL
			// 
			txtUsuarioIOL.Location = new Point(151, 30);
			txtUsuarioIOL.Margin = new Padding(4, 5, 4, 5);
			txtUsuarioIOL.Name = "txtUsuarioIOL";
			txtUsuarioIOL.Size = new Size(107, 31);
			txtUsuarioIOL.TabIndex = 2;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(73, 35);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(72, 25);
			label2.TabIndex = 1;
			label2.Text = "Usuario";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(17, 35);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(39, 25);
			label1.TabIndex = 0;
			label1.Text = "IOL";
			// 
			// cboUmbral
			// 
			cboUmbral.DropDownStyle = ComboBoxStyle.DropDownList;
			cboUmbral.FormattingEnabled = true;
			cboUmbral.Location = new Point(304, 158);
			cboUmbral.Margin = new Padding(4, 5, 4, 5);
			cboUmbral.Name = "cboUmbral";
			cboUmbral.Size = new Size(64, 33);
			cboUmbral.TabIndex = 15;
			// 
			// txtPresupuesto
			// 
			txtPresupuesto.Location = new Point(129, 158);
			txtPresupuesto.Margin = new Padding(4, 5, 4, 5);
			txtPresupuesto.Name = "txtPresupuesto";
			txtPresupuesto.Size = new Size(73, 31);
			txtPresupuesto.TabIndex = 14;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(211, 167);
			label8.Margin = new Padding(4, 0, 4, 0);
			label8.Name = "label8";
			label8.Size = new Size(90, 25);
			label8.TabIndex = 13;
			label8.Text = "Umbral %";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(17, 167);
			label4.Margin = new Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new Size(110, 25);
			label4.TabIndex = 6;
			label4.Text = "Presupuesto";
			// 
			// grdPanel
			// 
			grdPanel.AllowUserToAddRows = false;
			grdPanel.AllowUserToDeleteRows = false;
			grdPanel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = SystemColors.Window;
			dataGridViewCellStyle1.Font = new Font("Courier New", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
			grdPanel.DefaultCellStyle = dataGridViewCellStyle1;
			grdPanel.Location = new Point(17, 212);
			grdPanel.Margin = new Padding(4, 5, 4, 5);
			grdPanel.Name = "grdPanel";
			grdPanel.ReadOnly = true;
			grdPanel.RowHeadersWidth = 62;
			dataGridViewCellStyle2.Font = new Font("Courier New", 8F);
			grdPanel.RowsDefaultCellStyle = dataGridViewCellStyle2;
			grdPanel.RowTemplate.DefaultCellStyle.Font = new Font("Courier New", 8F);
			grdPanel.RowTemplate.Height = 20;
			grdPanel.RowTemplate.ReadOnly = true;
			grdPanel.ScrollBars = ScrollBars.Vertical;
			grdPanel.Size = new Size(774, 622);
			grdPanel.TabIndex = 2;
			// 
			// lbLog
			// 
			lbLog.FormattingEnabled = true;
			lbLog.ItemHeight = 25;
			lbLog.Location = new Point(17, 848);
			lbLog.Margin = new Padding(4, 5, 4, 5);
			lbLog.Name = "lbLog";
			lbLog.Size = new Size(773, 104);
			lbLog.TabIndex = 3;
			// 
			// tmr
			// 
			tmr.Interval = 5000;
			tmr.Tick += tmr_Tick;
			// 
			// chkAuto
			// 
			chkAuto.AutoSize = true;
			chkAuto.Checked = true;
			chkAuto.CheckState = CheckState.Checked;
			chkAuto.Location = new Point(387, 165);
			chkAuto.Margin = new Padding(4, 5, 4, 5);
			chkAuto.Name = "chkAuto";
			chkAuto.RightToLeft = RightToLeft.Yes;
			chkAuto.Size = new Size(182, 29);
			chkAuto.TabIndex = 16;
			chkAuto.Text = "Modo automático";
			chkAuto.UseVisualStyleBackColor = true;
			// 
			// chkBeep
			// 
			chkBeep.AutoSize = true;
			chkBeep.Location = new Point(570, 165);
			chkBeep.Margin = new Padding(4, 5, 4, 5);
			chkBeep.Name = "chkBeep";
			chkBeep.RightToLeft = RightToLeft.Yes;
			chkBeep.Size = new Size(94, 29);
			chkBeep.TabIndex = 17;
			chkBeep.Text = "Alarma";
			chkBeep.UseVisualStyleBackColor = true;
			// 
			// chkFollow
			// 
			chkFollow.AutoSize = true;
			chkFollow.Location = new Point(670, 165);
			chkFollow.Margin = new Padding(4, 5, 4, 5);
			chkFollow.Name = "chkFollow";
			chkFollow.RightToLeft = RightToLeft.Yes;
			chkFollow.Size = new Size(125, 29);
			chkFollow.TabIndex = 18;
			chkFollow.Text = "Auto Scroll";
			chkFollow.UseVisualStyleBackColor = true;
			// 
			// frmBOT
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(809, 973);
			Controls.Add(chkFollow);
			Controls.Add(chkBeep);
			Controls.Add(chkAuto);
			Controls.Add(cboUmbral);
			Controls.Add(lbLog);
			Controls.Add(label8);
			Controls.Add(txtPresupuesto);
			Controls.Add(grdPanel);
			Controls.Add(grbLogin);
			Controls.Add(label4);
			Margin = new Padding(4, 5, 4, 5);
			Name = "frmBOT";
			Text = "Form1";
			Load += frmBOT_Load;
			grbLogin.ResumeLayout(false);
			grbLogin.PerformLayout();
			((System.ComponentModel.ISupportInitialize)grdPanel).EndInit();
			ResumeLayout(false);
			PerformLayout();

		}

		#endregion

		private GroupBox grbLogin;
        private Label label8;
        private TextBox txtClaveVETA;
        private Label label5;
        private TextBox txtUsuarioVETA;
        private Label label6;
        private Label label7;
        private Label label4;
        private Button btnLogin;
        private TextBox txtClaveIOL;
        private Label label3;
        private TextBox txtUsuarioIOL;
        private Label label2;
        private Label label1;
        private DataGridView grdPanel;
        private ListBox lbLog;
        private ComboBox cboUmbral;
        private TextBox txtPresupuesto;
        private System.Windows.Forms.Timer tmr;
        private CheckBox chkAuto;
        private CheckBox chkBeep;
        private CheckBox chkFollow;
    }
}