namespace PCPowerBot
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.botToken = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveToken = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.maxDelayBox = new System.Windows.Forms.ComboBox();
            this.userIdBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.botNameBox = new System.Windows.Forms.TextBox();
            this.btnSaveUser = new System.Windows.Forms.Button();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bot Token:";
            // 
            // botToken
            // 
            this.botToken.Location = new System.Drawing.Point(14, 77);
            this.botToken.Name = "botToken";
            this.botToken.Size = new System.Drawing.Size(349, 23);
            this.botToken.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name: ";
            // 
            // btnSaveToken
            // 
            this.btnSaveToken.Location = new System.Drawing.Point(371, 77);
            this.btnSaveToken.Name = "btnSaveToken";
            this.btnSaveToken.Size = new System.Drawing.Size(77, 23);
            this.btnSaveToken.TabIndex = 4;
            this.btnSaveToken.Text = "Save";
            this.btnSaveToken.UseVisualStyleBackColor = true;
            this.btnSaveToken.Click += new System.EventHandler(this.btnSaveToken_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Maximal command delay:";
            // 
            // maxDelayBox
            // 
            this.maxDelayBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maxDelayBox.FormattingEnabled = true;
            this.maxDelayBox.Items.AddRange(new object[] {
            "10",
            "30",
            "45",
            "60",
            "90",
            "120",
            "150",
            "180",
            "300",
            "600",
            "1800",
            "3600"});
            this.maxDelayBox.Location = new System.Drawing.Point(14, 167);
            this.maxDelayBox.Name = "maxDelayBox";
            this.maxDelayBox.Size = new System.Drawing.Size(349, 23);
            this.maxDelayBox.TabIndex = 6;
            this.maxDelayBox.SelectedValueChanged += new System.EventHandler(this.maxDelayBox_SelectedValueChanged);
            // 
            // userIdBox
            // 
            this.userIdBox.Location = new System.Drawing.Point(14, 122);
            this.userIdBox.Name = "userIdBox";
            this.userIdBox.Size = new System.Drawing.Size(349, 23);
            this.userIdBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Allowed User:";
            // 
            // botNameBox
            // 
            this.botNameBox.Location = new System.Drawing.Point(14, 32);
            this.botNameBox.Name = "botNameBox";
            this.botNameBox.ReadOnly = true;
            this.botNameBox.Size = new System.Drawing.Size(349, 23);
            this.botNameBox.TabIndex = 9;
            this.botNameBox.Text = "N/A";
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Location = new System.Drawing.Point(371, 122);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(77, 23);
            this.btnSaveUser.TabIndex = 10;
            this.btnSaveUser.Text = "Save";
            this.btnSaveUser.UseVisualStyleBackColor = true;
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayIconMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // trayIconMenu
            // 
            this.trayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.trayIconMenu.Name = "trayIconMenu";
            this.trayIconMenu.Size = new System.Drawing.Size(166, 48);
            // 
            // showApplicationToolStripMenuItem
            // 
            this.showApplicationToolStripMenuItem.Name = "showApplicationToolStripMenuItem";
            this.showApplicationToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.showApplicationToolStripMenuItem.Text = "Show application";
            this.showApplicationToolStripMenuItem.Click += new System.EventHandler(this.showApplicationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 209);
            this.Controls.Add(this.btnSaveUser);
            this.Controls.Add(this.botNameBox);
            this.Controls.Add(this.userIdBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maxDelayBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveToken);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.botToken);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PCPower Bot";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.trayIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox botToken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveToken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox maxDelayBox;
        private System.Windows.Forms.TextBox userIdBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox botNameBox;
        private System.Windows.Forms.Button btnSaveUser;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem showApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

