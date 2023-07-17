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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbLogin = new System.Windows.Forms.GroupBox();
            this.txtClaveVETA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsuarioVETA = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtClaveIOL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsuarioIOL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboUmbral = new System.Windows.Forms.ComboBox();
            this.txtPresupuesto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grdPanel = new System.Windows.Forms.DataGridView();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.chkBeep = new System.Windows.Forms.CheckBox();
            this.chkFollow = new System.Windows.Forms.CheckBox();
            this.grbLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // grbLogin
            // 
            this.grbLogin.Controls.Add(this.txtClaveVETA);
            this.grbLogin.Controls.Add(this.label5);
            this.grbLogin.Controls.Add(this.txtUsuarioVETA);
            this.grbLogin.Controls.Add(this.label6);
            this.grbLogin.Controls.Add(this.label7);
            this.grbLogin.Controls.Add(this.btnLogin);
            this.grbLogin.Controls.Add(this.txtClaveIOL);
            this.grbLogin.Controls.Add(this.label3);
            this.grbLogin.Controls.Add(this.txtUsuarioIOL);
            this.grbLogin.Controls.Add(this.label2);
            this.grbLogin.Controls.Add(this.label1);
            this.grbLogin.Location = new System.Drawing.Point(12, 12);
            this.grbLogin.Name = "grbLogin";
            this.grbLogin.Size = new System.Drawing.Size(541, 77);
            this.grbLogin.TabIndex = 1;
            this.grbLogin.TabStop = false;
            this.grbLogin.Text = "Logins";
            this.grbLogin.Enter += new System.EventHandler(this.grbLogin_Enter);
            // 
            // txtClaveVETA
            // 
            this.txtClaveVETA.Location = new System.Drawing.Point(233, 47);
            this.txtClaveVETA.Name = "txtClaveVETA";
            this.txtClaveVETA.Size = new System.Drawing.Size(76, 23);
            this.txtClaveVETA.TabIndex = 12;
            this.txtClaveVETA.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Clave";
            // 
            // txtUsuarioVETA
            // 
            this.txtUsuarioVETA.Location = new System.Drawing.Point(106, 47);
            this.txtUsuarioVETA.Name = "txtUsuarioVETA";
            this.txtUsuarioVETA.Size = new System.Drawing.Size(76, 23);
            this.txtUsuarioVETA.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Usuario";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "VETA";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(321, 18);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(70, 52);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtClaveIOL
            // 
            this.txtClaveIOL.Location = new System.Drawing.Point(233, 18);
            this.txtClaveIOL.Name = "txtClaveIOL";
            this.txtClaveIOL.Size = new System.Drawing.Size(76, 23);
            this.txtClaveIOL.TabIndex = 4;
            this.txtClaveIOL.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Clave";
            // 
            // txtUsuarioIOL
            // 
            this.txtUsuarioIOL.Location = new System.Drawing.Point(106, 18);
            this.txtUsuarioIOL.Name = "txtUsuarioIOL";
            this.txtUsuarioIOL.Size = new System.Drawing.Size(76, 23);
            this.txtUsuarioIOL.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IOL";
            // 
            // cboUmbral
            // 
            this.cboUmbral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUmbral.FormattingEnabled = true;
            this.cboUmbral.Location = new System.Drawing.Point(213, 95);
            this.cboUmbral.Name = "cboUmbral";
            this.cboUmbral.Size = new System.Drawing.Size(46, 23);
            this.cboUmbral.TabIndex = 15;
            // 
            // txtPresupuesto
            // 
            this.txtPresupuesto.Location = new System.Drawing.Point(90, 95);
            this.txtPresupuesto.Name = "txtPresupuesto";
            this.txtPresupuesto.Size = new System.Drawing.Size(52, 23);
            this.txtPresupuesto.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(148, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Umbral %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Presupuesto";
            // 
            // grdPanel
            // 
            this.grdPanel.AllowUserToAddRows = false;
            this.grdPanel.AllowUserToDeleteRows = false;
            this.grdPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPanel.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdPanel.Location = new System.Drawing.Point(12, 127);
            this.grdPanel.Name = "grdPanel";
            this.grdPanel.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grdPanel.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdPanel.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grdPanel.RowTemplate.Height = 16;
            this.grdPanel.RowTemplate.ReadOnly = true;
            this.grdPanel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdPanel.Size = new System.Drawing.Size(542, 373);
            this.grdPanel.TabIndex = 2;
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.ItemHeight = 15;
            this.lbLog.Location = new System.Drawing.Point(12, 509);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(542, 64);
            this.lbLog.TabIndex = 3;
            // 
            // tmr
            // 
            this.tmr.Interval = 5000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Checked = true;
            this.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuto.Location = new System.Drawing.Point(271, 99);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAuto.Size = new System.Drawing.Size(122, 19);
            this.chkAuto.TabIndex = 16;
            this.chkAuto.Text = "Modo automático";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // chkBeep
            // 
            this.chkBeep.AutoSize = true;
            this.chkBeep.Location = new System.Drawing.Point(399, 99);
            this.chkBeep.Name = "chkBeep";
            this.chkBeep.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkBeep.Size = new System.Drawing.Size(64, 19);
            this.chkBeep.TabIndex = 17;
            this.chkBeep.Text = "Alarma";
            this.chkBeep.UseVisualStyleBackColor = true;
            // 
            // chkFollow
            // 
            this.chkFollow.AutoSize = true;
            this.chkFollow.Location = new System.Drawing.Point(469, 99);
            this.chkFollow.Name = "chkFollow";
            this.chkFollow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkFollow.Size = new System.Drawing.Size(84, 19);
            this.chkFollow.TabIndex = 18;
            this.chkFollow.Text = "Auto Scroll";
            this.chkFollow.UseVisualStyleBackColor = true;
            // 
            // frmBOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 584);
            this.Controls.Add(this.chkFollow);
            this.Controls.Add(this.chkBeep);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.cboUmbral);
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPresupuesto);
            this.Controls.Add(this.grdPanel);
            this.Controls.Add(this.grbLogin);
            this.Controls.Add(this.label4);
            this.Name = "frmBOT";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmBOT_Load);
            this.grbLogin.ResumeLayout(false);
            this.grbLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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